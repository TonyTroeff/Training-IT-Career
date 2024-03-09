using System.Net.Sockets;
using System.Text;

namespace SimpleHttpServer
{
    internal class Program
    {
        static void Main()
        {
            using TcpListener tcpListener = new TcpListener(System.Net.IPAddress.Loopback, 8080);
            tcpListener.Start();

            while (true)
            {
                using TcpClient client = tcpListener.AcceptTcpClient();
                using var stream = client.GetStream();

                string requestContent = ReadHttpRequest(stream, client.Available);
                Console.WriteLine(requestContent);

                string responseContent =
                    """
                    HTTP/1.1 200 OK
                    Content-Type: text/plain

                    Hello, world!
                    """;
                Console.WriteLine(responseContent);
                WriteHttpResponse(stream, responseContent);
            }
        }

        static string ReadHttpRequest(Stream stream, int size)
        {
            byte[] buffer = new byte[size];
            stream.ReadExactly(buffer);

            return Encoding.UTF8.GetString(buffer);
        }

        static void WriteHttpResponse(Stream stream, string rawResponse)
        {
            stream.Write(Encoding.UTF8.GetBytes(rawResponse));
        }
    }
}
