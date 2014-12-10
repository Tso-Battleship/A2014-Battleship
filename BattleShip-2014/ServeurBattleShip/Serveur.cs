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

        TableauAvecPiece joueur_un;
        TableauAvecPiece joueur_deux;

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

            cases = new List<CaseDeJeux>(cases);
            cases.Add(new CaseDeJeux(0, 2));
            cases.Add(new CaseDeJeux(0, 3));

            dp = new DescriptionPiece(cases, "battleship.pne", "Battleship");

            descriptionDuModeDeJeu.Add(dp);

            int tailleX = 10, tailleY = 10;

            string nom_mode = "Nom du mode";

            //joueur_deux = new TableauAvecPiece(tailleX, tailleY, )

            foreach(DescriptionPiece description in descriptionDuModeDeJeu)
            {

               /* FormatteurActions.
                description.*/
                  
            }

            /*
            List<

            
             * */
        }

        public void LogiqueServeur(string trame)
        {
            string[] splitTrameAction;
            splitTrameAction = trame.Split(';').ToArray();
            switch (splitTrameAction[0])
            {
                case "ACTION:CONNECT":
                    ConnectionClient(FormatteurActions.obtenirJoueur(trame));
                    break;
                case "ACTION:PIECES":

                    ReceptionPiece();
                    break;
                case "ACTION:TIR":
                    ReceptionTir(FormatteurActions.obtenirJoueur(trame), FormatteurActions.obtenirX(trame), FormatteurActions.obtenirY(trame));
                    break;
                case "ACTION:DISCONNECT":
                    DeconnectionClient(FormatteurActions.obtenirJoueur(trame));
                    break;
            }
        }

        public void readTCP()
        {
            
        }

        private void ConnectionClient(string trame)
        {
            NbConnection++;
            if(NbConnection==1)
            {
                nomJoueur1 = trame;
            }
            else if(NbConnection==2)
            {
                nomJoueur2 = trame;
                //lbReception.Items.Add(FormatteurActions.formatterActionEnvoiModeDeJeu());
                //lbReception2.Items.Add(FormatteurActions.formatterActionEnvoiModeDeJeu());
                lbReception.Items.Add(FormatteurActions.formatterCommencerPlacement(nomJoueur1, nomJoueur2));
                lbReception2.Items.Add(FormatteurActions.formatterCommencerPlacement(nomJoueur1, nomJoueur2));
            }

        }

        private void DeconnectionClient(string trame)
        {
            FormatteurActions.genererActionDeconnection(trame);
            if(trame==nomJoueur1)
            {
                FinDeJeu(nomJoueur2);
            }
            else if (trame == nomJoueur2)
            {
                FinDeJeu(nomJoueur1);
            }
        }

        private void FinDeJeu(string joueurGagnant)
        {
            lbReception.Items.Add(FormatteurActions.genererActionFin(joueurGagnant));
        }

       private void ReceptionTir(string nomJoueur, int x, int y)
        {
            if(nomJoueur==nomJoueur1)
            {

            }
            else if(nomJoueur==nomJoueur2)
            {

            }
            lbReception.Items.Add(FormatteurActions.retournerActionMiseAJour(nomJoueur, x, y, true, true));
        }

        private void ReceptionPiece()
        {
           /* TableauAvecPiece tableauJ1;
            tableauJ1 = new TableauAvecPiece(2,2,;
      /**/  }


        private void btConnection1_Click(object sender, EventArgs e)
        {
            LogiqueServeur(FormatteurActions.genererActionConnection("JOHN"));
            lbEnvoie.Items.Add(FormatteurActions.genererActionConnection("JOHN"));
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
