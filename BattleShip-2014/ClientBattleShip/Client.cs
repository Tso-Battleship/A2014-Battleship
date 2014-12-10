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
            piece1 = 0,
            piece2,
            piece3,
            piece4,
            piece5,
            invalide
        };
        enumImageCurseur imageCurseur = enumImageCurseur.invalide;
        bool toggle = true; //Permet de changer l'orientation du curseur
       
        //Variable global pour le reDraw
        bool redraw = false;
        Rotation rotation = Rotation.Haut;
        int nbPieces = 0;
        int posDepartX, posDepartY;

        List<Piece> listePiecesJoueur;
        TableauAvecPiece tableauJoueur;
        List<DescriptionPiece> descriptionRecueDuServeur;

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

            descriptionRecueDuServeur = new List<DescriptionPiece>();
            DescriptionPiece dp;

            List<CaseDeJeux> cases = new List<CaseDeJeux>();

            cases.Add(new CaseDeJeux(0, 0));
            cases.Add(new CaseDeJeux(0, 1));
            dp = new DescriptionPiece(cases, "patrolBoat.png", "Patrol Boat");
            descriptionRecueDuServeur.Add(dp);
            cases = new List<CaseDeJeux>(cases);
            cases.Add(new CaseDeJeux(0, 2));
            dp = new DescriptionPiece(cases, "destroyer.png", "Destroyer");
            descriptionRecueDuServeur.Add(dp);
            cases = new List<CaseDeJeux>(cases);
            dp = new DescriptionPiece(cases, "destroyer.png", "Submarine");
            descriptionRecueDuServeur.Add(dp);
            cases = new List<CaseDeJeux>(cases);
            cases.Add(new CaseDeJeux(0, 3));
            dp = new DescriptionPiece(cases, "battleShip.png", "Battleship ");
            descriptionRecueDuServeur.Add(dp);
            cases = new List<CaseDeJeux>(cases);
            cases.Add(new CaseDeJeux(0, 4));
            dp = new DescriptionPiece(cases, "aircraftCarrier.png", "Aircraft Carrier");
            descriptionRecueDuServeur.Add(dp);
            cases = new List<CaseDeJeux>(cases);
            listePiecesJoueur = new List<Piece>();
            tableauJoueur = new TableauAvecPiece(10, 10, listePiecesJoueur);

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
            piece1_button.Text = descriptionRecueDuServeur.ElementAt((int)enumImageCurseur.piece1).Nom;
            piece2_button.Text = descriptionRecueDuServeur.ElementAt((int)enumImageCurseur.piece2).Nom;
            piece3_button.Text = descriptionRecueDuServeur.ElementAt((int)enumImageCurseur.piece3).Nom;
            piece4_button.Text = descriptionRecueDuServeur.ElementAt((int)enumImageCurseur.piece4).Nom;
            piece5_button.Text = descriptionRecueDuServeur.ElementAt((int)enumImageCurseur.piece5).Nom;
            
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
            changerCurseur(imageCurseur, rotation);

        }

        private void FormClick(object sender, MouseEventArgs e)
        {
            int grilleX, grilleY;
            grilleX = (e.X / 50); //La grille est 10x10 et elle fait 500px X 500px
            grilleY = (e.Y / 50); //En divisant la position de la souris par 50 et en gardant seulement la partie entiere
            //On obtient la coordonnées de la case dans la grille qui a été cliqué

            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                try
                {
                    PictureBox pb;
                    pb = (PictureBox)sender;
                    if (pb.Name == "p1_board" && imageCurseur != enumImageCurseur.invalide)
                    {
                        placerBateau(imageCurseur, toggle, grilleX, grilleY);
                    }
                }
                catch (Exception)
                {
                }
            }
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                if (rotation == Rotation.Haut)
                    rotation = Rotation.Droite;
                else
                    rotation = Rotation.Haut;
                changerCurseur(imageCurseur, rotation);
            }
        }

        private void placerBateau(enumImageCurseur image, bool rotated, int x, int y)
        {
            switch (image)
            {
                case enumImageCurseur.piece1:
                    piece1_button.Enabled = false;
                    nbPieces = descriptionRecueDuServeur.ElementAt(0).CasesDeJeu.Count();
                    break;
                case enumImageCurseur.piece2:
                    piece2_button.Enabled = false;
                    nbPieces = descriptionRecueDuServeur.ElementAt(1).CasesDeJeu.Count();;
                    break;
                case enumImageCurseur.piece3:
                    piece3_button.Enabled = false;
                    nbPieces = descriptionRecueDuServeur.ElementAt(2).CasesDeJeu.Count();;
                    break;
                case enumImageCurseur.piece4:
                    piece4_button.Enabled = false;
                    nbPieces = descriptionRecueDuServeur.ElementAt(3).CasesDeJeu.Count();;
                    break;
                case enumImageCurseur.piece5:
                    piece5_button.Enabled = false;
                    nbPieces = descriptionRecueDuServeur.ElementAt(4).CasesDeJeu.Count();;
                    break;
                default:
                    break;
            }

            if (imageCurseur != enumImageCurseur.invalide)
            {
                if ( (rotation == Rotation.Droite && (x + nbPieces) <= 10) || (rotation == Rotation.Haut && (y+nbPieces <= 10)) )
                {
                    Piece piecePlace = new Piece(descriptionRecueDuServeur.ElementAt((int)image),x,y,rotation);
                    tableauJoueur.Pieces.Add(piecePlace);
                    redraw = true;
                    p1_board.Invalidate();
                }
            }
            else
            {
                redraw = false;
            }
        }

        private void changerCurseur(enumImageCurseur image, Rotation directionImage)
        {
            Bitmap bitmapCurseur;

            switch (image)
            {
                case enumImageCurseur.piece1:
                    bitmapCurseur = new Bitmap(descriptionRecueDuServeur.ElementAt((int)enumImageCurseur.piece1).PathVisuels.ToString());
                    break;
                case enumImageCurseur.piece2:
                    bitmapCurseur = new Bitmap(descriptionRecueDuServeur.ElementAt((int)enumImageCurseur.piece2).PathVisuels.ToString());
                    break;
                case enumImageCurseur.piece3:
                    bitmapCurseur = new Bitmap(descriptionRecueDuServeur.ElementAt((int)enumImageCurseur.piece3).PathVisuels.ToString());
                    break;
                case enumImageCurseur.piece4:
                    bitmapCurseur = new Bitmap(descriptionRecueDuServeur.ElementAt((int)enumImageCurseur.piece4).PathVisuels.ToString());
                    break;
                default:
                case enumImageCurseur.piece5:
                    bitmapCurseur = new Bitmap(descriptionRecueDuServeur.ElementAt((int)enumImageCurseur.piece5).PathVisuels.ToString());
                    break;
            }

            if (directionImage == Rotation.Droite )
            {
                bitmapCurseur.RotateFlip(RotateFlipType.Rotate90FlipX);
            }

            if (imageCurseur != enumImageCurseur.invalide)
            {
                Graphics g = Graphics.FromImage(bitmapCurseur);
                g.DrawImage(bitmapCurseur, 0, 0);
                this.Cursor = CreateCursor(bitmapCurseur, 3, 3);
                bitmapCurseur.Dispose();
            }
            else
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void p1_board_Paint(object sender, PaintEventArgs e)
        {
            Bitmap bitmap = new Bitmap("pieces.png");

            if (redraw)
            {
                redraw = false;
                imageCurseur = enumImageCurseur.invalide;
                changerCurseur(imageCurseur, rotation);
                foreach (Piece piecesPlace in tableauJoueur.Pieces)
                {
                    for (int i = 0; i < piecesPlace.CasesDeJeu.Count(); i++)
                    {
                        if (piecesPlace.RotationPiece == Rotation.Droite)
                        {
                            e.Graphics.DrawImage(bitmap, (((piecesPlace.PositionX * 50) + 25) + (50 * i) - 25), ((piecesPlace.PositionY * 50)));
                        }
                        else
                        {
                            e.Graphics.DrawImage(bitmap, ((piecesPlace.PositionX * 50)), (((piecesPlace.PositionY * 50) + 25) + (50 * i) - 25));
                        }

                    }
                    
                }
            }
        }
    }
}
