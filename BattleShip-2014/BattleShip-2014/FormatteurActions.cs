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
        String formatterActionEnvoiPositionPiece(Piece p)
        {
            String retour = "";

            retour += Commun.TRAME_ACTION + Commun.DELEMITEUR_DEBUT_DATA + Commun.ACTION_PLACER_PIECES + Commun.DELEMITEUR_FIN_DONNEE;
            retour += Commun.DATA_NOM_PIECE + Commun.DELEMITEUR_DEBUT_DATA + "NOMDELAPIECE" + Commun.DELEMITEUR_FIN_DONNEE;
            retour += Commun.ACTION_POINT_X + Commun.DELEMITEUR_DEBUT_DATA + 2 + Commun.DELEMITEUR_FIN_DONNEE;
            retour += Commun.ACTION_POINT_Y + Commun.DELEMITEUR_DEBUT_DATA + 3 + Commun.DELEMITEUR_FIN_DONNEE;

            return retour;
        }

        String formatterActionEnvoiModeDeJeu()
        {
            String retour = "";

            retour += Commun.TRAME_ACTION + Commun.DELEMITEUR_DEBUT_DATA + Commun.ACTION_MODE_DE_JEU + Commun.DELEMITEUR_FIN_DONNEE;
            retour += Commun.DATA_NOM_PI

            return retour;
        }


    }
}
