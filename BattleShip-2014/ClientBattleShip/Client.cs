using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
<<<<<<< Updated upstream
using ClientBattleShip;
using System.Net.Sockets;
using System.Net;
=======
using System.Runtime.InteropServices; // Cue Text
>>>>>>> Stashed changes

namespace BattleShip_2014
{
    public struct IconInfo
    {
        public bool fIcon;
        public int xHotspot;
        public int yHotspot;
        public IntPtr hbmMask;
        public IntPtr hbmColor;
    }

    public partial class Client : Form
    {
<<<<<<< Updated upstream
        TCPClient tcpClient = new TCPClient();
        TcpClient client = new TcpClient();
 
=======
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(
                                                    IntPtr hWnd,
                                                    int msg,
                                                    int wParam,
                                                    [MarshalAs(UnmanagedType.LPWStr)]string lParam
                                               );
        private const int EM_SETCUEBANNER = 0x1501;



        [DllImport("user32.dll")]
        public static extern IntPtr CreateIconIndirect(ref IconInfo icon);
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetIconInfo(IntPtr hIcon, ref IconInfo pIconInfo);


        public static Cursor CreateCursor(Bitmap bmp, int xHotSpot, int yHotSpot)
        {
            IntPtr ptr = bmp.GetHicon();
            IconInfo tmp = new IconInfo();
            GetIconInfo(ptr, ref tmp);
            tmp.xHotspot = xHotSpot;
            tmp.yHotspot = yHotSpot;
            tmp.fIcon = true;
            ptr = CreateIconIndirect(ref tmp);
            return new Cursor(ptr);
        }


>>>>>>> Stashed changes
        public Client()
        {
            InitializeComponent();
            SendMessage(textBox1.Handle, EM_SETCUEBANNER, 0, "Player 1");
            SendMessage(textBox2.Handle, EM_SETCUEBANNER, 0, "127.0.0.1");


            Bitmap bitmap = new Bitmap(140, 25);
            //Graphics g = Graphics.FromImage(bitmap);"C:\1color\aircraftCarrier.png"
            Graphics g = Graphics.FromImage(bitmap);
            using (Font f = new Font(FontFamily.GenericSansSerif, 16))
            g.DrawString("DESTROYER", f, Brushes.WhiteSmoke, 0, 0);
            this.Cursor = CreateCursor(bitmap, 3, 3);
            bitmap.Dispose();
        }

        private void exit_button_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void minimize_button_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Client_Load(object sender, EventArgs e)
        {
            
        }

        private void positionPlaceableShips()
        {
            /*Image img = aircraftCarrier_placeable.Image;
            img.RotateFlip(RotateFlipType.Rotate90FlipNone);
            aircraftCarrier_placeable.Image = img;*/
        }

        private void connecterServeur_button_Click(object sender, EventArgs e)
        {
            connect_panel.Visible = false;
            info_panel.Visible = true;
        }

        private void place_ship_buttons(object sender, EventArgs e)
        {
            Button bouton;
            string bPlaceShip;
            bouton = (Button)sender;
            bPlaceShip = bouton.Tag.ToString();
            switch(bPlaceShip)
            {
                case "aircraft_carrier":
                    //Cursor.Current = new Cursor("C:\1color\aircraftCarrier.png");
                    
                    break;
                case "battleship":

                    break;
                case "submarine":

                    break;
                case "destroyer":

                    break;
                case "patrol_boat":

                    break;
            }

        }

        private void connecterServeur_button_Click(object sender, EventArgs e)
        {
            try
            {
                IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 3000);
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

    
    }
}
