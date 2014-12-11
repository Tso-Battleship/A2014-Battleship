using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using ClientBattleShip;
using System.Net.Sockets;
using System.Net;

namespace BattleShip_2014
{
    public partial class FormTestClient : Form
    {
        delegate void delegateClient();
        delegateClient recoiClient;

        TCPClient tcpClient = new TCPClient();
        TcpClient client = new TcpClient();
       
        public FormTestClient()
        {
            InitializeComponent();
            //Event
            tcpClient.messageRecu += this.HandleEvent_messageRecu;      //Fonction qui relie 
            //Delegate
            recoiClient += this.TraiteRecoiClient;
        }

        private void connecterServeur_button_Click(object sender, EventArgs e)
        {
            tcpClient.connectionServeur(tbAddresseIp.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            tcpClient.envoyerCommande(textBoxEnvoie.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBoxRecoi.Text = tcpClient.strMessage;
        }

        public void HandleEvent_messageRecu(object sender, EventArgs args)
        {
            BeginInvoke(recoiClient);
        }

        public void TraiteRecoiClient() // étape 4 définition de la méthode qui sera appelée... les paramètres doivent être conformes à la définition à l'étape 1
        {
            textBoxRecoi.Text = tcpClient.strMessage;
            //   string test = serveur.strMessage[numClient];

        }

        private void bDeconnection_Click(object sender, EventArgs e)
        {
            tcpClient.deconnection();
            Environment.Exit(0); 
        }

        private void FormTestClient_FormClosing(object sender, FormClosingEventArgs e)
        {
            tcpClient.deconnection();
            Environment.Exit(0); 
        }

      

    }
}
