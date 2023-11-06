using System.Buffers;
using System.IO.Compression;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;

namespace Playground.Streams
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // WriteContent(100_000_000);
            // Console.WriteLine("The content is written successfully.");

            // Copy("test.txt", "test-copy.txt");
            // Console.WriteLine("The content is copied successfully.");

            // Compress("test.txt", "test-compressed.txt");
            // Console.WriteLine("The content is compressed successfully.");

            // Decompress("test-compressed.txt", "test-decompressed.txt");
            // Console.WriteLine("The content is decompressed successfully.");

            ComputeHash("test.txt");

            // ReadContent();
            // UseTextAsStream();
        }

        static void ComputeHash(string pathToFile)
        {
            using FileStream readStream = new FileStream(pathToFile, FileMode.Open, FileAccess.Read, FileShare.None);

            byte[] hash = SHA512.HashData(readStream);
            string hashAsString = BitConverter.ToString(hash);

            Console.WriteLine(hashAsString);
        }

        static void Compress(string pathToFile, string pathToResult, int bufferSize = 1024)
        {
            using FileStream readStream = new FileStream(pathToFile, FileMode.Open, FileAccess.Read, FileShare.None);
            using FileStream writeStream = new FileStream(pathToResult, FileMode.Create, FileAccess.Write, FileShare.None);
            using GZipStream compressStream = new GZipStream(writeStream, CompressionLevel.SmallestSize);

            byte[] buffer = ArrayPool<byte>.Shared.Rent(bufferSize);
            int readBytesCount = readStream.Read(buffer, 0, bufferSize);

            while (readBytesCount > 0)
            {
                compressStream.Write(buffer, 0, readBytesCount);
                readBytesCount = readStream.Read(buffer, 0, bufferSize);
            }
        }

        static void Decompress(string pathToFile, string pathToResult, int bufferSize = 1024)
        {
            using FileStream readStream = new FileStream(pathToFile, FileMode.Open, FileAccess.Read, FileShare.None);
            using GZipStream decompressStream = new GZipStream(readStream, CompressionMode.Decompress);
            using FileStream writeStream = new FileStream(pathToResult, FileMode.Create, FileAccess.Write, FileShare.None);

            byte[] buffer = ArrayPool<byte>.Shared.Rent(bufferSize);
            int readBytesCount = decompressStream.Read(buffer, 0, bufferSize);

            while (readBytesCount > 0)
            {
                writeStream.Write(buffer, 0, readBytesCount);
                readBytesCount = decompressStream.Read(buffer, 0, bufferSize);
            }
        }

        static void Copy(string from, string to)
        {
            using FileStream readStream = new FileStream(from, FileMode.Open, FileAccess.Read, FileShare.None);
            using FileStream writeStream = new FileStream(to, FileMode.Create, FileAccess.Write, FileShare.None);

            Console.WriteLine($"Read stream characteristics... Can read: {readStream.CanRead}, Can write: {readStream.CanWrite}, Can seek: {readStream.CanSeek}, Length: {readStream.Length}");

            Console.WriteLine($"Write stream characteristics... Can read: {writeStream.CanRead}, Can write: {writeStream.CanWrite}, Can seek: {writeStream.CanSeek}, Length: {writeStream.Length}");

            byte[] buffer = ArrayPool<byte>.Shared.Rent(1024);
            int readBytesCount = readStream.Read(buffer, 0, 1024);

            while (readBytesCount > 0)
            {
                // We need to write exactly `readBytesCount` bytes.
                // Approach #1: Use span
                // writeStream.Write(buffer.AsSpan(0, readBytesCount));
                //
                // Approach #2: Use the other `Write` overload
                writeStream.Write(buffer, 0, readBytesCount);

                readBytesCount = readStream.Read(buffer, 0, 1024);
            }
        }

        static void ReadContent()
        {
            using FileStream fileStream = new FileStream("test.txt", FileMode.Open, FileAccess.Read, FileShare.None);

            byte[] buffer = new byte[1024];

            int readBytesCount = fileStream.Read(buffer);
            int counter = 0;
            while (readBytesCount != 0)
            {
                Console.WriteLine($"#{++counter}: Read {readBytesCount} from the file.");

                readBytesCount = fileStream.Read(buffer);
            }
        }

        static void WriteContent(int lines)
        {
            using FileStream fileStream = new FileStream("test.txt", FileMode.Create, FileAccess.Write, FileShare.None);

            string lineContent = $"abcdefghijklmnopqrstuvwxyz{Environment.NewLine}";
            byte[] buffer = Encoding.UTF8.GetBytes(lineContent);

            if (lines <= 0) throw new InvalidOperationException("Lines must be one or more.");

            for (int i = 0; i < lines; i++) fileStream.Write(buffer);
        }

        static void UseTextAsStream()
        {
            string text = "Hello, world!";
            byte[] textAsBytes = Encoding.UTF8.GetBytes(text);
            using MemoryStream textAsStream = new MemoryStream(textAsBytes);
        }
    }
}