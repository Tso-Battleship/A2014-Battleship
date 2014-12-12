@@ -12,21 +12,20 @@ namespace BattleShip_2014
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
@@ -40,9 +39,26 @@ namespace BattleShip_2014

        public void lectureModeJeu()
        {
<<<<<<< Updated upstream
            descriptionDuModeDeJeu = new List<DescriptionPiece>();
=======

            mode_ = (new xml_crunch("battleship_xml.xml").getModeDeJeu());

            nomMode = mode_.NomModeDeJeu;
            tailleX = mode_.TailleX;
            tailleY = mode_.TailleY;
            nbPiece = mode_.Pieces.Count;

            //mode_ = (new xml_crunch("battleship_xml.xml").getModeDeJeu());
            List<CaseDeJeux> cases = new List<CaseDeJeux>();

            /*foreach (Piece p in mode_.Pieces)
            {

            }
            */
            /*descriptionDuModeDeJeu = new List<DescriptionPiece>();
>>>>>>> Stashed changes

            List<CaseDeJeux> cases = new List<CaseDeJeux>();

@@ -53,15 +69,13 @@ namespace BattleShip_2014

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
@@ -83,7 +97,7 @@ namespace BattleShip_2014
               /* FormatteurActions.
                description.*/
                  
            //}
            }

            /*
            List<
@@ -124,12 +138,10 @@ namespace BattleShip_2014
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
@@ -144,12 +156,10 @@ namespace BattleShip_2014
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

@@ -170,107 +180,15 @@ namespace BattleShip_2014

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

        private bool ReceptionPiece(string nomJoueur, string nomPiece, int x, int y, string rotation)
@@ -299,13 +217,7 @@ namespace BattleShip_2014
                            pieceExiste = false;
                    }
                    if(pieceExiste)
                    {
                        joueur_un.Pieces.Add(p);
                        

                    }
                        
                        

                    
                }
@@ -372,12 +284,12 @@ namespace BattleShip_2014

        private void btTir1_Click(object sender, EventArgs e)
        {
            LogiqueServeur(FormatteurActions.genererActionTir(nomJoueur1, Convert.ToInt16(tbX1.Text), Convert.ToInt16(tbY1.Text)));

        }

        private void btTir2_Click(object sender, EventArgs e)
        {
            LogiqueServeur(FormatteurActions.genererActionTir(nomJoueur2, Convert.ToInt16(tbX2.Text), Convert.ToInt16(tbY2.Text)));

        }

        private void btDeconnection1_Click(object sender, EventArgs e)
@@ -402,11 +314,6 @@ namespace BattleShip_2014

        }

        private void tbX1_TextChanged(object sender, EventArgs e)
        {

        }

        
    }
}
