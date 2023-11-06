using System.Buffers;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace WebServer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TcpListener listener = new TcpListener(IPAddress.Any, 3000);
            listener.Start();

            Console.WriteLine("The TCP listener has started!");

            while (true)
            {
                using TcpClient client = listener.AcceptTcpClient();
                using NetworkStream requestStream = client.GetStream();

                ReadRequest(requestStream);
                WriteResponse(requestStream);
            }
        }

        static void ReadRequest(NetworkStream stream)
        {
            byte[] buffer = ArrayPool<byte>.Shared.Rent(1024);
            Console.WriteLine($"Read buffer length: {buffer.Length}");
            Console.WriteLine("Request:");

            char[] textBuffer = ArrayPool<char>.Shared.Rent(buffer.Length);

            while (stream.DataAvailable)
            {
                int readBytes = stream.Read(buffer);
                if (readBytes == 0) break;

                Encoding.UTF8.GetChars(buffer, 0, readBytes, textBuffer, 0);
                Console.WriteLine(textBuffer, 0, readBytes);
            }
        }

        static void WriteResponse(NetworkStream stream)
        {
            StringBuilder responseBuilder = new StringBuilder();
            responseBuilder.AppendLine($"HTTP/1.1 200 OK");
            responseBuilder.AppendLine();
            responseBuilder.AppendLine($"<html><body><h1>Welcome to our basic web server!</h1><h2>The time is: {DateTime.Now}</h2></body></html>");

            Console.WriteLine("Response:");
            string responseContent = responseBuilder.ToString();
            Console.WriteLine(responseContent);

            byte[] responseBytes = Encoding.UTF8.GetBytes(responseContent);
            stream.Write(responseBytes);
        }
    }
}