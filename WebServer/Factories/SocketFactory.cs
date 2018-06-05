using System.Net.Sockets;

namespace WebServer.Factories
{
    public static class SocketFactory
    {
        public static Socket CreateSocketTcp()
        {
            return new Socket(SocketType.Stream, ProtocolType.Tcp);
        }

        public static Socket CreateSocketUdp()
        {
            return new Socket(SocketType.Dgram, ProtocolType.Udp);
        }

        public static Socket CreateCustomSocket(SocketType socketType, ProtocolType protocolType)
        {
            return new Socket(socketType, protocolType);
        }
    }
}
