using System;
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
        ModeDeJeu mode_;
        string nomJoueur1;
        string nomJoueur2;
        int Case;
        int NbConnection = 0;
        int tailleX;
        int tailleY;
        int nbPiece;
        string nomMode;


        TableauAvecPiece joueur_un;
        TableauAvecPiece joueur_deux;

        List<DescriptionPiece> descriptionDuModeDeJeu;
        List<CaseDeJeux> listeCaseTouchesJoueur1 = new List<CaseDeJeux>();
        List<CaseDeJeux> listeCaseTouchesJoueur2= new List<CaseDeJeux>();

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

            mode_ = (new xml_crunch("battleship_xml.xml").getModeDeJeu());

            nomMode = mode_.NomModeDeJeu;
            tailleX = mode_.TailleX;
            tailleY = mode_.TailleY;
            nbPiece = mode_.Pieces.Count;

            List<CaseDeJeux> cases = new List<CaseDeJeux>();
        

            /*foreach (Piece p in mode_.Pieces)
            {

            }
            */
            /*descriptionDuModeDeJeu = new List<DescriptionPiece>();

            List<CaseDeJeux> cases = new List<CaseDeJeux>();

            cases.Add(new CaseDeJeux(0, 0));
            cases.Add(new CaseDeJeux(0, 1));
            
            DescriptionPiece dp = new DescriptionPiece(cases, "partrol_boat.pne", "Patrol Boat");

            descriptionDuModeDeJeu.Add(dp);

            List<CaseDeJeux> cases2 = new List<CaseDeJeux>();
            cases2.Add(new CaseDeJeux(0, 0));
            cases2.Add(new CaseDeJeux(0, 1));
            cases2.Add(new CaseDeJeux(0, 2));
            cases2.Add(new CaseDeJeux(0, 3));
            cases = new List<CaseDeJeux>(cases);
            cases.Add(new CaseDeJeux(0, 2));
            cases.Add(new CaseDeJeux(0, 3));

            DescriptionPiece dp2 = new DescriptionPiece(cases2, "battleship.pne", "Battleship");
            dp = new DescriptionPiece(cases, "battleship.pne", "Battleship");

            descriptionDuModeDeJeu.Add(dp2);
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
                  
            //}
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
                lJoueur1.Text = "Joueur 1 : Connecter";
            }
            else if(NbConnection==2)
            {
                nomJoueur2 = trame;
                lJoueur2.Text = "Joueur 2 : Connecter";
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
                lJoueur1.Text = "Joueur 1 : non connecter";
            }
            else if (trame == nomJoueur2)
            {
                FinDeJeu(nomJoueur1);
                lJoueur2.Text = "Joueur 2 : non connecter";
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
           bool touche=false;
           bool dejaTirer = false;
           bool couler = false;
            if(nomJoueur==nomJoueur1)
            {
                foreach (Piece piecesEnnemie in joueur_deux.Pieces)                     //Pour chaque Piece dans le tableau
                {
                    foreach (CaseDeJeux caseDeJeuxEnnemie in piecesEnnemie.CasesDeJeu)   //Tester chaque case du tableau
                    {
                        CaseDeJeux caseTemp = new CaseDeJeux((piecesEnnemie.PositionX + caseDeJeuxEnnemie.OffsetX),(piecesEnnemie.PositionY + caseDeJeuxEnnemie.OffsetY)); 
                    
                        if ((caseTemp.OffsetX == x) && (caseTemp.OffsetY == y))
                        {

                            if (piecesEnnemie.caseEstTouch(x,y))
                            {
                                MessageBox.Show("Case déjà tirer");
                                dejaTirer = true;
                            }
                            else
                            {
                                piecesEnnemie.tirerCase(x,y);    
                                touche = true;
                            }
                        }
                        if(piecesEnnemie.toutesCasesToucher()) 
                        {
                            couler = true;
                        }
                        
                    }
                }
                if(touche==false)
                { 
                    if(joueur_deux.Cases[x,y].EstTouchee)
                    {
                        MessageBox.Show("Case déjà tirer");
                        dejaTirer = true;
                    }
                    else
                    {
                        joueur_deux.Cases[x, y].tirer();
                    }
                }
            }
            else if(nomJoueur==nomJoueur2)
            {

            }
            lbReception.Items.Add(FormatteurActions.retournerActionMiseAJour(nomJoueur, x, y, true, true));
			if (nomJoueur == nomJoueur2)
            {
                foreach (Piece piecesEnnemie in joueur_un.Pieces)                     //Pour chaque Piece dans le tableau
                {
                    foreach (CaseDeJeux caseDeJeuxEnnemie in piecesEnnemie.CasesDeJeu)   //Tester chaque case du tableau
                    {
                        CaseDeJeux caseTemp = new CaseDeJeux((piecesEnnemie.PositionX + caseDeJeuxEnnemie.OffsetX), (piecesEnnemie.PositionY + caseDeJeuxEnnemie.OffsetY));

                        if ((caseTemp.OffsetX == x) && (caseTemp.OffsetY == y))
                        {

                            if (piecesEnnemie.caseEstTouch(x, y))
                            {
                                MessageBox.Show("Case déjà tirer");
                                dejaTirer = true;
                            }
                            else
                            {
                                piecesEnnemie.tirerCase(x, y);
                                touche = true;
                            }
                        }
                        if (piecesEnnemie.toutesCasesToucher())
                        {
                            couler = true;
                        }

                    }
                }
                if (touche == false)
                {
                    if (joueur_un.Cases[x, y].EstTouchee)
                    {
                        MessageBox.Show("Case déjà tirer");
                        dejaTirer = true;
                    }
                    else
                    {
                        joueur_un.Cases[x, y].tirer();
                    }
                }
            }
            if(dejaTirer==false)
            {
                lbReception.Items.Add(FormatteurActions.retournerActionMiseAJour(nomJoueur, x, y, touche, couler));
                lbReception2.Items.Add(FormatteurActions.retournerActionMiseAJour(nomJoueur, x, y, touche, couler));
            }
            if(joueur_deux.piecesToutesTouchees())
            else if(nomJoueur==nomJoueur2)
            {
                FinDeJeu(nomJoueur1);
            }
            else if(joueur_un.piecesToutesTouchees())
            {
                FinDeJeu(nomJoueur2);

            }
            lbReception.Items.Add(FormatteurActions.retournerActionMiseAJour(nomJoueur, x, y, true, true));
        }
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
