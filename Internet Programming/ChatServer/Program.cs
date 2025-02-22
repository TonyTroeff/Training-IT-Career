using System.Buffers;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ChatServer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string hostName = Dns.GetHostName();
            IPHostEntry hostIp = Dns.GetHostEntry(hostName);
            IPEndPoint endPoint = new IPEndPoint(hostIp.AddressList[0], 8001);

            using Socket listener = new Socket(endPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            byte[]? buffer = null;
            try
            {
                listener.Bind(endPoint);
                listener.Listen();

                using Socket handle = listener.Accept();

                buffer = ArrayPool<byte>.Shared.Rent(1024 * 1024);

                int segmentId = 1;
                while (handle.Connected)
                {
                    int messageSize = handle.Receive(buffer);
                    string currentMessage = Encoding.UTF8.GetString(buffer, 0, messageSize);

                    Console.WriteLine($"{segmentId++}: {currentMessage}");

                    if (currentMessage == "exit")
                        break;
                }

                handle.Shutdown(SocketShutdown.Both);
                handle.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error occurred: {e.Message}");
            }
            finally
            {
                if (buffer is not null)
                    ArrayPool<byte>.Shared.Return(buffer);
            }
        }
    }
}
