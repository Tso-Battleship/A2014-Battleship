using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace xml_test
{
    public partial class Form1 : Form
    {
        ModeDeJeu modeDeJeu;
        xml_crunch xml;
        public Form1()
        {
            InitializeComponent();
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            modeDeJeu = (new xml_crunch("battleship_xml.xml").getModeDeJeu());

            genereListBoxXML();
        }

        private void genereListBoxXML()
        {
            string tempCaseX = "";
            string tempCaseY = "";
            
            //foreach pour afficher ce qui ce retrouve dans la DescriptionPiece
            foreach(DescriptionPiece dp in modeDeJeu.pieces_)
            {
                //foreach pour afficher les cases qui sont dans la DescriptionPiece
                foreach(CaseDeJeux c in dp.CasesDeJeu)
                {
                    tempCaseX += c.OffsetX.ToString() + ",";
                    tempCaseY += c.OffsetY.ToString() + ":";
                }
                //ajout dans dans le listBox de la descriptionPiece courante POUR UNE PIECE
                listBox1.Items.Insert(0, dp.Nom  + " : " + tempCaseX + ":" + tempCaseY + " " + dp.PathVisuels);
                tempCaseX = "";
                tempCaseY = "";
            }
           
        }

    }
}
