using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace WebServer
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
