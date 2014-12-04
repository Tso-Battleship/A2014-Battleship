using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip_2014
{
    public class DescriptionPiece
    {

        string nom_;
        string path_visuel_;
        protected List<CaseDeJeux> cases_;

        public DescriptionPiece()
        {

        }

        public DescriptionPiece(List<CaseDeJeux> cases, string path_visuel, string nom)
        {
            nom_ = nom;
            path_visuel_ = path_visuel;
            cases_ = cases;
        }


        public string gsnom_
        {
            get
            {
                return this.nom_;
            }

        }
        public string gspath_visuel_
        {
            get
            {
                return this.path_visuel_;
            }

        }
        public List<CaseDeJeux> gscases_
        {
            get
            {
                return this.cases_;
            }

        }

    }
}
