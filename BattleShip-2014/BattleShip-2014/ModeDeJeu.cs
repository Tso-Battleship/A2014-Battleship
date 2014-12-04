using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip_2014
{
    class ModeDeJeu
    {
        /// <summary>
        /// Constructeur
        /// </summary>
        List<CaseDeJeux> cases_;
        xml_crunch xml;

        public ModeDeJeu()
        {
            xml = new xml_crunch();
            cases_ = new List<CaseDeJeux>();
            
            DescriptionPiece dp = new DescriptionPiece(cases_, "path_visuel", "nom de pice");
        }

        private void mode(int x, int y)
        {
           
           // CaseDeJeux c = new CaseDeJeux(i, j);
            //cases_.Add(c);
        }
    }
}
