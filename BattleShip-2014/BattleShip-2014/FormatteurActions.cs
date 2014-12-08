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

        public static String formatterActionEnvoiModeDeJeu(string modeJeu, int x, int y,int nbBateau)
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
    }
}
