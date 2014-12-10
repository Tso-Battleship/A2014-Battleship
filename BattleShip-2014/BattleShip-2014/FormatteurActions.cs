using System;
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
        public static String formatterActionEnvoiPositionPiece(Piece p)
        {
            String retour = "";

            retour += Commun.TRAME_ACTION + Commun.DELEMITEUR_DEBUT_DATA + Commun.ACTION_PLACER_PIECES + Commun.DELEMITEUR_FIN_DONNEE;
            retour += Commun.DATA_NOM_PIECE + Commun.DELEMITEUR_DEBUT_DATA + "NOMDELAPIECE" + Commun.DELEMITEUR_FIN_DONNEE;
            retour += Commun.DATA_PATH + Commun.DELEMITEUR_DEBUT_DATA + "XEX/C.jpg" + Commun.DELEMITEUR_FIN_DONNEE;
            retour += Commun.ACTION_POINT_X + Commun.DELEMITEUR_DEBUT_DATA + 2 + Commun.DELEMITEUR_FIN_DONNEE;
            retour += Commun.ACTION_POINT_Y + Commun.DELEMITEUR_DEBUT_DATA + 3 + Commun.DELEMITEUR_FIN_DONNEE;

            return retour;
        }

        public static String formatterCommencerPlacement(String nomJoueur1, String nomJoueur2)
        {
            String retour = "";

            retour += Commun.TRAME_ACTION + Commun.DELEMITEUR_DEBUT_DATA + Commun.ACTION_COMMENCER_PLACEMENT + Commun.DELEMITEUR_FIN_DONNEE;
            retour += Commun.TRAME_JOUEUR + Commun.DELEMITEUR_DEBUT_DATA + nomJoueur1 + Commun.DELEMITEUR_FIN_DONNEE;
            retour += Commun.TRAME_JOUEUR + Commun.DELEMITEUR_DEBUT_DATA + nomJoueur2 + Commun.DELEMITEUR_FIN_DONNEE;

            return retour;
        }

        public static String formatterCommencerPartie(String nomJoueur)
        {
            String retour = "";

            retour += Commun.TRAME_ACTION + Commun.DELEMITEUR_DEBUT_DATA + Commun.ACTION_COMMENCER_PARTIE + Commun.DELEMITEUR_FIN_DONNEE;
            retour += Commun.TRAME_JOUEUR + Commun.DELEMITEUR_DEBUT_DATA + nomJoueur + Commun.DELEMITEUR_FIN_DONNEE;

            return retour;
        }

        public static String formatterActionEnvoiModeDeJeu(string modeJeu, int x, int y, int nbBateau)
        {
            String retour = "";

            retour += Commun.TRAME_ACTION + Commun.DELEMITEUR_DEBUT_DATA + Commun.ACTION_MODE_DE_JEU + Commun.DELEMITEUR_FIN_DONNEE;
            retour += Commun.DATA_NOM_MODE + Commun.DELEMITEUR_DEBUT_DATA + modeJeu + Commun.DELEMITEUR_FIN_DONNEE;
            retour += Commun.ACTION_POINT_X + Commun.DELEMITEUR_DEBUT_DATA + x + Commun.DELEMITEUR_FIN_DONNEE;
            retour += Commun.ACTION_POINT_Y + Commun.DELEMITEUR_DEBUT_DATA + y + Commun.DELEMITEUR_FIN_DONNEE;
            retour += Commun.DATA_NBRE + Commun.DELEMITEUR_DEBUT_DATA + nbBateau + Commun.DELEMITEUR_FIN_DONNEE;
            return retour;
        }

        public static String formatterActionEnvoiPieces()
        {
            String retour = "";
            retour += Commun.TRAME_ACTION + Commun.DELEMITEUR_DEBUT_DATA + Commun.ACTION_DESCRIPTION_PIECE + Commun.DELEMITEUR_FIN_DONNEE;
            /*tour += */

            return retour;
        }

        public static String retournerActionMiseAJour(String nomJoueur, int x, int y, bool touche, bool coule)
        {
            String retour = "";

            retour += Commun.TRAME_ACTION + Commun.DELEMITEUR_DEBUT_DATA + Commun.ACTION_MISE_A_JOUR + Commun.DELEMITEUR_FIN_DONNEE;
            retour += Commun.TRAME_JOUEUR + Commun.DELEMITEUR_DEBUT_DATA +  nomJoueur + Commun.DELEMITEUR_FIN_DONNEE;
            retour += Commun.ACTION_POINT_X + Commun.DELEMITEUR_DEBUT_DATA + Convert.ToString(x) + Commun.DELEMITEUR_FIN_DONNEE;
            retour += Commun.ACTION_POINT_Y + Commun.DELEMITEUR_DEBUT_DATA + Convert.ToString(y) + Commun.DELEMITEUR_FIN_DONNEE;
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
            retour += Commun.ACTION_POINT_X + Commun.DELEMITEUR_DEBUT_DATA + Convert.ToString(x) + Commun.DELEMITEUR_FIN_DONNEE;
            retour += Commun.ACTION_POINT_Y + Commun.DELEMITEUR_DEBUT_DATA + Convert.ToString(y) + Commun.DELEMITEUR_FIN_DONNEE;

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

        public static String obtenirModeJeu(String trame)
        {
            String modeJeu = "";

            string[] splitTrameAction;
            string[] splitModeJeu;
            splitTrameAction = trame.Split(';').ToArray();
            splitModeJeu = splitTrameAction[1].Split(':').ToArray();
            modeJeu = splitModeJeu[1];

            return modeJeu;
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
    }
}
