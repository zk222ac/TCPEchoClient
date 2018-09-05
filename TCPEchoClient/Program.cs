using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TCPEchoClient
{
    class Program
    {
        private static TcpClient _clientSocket = null;
        private static Stream _nstream = null;
        private static StreamWriter _sWriter = null;
        private static StreamReader _sReader = null;
        static void Main(string[] args)
        {
            try
            {
                // Step no : 1
                //TCP establish connection via its socket through request to server

                // Step no: 3 
                // when TCP connection is established then client send (bytes of data) to server
                using (_clientSocket = new TcpClient("127.0.0.1", 6789))
                {
                    using (_nstream = _clientSocket.GetStream())
                    {
                        // Data will be flushed from the buffer to the stream after each write operation
                        using (_sWriter = new StreamWriter(_nstream) { AutoFlush = true })
                        {
                            Console.WriteLine("Client ready to send bytes of data to server...");
                            Console.WriteLine("Kindly write your message here ");
                            string clientMsg = Console.ReadLine();
                            // client ready to send (bytes of data) which has collected through user input
                            _sWriter.WriteLine(clientMsg);
                        }
                        // Step no: 6 ........................................
                        // Client recieved the (modified server Message) sent back by server to client 
                        // perform write operation 
                        using (_sReader = new StreamReader(_nstream))
                        {
                            string rdMsgFromServer = _sReader.ReadLine();
                            if (rdMsgFromServer != null)
                            {
                                Console.WriteLine("Server modified Message");

                            }
                        }

                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

    }
}
