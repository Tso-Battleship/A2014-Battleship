using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Threading;
using System.Net;
using System.Collections;


namespace BattleShip_2014
{
    public class TCPServeur
    {
        private TcpListener tcpListener;
        private Thread listenThread;
        private string[] adrIp = { "" };
        public string[] strMessage = new string[4];
        public int clientCourant = 0;
        public event EventHandler SomethingHappened;
        ArrayList list = new ArrayList();

        public TCPServeur()
        {
            this.tcpListener = new TcpListener(IPAddress.Any, 3000);            //Crée un socket avec 127.0.0.1 et le port 3000.
            this.listenThread = new Thread(new ThreadStart(ListenForClients));  //Crée un nouveau thread qui écoute pour des clients
            this.listenThread.Start();
            adrIp = new string[4];

        }
        /// <summary>
        /// Delegate qui attends de nouveaux clients. Il crée un nouveau thread lorsqu'un client se connecte.
        /// </summary>
        private void ListenForClients()
        {
            this.tcpListener.Start();
            int nbClients = 0;
            while (true)
            {
                //Code bloquant jusqu'à ce qu'un client soit accepté
                TcpClient client = this.tcpListener.AcceptTcpClient();
                //Crée un thread qui va gérer la communication avec le client
                Thread clientThread = new Thread(() => HandleClientComm(client, nbClients));
                clientThread.Start();

                while(adrIp[nbClients] == null);
                envoyerCommande(nbClients, "Connection Reussi");
                /*chagnement dans le code ici*/
                //**************************************
                //while (adrIp[nbClients] == "") ;
                //IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Parse(adrIp[nbClients]), 3000);
                //client.Connect(serverEndPoint);
                // NetworkStream clientStream = client.GetStream();
                // ASCIIEncoding encoder = new ASCIIEncoding();
                nbClients++;
                //***************************************
            }
        }

        private void HandleClientComm(object client, int numClient)
        {
            TcpClient tcpClient = (TcpClient)client;
            NetworkStream clientStream = tcpClient.GetStream();

            byte[] message = new byte[4096];
            int bytesRead;
            bool premierCoup = true;

            while (true)
            {
                bytesRead = 0;

                try
                {
                    //blocks until a client sends a message
                    bytesRead = clientStream.Read(message, 0, 4096);
                }
                catch
                {
                    //a socket error has occured
                    break;
                }

                if (bytesRead == 0)
                {
                    //the client has disconnected from the server
                    break;
                }

                //message has successfully been received
                ASCIIEncoding encoder = new ASCIIEncoding();
                System.Diagnostics.Debug.WriteLine(encoder.GetString(message, 0, bytesRead));
                if (premierCoup == true)
                {
                    adrIp[numClient] = encoder.GetString(message, 0, bytesRead);
                    premierCoup = false;
                }
                else
                {
                    strMessage[numClient] = encoder.GetString(message, 0, bytesRead);
                    clientCourant = numClient;
                    DoSomething();
                }
            }

            tcpClient.Close();
        }

        public void DoSomething()
        {
            EventHandler handler = SomethingHappened;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }


        public void envoyerCommande(int numClient, string message)
        {
            try
            {
                byte[] buffer = new byte[4096];
                TcpClient client = new TcpClient();
                IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Parse(adrIp[numClient]), 3000);
                client.Connect(serverEndPoint);
                NetworkStream clientStream = client.GetStream();
                ASCIIEncoding encoder = new ASCIIEncoding();
                buffer = encoder.GetBytes(message);
                clientStream.Write(buffer, 0, buffer.Length);
                clientStream.Flush();
            }
            catch (System.Net.Sockets.SocketException)
            {
            }
        }
    }
}
