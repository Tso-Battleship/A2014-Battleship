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
            for (int i = 0; i <= tailleX; i++)
            {
                for (int j = 0; j <= tailleY; j++)
                {
                    cases_ = new CaseDeJeux[i, j];
                }
            }
                
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
            
            if (((tirX < tailleX_) && (tirX >= 0)) && ((tirY < tailleY_)&&(tirY >=0)))    // verifie si le le tir est dans le tableau
            {
                if (c.EstTouchee)
                {
                    return false;
                }
                else
                {
                    c.tirer();
                    return true;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
