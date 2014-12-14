/**
 * @file   Serveur.cs
 * @author Olivier Arsenault/Jérémie Daigneault
 * @date   11-dec 2014
 * @brief  Logique du serveur du jeu BattleShip
 *
 * @version 1.0 : Première version
 *
 * Matériel:
 *   Interface de programmation: Microsoft Visual Studio
 *   Système de développement: PC avec Windows 7
 */

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
        /**La stucture ModeDeJeu contient le nom du mode, la taille de la plaquette de jeu et une liste de description des pieces*/
        ModeDeJeu mode_;
        /** valeur contenant le nom du joueur s'étant connecter en premier*/
        string nomJoueur1;
        /** valeur contenant le nom du joueur s'étant connecter en deuxième*/
        string nomJoueur2;
        /** valeur contenant le nombre de joueur connecté*/
        int NbConnection = 0;
        /** valeur contenant le nombre de colonne de la plaquette de jeu*/
        int tailleX;
        /** valeur contenant le nombre de rangée de la plaquette de jeu*/
        int tailleY;

        /**Création du tableau des tableaux de pièce des joueurs*/
        TableauAvecPiece joueur_un;
        TableauAvecPiece joueur_deux;

        /** list de description de pièce utiliser pour la création des pièces dans le mode de test*/
        List<DescriptionPiece> descriptionDuModeDeJeu;

        public Serveur()
        {
            InitializeComponent();
            //lecture du mode de jeu dans le fichier xml, ou création des pièces dans le programme de test
            lectureModeJeu();
        }

        /**
         * @lecture du mode de jeu dans le fichier xml, ou création des pièces et grille de jeu dans le programme de test
         */
        public void lectureModeJeu()
        {
            //lecture du mode de jeu dans le xml
            //mode_ = (new xml_crunch("battleship_xml.xml").getModeDeJeu());

            //création d'un nouvelle description de pièce
            descriptionDuModeDeJeu = new List<DescriptionPiece>();
            //création d'une nouvelle list contenant les cases de jeux occuper par la pièces qui est créées
            List<CaseDeJeux> cases = new List<CaseDeJeux>();
            //ajout à la liste des cases décrites par leur position (x,y) sur la grille
            cases.Add(new CaseDeJeux(0, 0));
            cases.Add(new CaseDeJeux(0, 1));
            //Descriptions de pièces créées avec les cases choisie, un chemin vers l'image de la pièce et un nom
            DescriptionPiece dp = new DescriptionPiece(cases, "partrol_boat.pne", "Patrol Boat");
            //ajout de la description de pièce à la liste de description
            descriptionDuModeDeJeu.Add(dp);
            //création d'une nouvelle list contenant les cases de jeux occuper par la pièces qui est créées
            List<CaseDeJeux> cases2 = new List<CaseDeJeux>();
            //ajout à la liste des cases décrites par leur position (x,y) sur la grille
            cases2.Add(new CaseDeJeux(0, 0));
            cases2.Add(new CaseDeJeux(0, 1));
            cases2.Add(new CaseDeJeux(0, 2));
            cases2.Add(new CaseDeJeux(0, 3));
            //Descriptions de pièces créées avec les cases choisie, un chemin vers l'image de la pièce et un nom
            DescriptionPiece dp2 = new DescriptionPiece(cases2, "battleship.pne", "Battleship");
            //ajout de la description de pièce à la liste de description
            descriptionDuModeDeJeu.Add(dp2);
            //définit la taille de la grille de jeux
            tailleX = 10;
            tailleY = 10;
            //création du tableau de jeu des joueurs avec la taille définit et la liste des pièces présentes.
            joueur_un = new TableauAvecPiece(tailleX, tailleY, new List<Piece>());
            joueur_deux = new TableauAvecPiece(tailleX, tailleY, new List<Piece>());
        }

        /**
         * @brief Fonction recevant une trame en provenance d'un des joueurs et execute des fonctions selons le début de la trame 
         * @param trame envoyer par le joueur
         */
        public void LogiqueServeur(string trame)
        {
            //sépare la trame pour aller chercher l'action envoyé par le joueur
            string[] splitTrameAction;
            splitTrameAction = trame.Split(';').ToArray();
            switch (splitTrameAction[0])
            {
                    //action recue lors de la connection d'un joueur.
                case "ACTION:CONNECT":
                    ConnectionClient(FormatteurActions.obtenirJoueur(trame));
                    break;
                    //action recue lors de l'envoie de la grille de jeu d'un joueur.
                case "ACTION:PIECES":
                    ReceptionPiece(FormatteurActions.obtenirJoueur(trame), FormatteurActions.obtenirNomPiece(trame), FormatteurActions.obtenirOffX(trame), FormatteurActions.obtenirOffY(trame), FormatteurActions.obtenirRotation(trame));
                    break;
                   //action recue lors d'un tir
                case "ACTION:TIR":
                    ReceptionTir(FormatteurActions.obtenirJoueur(trame), FormatteurActions.obtenirX(trame), FormatteurActions.obtenirY(trame));
                    break;
                    //action recue lors de la déconnection d'un joueur
                case "ACTION:DISCONNECT":
                    DeconnectionClient(FormatteurActions.obtenirJoueur(trame));
                    break;
            }
        }

        /**
         * @brief Fonction appelée lors de la connection d'un joueur
         * @param trame contenant le nom du joueur que ce connecte
         */
        private void ConnectionClient(string trame)
        {
            NbConnection++;
            //La fonction attend la connection des deux joueurs avant d'envoyer la trame de début de placement au joueurs
            if(NbConnection==1)
            {
                nomJoueur1 = trame;
                lJoueur1.Text = "Joueur 1 : Connecter";
            }
            else if(NbConnection==2)
            {
                nomJoueur2 = trame;
                lJoueur2.Text = "Joueur 2 : Connecter";
                lbReception.Items.Add(FormatteurActions.formatterCommencerPlacement(nomJoueur1, nomJoueur2));
                lbReception2.Items.Add(FormatteurActions.formatterCommencerPlacement(nomJoueur1, nomJoueur2));
            }

        }

        /**
         * @brief Fonction appelée lors de la déconnection d'un joueur
         * @param trame contenant le nom du joueur que ce connecte
         */
        private void DeconnectionClient(string trame)
        {
            //Si un joueur ce déconnection, la fonction FinDeJeu est appelé avec le nom du joueur restant en tant que gagnant
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

        /**
         * @brief Envoie aux joueurs la trame indiquant la fin du jeu et le nom du joueur gagnant
         * @param trame contenant le nom du joueur gagnant
         */
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

        /**
        * @brief Gestion des tirs 
        * @param trame contenant le nom du joueur ayant tirer et les coordonnés de la case tirée
        */
       private void ReceptionTir(string nomJoueur, int x, int y)
        {
           /**valeur indiquant aux joueurs qu'un bateau occupais la case tirée*/
           bool touche=false;
           /**valeur indiquant aux joueurs que la case choisie à déjà été tirée*/
           bool dejaTirer = false;
           /**valeur indiquant aux joueurs qu'un bateau à été coulé*/
           bool couler = false;
           //Si le joueur 1 à tiré, regarde dans les cases du joueur 2
            if(nomJoueur==nomJoueur1)
            {
                foreach (Piece piecesEnnemie in joueur_deux.Pieces)                     //Pour chaque Piece dans le tableau
                {
                    foreach (CaseDeJeux caseDeJeuxEnnemie in piecesEnnemie.CasesDeJeu)   //Tester chaque case du tableau
                    {
                        //création d'une nouvelle case de jeu contenant une case occuper par un bateau
                        CaseDeJeux caseTemp = new CaseDeJeux((piecesEnnemie.PositionX + caseDeJeuxEnnemie.OffsetX),(piecesEnnemie.PositionY + caseDeJeuxEnnemie.OffsetY)); 
                        //si la case tirée est la même que la case occuper par un bateau
                        if ((caseTemp.OffsetX == x) && (caseTemp.OffsetY == y))
                        {
                            //Regarde si la case n'a pas déjà été tirée
                            if (piecesEnnemie.caseEstTouch(x,y))
                            {
                                MessageBox.Show("Case déjà tirer");
                                dejaTirer = true;
                            }
                            //si non, rend la case tirée
                            else
                            {
                                piecesEnnemie.tirerCase(x,y);    
                                touche = true;
                            }
                        }
                        //Regarde si toute les cases d'un bateau ont été touchée
                        if(piecesEnnemie.toutesCasesToucher()) 
                        {
                            couler = true;
                        }
                        
                    }
                }
                //Si la case ne contenais pas de bateau
                if(touche==false)
                {
                    //Regarde si la case n'a pas déjà été tirée
                    if(joueur_deux.Cases[x,y].EstTouchee)
                    {
                        MessageBox.Show("Case déjà tirer");
                        dejaTirer = true;
                    }
                    //si non, rend la case tirée
                    else
                    {
                        joueur_deux.Cases[x, y].tirer();
                    }
                }
            }
            //Si le joueur 2 à tiré, regarde dans les cases du joueur 1
            if (nomJoueur == nomJoueur2)
            {
                foreach (Piece piecesEnnemie in joueur_un.Pieces)                     //Pour chaque Piece dans le tableau
                {
                    foreach (CaseDeJeux caseDeJeuxEnnemie in piecesEnnemie.CasesDeJeu)   //Tester chaque case du tableau
                    {
                        //création d'une nouvelle case de jeu contenant une case occuper par un bateau
                        CaseDeJeux caseTemp = new CaseDeJeux((piecesEnnemie.PositionX + caseDeJeuxEnnemie.OffsetX), (piecesEnnemie.PositionY + caseDeJeuxEnnemie.OffsetY));
                        //si la case tirée est la même que la case occuper par un bateau
                        if ((caseTemp.OffsetX == x) && (caseTemp.OffsetY == y))
                        {
                            //Regarde si la case n'a pas déjà été tirée
                            if (piecesEnnemie.caseEstTouch(x, y))
                            {
                                MessageBox.Show("Case déjà tirer");
                                dejaTirer = true;
                            }
                            //si non, rend la case tirée
                            else
                            {
                                piecesEnnemie.tirerCase(x, y);
                                touche = true;
                            }
                        }
                        //Regarde si toute les cases d'un bateau ont été touchée
                        if (piecesEnnemie.toutesCasesToucher())
                        {
                            couler = true;
                        }

                    }
                }
                //Si la case ne contenais pas de bateau
                if (touche == false)
                {
                    //Regarde si la case n'a pas déjà été tirée
                    if (joueur_un.Cases[x, y].EstTouchee)
                    {
                        MessageBox.Show("Case déjà tirer");
                        dejaTirer = true;
                    }
                    //si non, rend la case tirée
                    else
                    {
                        joueur_un.Cases[x, y].tirer();
                    }
                }
            }
            //Envoie l'état de la case tiré au deux joueurs, si celle-ci n'avait pas déjà été tirée
            if(dejaTirer==false)
            {
                lbReception.Items.Add(FormatteurActions.retournerActionMiseAJour(nomJoueur, x, y, touche, couler));
                lbReception2.Items.Add(FormatteurActions.retournerActionMiseAJour(nomJoueur, x, y, touche, couler));
            }
            //appele la fin de jeu avec le joueur 1 comme gagnant si toute les pieces du joueur 2 sont touchées
            if(joueur_deux.piecesToutesTouchees())
            {
                FinDeJeu(nomJoueur1);
            }
            //appele la fin de jeu avec le joueur 2 comme gagnant si toute les pieces du joueur 1 sont touchées
            else if(joueur_un.piecesToutesTouchees())
            {
                FinDeJeu(nomJoueur2);
            }
        }

       /**
        * @brief Popule la grille de jeu du joueur avec les pieces recues
        * @param nomJoueur Contient le nom du joueur ayant envoyer ces pièces
        *        nomPiece Contient le nom de la pièce envoyée
        *        x  Contient la coordonée x de départ de la pièce
        *        y  Contient la coordonée y de départ de la pièce
        *        rotation Contient l'orientation de la pièce
        * @return pieceExiste retourne un bool indiquant si la pièce est valide ou non.  True=valide
        */
        private bool ReceptionPiece(string nomJoueur, string nomPiece, int x, int y, string rotation)
        {
            //création d'un nouvelle pièce
            Piece p = new Piece(new List<CaseDeJeux>(), "AUCUNE", "NULL");
            /**Variable indiquant si la pièce existe dans la liste de pièces*/
            bool pieceExiste = false;
            //compare tous les nom de pièces dans la liste avec le nom de la pièce recue
            foreach(DescriptionPiece dp in descriptionDuModeDeJeu)
            {
                //Si le nom existe, la pièce créer prend les paramètres envoyer par le joueur
                if(dp.Nom.Equals(nomPiece))
                {
                    p = new Piece(dp, x, y);
                    pieceExiste = true;
                }
            }          
            if(pieceExiste)
            {
                //Si la pièce a une rotation vers la droite, le x devient le y et vice-versa
                if (rotation.Equals("Droite"))
                    p.tournerPiece();
                if(nomJoueur1==nomJoueur)
                {
                    //regarde si la pièce existe déjà dans la grille
                    foreach(Piece pieceDejaPlacee in joueur_un.Pieces)
                    {
                        if (pieceDejaPlacee.Nom.Equals(p.Nom))
                            pieceExiste = false;
                    }
                    //si non, rajoute la pièce
                    if(pieceExiste)
                    {
                        joueur_un.Pieces.Add(p);
                    }
                    
                }
                else if(nomJoueur2==nomJoueur)
                {
                    //regarde si la pièce existe déjà dans la grille
                    foreach (Piece pieceDejaPlacee in joueur_deux.Pieces)
                    {
                        if (pieceDejaPlacee.Nom.Equals(p.Nom))
                            pieceExiste = false;
                    }
                    //si non, rajoute la pièce
                    if(pieceExiste)
                        joueur_deux.Pieces.Add(p);
                }
            }
            //lorsque les deux joueurs on fini de placer toutes leurs pièces, envoie la trame de début de partie
            if (descriptionDuModeDeJeu.Count == joueur_deux.Pieces.Count && descriptionDuModeDeJeu.Count == joueur_un.Pieces.Count)
            {
                lbReception.Items.Add(FormatteurActions.formatterCommencerPartie(nomJoueur1));
                lbReception2.Items.Add(FormatteurActions.formatterCommencerPartie(nomJoueur1));
            }
            return pieceExiste;
        }



        /* Les boutons suivants sont utilisés pour le mode test seulement
         * Ils servent à remplacer les joueurs et à envoyer des trames à leur place
         * */

        /**
         * @brief Envoie au serveur  la trame de connection du joueur de gauche
         */
        private void btConnection1_Click(object sender, EventArgs e)
        {
            LogiqueServeur(FormatteurActions.genererActionConnection("JOHN"));
            lbEnvoie.Items.Add(FormatteurActions.genererActionConnection("JOHN"));
        }

        /**
          * @brief Envoie au serveur  la trame de connection du joueur de droite
          */
        private void btConnection2_Click(object sender, EventArgs e)
        {
            LogiqueServeur(FormatteurActions.genererActionConnection("Jack"));
            lbEnvoie2.Items.Add(FormatteurActions.genererActionConnection("Jack"));
        }

        /**
         * @brief Envoie au serveur les trames contenant les pièces et leurs positions
         */
        private void btEnvoiePiece1_Click(object sender, EventArgs e)
        {
            
            Piece p = new Piece(descriptionDuModeDeJeu.ElementAt(0), 3, 5, Rotation.Droite);
            
            LogiqueServeur(FormatteurActions.formatterActionEnvoiPositionPiece("JOHN", p));
            lbEnvoie.Items.Add(FormatteurActions.formatterActionEnvoiPositionPiece("JOHN", p));

            p  = new Piece(descriptionDuModeDeJeu.ElementAt(1), 1, 1, Rotation.Droite);

            LogiqueServeur(FormatteurActions.formatterActionEnvoiPositionPiece("JOHN", p));
            lbEnvoie.Items.Add(FormatteurActions.formatterActionEnvoiPositionPiece("JOHN", p));
            
        }

        /**
         * @brief Envoie au serveur les trames contenant les pièces et leurs positions
         */
        private void btEnvoiePiece2_Click(object sender, EventArgs e)
        {
            Piece p = new Piece(descriptionDuModeDeJeu.ElementAt(0), 4, 3, Rotation.Haut);

            LogiqueServeur(FormatteurActions.formatterActionEnvoiPositionPiece("Jack", p));
            lbEnvoie2.Items.Add(FormatteurActions.formatterActionEnvoiPositionPiece("Jack", p));

            p = new Piece(descriptionDuModeDeJeu.ElementAt(1), 5, 3, Rotation.Haut);

            LogiqueServeur(FormatteurActions.formatterActionEnvoiPositionPiece("Jack", p));
            lbEnvoie2.Items.Add(FormatteurActions.formatterActionEnvoiPositionPiece("Jack", p));
        }

        /**
         * @brief Envoie au serveur l'emplacement de tir choisie par le joueur
         */
        private void btTir1_Click(object sender, EventArgs e)
        {
            LogiqueServeur(FormatteurActions.genererActionTir(nomJoueur1, Convert.ToInt16(tbX1.Text), Convert.ToInt16(tbY1.Text)));
        }

        /**
         * @brief Envoie au serveur l'emplacement de tir choisie par le joueur
         */
        private void btTir2_Click(object sender, EventArgs e)
        {
            LogiqueServeur(FormatteurActions.genererActionTir(nomJoueur2, Convert.ToInt16(tbX2.Text), Convert.ToInt16(tbY2.Text)));
        }

        /**
           * @brief Envoie au serveur  la trame de connection du joueur de gauche
           */
        private void btDeconnection1_Click(object sender, EventArgs e)
        {
            LogiqueServeur(FormatteurActions.genererActionDeconnection("JOHN"));
            lbEnvoie.Items.Add(FormatteurActions.genererActionDeconnection("JOHN"));
        }

        /**
          * @brief Envoie au serveur  la trame de connection du joueur de droite
          */
        private void btDeconnection2_Click(object sender, EventArgs e)
        {
            LogiqueServeur(FormatteurActions.genererActionDeconnection("Jack"));
            lbEnvoie2.Items.Add(FormatteurActions.genererActionDeconnection("Jack"));
        }
    }
}
