using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip_2014
{
    public class ModeDeJeu
    {
        public List<CaseDeJeux> cases_;
        public List<DescriptionPiece> pieces_;

        private int tailleY_;

	    public int TailleY
	    {
		    get { return tailleY_;}
		    //set { tailleY_ = value;}
	    }
	

        private int tailleX_;

        public int TailleX
        {
            get { return tailleX_; }
           // set { tailleX_ = value; }
        }


        private int mode_;

        public int mode
        {
            get { return mode_; }
            //set { myVar = value; }
        }
        

        private string nom_;

        public string Nom
        {
            get { return nom_; }
            //set { myVar = value; }
        }

        /// <summary>
        /// Constructeur
        /// </summary>
        public ModeDeJeu(int tailleX, int tailleY, List<DescriptionPiece> pieces, String nom = "Battleship")
        {
            cases_ = new List<CaseDeJeux>();
            pieces_ = new List<DescriptionPiece>();

        }

    }
}
