using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xml_test
{
    public enum Rotation
    {
        Haut = 0,
        Droite = 90,
        Bas = 180,
        Gauche = 270
    }

    struct sPoint
    {
        private int x_;
        public int X
        {
            get
            {
                return x_;
            }
            set
            {
                if (value < 100 && value >= 0)
                    x_ = value;
            }
        }

        private int y_;
        public int Y
        {
            get
            {
                return y_;
            }
            set
            {
                if (value < 100 && value >= 0)
                    y_ = value;
            }
        }
    }

    

    public static class Commun
    {
        /// <summary>
        /// Trames de communication 
        /// L'équipe des communication aura pour objectif d'envoyer des données de mode 
        /// de jeu, placements de pièce de manière simple
        /// 
        /// Une trame est comprise de : 
        /// Action - Joueur (si il y a lieu) - Data
        /// 
        /// Exemple :
        /// "ACTION:TIR;JOUEUR:1;DATA:2;X:1;Y:2;"
        /// 
        /// La partie ACTION indique l'action qui sera a venir
        /// La partie JOUEUR indique que l'action concerne le joueur suivant
        /// La partie DATA fournis la quantité d'informations à venir
        /// Le restant de la trame contient les données elle memes
        /// </summary>
        
        public const String TRAME_ACTION = "ACTION";
        public const String TRAME_JOUEUR = "JOUEUR";
        public const String TRAME_DATA = "DATA";

        public const String ACTION_CONNECTION = "CONNECT";
        public const String ACTION_FERMETURE = "DISCONNECT";
        public const String ACTION_TIR = "TIR";
        public const String ACTION_PLACER_PIECES = "PIECES";
        public const String ACTION_MODE_DE_JEU = "MODEJEU";
        public const String ACTION_MISE_A_JOUR = "MAJ";

        public const String ACTION_POINT_X = "X";
        public const String ACTION_POINT_Y = "Y";

        public const String DELEMITEUR_FIN_DONNEE = ";";
        public const String DELEMITEUR_DEBUT_DATA = ":";

        public const String DATA_NOM_PIECE = "NOMPIECE";
        public const String DATA_NOM_MODE = "NOMMODE";
        public const String DATA_PATH = "PATH";
        public const String DATA_NBRE = "NBR";
    }
    
}
