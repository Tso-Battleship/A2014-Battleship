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
    class xml_crunch
    {
        XmlReader reader;
        private string NomFichier_ = "battleship_xml.xml";
        xml_crunch()
        {
            //initialisation de lobjet configure xml et initialisation du Xml Reader
            XmlReaderSettings configurationReader = new XmlReaderSettings();
            reader = XmlReader.Create(NomFichier_, configurationReader);
           
            //config du xml reader qui est linker sa ligne en haut
            configurationReader.ConformanceLevel = ConformanceLevel.Fragment;
            configurationReader.IgnoreComments = true;
            configurationReader.IgnoreWhitespace = false;
                
        }

        void main()
        {
            string genre;

            while (reader.Read())
            {
                reader.MoveToElement();
                switch(reader.Name){
                    /*
                        //Lire le mode de jeux
            reader.ReadToFollowing("modeDeJeu");
            reader.MoveToFirstAttribute();
            genre = reader.Value;
            //output.AppendLine("The genre value: " + genre);

            reader.ReadToFollowing("title");
            //output.AppendLine("Content of the title element: " + reader.ReadElementContentAsString());*/
                        
                case "modeDeJeu":
                        ;
                        break;
                }
            }
            
        }

    }
}
