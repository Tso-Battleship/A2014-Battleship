using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip_2014
{
    public class TableauAvecPiece : TableauDeJeu
    {
        
        private List<Piece> pieces_;

        // permet de chercher la liste et la "seter"
        public List<Piece> Pieces
        {
            get { return pieces_; }
            set { pieces_ = value; }
        }

        /* créer le tableau de jeu avec les pièces à l'intérieur
         * 
         * parametre: tailleX taille en X du tableau
         * parametre: tailleX taille en X du tableau
         * parametre: list<Piece> liste de pièces
         * */
        public TableauAvecPiece(int tailleX, int tailleY, List<Piece> pieces) :
            base(tailleX, tailleY) 
        {
            pieces_ = pieces;
        }

        // vérifie si TOUTES les pièces sont touchées
        public bool piecesToutesTouchees()
        {
            int i = 0;

            foreach (Piece p in pieces_)    // une pièces à la fois
            {
                if (p.toutesCasesToucher()) // case touché?
                    i++;
            }

            if (i == pieces_.Count) // TOUTE touché?
                return true;
            else
                return false;
        }
    }
}
