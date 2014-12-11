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
    public class TCPServeur
    {
        private TcpListener tcpListener;
        private Thread listenThread;
        private string[] adrIp = { "" };
        private int nbClients = 0;

        System.Timers.Timer aTimer = new System.Timers.Timer();
        public bool[] etatJoueur = new bool[4];
        public string[] strMessage = new string[4];
        public int clientCourant = 0;

        //Event 
        public event EventHandler messageRecu;

        public event EventHandler joueurDeconnecte;


        public TCPServeur()
        {
            StartTimer();
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
            while (true)
            {
                //Code bloquant jusqu'à ce qu'un client soit accepté
                TcpClient client = this.tcpListener.AcceptTcpClient();
                //Crée un thread qui va gérer la communication avec le client
                Thread clientThread = new Thread(() => HandleClientComm(client, nbClients)); //Envoie à la fonction l'object ainsi que le numero du client
                clientThread.Start();       //Démarre le nouveau thread

                while(adrIp[nbClients] == null);    //attend de recevoir l'addresse IP du client.
                envoyerCommande(nbClients, "Connection Reussi");    //comfirme la connection
                nbClients++;    //incrémente le numero pour le prochain client
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
                    //attend de recevoir un message du client
                    bytesRead = clientStream.Read(message, 0, 4096);
                }
                catch
                {
                    //une erreur s'est produit
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
                    event_messageRecu();
                }
            }

            tcpClient.Close();
        }

        public void event_messageRecu()
        {
            EventHandler handler = messageRecu;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }
        /// <summary>
        /// Event pour la déconnection d'un joueur
        /// </summary>
        public void event_joueurDeconecte()
        {
            EventHandler handler = joueurDeconnecte;
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
                event_joueurDeconecte();
                etatJoueur[numClient] = false;
            }
        }

        /// <summary>
        /// Timer de la classe serveur
        /// À tous les 2000ms, il envoie un ping au client
        /// </summary>
        void StartTimer()
        {
            aTimer = new System.Timers.Timer(2000);
            aTimer.Elapsed += (sender, e) => _timer_Elapsed(sender, e);
            aTimer.Enabled = true; // active le timer
        }

        void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            for (int numeroClient = 0; numeroClient < nbClients; numeroClient++)
            {
                if (etatJoueur[numeroClient] == true)
                {
                    envoyerCommande(numeroClient, "test de connection");
                }
            }
        }
    }
}
