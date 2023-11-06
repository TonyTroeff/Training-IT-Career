using System.Buffers;
using System.IO.Compression;
using System.Text;

namespace Exercises.Streams
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // PrintOddLines("participants.txt");
            // AddNumberedLines("participants.txt", "participants-ordered.txt");
            // CountWords("words.txt", "text.txt", "result.txt");
            
            // string[] pathToChunks = Slice("test.txt", ".", 17, i => $"chunk-{i + 1}.txt");
            // Assemble(pathToChunks, "test-assembled.txt");

            string[] pathToCompressedChunks = Slice("test.txt", ".", 17, i => $"compressed-chunk-{i + 1}.txt", compress: true);
            Assemble(pathToCompressedChunks, "test-assembled-from-compressed-chunks.txt", decompress: true);
        }

        static string[] Slice(string pathToFile, string destinationDirectory, int parts, Func<int, string> chunkNameFunc, bool compress = false, int bufferLength = 1024)
        {
            using FileStream fileStream = new FileStream(pathToFile, FileMode.Open, FileAccess.Read, FileShare.None);

            long fileLength = fileStream.Length;
            if (fileLength < parts) throw new InvalidOperationException($"This file is too small and cannot be slied into {parts} parts.");

            long bytesInPart = fileLength / parts;
            string[] result = new string[parts];
            for (int i = 0; i < parts; i++)
            {
                string fullPathToResultFile = Path.Combine(destinationDirectory, chunkNameFunc(i));
                result[i] = fullPathToResultFile;

                long bytesInCurrentPart = bytesInPart;
                if (i + 1 == parts) bytesInCurrentPart += fileLength % parts;

                Stream? destinationFileStream = null;
                Stream? compressStream = null;
                try
                {
                    destinationFileStream = new FileStream(fullPathToResultFile, FileMode.Create, FileAccess.Write, FileShare.None);
                    
                    if (compress)
                        compressStream = new GZipStream(destinationFileStream, CompressionMode.Compress);

                    Slice(fileStream, compressStream ?? destinationFileStream, bytesInCurrentPart, bufferLength);
                }
                finally
                {
                    compressStream?.Dispose();
                    destinationFileStream?.Dispose();
                }
            }

            return result;
        }

        static void Slice(Stream sourceStream, Stream destinationStream, long partSize, int bufferLength = 1024)
        {
            byte[] buffer = ArrayPool<byte>.Shared.Rent(bufferLength);
            while (partSize > 0)
            {
                int maxCount = buffer.Length;
                if (partSize < maxCount) maxCount = (int)partSize;

                int readBytesCount = sourceStream.Read(buffer, 0, maxCount);
                if (readBytesCount == 0) throw new InvalidOperationException("Stream was too short.");

                destinationStream.Write(buffer, 0, readBytesCount);
                partSize -= readBytesCount;
            }
        }

        static void Assemble(IEnumerable<string> pathToChunks, string pathToResult, bool decompress = false, int bufferLength = 1024)
        {
            using FileStream resultStream = new FileStream(pathToResult, FileMode.Create, FileAccess.Write, FileShare.None);

            foreach (var pathToChunk in pathToChunks)
            {
                Stream? chunkFileStream = null;
                Stream? decompressStream = null;

                try
                {
                    chunkFileStream = new FileStream(pathToChunk, FileMode.Open, FileAccess.Read, FileShare.None);

                    if (decompress) decompressStream = new GZipStream(chunkFileStream, CompressionMode.Decompress);

                    (decompressStream ?? chunkFileStream).CopyTo(resultStream, bufferLength);
                }
                finally
                {
                    decompressStream?.Dispose();
                    chunkFileStream?.Dispose();
                }
            }
        }

        static void PrintOddLines(string pathToFile)
        {
            using FileStream fileStream = new FileStream(pathToFile, FileMode.Open, FileAccess.Read, FileShare.None);
            using StreamReader reader = new StreamReader(fileStream);

            bool lineIsOdd = true;
            while (!reader.EndOfStream)
            {
                string currentLine = reader.ReadLine();
                if (lineIsOdd) Console.WriteLine(currentLine);

                lineIsOdd = !lineIsOdd;
            }
        }

        static void AddNumberedLines(string pathToSourceFile, string pathToDestinationFile)
        {
            using FileStream sourceFileStream = new FileStream(pathToSourceFile, FileMode.Open, FileAccess.Read, FileShare.None);
            using StreamReader reader = new StreamReader(sourceFileStream);

            using FileStream destinationFileStream = new FileStream(pathToDestinationFile, FileMode.Create, FileAccess.Write, FileShare.None);
            using StreamWriter writer = new StreamWriter(destinationFileStream);

            int line = 1;
            while (!reader.EndOfStream)
            {
                string currentLine = reader.ReadLine();
                writer.WriteLine($"Line #{line++}: {currentLine}");
            }
        }

        static void CountWords(string pathToWordsFile, string pathToTextFile, string pathToResultFile)
        {
            using FileStream wordsFileStream = new FileStream(pathToWordsFile, FileMode.Open, FileAccess.Read, FileShare.None);
            using StreamReader wordsReader = new StreamReader(wordsFileStream);

            string allWords = wordsReader.ReadToEnd();
            Dictionary<string, int> occurrencesMap = Split(allWords).ToDictionary(w => w, _ => 0);

            using FileStream textFileStream = new FileStream(pathToTextFile, FileMode.Open, FileAccess.Read, FileShare.None);
            using StreamReader textReader = new StreamReader(textFileStream);

            while (!textReader.EndOfStream)
            {
                string currentLine = textReader.ReadLine();
                foreach (var word in Split(currentLine))
                {
                    if (occurrencesMap.ContainsKey(word))
                        occurrencesMap[word]++;
                }
            }

            using FileStream resultFileStream = new FileStream(pathToResultFile, FileMode.Create, FileAccess.Write, FileShare.None);
            using StreamWriter resultWriter = new StreamWriter(resultFileStream);

            foreach (var (word, occurrences) in occurrencesMap.OrderByDescending(x => x.Value))
            {
                resultWriter.WriteLine($"{word} - {occurrences}");
            }
        }

        static IEnumerable<string> Split(string text)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < text.Length; i++)
            {
                if (char.IsLetterOrDigit(text[i])) sb.Append(char.ToLower(text[i]));
                else if (sb.Length > 0)
                {
                    yield return sb.ToString();
                    sb.Clear();
                }
            }

            if (sb.Length > 0) yield return sb.ToString();
        }
    }
}