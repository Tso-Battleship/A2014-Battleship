using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml; // ajout pour avoir les fonctionnalites XML reader

namespace BattleShip_2014
{
    /// <summary>
    /// La classe qui lit le xml
    /// </summary>
    public class xml_crunch
    {
        XmlReader reader;
        private string NomFichier_ = "battleship_xml.xml";
        public xml_crunch()
        {
            //initialisation de lobjet configure xml et initialisation du Xml Reader
            XmlReaderSettings configurationReader = new XmlReaderSettings();
            reader = XmlReader.Create(NomFichier_, configurationReader);
           
            //config du xml reader qui est linker sa ligne en haut
            configurationReader.ConformanceLevel = ConformanceLevel.Fragment;
            configurationReader.IgnoreComments = true;
            configurationReader.IgnoreWhitespace = false;
                
        }

        private String[] modeDeJeu_;

        void main()
        {
            string genre;

            while (reader.Read())
            {
                reader.MoveToElement();
                switch(reader.Name){
                

                    case "modeDeJeu":
                        if (reader.HasAttributes)
                            modeDeJeu_[0] = reader["nomDeJeu"];
                        break;
                    case "taille":
                        modeDeJeu_[1] = reader.ReadContentAsString();
                        break;
                    case "path":
                        if (reader.HasAttributes)
                            modeDeJeu_[2] = reader["emplacement"];
                        break;
                    case "piece":
                        if (reader.HasAttributes)
                            modeDeJeu_[3] = reader["ship1"];
                        break;
                    case "cases":
                        modeDeJeu_[4] = reader.ReadContentAsString();
                        break;
                    case "description":
                        modeDeJeu_[5] = reader.ReadContentAsString();
                        break;
                    default:
                        break;
                }
            }
            
        }

    }
}
