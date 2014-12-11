using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip_2014
{
    public class DescriptionPiece
    {

        protected string nom_;
        protected string path_visuel_;
        protected List<CaseDeJeux> cases_;

        public DescriptionPiece()
        {
            cases_ = new List<CaseDeJeux>();
            cases_.Add(new CaseDeJeux(0, 0));
            nom_ = "UneCaseGenerique";
            path_visuel_ = "/";
        }

        public DescriptionPiece(List<CaseDeJeux> cases, string path_visuel, string nom)
        {
            nom_ = nom;
            path_visuel_ = path_visuel;
            cases_ = cases;
        }


        public string Nom
        {
            get
            {
                return this.nom_;
            }

        }
        public string PathVisuels
        {
            get
            {
                return this.path_visuel_;
            }

        }
        public List<CaseDeJeux> CasesDeJeu
        {
            get
            {
                return this.cases_;
            }

        }

    }
}
