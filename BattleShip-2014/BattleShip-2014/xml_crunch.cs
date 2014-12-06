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
        /// <summary>
        /// !!! Les variables pour l'acquisition des coordonées de pieces !!!
        /// </summary>
        private string[] modeDeJeu_ = { "", "", "", "", "", "" };
        private string[] piecesDeJeu_ = { "", "", "", "", "", "" };
        private string[] casesDeJeu_ = { "", "", "", "", "", "" };
        private string[] descriptionDeJeu_ = { "", "", "", "", "", "" };
        private int[] piecesX_ = { 0, 0, 0, 0, 0, 0 };
        private int[] piecesY_ = { 0, 0, 0, 0, 0, 0 };
        private int nbrCasePieces = 0;

        //Declaration de l'objet
        XmlReader reader;
        Piece piece;
        //Le nom du fichier xml
        private string NomFichier_ = "battleship_xml.xml";

        /// <summary>
        /// Constructeur
        /// </summary>
        public xml_crunch(String nomFichier)
        {
            NomFichier_ = nomFichier;
            //initialisation de lobjet configure xml et initialisation du Xml Reader
            XmlReaderSettings configurationReader = new XmlReaderSettings();
            reader = XmlReader.Create(NomFichier_, configurationReader);
            piece = new Piece();


            //config du xml reader qui est linker sa ligne en haut
            configurationReader.ConformanceLevel = ConformanceLevel.Fragment;
            configurationReader.IgnoreComments = true;
            configurationReader.IgnoreWhitespace = false;


        }

        /// <summary>
        /// get set pieces endroit
        /// </summary>

        public string[] PiecesDeJeu
        {
            get { return piecesDeJeu_; }
            set { piecesDeJeu_ = value; }
        }

        /// <summary>
        /// Description get set selon le xml
        /// </summary>
        public string[] DescriptionDeJeu
        {
            get { return descriptionDeJeu_; }
            set { descriptionDeJeu_ = value; }
        }


        /// <summary>
        /// get set Case de jeu selon le xml
        /// </summary>
        public string[] CasesDeJeu
        {
            get { return casesDeJeu_; }
            set { casesDeJeu_ = value; }
        }

        /// <summary>
        /// get set du type de jeu
        /// </summary>
        public string[] ModeDeJeu
        {
            get { return modeDeJeu_; }
            set { modeDeJeu_ = value; }
        }

        public int indexPieces
        {
            get { return indexPieces_; }
            set { indexPieces_ = value; }
        }


        //Compte de pieces, car on peut avoir 32767 pieces
        private int indexPieces_ = -1;
        public void xmlreader()
        {

            //Boucle jusqu'a temps qu'il n'ai plus de ligne dans le xml
            while (reader.Read())
            {
                //Change au prochain element du xml
                reader.MoveToElement();
                switch (reader.Name)
                {
                    case "modeDeJeu":
                        if (reader.HasAttributes)
                            modeDeJeu_[0] = reader["nomDeJeu"];
                        indexPieces_ = -1;
                        break;
                    case "taille":
                        modeDeJeu_[1] = reader.ReadElementContentAsString();
                        break;
                    case "path":
                        if (reader.HasAttributes)
                            modeDeJeu_[2] = reader["emplacement"];
                        break;
                    case "pieces":
                        if (reader.HasAttributes)
                        {
                            indexPieces_++;
                            piecesDeJeu_[indexPieces_] = reader["ship"];
                        }
                        break;
                    case "cases":
                        casesDeJeu_[indexPieces_] = reader.ReadElementContentAsString();
                        break;
                    case "description":
                        descriptionDeJeu_[indexPieces_] = reader.ReadElementContentAsString();
                        break;
                    default:
                        break;
                }
                //Slipt pour X Y donc appeler la fonction
                separationXY(indexPieces_);
                //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                //!!!!!!!!!!!!!!mettre la methode pour l'association à la description de pièces dans modeDeJeu!!!!!!!!!
                //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            }

        }

        /// <summary>
        /// Split des x y de notre string preablement acquisitionne
        /// </summary>
        private void separationXY(int nbrPieces)
        {
            int i = 0;
            int j = 0;
            string[] tempString = { "", "", "", "", "", "", "" };

            string[] split = piecesDeJeu_[nbrPieces].Split(new Char[] { ':' });


            //Boucle 1 pour separer avec le couple de coordonnee x,y
            foreach (string s in split)
            {
                if (s.Trim() != "")
                {
                    tempString[i] = s;

                }
                i++;
            }

            i = 0;
            //Associe le buffer
            // les index pair du buffer seront les coordonnee en X(0.2.4.6.8.10) et les impaires seront en Y(1.3.5.7.9.11)
            string[] split2 = tempString[nbrPieces].Split(new Char[] { ',' });

            foreach (string s in split2)
            {
                if (s.Trim() != "")
                {
                    //piecesX[i] selon le split, j = x et j+2 = y
                    piecesX_[i] = Convert.ToInt16(s[j]);
                    piecesY_[i] = Convert.ToInt16(s[j + 1]);
                }
                //Sauter une coordonnee donc 2 caracteres
                i++;
                nbrCasePieces = i;
                j += 2;
            }
        }

        public ModeDeJeu getModeDeJeu()
        {
            int i = 0;
            ModeDeJeu mode = new ModeDeJeu();


            for (i = 0; i <= nbrCasePieces; i++)
            {
                CaseDeJeux c = new CaseDeJeux(piecesX_[i], piecesY_[i]);
                mode.cases_.Add(c);
            }
            //resetter la valeur du nbr de case d'une piece
            nbrCasePieces = 0;
            DescriptionPiece dp = new DescriptionPiece(mode.cases_, modeDeJeu_[2], descriptionDeJeu_[indexPieces_]);  //cases_, emplacement, description pieces donc nom
            return mode;
        }

    }
}