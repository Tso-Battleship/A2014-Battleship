using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BattleShip_2014
{
    public partial class Serveur : Form
    {
        string nomJoueur1;
        string nomJoueur2;
        int Case;
        int NbConnection = 0;

        public Serveur()
        {
            InitializeComponent();
            lectureModeJeu();
        }

        public void lectureModeJeu()
        {
            List<DescriptionPiece> descriptionDuModeDeJeu;
            descriptionDuModeDeJeu = new List<DescriptionPiece>();

            List<CaseDeJeux> cases = new List<CaseDeJeux>();

            cases.Add(new CaseDeJeux(0, 0));
            cases.Add(new CaseDeJeux(0, 1));

            DescriptionPiece dp = new DescriptionPiece(cases, "partrol_boat.pne", "Patrol Boat");

            descriptionDuModeDeJeu.Add(dp);

            cases.Add(new CaseDeJeux(0, 2));
            cases.Add(new CaseDeJeux(0, 3));

            dp = new DescriptionPiece(cases, "battleship.pne", "Battleship");

            descriptionDuModeDeJeu.Add(dp);

            int tailleX = 10, tailleY = 10;

            string nom_mode = "Nom du mode";

            foreach(DescriptionPiece description in descriptionDuModeDeJeu)
            {

               /* FormatteurActions.
                description.*/
                  
            }

            /*
            List<

            TableauAvecPiece tableauJ1;
            tableauJ1 = new TableauAvecPiece(2,2,)
             * */
        }

        public void LogiqueServeur(string trame)
        {
            string[] splitTrameAction;
            splitTrameAction = trame.Split(';').ToArray();
            switch (splitTrameAction[0])
            {
                case "ACTION:CONNECT":
                    ConnectionClient(splitTrameAction[1]);
                    break;
                
            }
        }

        public void readTCP()
        {
            
        }

        private void btConnection1_Click(object sender, EventArgs e)
        {
            LogiqueServeur(FormatteurActions.genererActionConnection("JOHN"));
            lbEnvoie.Items.Add(FormatteurActions.genererActionConnection("JOHN"));
        }

        private void ConnectionClient(string trame)
        {
            string[] splitJoueur;
            NbConnection++;
            splitJoueur = trame.Split(':').ToArray();
            if(NbConnection==1)
            {
                nomJoueur1 = splitJoueur[1];
                

            }
            else if(NbConnection==2)
            {
                nomJoueur2 = splitJoueur[1];
                //lbReception.Items.Add(FormatteurActions.formatterActionEnvoiModeDeJeu());
                //lbReception2.Items.Add(FormatteurActions.formatterActionEnvoiModeDeJeu());
                lbReception.Items.Add(FormatteurActions.formatterCommencerPlacement(nomJoueur1, nomJoueur2));
                lbReception2.Items.Add(FormatteurActions.formatterCommencerPlacement(nomJoueur1, nomJoueur2));
            }

        }

        private void btConnection2_Click(object sender, EventArgs e)
        {
            LogiqueServeur(FormatteurActions.genererActionConnection("Jack"));
            lbEnvoie2.Items.Add(FormatteurActions.genererActionConnection("Jack"));
        }

        private void btEnvoiePiece1_Click(object sender, EventArgs e)
        {
            
            //LogiqueServeur.(FormatteurActions.formatterActionEnvoiPositionPiece());
        }
    }
}
