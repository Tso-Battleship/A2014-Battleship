using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net.Sockets;
using System.Net;

namespace BattleShip_2014
{
    public partial class Client : Form
    {
        Server tcpServer = new Server();
        TcpClient client = new TcpClient();


        private TCPClient TCPClient;
        public Client()
        {
            InitializeComponent();
            
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void connecterServeur_button_Click(object sender, EventArgs e)
        {
            try
            {
                IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 3000);
                client.Connect(serverEndPoint);
                NetworkStream clientStream = client.GetStream();
                ASCIIEncoding encoder = new ASCIIEncoding();
            }
            catch (System.Net.Sockets.SocketException)
            {
                MessageBox.Show("La connection au serveur a été refusé");
            }
            
           // textBox3.Text = TCPClient.retourneAdresseIpClient();
        }
    }
}
