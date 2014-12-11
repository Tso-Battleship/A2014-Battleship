using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip_2014
{
    public class ModeDeJeu
    {
        public List<DescriptionPiece> pieces_;

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
        /// Constructeur
        /// </summary>
        public ModeDeJeu(int tailleX, int tailleY, List<DescriptionPiece> pieces, String nomModeDeJeu = "Battleship")
        {
            pieces_ = pieces;
            tailleX_ = tailleX;
            tailleY_ = tailleY;
            nomModeDeJeu_ = nomModeDeJeu;
        }

    }
}
