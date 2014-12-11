using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xml_test
{
    /// <summary>
    /// classe qui permet de 
    /// </summary>
    public class CaseDeJeux
    {

        /// <summary>
        /// Variables globales
        /// </summary>
        private bool estTouchee_;
        private int offsetX_, offsetY_;

        /// <summary>
        /// getter pour la variable EstTouchee
        /// </summary>
        public bool EstTouchee
        {
            get { return estTouchee_; }
            //set { myVar = value; }
        }

        /// <summary>
        /// getter pour la variable OffsetX
        /// </summary>
        public int OffsetX
        {
            get { return offsetX_; }
            //set { myVar = value; }
        }

        /// <summary>
        /// getter pour la variable OffsetY
        /// </summary>
        public int OffsetY
        {
            get { return offsetY_; }
            //set { myVar = value; }
        }
        

        /// <summary>
        /// Constructeur de la classe CaseDeJeux
        /// </summary>
        public CaseDeJeux()
        {
            estTouchee_ = false;
            offsetX_ = 0;
            offsetY_ = 0;
        }

      
        /// <summary>
        /// permet au serveur de savoir si la case sélectionné est touché ou non grâce à la variable estTouchee (boolean)
        /// </summary>
        /// <param name="offX">coordonnée en x de la case choisie</param>
        /// <param name="offY">coordonnée en y de la case choisie</param>
        public CaseDeJeux(int offX, int offY)
        {
            estTouchee_ = false;
            offsetX_ = offX;
            offsetY_ = offY;
        }

        /// <summary>
        /// change l'état d'une case étant touchée après qu'un tir est effectué 
        /// </summary>
        public void tirer()
        {
            estTouchee_ = true;
        }
    }
}
