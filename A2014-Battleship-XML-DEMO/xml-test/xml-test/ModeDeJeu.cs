using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xml_test
{
    public class ModeDeJeu
    {
        /// <summary>
        /// création de la liste de Description de pièces
        /// </summary>
        private List<DescriptionPiece> pieces_;


        public List<DescriptionPiece> Pieces
        {
            get { return pieces_; }
            set { pieces_ = value; }
        }
        


        /// <summary>
        /// section des getter pour les variables globales incluse dans la classe ModeDeJeu
        /// </summary>
        private int tailleY_;

        public int TailleY
        {
            get { return tailleY_; }
            //set { tailleY_ = value;}
        }


        private int tailleX_;

        public int TailleX
        {
            get { return tailleX_; }
            // set { tailleX_ = value; }
        }


        private string nomModeDeJeu_;

        public string NomModeDeJeu
        {
            get { return nomModeDeJeu_; }
            //set { myVar = value; }
        }

        /// <summary>
        /// Constructeur du ModeDeJeu pour l'association de la taille du tableau de jeu en x et y
        /// de la liste des pièce avec leurs cases, nom et emplacement visuel
        /// ainsi que le nom du mode de jeu
        /// </summary>
        public ModeDeJeu(int tailleX, int tailleY, List<DescriptionPiece> pieces, String nomModeDeJeu = "classique")
        {
            pieces_ = pieces;
            tailleX_ = tailleX;
            tailleY_ = tailleY;
            nomModeDeJeu_ = nomModeDeJeu;
        }

    }
}
