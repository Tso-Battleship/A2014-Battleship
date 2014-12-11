﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BattleShip_2014
{
    public partial class Serveur : Form
    {
        string nomJoueur1;
        string nomJoueur2;
        int Case;
        int NbConnection = 0;
        int tailleX;
        int tailleY;


        TableauAvecPiece joueur_un;
        TableauAvecPiece joueur_deux;

        List<DescriptionPiece> descriptionDuModeDeJeu;

        public Serveur()
        {
            InitializeComponent();
            lectureModeJeu();


            if("Droite".Equals(Rotation.Droite.ToString()))
                Console.WriteLine(Rotation.Droite);
        }

        public void lectureModeJeu()
        {
            descriptionDuModeDeJeu = new List<DescriptionPiece>();

            List<CaseDeJeux> cases = new List<CaseDeJeux>();

            cases.Add(new CaseDeJeux(0, 0));
            cases.Add(new CaseDeJeux(0, 1));
            
            DescriptionPiece dp = new DescriptionPiece(cases, "partrol_boat.pne", "Patrol Boat");

            descriptionDuModeDeJeu.Add(dp);

            cases = new List<CaseDeJeux>(cases);
            cases.Add(new CaseDeJeux(0, 2));
            cases.Add(new CaseDeJeux(0, 3));

            dp = new DescriptionPiece(cases, "battleship.pne", "Battleship");

            descriptionDuModeDeJeu.Add(dp);

            tailleX = 10;
            tailleY = 10;

            joueur_un = new TableauAvecPiece(tailleX, tailleY, new List<Piece>());
            joueur_deux = new TableauAvecPiece(tailleX, tailleY, new List<Piece>());

            
            string nom_mode = "Nom du mode";




            //joueur_deux = new TableauAvecPiece(tailleX, tailleY, )

            foreach(DescriptionPiece description in descriptionDuModeDeJeu)
            {

               /* FormatteurActions.
                description.*/
                  
            }

            /*
            List<

            
             * */
            }

        public void LogiqueServeur(string trame)
        {
            string[] splitTrameAction;
            splitTrameAction = trame.Split(';').ToArray();
            switch (splitTrameAction[0])
            {
                case "ACTION:CONNECT":
                    ConnectionClient(FormatteurActions.obtenirJoueur(trame));
                    break;
                case "ACTION:PIECES":
                    ReceptionPiece(FormatteurActions.obtenirJoueur(trame), FormatteurActions.obtenirNomPiece(trame), FormatteurActions.obtenirOffX(trame), FormatteurActions.obtenirOffY(trame), FormatteurActions.obtenirRotation(trame));
                    break;
                case "ACTION:TIR":
                    ReceptionTir(FormatteurActions.obtenirJoueur(trame), FormatteurActions.obtenirX(trame), FormatteurActions.obtenirY(trame));
                    break;
                case "ACTION:DISCONNECT":
                    DeconnectionClient(FormatteurActions.obtenirJoueur(trame));
                    break;
            }
        }

        public void readTCP()
        {
            
        }

        private void ConnectionClient(string trame)
        {
            NbConnection++;
            if(NbConnection==1)
            {
                nomJoueur1 = trame;
            }
            else if(NbConnection==2)
            {
                nomJoueur2 = trame;
                //lbReception.Items.Add(FormatteurActions.formatterActionEnvoiModeDeJeu());
                //lbReception2.Items.Add(FormatteurActions.formatterActionEnvoiModeDeJeu());
                lbReception.Items.Add(FormatteurActions.formatterCommencerPlacement(nomJoueur1, nomJoueur2));
                lbReception2.Items.Add(FormatteurActions.formatterCommencerPlacement(nomJoueur1, nomJoueur2));
            }

        }

        private void DeconnectionClient(string trame)
        {
            FormatteurActions.genererActionDeconnection(trame);
            if(trame==nomJoueur1)
            {
                FinDeJeu(nomJoueur2);
            }
            else if (trame == nomJoueur2)
            {
                FinDeJeu(nomJoueur1);
            }
        }

        private void FinDeJeu(string joueurGagnant)
        {
            if (joueurGagnant == nomJoueur1)
            {
                lbReception2.Items.Add(FormatteurActions.genererActionFin(joueurGagnant));
                lbReception.Items.Add(FormatteurActions.genererActionFin(joueurGagnant));
            }
            else if (joueurGagnant == nomJoueur2)
            {
                lbReception.Items.Add(FormatteurActions.genererActionFin(joueurGagnant));
                lbReception2.Items.Add(FormatteurActions.genererActionFin(joueurGagnant));
            }
            
        }

       private void ReceptionTir(string nomJoueur, int x, int y)
        {
            if(nomJoueur==nomJoueur1)
            {

            }
            else if(nomJoueur==nomJoueur2)
            {

            }
            lbReception.Items.Add(FormatteurActions.retournerActionMiseAJour(nomJoueur, x, y, true, true));
        }

        private bool ReceptionPiece(string nomJoueur, string nomPiece, int x, int y, string rotation)
        {
            Piece p = new Piece(new List<CaseDeJeux>(), "AUCUNE", "NULL");
            bool pieceExiste = false;
            foreach(DescriptionPiece dp in descriptionDuModeDeJeu)
            {
                if(dp.Nom.Equals(nomPiece))
                {
                    p = new Piece(dp, x, y);
                    pieceExiste = true;
                }
            }                      
            if(pieceExiste)
            {

                if (rotation.Equals("Droite"))
                    p.tournerPiece();

                if(nomJoueur1==nomJoueur)
                {
                    foreach(Piece pieceDejaPlacee in joueur_un.Pieces)
                    {
                        if (pieceDejaPlacee.Nom.Equals(p.Nom))
                            pieceExiste = false;
                    }
                    if(pieceExiste)
                        joueur_un.Pieces.Add(p);

                    
                }
                else if(nomJoueur2==nomJoueur)
                {
                    foreach (Piece pieceDejaPlacee in joueur_deux.Pieces)
                    {
                        if (pieceDejaPlacee.Nom.Equals(p.Nom))
                            pieceExiste = false;
                    }
                    if(pieceExiste)
                        joueur_deux.Pieces.Add(p);
                }
            }
            if (descriptionDuModeDeJeu.Count == joueur_deux.Pieces.Count && descriptionDuModeDeJeu.Count == joueur_un.Pieces.Count)
            {
                lbReception.Items.Add(FormatteurActions.formatterCommencerPartie(nomJoueur1));
                lbReception2.Items.Add(FormatteurActions.formatterCommencerPartie(nomJoueur1));
            }
            return pieceExiste;
        }


        private void btConnection1_Click(object sender, EventArgs e)
        {
            LogiqueServeur(FormatteurActions.genererActionConnection("JOHN"));
            lbEnvoie.Items.Add(FormatteurActions.genererActionConnection("JOHN"));
        }


        private void btConnection2_Click(object sender, EventArgs e)
        {
            LogiqueServeur(FormatteurActions.genererActionConnection("Jack"));
            lbEnvoie2.Items.Add(FormatteurActions.genererActionConnection("Jack"));
        }

        private void btEnvoiePiece1_Click(object sender, EventArgs e)
        {
            
            Piece p = new Piece(descriptionDuModeDeJeu.ElementAt(0), 3, 5, Rotation.Droite);
            
            LogiqueServeur(FormatteurActions.formatterActionEnvoiPositionPiece("JOHN", p));
            lbEnvoie.Items.Add(FormatteurActions.formatterActionEnvoiPositionPiece("JOHN", p));

            p  = new Piece(descriptionDuModeDeJeu.ElementAt(1), 1, 1, Rotation.Droite);

            LogiqueServeur(FormatteurActions.formatterActionEnvoiPositionPiece("JOHN", p));
            lbEnvoie.Items.Add(FormatteurActions.formatterActionEnvoiPositionPiece("JOHN", p));
            
        }

        private void btEnvoiePiece2_Click(object sender, EventArgs e)
        {
            Piece p = new Piece(descriptionDuModeDeJeu.ElementAt(0), 4, 3, Rotation.Haut);

            LogiqueServeur(FormatteurActions.formatterActionEnvoiPositionPiece("Jack", p));
            lbEnvoie2.Items.Add(FormatteurActions.formatterActionEnvoiPositionPiece("Jack", p));

            p = new Piece(descriptionDuModeDeJeu.ElementAt(1), 5, 3, Rotation.Haut);

            LogiqueServeur(FormatteurActions.formatterActionEnvoiPositionPiece("Jack", p));
            lbEnvoie2.Items.Add(FormatteurActions.formatterActionEnvoiPositionPiece("Jack", p));
        }

        private void btTir1_Click(object sender, EventArgs e)
        {

        }

        private void btTir2_Click(object sender, EventArgs e)
        {

        }

        private void btDeconnection1_Click(object sender, EventArgs e)
        {
            LogiqueServeur(FormatteurActions.genererActionDeconnection("JOHN"));
            lbEnvoie.Items.Add(FormatteurActions.genererActionDeconnection("JOHN"));
        }

        private void btDeconnection2_Click(object sender, EventArgs e)
        {
            LogiqueServeur(FormatteurActions.genererActionDeconnection("Jack"));
            lbEnvoie2.Items.Add(FormatteurActions.genererActionDeconnection("Jack"));
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        
    }
}
