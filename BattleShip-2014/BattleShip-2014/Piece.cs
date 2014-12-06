using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip_2014
{
    public class Piece : DescriptionPiece
    {

        private int positionX_, positionY_;
        Rotation rotation_;

        public Piece()
        {

        }

        public Piece(List<CaseDeJeux> cases,string name, string path, Rotation Rotation)
        { 
            
        }
        

        public Piece(DescriptionPiece Piece, int x, int y)
        {
            positionX_ = x;
            positionY_ = y;

        }

        
/////////////////////////////////////////////////////////////////////////////////////////////



        public int PositionX
        {
            get
            {
                return this.positionX_;
            }
            set
            {
                this.positionX_ = value;
            }

        }
        public int PositionY
        {
            get
            {
                return this.positionY_;
            }
            set
            {
                this.positionY_ = value;
            }

        }
        public Rotation RotationPiece
        {
            get
            {
                return this.rotation_;
            }
            set
            {
                this.rotation_ = value;
            }
        }

///////////////////////////////////////////////////////////////////////////////////////////// 
      
        /// <summary>
        /// A ajouter le code
        /// </summary>
        /// <param name="posx"></param>
        /// <param name="posy"></param>
        /// <returns></returns>
        public bool caseExiste(int posx, int posy)
        {
            //TODO Ajouter le code de logique de verification de l'existence de la case -JP
            return false;
        }

        public bool caseEstTouch(int posx, int posy)
        {
            foreach(CaseDeJeux c in cases_)
            {
                 if(positionX_ + c.OffsetX == posx && positionY_ + c.OffsetY == posy)
                 {
                     if (c.EstTouchee)
                         return true;
                 }                 
            }
            return false;
        }

        public void tirerCase(int posx, int posy)
        {
            foreach (CaseDeJeux c in cases_)
            {                
                if (positionX_ + c.OffsetX == posx && positionY_ + c.OffsetY == posy)
                {
                    c.tirer();
                }
            }
        }

        public bool toutesCasesToucher()
        {
            foreach (CaseDeJeux c in cases_)
            {
                if (!c.EstTouchee)
                    return false;
            }
            return true;
        }
    }
}
