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
        List<CaseDeJeux> cases_;

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
            set
            {
                this.nom_ = value;
            }
        }
        public string gspath_visuel_
        {
            get
            {
                return this.path_visuel_;
            }
            set
            {
                this.path_visuel_ = value;
            }
        }
        public List<CaseDeJeux> gscases_
        {
            get
            {
                return this.cases_;
            }
            set
            {
                this.cases_ = value;
            }
        }

    }
}
