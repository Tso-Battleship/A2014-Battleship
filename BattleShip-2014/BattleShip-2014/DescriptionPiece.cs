using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip_2014
{
    public class DescriptionPiece //Devrait être vu comme un type de Pièce et non une simple description
    {

        protected string nom_;  //Nom du nouveau type de pièce.
        protected string path_visuel_; //Emplacement de l'image représentant la pièce dans le jeu.
        protected List<CaseDeJeux> cases_;  //Liste de case composant la nouvelle pièce.

        /*Constructeur de pièce générique qui ne sera probablement pas utilisée*/
        public DescriptionPiece()
        {
            cases_ = new List<CaseDeJeux>();
            cases_.Add(new CaseDeJeux(0, 0));
            nom_ = "UneCaseGenerique";
            path_visuel_ = "/";
        }
        /*
         * Constructeur de pièce qui crée un nouveau type de pièce contenant une liste de case vide par défault, un nom
         * et l'emplacement de sa représentation graphique sur la machine
         */
        public DescriptionPiece(List<CaseDeJeux> cases, string path_visuel, string nom)
        {
            nom_ = nom;
            path_visuel_ = path_visuel;
            cases_ = cases;
        }


        //Définitions des Getter et Setter pour DescriptionPiece
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
