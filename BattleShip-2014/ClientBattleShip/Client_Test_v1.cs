﻿using System;
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
        bool redrawGridNeeded = false;
        bool redrawEnnemi = false;
        Rotation rotation = Rotation.Haut;
        int nbPieces = 0;

        List<Piece> listePiecesJoueur;
        TableauAvecPiece tableauJoueur;
        TableauAvecPiece tableauEnnemi;
        List<DescriptionPiece> descriptionRecueDuServeur;
        List<CaseDeJeux> listeCaseTouches;

        TCPClient tcpClient = new TCPClient();
        TcpClient client = new TcpClient();

        /** TODO COMMENTER CETTE DEMARCHE QUI CRÉE DES CURSEUR **/
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
        /** ** ** ** ** ** **/


        public Client()
        {
            InitializeComponent();
            
            /// Variables Global pour TEST                                          
            /// Ces Variables seront remplacer par les informations provenant du serveur
            descriptionRecueDuServeur = new List<DescriptionPiece>();
            DescriptionPiece dp;

            List<CaseDeJeux> cases = new List<CaseDeJeux>();

            cases.Add(new CaseDeJeux(0, 0));
            cases.Add(new CaseDeJeux(0, 1));
            dp = new DescriptionPiece(cases, "patrolBoat.png", "Patrol Boat");
            Piece patrolBoatEnnemie = new Piece(dp,0,0,Rotation.Droite);
            descriptionRecueDuServeur.Add(dp);
            cases = new List<CaseDeJeux>(cases);
            cases.Add(new CaseDeJeux(0, 2));
            dp = new DescriptionPiece(cases, "destroyer.png", "Destroyer");
            Piece destroyerEnnemie = new Piece(dp,2,0,Rotation.Haut);
            descriptionRecueDuServeur.Add(dp);
            cases = new List<CaseDeJeux>(cases);
            dp = new DescriptionPiece(cases, "destroyer.png", "Submarine");
            Piece submarinetEnnemie = new Piece(dp,5,5,Rotation.Droite);
            descriptionRecueDuServeur.Add(dp);
            cases = new List<CaseDeJeux>(cases);
            cases.Add(new CaseDeJeux(0, 3));
            dp = new DescriptionPiece(cases, "battleShip.png", "Battleship ");
            Piece battleshipEnnemie = new Piece(dp,6,0,Rotation.Haut);
            descriptionRecueDuServeur.Add(dp);
            cases = new List<CaseDeJeux>(cases);
            cases.Add(new CaseDeJeux(0, 4));
            dp = new DescriptionPiece(cases, "aircraftCarrier.png", "Aircraft Carrier");
            Piece aircraftEnnemie = new Piece(dp,0,8,Rotation.Droite);
            descriptionRecueDuServeur.Add(dp);
            cases = new List<CaseDeJeux>(cases);

            listePiecesJoueur = new List<Piece>();
            List<Piece> listePiecesEnnemie = new List<Piece>();


            tableauJoueur = new TableauAvecPiece(10, 10, listePiecesJoueur);
            tableauEnnemi = new TableauAvecPiece(10, 10, listePiecesEnnemie);

            tableauEnnemi.Pieces.Add(patrolBoatEnnemie);
            tableauEnnemi.Pieces.Add(destroyerEnnemie);
            tableauEnnemi.Pieces.Add(submarinetEnnemie);
            tableauEnnemi.Pieces.Add(battleshipEnnemie);
            tableauEnnemi.Pieces.Add(aircraftEnnemie);

            listeCaseTouches = new List<CaseDeJeux>();

            /// PlaceHolder pour les TextBox
            SendMessage(nomJoueur_TB.Handle, EM_SETCUEBANNER, 0, "Player 1");
            SendMessage(textBox2.Handle, EM_SETCUEBANNER, 0, "127.0.0.1");
        }
        /// <summary>
        /// Fermer l'application lorsqu'on clique sur le X
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exit_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Minimizer l'application lorsqu'on click sur _
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void minimize_button_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        /// <summary>
        /// Placer les textes des boutons selon le mode de jeu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Client_Load(object sender, EventArgs e)
        {
            piece1_button.Text = descriptionRecueDuServeur.ElementAt((int)enumImageCurseur.piece1).Nom;
            piece2_button.Text = descriptionRecueDuServeur.ElementAt((int)enumImageCurseur.piece2).Nom;
            piece3_button.Text = descriptionRecueDuServeur.ElementAt((int)enumImageCurseur.piece3).Nom;
            piece4_button.Text = descriptionRecueDuServeur.ElementAt((int)enumImageCurseur.piece4).Nom;
            piece5_button.Text = descriptionRecueDuServeur.ElementAt((int)enumImageCurseur.piece5).Nom;    
        }

        /// <summary>
        /// Connecter au Serveur à l'adresse dans le textBox
        /// en fournissant le nom du joueur
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void connecterServeur_button_Click(object sender, EventArgs e)
        {
            connect_panel.Visible = false;
            info_panel.Visible = true;
            //TODO Rendre le connectPanel Invisible si la connection Réussis
            try
            {
                IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 3000);
                client.Connect(serverEndPoint);
                NetworkStream clientStream = client.GetStream();
                ASCIIEncoding encoder = new ASCIIEncoding();
                //tcpClient.envoyerCommande(client, tcpClient.retourneAdresseIpClient());
                //stcpClient.envoyerCommande(client, FormatteurActions.genererActionConnection(nomJoueur_TB.Text));
                
            }
            catch (System.Net.Sockets.SocketException)
            {
                MessageBox.Show("La connection au serveur a été refusé");
            }

            //label1.Text = TCPClient.retourneAdresseIpClient();
        }

        /// <summary>
        /// Evenement qui retourne quelle bateau a été sélectionné
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void place_ship_buttons(object sender, EventArgs e)
        {
            Button bouton;
            bouton = (Button)sender;
            imageCurseur = (enumImageCurseur)Convert.ToInt16(bouton.Tag);
            changerCurseur(imageCurseur, rotation);

        }

        /// <summary>
        /// Gère les clicks de souris
        /// Pour placer les pièces
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormClick(object sender, MouseEventArgs e)
        {
            int grilleX, grilleY;
            //TODO enlever le HARDCODE
            grilleX = (e.X / 50); //La grille est 10x10 et elle fait 500px X 500px
            grilleY = (e.Y / 50); //En divisant la position de la souris par 50 et en gardant seulement la partie entiere
            //On obtient la coordonnées de la case dans la grille qui a été cliqué

            if (e.Button == System.Windows.Forms.MouseButtons.Left) //Click de souris Gauche
            {
                try
                {
                    PictureBox pb;
                    pb = (PictureBox)sender;
                    if (pb.Name == "p1_board" && imageCurseur != enumImageCurseur.invalide) //Si nous sommes dans la grille du joueur
                    {                                                                       //On place une piece
                        placerBateau(imageCurseur, toggle, grilleX, grilleY);
                    }
                    if(pb.Name == "p2_board")
                    {
                        attaquerEnnemie(grilleX,grilleY);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.StackTrace);
                }
            }
            if (e.Button == System.Windows.Forms.MouseButtons.Right)    //Click de souris Droit
            {                                                           //Changer la rotation de la piece a placer
                if (rotation == Rotation.Haut)
                    rotation = Rotation.Droite;
                else
                    rotation = Rotation.Haut;
                changerCurseur(imageCurseur, rotation);
            }
        }

        private void attaquerEnnemie(int x, int y)
        {
            FormatteurActions.genererActionTir(nomJoueur_TB.Text, x, y);
            //Lecture de la réponse du serveur
            //Si la réponse est true pour hit
            bool hit = false;

            foreach (Piece piecesEnnemie in tableauEnnemi.Pieces)                     //Pour chaque Piece dans le tableau
            {
                foreach (CaseDeJeux caseDeJeuxEnnemie in piecesEnnemie.CasesDeJeu)   //Tester chaque case du tableau
                {
                    if (piecesEnnemie.PositionX + caseDeJeuxEnnemie.OffsetX == x)
                    {
                        if (piecesEnnemie.PositionY + caseDeJeuxEnnemie.OffsetY == y)
                        {
                            hit = true;
                        }
                    }
                }
            }

            if(hit)
            {
                listeCaseTouches.Add(new CaseDeJeux(x, y));   
            }
            else
            {
                tableauEnnemi.Cases[x, y].tirer();
            }

            redrawEnnemi = true;
            p2_board.Invalidate();
        }

        /// <summary>
        /// Placer le Bateau sélectionné dans la case Sélectionné
        /// </summary>
        /// <param name="image"></param>
        /// <param name="rotated"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        private void placerBateau(enumImageCurseur image, bool rotated, int x, int y)
        {
            bool positionVAlide = true;
            Button boutonAppuyer = new Button();
            switch (image) //Trouver combien de pieces construit le bateau
            {
                case enumImageCurseur.piece1:
                    boutonAppuyer = piece1_button;
                    nbPieces = descriptionRecueDuServeur.ElementAt(0).CasesDeJeu.Count();
                    break;
                case enumImageCurseur.piece2:
                    boutonAppuyer = piece2_button;
                    nbPieces = descriptionRecueDuServeur.ElementAt(1).CasesDeJeu.Count();;
                    break;
                case enumImageCurseur.piece3:
                    boutonAppuyer = piece3_button;
                    nbPieces = descriptionRecueDuServeur.ElementAt(2).CasesDeJeu.Count();;
                    break;
                case enumImageCurseur.piece4:
                    boutonAppuyer = piece4_button;
                    nbPieces = descriptionRecueDuServeur.ElementAt(3).CasesDeJeu.Count();;
                    break;
                case enumImageCurseur.piece5:
                    boutonAppuyer = piece5_button;
                    nbPieces = descriptionRecueDuServeur.ElementAt(4).CasesDeJeu.Count();;
                    break;
                default:
                    break;
            }

            /// Vérifier qu"il n'y a pas une pieces sous la pieces que l'on tente de placer
            if (imageCurseur != enumImageCurseur.invalide)
            {
                if ( (rotation == Rotation.Droite && (x + nbPieces) <= tableauJoueur.TailleX) || (rotation == Rotation.Haut && (y+nbPieces <= tableauJoueur.TailleY)) )
                {
                    Piece pieceAPlace = new Piece(descriptionRecueDuServeur.ElementAt((int)image),x,y,rotation);
                    if(rotation == Rotation.Droite)
                        pieceAPlace.tournerPiece();

                    foreach (Piece piecesDejaPlace in tableauJoueur.Pieces)                     //Pour chaque Piece dans le tableau
                    {
                        foreach(CaseDeJeux caseDeJeuxDejaPlace in piecesDejaPlace.CasesDeJeu)   //Tester chaque case du tableau
                        {
                            foreach (CaseDeJeux caseDeJeuxAPlace in pieceAPlace.CasesDeJeu)      //Contre chaque Case du bateau a placer
                            {
                                if (caseDeJeuxAPlace.OffsetX + pieceAPlace.PositionX == caseDeJeuxDejaPlace.OffsetX + piecesDejaPlace.PositionX)
                                {
                                    if (caseDeJeuxAPlace.OffsetY + pieceAPlace.PositionY == caseDeJeuxDejaPlace.OffsetY + piecesDejaPlace.PositionY)
                                    {
                                        positionVAlide = false;
                                    }
                                }
                            }
                        }                        
                    }

                    if(positionVAlide) 
                    {
                        boutonAppuyer.Enabled = false;
                        tableauJoueur.Pieces.Add(pieceAPlace); //Ajouter le bateau sélectionné au tableau
                        redrawGridNeeded = true;                        //Indiquer qu'il y a un changement a faire a la grille
                        p1_board.Invalidate();                //Invalider le panel du joeur1 pour forcer l'évènement Paint
                    }
                }
            }
            else
            {
                redrawGridNeeded = false;
            }
        }

        /// <summary>
        /// Changer l'image du curseur pour l'image du bateau sélectionné
        /// </summary>
        /// <param name="image"></param>
        /// <param name="directionImage"></param>
        private void changerCurseur(enumImageCurseur image, Rotation directionImage)
        {
            Bitmap bitmapCurseur;

            switch (image)  //Charger l'image du bateau sélectionné
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

            if (directionImage == Rotation.Droite ) //Pivoter L'image du bateau
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
            else //Si l'image est invalide retourner au curseur original
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Évenement Paint
        /// Permet de redessiner la grille du joueur
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void p1_board_Paint(object sender, PaintEventArgs e)
        {
            Bitmap bitmap = new Bitmap("pieces.png");
            int posX, posY;

            if (redrawGridNeeded)
            {
                redrawGridNeeded = false;
                imageCurseur = enumImageCurseur.invalide;
                changerCurseur(imageCurseur, rotation);
                foreach (Piece piecesPlace in tableauJoueur.Pieces)
                {
                    foreach(CaseDeJeux uneCase in piecesPlace.CasesDeJeu)
                    {
                        posX = (((piecesPlace.PositionX * 50) + 25) + (50 * uneCase.OffsetX) - 25);
                        posY = (((piecesPlace.PositionY * 50) + 25) + (50 * uneCase.OffsetY) - 25);
                        e.Graphics.DrawImage(bitmap, posX,posY);
                    }  
                }
            }
        }

        private void p2_board_Paint(object sender, PaintEventArgs e)
        {
            Bitmap bitmapHit = new Bitmap("hit.png");
            Bitmap bitmapMiss = new Bitmap("miss.png");
            int posX, posY;

            if (redrawEnnemi)
            {
                foreach (CaseDeJeux casesTire in tableauEnnemi.Cases)
                {
                    if (casesTire.EstTouchee == true)
                    {
                        posX = (casesTire.OffsetX * 50);
                        posY = (casesTire.OffsetY * 50);
                        try
                        {
                            e.Graphics.DrawImage(bitmapMiss, posX, posY);
                        }
                        catch
                        {
                            Console.WriteLine("slefgih");
                        }
                        
                    }
                }

                foreach (CaseDeJeux caseTouche in listeCaseTouches)
                {
                    posX = (caseTouche.OffsetX * 50);
                    posY = (caseTouche.OffsetY * 50);
                    try
                    {
                        e.Graphics.DrawImage(bitmapHit, posX, posY);
                    }
                    catch
                    {
                        Console.WriteLine("slefgadwadwadih");
                    }
                }
            }
        }
    }
}
