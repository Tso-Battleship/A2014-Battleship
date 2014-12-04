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
        
        TCPClient tcpClient = new TCPClient();
        TcpClient client = new TcpClient();

        public FormTestClient()
        {
            InitializeComponent();

        }


        private void connecterServeur_button_Click(object sender, EventArgs e)
        {
            try
            {
                IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Parse("10.240.7.109"), 3000);
                client.Connect(serverEndPoint);
                NetworkStream clientStream = client.GetStream();
                ASCIIEncoding encoder = new ASCIIEncoding();
                tcpClient.envoyerCommande(client, tcpClient.retourneAdresseIpClient());
            }
            catch (System.Net.Sockets.SocketException)
            {
                MessageBox.Show("La connection au serveur a été refusé");
            }

            // textBox3.Text = TCPClient.retourneAdresseIpClient();
        }

        private void exit_button_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox4.Text = tcpClient.strMessage;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tcpClient.envoyerCommande(client, textBox5.Text);
        }


    }
}
