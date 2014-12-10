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
        //creation de l'objet
        ModeDeJeu mode;
        DescriptionPiece dp;
        xml_crunch xml;
        public Form1()
        {
            InitializeComponent();
            mode = new ModeDeJeu();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //xml.xmlreader();
            //genereListBoxXML();
            xml = new xml_crunch("battleship_xml.xml");
            xml.xmlreader();
            //ModeDeJeu mode = xml.getModeDeJeu();
            DescriptionPiece dp = new DescriptionPiece();
            genereListBoxXML(dp);
        }

        private void genereListBoxXML(DescriptionPiece descPieces)
        {
            //listBox1.Items.Add(descPieces.gspath_visuel_);
            //listBox1.Items.Add(descPieces.gsnom_);
            //listBox1.Items.Add(descPieces.gscases_);

            listBox1.Items.Insert(0, xml.ModeDeJeu[0].ToString() + " " + xml.ModeDeJeu[1] + " " + xml.ModeDeJeu[2].ToString());
            listBox1.Items.Insert(0, "Ship1" + " : " + xml.PiecesDeJeu[0].ToString() + " " + xml.CasesDeJeu[0] + " " + xml.DescriptionDeJeu[0]);
            listBox1.Items.Insert(0, "Ship2" + " : " + xml.PiecesDeJeu[1].ToString() + " " + xml.CasesDeJeu[1] + " " + xml.DescriptionDeJeu[1]);
            listBox1.Items.Insert(0, "Ship3" + " : " + xml.PiecesDeJeu[2].ToString() + " " + xml.CasesDeJeu[2] + " " + xml.DescriptionDeJeu[2]);
            listBox1.Items.Insert(0, "Ship4" + " : " + xml.PiecesDeJeu[3].ToString() + " " + xml.CasesDeJeu[3] + " " + xml.DescriptionDeJeu[3]);
            listBox1.Items.Insert(0, "Ship5" + " : " + xml.PiecesDeJeu[4].ToString() + " " + xml.CasesDeJeu[4] + " " + xml.DescriptionDeJeu[4]);
           
        }


    }
}
