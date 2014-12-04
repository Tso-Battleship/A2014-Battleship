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
        int x;
        int y;
        public Serveur()
        {
            InitializeComponent();
            
        }

        public void LogiqueServeur(string Trame)
        {
            string[] TrameSpliter;
            
            TrameSpliter = Trame.Split(';').ToArray();

            switch (TrameSpliter[0])
            {
                case "ACTION:TIR":
                    {
                        
                    }
                    break;

                default :
                    {
                        //envoie d'erreur au joueur
                    }
                    break;
        
            }
         }
    }
}
