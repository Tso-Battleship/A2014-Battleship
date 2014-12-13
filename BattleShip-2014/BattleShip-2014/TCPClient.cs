/**
 * @file   TCPClient.cs
 * @author ?
 * @modifier David Duchesne , Alexandre Bergeron 
 * @date   Décembre 2014
 * @brief  Fonction utilitaire pour la connexion et actions du clients dans la communication Tcp
 *
 *   Système de développement: PC avec Windows 8.1
 *   GIT HUB application pour Windows
 */


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
        private bool fermerServer = false; // variable qui sert a fermer le serveur au moment voulu (de préférence lors de la deconnexion 
        private TcpListener tcpListener; 
        private Thread listenThread;
        TcpClient tcpClient = new TcpClient();

        System.Timers.Timer aTimer = new System.Timers.Timer();
        //public int testTimer = 0;
        int testTimer = 0;
        public string strMessage; // message recu lors de la connexion
        public event EventHandler messageRecu; // définition de l'event pour la recepetion de messages 

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
        void StartTimer( int testTimer) // timer de classe qui avait été défini pour le client mais le client ne ping pas le serveur mais plutot l'inverse. La possibilité est toujours la si il  faut
        {
            
            aTimer = new System.Timers.Timer(2000);
            aTimer.Elapsed += (sender, e) => _timer_Elapsed(sender, e, ref testTimer);
            aTimer.Enabled = true; // active le timer
        }

         void _timer_Elapsed(object sender, ElapsedEventArgs e, ref int testTimer) // quand le timer atteint son delai
         {
            // envoyerCommande("1");
         }
        /// <summary>
        /// Delegate qui attends de nouveaux clients. Il crée un nouveau thread lorsqu'un client se connecte.
        /// </summary>
        private void ListenForClients() 
        {
            this.tcpListener.Start();
            while (fermerServer == false)
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

            while (fermerServer == false)
            {
                bytesRead = 0;

                try
                {
                    // bloque tant que un client n'a pas envoyé de message
                    bytesRead = clientStream.Read(message, 0, 4096);
                }
                catch
                {
                    //un erreur de socket c'est produit
                    break;
                }

                if (bytesRead == 0)
                {
                    //le client est déconnecté du serveur
                    break;
                }

                // le message a été recu avec succes 
                ASCIIEncoding encoder = new ASCIIEncoding();
                System.Diagnostics.Debug.WriteLine(encoder.GetString(message, 0, bytesRead));
                if (encoder.GetString(message, 0, bytesRead) != "test de connection")
                {
                    strMessage = encoder.GetString(message, 0, bytesRead);
                    event_messageRecu();
                }
            }

            tcpClient.Close();
        }
        /// <summary>
        /// Crée un event qui est utilisé pour la reception de message 
        /// </summary>
        public void event_messageRecu()
        {
            EventHandler handler = messageRecu;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }
		/// <summary>
        /// Fonction qui permet au client de se connecter au serveur 
        /// </summary>
        public bool connectionServeur(string addresseIp)
        {
            //Return true si la connection au serveur est accepté.
            try
            {
                IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Parse(addresseIp), 3000); // passe l'adresseIp du client suivi du numéro de socket 
                tcpClient.Connect(serverEndPoint); // la variable avec l'adresse ip et le socket peu maintenant se connecter au serveur via la fonction connect.
                NetworkStream clientStream = tcpClient.GetStream();
                ASCIIEncoding encoder = new ASCIIEncoding();
                StartTimer(testTimer); // dans notre cas le timer n'est pas important.
                envoyerCommande(retourneAdresseIpClient()); // envoie la string de l'adresse ip qui est retourné par la fonction retourneAdresseIpClient
                return true;
            }
            //Return false si il y a eu une erreur lors de la connection au serveur.
            catch (System.Net.Sockets.SocketException)
            {
                return false;
            }
            catch // catch qui gere tout les erreurs possible dans le try contrairement a seulement les erreurs liées au socket .
            {
                return false;
            }
        }
		/// <summary>
        /// Fonction qui permet au client de se deconnecter du serveur
        /// </summary>
        public void deconnection() 
        {
            tcpClient.Close(); // arret du thread
            fermerServer = true; // variable mise a vrai pour sortir du while et ainsi tout fermer 
        }
		/// <summary>
        /// Fonction qui permet d'envoyer une string au serveur
        /// </summary>
        public void envoyerCommande(string message)
        {
            try
            { 
				NetworkStream clientStream = tcpClient.GetStream(); 
				ASCIIEncoding encoder = new ASCIIEncoding();
				byte[] buffer = encoder.GetBytes(message); // passe le parametre de la fonction dans un buffer avec l'encoder ascii qui utilise une fonction pour prendre les octets 

				clientStream.Write(buffer, 0 , buffer.Length); // le buffer est alors envoyé au complet.
				clientStream.Flush(); // on vide le stream pour la prochaine envoie.
            }
            catch // protection
            {

            }
        }
        /// <summary>
        /// Retourne l'adresse Ip du systeme d'exploitation	windows sur lequel le programme est lancé 
        /// </summary>
        /// <returns>adresse Ip du poste </returns>
        public string retourneAdresseIpClient ()
        {
            string adresseIp; // adresse ip retourné sous forme de string 

            String strHostName = string.Empty;
            //   prend l'adresse ip de la machine local...
            // En premier accede au nom du propriétaire de la machine local
            strHostName = Dns.GetHostName();
            //Ensuite utilise le nom et accede a une liste d'adresses Ip
            IPHostEntry ipEntry = Dns.GetHostEntry(strHostName);
            IPAddress[] addr = ipEntry.AddressList; // buffer qui contient certaines informations utile pour une connection internet.
             adresseIp=  addr[3].ToString(); // parmis les informations prise sur l'os c'est a l'index 3 que se trouve l'adresse ip que nous voulons pour la communication 
            return adresseIp; 
        }
    }
}