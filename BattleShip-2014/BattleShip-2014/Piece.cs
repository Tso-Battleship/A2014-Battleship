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


/////////////////////////////////////////////////////////////////////////////////////////////


        

        public bool caseEstTouch(int posx, int posy)
        {
            return false;
        }
        public void tirerCase(int posx, int posy)
        { 
            
        }
    }
}
