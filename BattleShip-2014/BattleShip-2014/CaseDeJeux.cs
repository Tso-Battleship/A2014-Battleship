using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip_2014
{
    public class CaseDeJeux
    {
        /// <summary>
        /// Variable globale
        /// </summary>
        private bool estTouchee_;
        private int offsetX_, offsetY_;


        public bool EstTouchee
        {
            get { return estTouchee_; }
            //set { myVar = value; }
        }


        public int OffsetX
        {
            get { return offsetX_; }
            //set { myVar = value; }
        }

        public int OffsetY
        {
            get { return offsetY_; }
            //set { myVar = value; }
        }
        

        /// <summary>
        /// Constructeur
        /// </summary>
        public CaseDeJeux()
        {
            estTouchee_ = false;
            offsetX_ = 0;
            offsetY_ = 0;
        }

      
        /// <summary>
        /// 
        /// </summary>
        /// <param name="offX"></param>
        /// <param name="offY"></param>
        public CaseDeJeux(int offX, int offY)
        {
            estTouchee_ = false;
            offsetX_ = offX;
            offsetY_ = offY;
        }

        /// <summary>
        /// 
        /// </summary>
        public void tirer()
        {
            estTouchee_ = true;
        }

        public void resetCase()
        {
            estTouchee_ = false;
        }
    }
}
