using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip_2014
{
    public class TableauDeJeu
    {
        protected CaseDeJeux[,] cases_;
        protected int tailleX_, tailleY_;

        public TableauDeJeu(int tailleX, int tailleY)
	    {
            cases_ = new CaseDeJeux[tailleX, tailleY];
		    tailleX_ = tailleX;
		    tailleY_ = tailleY;
	    }

        /**
        *methode 
         *parametre tirX: position X du tir
         *parametre tirY: position Y du tir 
         *retourne true si le tir est dans le tableau
        */
        public bool tirerSurCase(int tirX, int tirY)
        {
            CaseDeJeux c = cases_[tirX, tirY];
            if(c.EstTouchee)
            {

            }
            else
            {
                c.tirer();
            }

            if ((tirX <= tailleX_) && (tirY <= tailleY_) )
                return true;
            else
                return false;
        }
    }
}
