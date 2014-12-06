using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip_2014
{
    public class TableauAvecPiece : TableauDeJeu
    {
        public List<Piece> pieces_;

        // selon le forum de stackoverflow.com ca fonctionne :p
        public TableauAvecPiece(int tailleX, int tailleY, List<Piece> pieces) :
            base(tailleX, tailleY)
	    {
            pieces_ = pieces;
	    }

	    public bool piecesToutesTouchees()
	    {
            int i = 0;
            foreach(Piece p in pieces_)
            {
                if(p.toutesCasesToucher())
                    i++;
            }

            if (i == pieces_.Count)
                return true;
            else
                return false;
	    }
    }
}
