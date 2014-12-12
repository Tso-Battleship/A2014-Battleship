﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip_2014
{
    public static class FormatteurActions
    {
        /*String PIECES
            MODEJE
            MAJ
            DESPiece*/
        public static String genererActionEnvoiPositionPiece(String nomJoueur, Piece p)
        {
            String retour = "";

            retour += Commun.TRAME_ACTION + Commun.DELEMITEUR_DEBUT_DATA + Commun.ACTION_PLACER_PIECES + Commun.DELEMITEUR_FIN_DONNEE;
            retour += Commun.TRAME_JOUEUR + Commun.DELEMITEUR_DEBUT_DATA + nomJoueur + Commun.DELEMITEUR_FIN_DONNEE;
            retour += Commun.DATA_NOM_PIECE + Commun.DELEMITEUR_DEBUT_DATA + p.Nom + Commun.DELEMITEUR_FIN_DONNEE;
            retour += Commun.DATA_POINT_X + Commun.DELEMITEUR_DEBUT_DATA + p.PositionX + Commun.DELEMITEUR_FIN_DONNEE;
            retour += Commun.DATA_POINT_Y + Commun.DELEMITEUR_DEBUT_DATA + p.PositionY + Commun.DELEMITEUR_FIN_DONNEE;
            retour += Commun.ACTION_ROTATION + Commun.DELEMITEUR_DEBUT_DATA + p.RotationPiece + Commun.DELEMITEUR_FIN_DONNEE;

            return retour;
        }

        public static String genererCommencerPlacement(String nomJoueur1, String nomJoueur2)
        {
            String retour = "";

            retour += Commun.TRAME_ACTION + Commun.DELEMITEUR_DEBUT_DATA + Commun.ACTION_COMMENCER_PLACEMENT + Commun.DELEMITEUR_FIN_DONNEE;
            retour += Commun.TRAME_JOUEUR + Commun.DELEMITEUR_DEBUT_DATA + nomJoueur1 + Commun.DELEMITEUR_FIN_DONNEE;
            retour += Commun.TRAME_JOUEUR + Commun.DELEMITEUR_DEBUT_DATA + nomJoueur2 + Commun.DELEMITEUR_FIN_DONNEE;

            return retour;
        }

        public static String genererCommencerPartie(String nomJoueur)
        {
            String retour = "";

            retour += Commun.TRAME_ACTION + Commun.DELEMITEUR_DEBUT_DATA + Commun.ACTION_COMMENCER_PARTIE + Commun.DELEMITEUR_FIN_DONNEE;
            retour += Commun.TRAME_JOUEUR + Commun.DELEMITEUR_DEBUT_DATA + nomJoueur + Commun.DELEMITEUR_FIN_DONNEE;

            return retour;
        }

        public static String genererActionEnvoiModeDeJeu(ModeDeJeu modeDeJeu)
        {
            String retour = "";

            retour += Commun.TRAME_ACTION + Commun.DELEMITEUR_DEBUT_DATA + Commun.ACTION_MODE_DE_JEU + Commun.DELEMITEUR_FIN_DONNEE;
            retour += Commun.DATA_NOM_MODE + Commun.DELEMITEUR_DEBUT_DATA + modeDeJeu.NomModeDeJeu + Commun.DELEMITEUR_FIN_DONNEE;
            retour += Commun.DATA_POINT_X + Commun.DELEMITEUR_DEBUT_DATA + modeDeJeu.TailleX + Commun.DELEMITEUR_FIN_DONNEE;
            retour += Commun.DATA_POINT_Y + Commun.DELEMITEUR_DEBUT_DATA + modeDeJeu.TailleY + Commun.DELEMITEUR_FIN_DONNEE;
            retour += Commun.DATA_NBRE + Commun.DELEMITEUR_DEBUT_DATA + modeDeJeu.Pieces.Count + Commun.DELEMITEUR_FIN_DONNEE;

            return retour;
        }

        public static String genererActionEnvoiPieces(DescriptionPiece p)
        {
            String retour = "";

            retour += Commun.TRAME_ACTION + Commun.DELEMITEUR_DEBUT_DATA + Commun.ACTION_PLACER_PIECES + Commun.DELEMITEUR_FIN_DONNEE;
            retour += Commun.DATA_NOM_PIECE + Commun.DELEMITEUR_DEBUT_DATA + p.Nom + Commun.DELEMITEUR_FIN_DONNEE;
            retour += Commun.DATA_PATH + Commun.DELEMITEUR_DEBUT_DATA + p.PathVisuels + Commun.DELEMITEUR_FIN_DONNEE;
            retour += Commun.DATA_NBRE + Commun.DELEMITEUR_DEBUT_DATA + p.CasesDeJeu.Count + Commun.DELEMITEUR_FIN_DONNEE;           

            return retour;
        }

        public static String genererActionEnvoiCases(String nomPiece, CaseDeJeux caseDeJeu)
        {
            String retour = "";

            retour += Commun.TRAME_ACTION + Commun.DELEMITEUR_DEBUT_DATA + Commun.ACTION_CASE_DE_JEU + Commun.DELEMITEUR_FIN_DONNEE;
            retour += Commun.DATA_NOM_PIECE + Commun.DELEMITEUR_DEBUT_DATA + nomPiece + Commun.DELEMITEUR_FIN_DONNEE;
            retour += Commun.DATA_POINT_X + Commun.DELEMITEUR_DEBUT_DATA + caseDeJeu.OffsetX + Commun.DELEMITEUR_FIN_DONNEE;
            retour += Commun.DATA_POINT_Y + Commun.DELEMITEUR_DEBUT_DATA + caseDeJeu.OffsetY + Commun.DELEMITEUR_FIN_DONNEE;

            return retour;
        }

        public static String genererActionMiseAJour(String nomJoueur, int x, int y, bool touche, bool coule)
        {
            String retour = "";

            retour += Commun.TRAME_ACTION + Commun.DELEMITEUR_DEBUT_DATA + Commun.ACTION_MISE_A_JOUR + Commun.DELEMITEUR_FIN_DONNEE;
            retour += Commun.TRAME_JOUEUR + Commun.DELEMITEUR_DEBUT_DATA +  nomJoueur + Commun.DELEMITEUR_FIN_DONNEE;
            retour += Commun.DATA_POINT_X + Commun.DELEMITEUR_DEBUT_DATA + Convert.ToString(x) + Commun.DELEMITEUR_FIN_DONNEE;
            retour += Commun.DATA_POINT_Y + Commun.DELEMITEUR_DEBUT_DATA + Convert.ToString(y) + Commun.DELEMITEUR_FIN_DONNEE;
            retour += Commun.ACTION_BATEAU_TOUCHE + Commun.DELEMITEUR_DEBUT_DATA + Convert.ToString(touche) + Commun.DELEMITEUR_FIN_DONNEE;
            retour += Commun.ACTION_BATEAU_COULE + Commun.DELEMITEUR_DEBUT_DATA + Convert.ToString(coule) + Commun.DELEMITEUR_FIN_DONNEE;

            return retour;
        }

        public static String genererActionConnection(String nomJoueur)
        {
            String retour = "";

            retour += Commun.TRAME_ACTION + Commun.DELEMITEUR_DEBUT_DATA + Commun.ACTION_CONNECTION + Commun.DELEMITEUR_FIN_DONNEE;
            retour += Commun.TRAME_JOUEUR + Commun.DELEMITEUR_DEBUT_DATA + nomJoueur + Commun.DELEMITEUR_FIN_DONNEE;

            return retour;
        }

        public static String genererActionDeconnection(String nomJoueur)
        {
            String retour = "";

            retour += Commun.TRAME_ACTION + Commun.DELEMITEUR_DEBUT_DATA + Commun.ACTION_FERMETURE + Commun.DELEMITEUR_FIN_DONNEE;
            retour += Commun.TRAME_JOUEUR + Commun.DELEMITEUR_DEBUT_DATA + nomJoueur + Commun.DELEMITEUR_FIN_DONNEE;

            return retour;
        }

        public static String genererActionTir(String nomJoueur, int x, int y)
        {
            String retour = "";

            retour += Commun.TRAME_ACTION + Commun.DELEMITEUR_DEBUT_DATA + Commun.ACTION_TIR + Commun.DELEMITEUR_FIN_DONNEE;
            retour += Commun.TRAME_JOUEUR + Commun.DELEMITEUR_DEBUT_DATA + nomJoueur + Commun.DELEMITEUR_FIN_DONNEE;
            retour += Commun.DATA_POINT_X + Commun.DELEMITEUR_DEBUT_DATA + Convert.ToString(x) + Commun.DELEMITEUR_FIN_DONNEE;
            retour += Commun.DATA_POINT_Y + Commun.DELEMITEUR_DEBUT_DATA + Convert.ToString(y) + Commun.DELEMITEUR_FIN_DONNEE;

            return retour;
        }

        public static String genererActionFin(String nomJoueur)
        {
            String retour = "";

            retour += Commun.TRAME_ACTION + Commun.DELEMITEUR_DEBUT_DATA + Commun.ACTION_FIN_DE_PARTIE + Commun.DELEMITEUR_FIN_DONNEE;
            retour += Commun.TRAME_JOUEUR + Commun.DELEMITEUR_DEBUT_DATA + nomJoueur + Commun.DELEMITEUR_FIN_DONNEE;

            return retour;
        }

        public static String obtenirJoueur(String trame)
        {
            String nomJoueur = "";

            string[] splitTrameAction;
            string[] splitJoueur;
            splitTrameAction = trame.Split(';').ToArray();
            splitJoueur = splitTrameAction[1].Split(':').ToArray();
            nomJoueur = splitJoueur[1];

            return nomJoueur;
        }

        public static String obtenirJoueur2(String trame)
        {
            String nomJoueur2 = "";

            string[] splitTrameAction;
            string[] splitJoueur2;
            splitTrameAction = trame.Split(';').ToArray();
            splitJoueur2 = splitTrameAction[2].Split(':').ToArray();
            nomJoueur2 = splitJoueur2[1];

            return nomJoueur2;
        }

        public static String obtenirPathVisuel(String trame)
        {
            String path = "";

            string[] splitTrameAction;
            string[] splitpath;
            splitTrameAction = trame.Split(';').ToArray();
            splitpath = splitTrameAction[2].Split(':').ToArray();
            path = splitpath[1];

            return path;
        }

        /// <summary>
        /// Fonction qui construis un objet de mode de jeu sans pieces 
        /// </summary>
        /// <param name="trame">La trame recue qui contient l'action mode de jeu</param>
        /// <param name="nbreBateaux">Le nombre de pieces a recevoir pour completer l'objet</param>
        /// <returns>Un mode de jeu sans descriptions de pieces</returns>
        public static ModeDeJeu obtenirModeJeu(String trame, ref int nbreBateaux)
        {
            String nomDuMode = "";
            int tailleX = 0 , tailleY  = 0;

            String[] split = trame.Split(Commun.DELEMITEUR_FIN_DONNEE);
            foreach (String s in split)
                if(s.Length > 0)
                {
                    String head = getActionFromTrame(s);                    
                    switch(head)
                    {
                        case Commun.DATA_NOM_MODE:
                            nomDuMode = getDataFromTrame(s);
                            break;
                        case Commun.DATA_POINT_X:
                            tailleX = Convert.ToInt32(getDataFromTrame(s));
                            break;
                        case Commun.DATA_POINT_Y:
                            tailleY = Convert.ToInt32(getDataFromTrame(s));
                            break;
                        case Commun.DATA_NBRE:
                            nbreBateaux = Convert.ToInt32(getDataFromTrame(s));
                            break;

                    }
                }
            return new ModeDeJeu(tailleX, tailleY, new List<DescriptionPiece>(), nomDuMode);
        }

        /// <summary>
        /// Fonction qui obtiens une description de piece sans cases de jeu, mais avec son nom et autres membres
        /// </summary>
        /// <param name="trame">la trame</param>
        /// <param name="nbreCases">le nombre de cases qui seront recues par la suite</param>
        /// <returns>la descritption de la nouvelles piece sans ses cases de jeu</returns>
        public static DescriptionPiece obtenirDescriptionDePiece(String trame, ref int nbreCases)
        {
            String path = "", nom = "";
            String[] split = trame.Split(Commun.DELEMITEUR_FIN_DONNEE);

            foreach (String s in split)
                if(s.Length > 0)
                {
                    String head = getActionFromTrame(s);                    
                    switch(head)
                    {
                        case Commun.DATA_PATH:
                            path = getDataFromTrame(s);
                            break;
                        case Commun.DATA_NOM_PIECE:
                            nom = getDataFromTrame(s);
                            break;
                        case Commun.DATA_NBRE:
                            nbreCases = Convert.ToInt32(getDataFromTrame(s));
                            break;

                    }
                }
            return new DescriptionPiece(new List<CaseDeJeux>(), path, nom);
        }

        /// <summary>
        /// Fonction qui receptionne une case de jeu, utile pour recevoir des positions etc.
        /// </summary>
        /// <param name="trame">la trame recue</param>
        /// <returns>Ine case de jeu selon la trame</returns>
        public static CaseDeJeux obtenirCaseDeJeu(String trame)
        {
            int x = 0, y = 0;
            String[] split = trame.Split(Commun.DELEMITEUR_FIN_DONNEE);

            foreach (String s in split)
                if (s.Length > 0)
                {
                    String head = getActionFromTrame(s);
                    switch (head)
                    {
                        case Commun.DATA_POINT_X:
                            x = Convert.ToInt32(getDataFromTrame(s));
                            break;
                        case Commun.DATA_POINT_Y:
                            y = Convert.ToInt32(getDataFromTrame(s));
                            break;

                    }
                }
            return new CaseDeJeux(x, y);
        }

        public static int obtenirNbBateau(String trame)
        {
            int nbBateau;

            string[] splitTrameAction;
            string[] splitNbBateau;
            splitTrameAction = trame.Split(';').ToArray();
            splitNbBateau = splitTrameAction[3].Split(':').ToArray();
            nbBateau = Convert.ToInt16(splitNbBateau[1]);

            return nbBateau;
        }

        public static int obtenirX(String trame)
        {
            int X;

            string[] splitTrameAction;
            string[] splitX;
            splitTrameAction = trame.Split(';').ToArray();
            splitX = splitTrameAction[2].Split(':').ToArray();
            X = Convert.ToInt16(splitX[1]);

            return X;
        }

        public static int obtenirY(String trame)
        {
            int Y;

            string[] splitTrameAction;
            string[] splitY;
            splitTrameAction = trame.Split(';').ToArray();
            splitY = splitTrameAction[3].Split(':').ToArray();
            Y = Convert.ToInt16(splitY[1]);

            return Y;
        }

        public static bool obtenirTouche(String trame)
        {
            bool touche;

            string[] splitTrameAction;
            string[] splitTouche;
            splitTrameAction = trame.Split(';').ToArray();
            splitTouche = splitTrameAction[4].Split(':').ToArray();
            touche = Convert.ToBoolean(splitTouche[1]);

            return touche;
        }

        public static bool obtenirCoule(String trame)
        {
            bool coule;

            string[] splitTrameAction;
            string[] splitCoule;
            splitTrameAction = trame.Split(';').ToArray();
            splitCoule = splitTrameAction[4].Split(':').ToArray();
            coule = Convert.ToBoolean(splitCoule[1]);

            return coule;
        }

        public static string obtenirNomPiece(String trame)
        {
            string nomPiece;

            string[] splitTrameAction;
            string[] splitNomPiece;
            splitTrameAction = trame.Split(';').ToArray();
            splitNomPiece = splitTrameAction[2].Split(':').ToArray();
            nomPiece = splitNomPiece[1];

            return nomPiece;
        }

        public static int obtenirOffX(String trame)
        {
            int offX;

            string[] splitTrameAction;
            string[] splitX;
            splitTrameAction = trame.Split(';').ToArray();
            splitX = splitTrameAction[3].Split(':').ToArray();
            offX = Convert.ToInt16(splitX[1]);

            return offX;
        }

        public static int obtenirOffY(String trame)
        {
            int offY;

            string[] splitTrameAction;
            string[] splitY;
            splitTrameAction = trame.Split(';').ToArray();
            splitY = splitTrameAction[4].Split(':').ToArray();
            offY = Convert.ToInt16(splitY[1]);

            return offY;
        }

        public static string obtenirRotation(String trame)
        {
            string rotation;

            string[] splitTrameAction;
            string[] splitRotation;
            splitTrameAction = trame.Split(';').ToArray();
            splitRotation = splitTrameAction[3].Split(':').ToArray();
            rotation = splitRotation[1];

            return rotation;
        }

        /// <summary>
        /// Obtiens l'action dans le début de la trame recue, permet de faire la distinction entre le trames
        /// </summary>
        /// <param name="trame">La trame recues</param>
        /// <returns>La valeur qui détermine l'action</returns>
        public static string obtenirAction(String trame)
        {
            return trame.Substring(trame.IndexOf(Commun.DELEMITEUR_DEBUT_DATA) + 1, (trame.IndexOf(Commun.DELEMITEUR_FIN_DONNEE) - trame.IndexOf(Commun.DELEMITEUR_DEBUT_DATA) - 1));
        }

        /// <summary>
        /// Permet de prendre une trame sous le formate TYPEDATA:DATA et d'en sortir TYPEDATA
        /// </summary>
        /// <param name="partieDeTrame">la partie de trame a analyser</param>
        /// <returns>le type de data dans la trame</returns>
        private static String getActionFromTrame(String partieDeTrame)
        {
            return partieDeTrame.Substring(0, partieDeTrame.IndexOf(Commun.DELEMITEUR_DEBUT_DATA));
        }

        /// <summary>
        /// Permet de prendre une trame sous le formate TYPEDATA:DATA et d'en sortir DATA
        /// </summary>
        /// <param name="partieDeTrame">la partie de trame a analyser</param>
        /// <returns>le data dans la trame</returns>
        private static String getDataFromTrame(String partieDeTrame)
        {
            return partieDeTrame.Substring(partieDeTrame.IndexOf(Commun.DELEMITEUR_DEBUT_DATA) + 1);
        }

    }
}
