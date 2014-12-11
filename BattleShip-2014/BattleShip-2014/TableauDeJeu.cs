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

        // détermine les cases de jeu
        public CaseDeJeux[,] Cases 
        {
            get
            {
                return cases_;
            }
        }

        // détermine la taille en X du tableau de jeu
        public int TailleX
        {
            get
            {
                return tailleX_;
            }
        }

        // détermine la taille en Y du tableau de jeu
        public int TailleY
        {
            get
            {
                return tailleY_;
            }
        }

        /*
         * 
         * Fonction pour créer un tableau de jeu
         * 
         * parametre: détermine la taille en X du tableau de jeu
         * parametre: détermine la taille en Y du tableau de jeu
         * 
         * */
        public TableauDeJeu(int tailleX, int tailleY)
	    {
            cases_ = new CaseDeJeux[tailleX, tailleY];  // tableau de case

            for (int i = 0; i < tailleX; i++)
            {
                for(int j = 0; j < tailleY; j++)
                {
                    cases_[i, j] = new CaseDeJeux(i, j);    // initialise et créer chaque case du tableau de cases                  
                }
            }
                
            tailleX_ = tailleX;
		    tailleY_ = tailleY;
	    }

        /**
        *methode 
         *parametre tirX: position X du tir
         *parametre tirY: position Y du tir
         *retourne 0 si le tire a été réussit
         *retourne 1 si la case a déjà été touché
         *retourne 2 la case est à l'exterieur du tableau
         **/
        public int tirerSurCase(int tirX, int tirY)
        {   
            // verifie si le le tir est dans le tableau
            if (((tirX < tailleX_) && (tirX >= 0)) && 
                ((tirY < tailleY_)&&(tirY >=0)))   
            {
                //vérifie si la case est touché ou pas
                CaseDeJeux c = cases_[tirX, tirY];  
                if (c.EstTouchee)
                {
                    return 1;
                }
                else // sinon tire
                {
                    c.tirer(); 
                    return 0;
                }
            }
            else
            {
                return 2;
            }
        }

        public void resetCases()
        {
            foreach(CaseDeJeux c in cases_)
            {
                c.resetCase();
            }
        }

    }
}
