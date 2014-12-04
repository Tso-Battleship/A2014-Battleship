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

        public Piece(List<CaseDeJeux> cases,string name, string path,Rotation Rotation)
        { 
            
        }
        

        public Piece(DescriptionPiece Piece, int x, int y)
        {
            positionX_ = x;
            positionY_ = y;

        }

        
/////////////////////////////////////////////////////////////////////////////////////////////

        

        



        public int gspositionX
        {
            get
            {
                return this.positionX_;
            }

        }
        public int gspositionY
        {
            get
            {
                return this.positionY_;
            }

        }
        public int gsrotation
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


/////////////////////////////////////////////////////////////////////////////////////////////


        

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

        public bool toutesCasesToucher(int posx, int posy)
        {
            foreach (CaseDeJeux c in cases_)
            {
                if (positionX_ + c.OffsetX == posx && positionY_ + c.OffsetY == posy)
                {
                    if (!c.EstTouchee)
                        return false;
                }

            }
            return true;
        }
    }
}
