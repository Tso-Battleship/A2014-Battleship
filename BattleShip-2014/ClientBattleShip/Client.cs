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
using ClientBattleShip;
using System.Net.Sockets;
using System.Net;
using System.Runtime.InteropServices; // Cue Text

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
        enum enumImageCurseur {
            aircraft_carrier = 0,
            battleship,
            submarine,
            destroyer,
            patrol_boat            
        };
        enumImageCurseur imageCurseur;
        bool toggle = true; //Permet de changer l'orientation du curseur
        bool redraw = false;
        

        TCPClient tcpClient = new TCPClient();
        TcpClient client = new TcpClient();
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
            tmp.fIcon = false;
            ptr = CreateIconIndirect(ref tmp);
            return new Cursor(ptr);
        }


        public Client()
        {
            InitializeComponent();
            SendMessage(textBox1.Handle, EM_SETCUEBANNER, 0, "Player 1");
            SendMessage(textBox2.Handle, EM_SETCUEBANNER, 0, "127.0.0.1");
        }

        private void exit_button_Click(object sender, EventArgs e)
        {
            this.Close();
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

            //label1.Text = TCPClient.retourneAdresseIpClient();
        }

        private void place_ship_buttons(object sender, EventArgs e)
        {
            Button bouton;
            bouton = (Button)sender;

            imageCurseur = (enumImageCurseur)Convert.ToInt16(bouton.Tag);
            changerCurseur(imageCurseur, false);

        }

        private void FormClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                try
                {
                    PictureBox pb;
                    pb = (PictureBox)sender;
                    if (pb.Name == "p1_board")
                    {
                        placerBateau(imageCurseur, toggle, e.X, e.Y);
                    }
                }
                catch (Exception)
                {
                }
            }
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                toggle = !toggle;
                changerCurseur(imageCurseur, toggle);
            }
        }

        private void placerBateau(enumImageCurseur image, bool rotated,int x, int y)
        {
            int numeroCase;
            int imageX, imageY;
            numeroCase = ((x / 50)+1) + (10*(y/50)); // (X la position de la souris / par 50 la largeur d'une case)
                                                     // + 1 pour commencer a un a la place de zero

            Bitmap bitmap = new Bitmap("battleShip.png");
            Graphics g = Graphics.FromImage(bitmap);
            g.DrawImage(bitmap, x, y);
            
        }

        private void changerCurseur(enumImageCurseur image, bool rotated)
        {
            Bitmap bitmapCurseur;

            switch (image)
            {
                case enumImageCurseur.aircraft_carrier:
                    bitmapCurseur = new Bitmap("aircraftCarrier.png");
                    break;
                case enumImageCurseur.battleship:
                    bitmapCurseur = new Bitmap("battleShip.png");
                    break;
                case enumImageCurseur.submarine:
                    bitmapCurseur = new Bitmap("destroyer.png");
                    break;
                case enumImageCurseur.destroyer:
                    bitmapCurseur = new Bitmap("destroyer.png");
                    break;
                default:
                case enumImageCurseur.patrol_boat:
                    bitmapCurseur = new Bitmap("patrolBoat.png");
                    break;
            }

            if (rotated)
            {
                bitmapCurseur.RotateFlip(RotateFlipType.Rotate90FlipX);
            }
            else
            {
                toggle = false;
            }

            Graphics g = Graphics.FromImage(bitmapCurseur);
            g.DrawImage(bitmapCurseur, 0, 0);
            this.Cursor = CreateCursor(bitmapCurseur, 3, 3);
            bitmapCurseur.Dispose();
        }

        private void Client_Paint(object sender, PaintEventArgs e)
        {
            int x = 0;

            Bitmap bitmap = new Bitmap("pieces.png");
            for (x = 0; x < 50; x++ )
            { 
                e.Graphics.DrawImage(bitmap, x, 0);
            }
        }
    }
}
