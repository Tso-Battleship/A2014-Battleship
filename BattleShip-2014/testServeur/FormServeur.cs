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

        TCPServeur serveur = new TCPServeur();
        int numClient = 0;

        public FormServeur()
        {
            InitializeComponent();
            serveur.SomethingHappened += this.HandleEvent;
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
            numClient = Convert.ToInt16(tbNumClient.Text);
        }
        
        public void HandleEvent(object sender, EventArgs args)
        {
            MessageBox.Show("Event");
            tbReception.Text = serveur.strMessage[serveur.clientCourant];
        }
        
    }
}
