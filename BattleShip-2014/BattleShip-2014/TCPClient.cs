using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Threading;
using System.Net;
using System.Collections;
using System.Timers;

namespace BattleShip_2014
{
    public class TCPClient
    {
        
        private TcpListener tcpListener;
        private Thread listenThread;
        TcpClient tcpClient = new TcpClient();

        System.Timers.Timer aTimer = new System.Timers.Timer();
        //public int testTimer = 0;
        int testTimer = 0;
        public string strMessage;
        public event EventHandler SomethingHappened2;

        public TCPClient()
        {
            this.tcpListener = new TcpListener(IPAddress.Any, 3000);            //Crée un socket avec 127.0.0.1 et le port 3000.
            this.listenThread = new Thread(new ThreadStart(ListenForClients));  //Crée un nouveau thread qui écoute pour des clients
            this.listenThread.Start();
        }
        /// <summary>
        /// Timer de la classe client
        /// À tous les 500ms, il envoie un ping au serveur
        /// </summary>
        void StartTimer( int testTimer)
        {
            
            aTimer = new System.Timers.Timer(500);
            aTimer.Elapsed += (sender, e) => _timer_Elapsed(sender, e, ref testTimer);
            aTimer.Enabled = true; // active le timer
        }

         void _timer_Elapsed(object sender, ElapsedEventArgs e, ref int testTimer)
         {
             envoyerCommande(tcpClient, "1");
         }
        /// <summary>
        /// Delegate qui attends de nouveaux clients. Il crée un nouveau thread lorsqu'un client se connecte.
        /// </summary>
        private void ListenForClients()
        {
            this.tcpListener.Start();
            while (true)
            {
                //Code bloquant jusqu'à ce qu'un client soit accepté
                TcpClient client = this.tcpListener.AcceptTcpClient();
                //Crée un thread qui va gérer la communication avec le client
                Thread clientThread = new Thread(() => HandleClientComm(client));
                clientThread.Start();
            }
        }

        private void HandleClientComm(object client)
        {

            TcpClient tcpClient = (TcpClient)client;
            NetworkStream clientStream = tcpClient.GetStream();
            byte[] message = new byte[4096];
            int bytesRead;

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
                strMessage = encoder.GetString(message, 0, bytesRead);
                DoSomething();
            }

            tcpClient.Close();
        }
        /// <summary>
        /// Crée un event
        /// </summary>
        public void DoSomething()
        {
            EventHandler handler = SomethingHappened2;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }
        public bool connectionServeur(string addresseIp)
        {
            //Return true si la connection au serveur est accepté.
            try
            {
                IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Parse(addresseIp), 3000);
                tcpClient.Connect(serverEndPoint);
                NetworkStream clientStream = tcpClient.GetStream();
                ASCIIEncoding encoder = new ASCIIEncoding();
                StartTimer(testTimer);
                return true;
            }
            //Return false si il y a eu une erreur lors de la connection au serveur.
            catch (System.Net.Sockets.SocketException)
            {
                return false;
            }
        }
        public void envoyerCommande(string message)
        {
            byte[] buffer = new byte[4096];
            TcpClient Client = (TcpClient)tcpClient;
            NetworkStream clientStream = Client.GetStream();
            ASCIIEncoding encoder = new ASCIIEncoding();
            buffer = encoder.GetBytes(message);
            clientStream.Write(buffer, 0, buffer.Length);
            clientStream.Flush();
        }
        /// <summary>
        /// Retourne l'adresse Ip du windows qui utilise le programme 
        /// </summary>
        /// <returns>adresse Ip</returns>
        public string retourneAdresseIpClient ()
        {
            string adresseIp;

            String strHostName = string.Empty;
            // Getting Ip address of local machine...
            // First get the host name of local machine.
            strHostName = Dns.GetHostName();
            // Then using host name, get the IP address list..
            IPHostEntry ipEntry = Dns.GetHostEntry(strHostName);
            IPAddress[] addr = ipEntry.AddressList;
             adresseIp=  addr[3].ToString();
            return adresseIp;
        }
    }
}