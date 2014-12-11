using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml; // ajout pour avoir les fonctionnalites XML reader
using System.Xml.Schema;    //Analyser avec le xsd
using System.IO;
using System.Windows.Forms;

namespace xml_test

{

    /// <summary>
    /// La classe qui lit le xml
    /// </summary>
    public class xml_crunch
    {
        /// <summary>
        /// !!! Les variables pour l'acquisition des coordonées de pieces !!!
        /// </summary>
        private string[] dataModeDeJeu= {"","","","","",""};
        private string[] piecesDeJeu_ = { "", "", "", "", "", ""};
        private string[] casesDeJeu_ = { "", "", "", "", "", "" };
        private string[] descriptionDeJeu_ = { "", "", "", "", "", "" };
        private int[] piecesX_;
        private int[] piecesY_;
        private int nbrCasePieces = 0;

        List<DescriptionPiece> descriptionDesPieces;
        int tailleDuModeX, tailleDuModeY;
        String nomDuModeDeJeu;

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

            //Validation du xml par l'entremise de'un fichier .xsd, trouver sur stack overflow
            configurationReader.ValidationType = ValidationType.Schema;
            configurationReader.ValidationFlags |= XmlSchemaValidationFlags.ProcessInlineSchema;
            configurationReader.ValidationFlags |= XmlSchemaValidationFlags.ProcessSchemaLocation;
            configurationReader.ValidationFlags |= XmlSchemaValidationFlags.ReportValidationWarnings;
            configurationReader.ValidationEventHandler += new ValidationEventHandler(ValidationCallBack);
            

            reader = XmlReader.Create(NomFichier_, configurationReader);
            piece = new Piece();
            descriptionDesPieces = new List<DescriptionPiece>();


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
            get { return dataModeDeJeu; }
            set { dataModeDeJeu = value; }
        }

        public int indexPieces
        {
            get { return indexPieces_; }
            set { indexPieces_ = value; }
        }
        
        
        

        /// <summary>
        /// Analyse le xml avec un fichier xsd
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private static void ValidationCallBack(object sender, ValidationEventArgs args)
        {
            if (args.Severity == XmlSeverityType.Warning)
                Console.WriteLine("\tWarning: Matching schema not found.  No validation occurred." + args.Message);
            else
                Console.WriteLine("\tValidation error: " + args.Message);
        }

        //Compte de pieces, car on peut avoir 32767 pieces
        private int indexPieces_ = -1;
        /// <summary>
        /// lit le xml
        /// </summary>
        private void xmlreader()
        {
            //Boucle jusqu'a temps qu'il n'ai plus de ligne dans le xml
            while (reader.Read())
            {
                //Change au prochain element du xml
                reader.MoveToElement();
                switch(reader.Name){
                    case "modeDeJeu":
                        if (reader.HasAttributes)
                            nomDuModeDeJeu = reader["nomDeJeu"];
                        indexPieces_ = -1;
                        break;
                    case "taille":
                        //TODO Separer les tailles
                        dataModeDeJeu[1] = reader.ReadElementContentAsString();
                        break;
                    case "path":
                        if (reader.HasAttributes)
                            dataModeDeJeu[2] = reader["emplacement"];
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
                       separationXY(indexPieces_);      //Separation x y des differentes cases
                       getPiece();                  //Ajoute la case l'endroit de l'image et le nom du ship dans La description de pieces
                        break;
                    default:
                        break;         
                }
            }    
        }

        /// <summary>
        /// Split des x y de notre string preablement acquisitionne
        /// </summary>
        private void separationXY(int nbrPieces)
        {
            int i = 0;
            
            string[] tempString = {};
            string[] tempStringCoord = {};
            string[] split = casesDeJeu_[nbrPieces].Split(new Char[] { ':' });

            String X, Y;

            tempString = trimXML(split);
            int longeurDeBuffer = tempString.Length;

            try
            {

            }
            catch(FormatException ex)
            {
                MessageBox.Show(ex.Message);        
            }
            piecesX_ = new int[longeurDeBuffer];
            piecesY_ = new int[longeurDeBuffer];

            for (i = 0; i < longeurDeBuffer; i++)
            {
                X = tempString[i].Substring(0, 1);  //0 start index, 1 the length of the substring
                Y = tempString[i].Substring(2);
                
                piecesX_[i] = Convert.ToInt16(X);
                piecesY_[i] = Convert.ToInt16(Y);
            }
        }
        
        /// <summary>
        /// Create a list of CaseDeJeu with positionX and positionY and create a DescriptionDePiece
        /// </summary>
        /// <returns>Mode de Jeu</returns>
        public void getPiece()
        {
            int i = 0;
            List<CaseDeJeux> cases = new List<CaseDeJeux>();

            for (i = 0; i < piecesX_.Length; i++)
            {
                CaseDeJeux c = new CaseDeJeux(piecesX_[i], piecesY_[i]);
                cases.Add(c);
            }
            //resetter la valeur du nbr de case d'une piece
            //indexPieces_ = 0;
            //nbrCasePieces = 0;


            descriptionDesPieces.Add(new DescriptionPiece(cases, dataModeDeJeu[2], descriptionDeJeu_[indexPieces_])); //création d l'objet description de pièces
            //DescriptionPiece dp = new DescriptionPiece(mode.cases_, modeDeJeu_[2], descriptionDeJeu_[indexPieces_]);  //cases_, emplacement, description pieces donc nom

            //mode = dp.CasesDeJeu;
        }

        public ModeDeJeu getModeDeJeu()
        {
            xmlreader();
            return new ModeDeJeu(10, 10, descriptionDesPieces, nomDuModeDeJeu);
        }


        /// <summary>
        /// This methode split a string array and return the result of it
        /// </summary>
        /// <param name="strArray1">String to split </param>
        /// <returns>The result of the split in a array</returns>
        private string[] trimXML(string [] strArray1)
        {
            string[] valreturn = new string[strArray1.Length];
            int i = 0;
            //Boucle 1 pour separer avec le couple de coordonnee x,y
            foreach (string s in strArray1)
            {
                if (s.Trim() != "")
                {
                    valreturn[i] = s;
                }
                i++;
            }
            return valreturn;
        }
        
    }
}
