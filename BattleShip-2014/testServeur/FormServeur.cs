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
    public partial class FormServeur : Form
    {

        delegate void delegateServeur();
        delegateServeur recoiServeur;

        TCPServeur serveur = new TCPServeur();
        int numClient = 0;

        public FormServeur()
        {
            InitializeComponent();
            //Event
            serveur.messageRecu += this.HandleEvent_messageRecu;
            serveur.joueurDeconnecte += this.HandleEvent_joueurDeconnecte;
            //Delegate
            recoiServeur += this.TraiteRecoiServeur;
        }

        private void bEnvoie_Click(object sender, EventArgs e)
        {
            serveur.envoyerCommande(numClient, tbEnvoie.Text);
        }

        private void bReception_Click(object sender, EventArgs e)
        {
            tbReception.Text = serveur.strMessage[numClient];
        }

        private void bNumClient_Click(object sender, EventArgs e)
        {
            try
            {
                numClient = Convert.ToInt16(tbNumClient.Text);
            }
           catch
            {

            }
        }

        public void HandleEvent_joueurDeconnecte(object sender, EventArgs args)
        {
            MessageBox.Show("Joueur déconnecté");
        }

        public void HandleEvent_messageRecu(object sender, EventArgs args)
        {
            MessageBox.Show("Message Recu");
            BeginInvoke(recoiServeur); 
            //tbReception.Text = serveur.strMessage[serveur.clientCourant];
        }
        /// <summary>
        /// Delegate
        /// </summary>
        public void TraiteRecoiServeur() // étape 4 définition de la méthode qui sera appelée... les paramètres doivent être conformes à la définition à l'étape 1
        {
            tbReception.Text = serveur.strMessage[serveur.clientCourant]; 
            //   string test = serveur.strMessage[numClient];

        }
    }
}
