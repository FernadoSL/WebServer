using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using WebServer.Factories;
using WebServer.Server;

namespace WebServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Número da porta usada pelo servidor
            int portNumber = 11000;

            // Get das informações de rede dinamicamente
            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, portNumber);

            // Criação do socket
            Socket socketTcp = SocketFactory.CreateSocketTcp();

            // Bind do socket
            socketTcp.Bind(localEndPoint);
            socketTcp.Listen(20);
            
            // Rotina de conexão
            while (true)
            {
                Console.WriteLine("Esperando Conexão \n");
                Socket newConnection = socketTcp.Accept();

                Request clientRequest = new Request();
                newConnection.Receive(clientRequest.Bytes);
                clientRequest.FormatRequest();
                Console.WriteLine(clientRequest.AllText);
                
                Response serverResponse = Server.Server.ReceiveAndRespond(clientRequest);
                if (serverResponse != null)
                {
                    newConnection.Send(serverResponse.Bytes);
                    Console.WriteLine(serverResponse.AllText + '\n');
                }
                
                Thread.Sleep(1000);
                newConnection.Close();
            }
        }
    }
}
