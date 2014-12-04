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
        string nomJoueur;
        string nomJoueur2;
        int Case;

        public Serveur()
        {
            InitializeComponent();
        }

        public void LogiqueServeur(string Trame)
        {
            string[] TrameSplitterAction;
            string[] TrameSplitterJoueur;
            string[] TrameSplitterCase;
            TrameSplitterAction = Trame.Split(';').ToArray();
            TrameSplitterJoueur = TrameSplitterAction[1].Split(':');
            TrameSplitterCase = TrameSplitterAction[2].Split(':');
            nomJoueur = TrameSplitterJoueur[1];
            lectureModeJeu();
            readTCP();
            lbEnvoie.Items.Add(FormatteurActions.formatterActionEnvoiModeDeJeu(nomJoueur));
            readTCP();
            lbEnvoie2.Text = FormatteurActions.formatterActionEnvoiModeDeJeu(nomJoueur2);
            lbEnvoie.Text = FormatteurActions.formatterCommencerPlacement(nomJoueur, nomJoueur2);
            switch (TrameSplitterAction[0])
            {
                case "ACTION:TIR":
                    {
                        
                        Case = Convert.ToInt16(TrameSplitterCase[1]);
                    }
                    break;

                default :
                    {
                        //envoie d'erreur au joueur
                    }
                    break;
        
            }
         }

        public void lectureModeJeu()
        {

        }

        public void readTCP()
        {
            
        }

        private void btConnection1_Click(object sender, EventArgs e)
        {
            LogiqueServeur(FormatteurActions.genererActionConnection("SALUT"));
        }
    }
}
