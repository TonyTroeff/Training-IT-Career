using System.Net.Sockets;
using System.Net;
using System.Text;

namespace ChatClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string hostName = Dns.GetHostName();
            IPHostEntry hostIp = Dns.GetHostEntry(hostName);
            IPEndPoint endPoint = new IPEndPoint(hostIp.AddressList[0], 8001);

            using Socket sender = new Socket(endPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                sender.Connect(endPoint);

                string message;
                do
                {
                    Console.Write("> ");
                    message = Console.ReadLine()!;

                    byte[] messageBytes = Encoding.UTF8.GetBytes(message);
                    sender.Send(messageBytes);
                } while (message != "exit");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error occurred: {e.Message}");
            }
            finally
            {
                sender.Shutdown(SocketShutdown.Both);
                sender.Close();
            }
        }
    }
}
