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
    /// La classe qui lit le fichier xml et renvoie un objet ModeDeJeu
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

        //Déclaration de l'objet lecteur d'xml
        XmlReader reader;
        //Déclaration de l'objet pièce
        Piece piece;
        //Le nom du fichier xml
        private string NomFichier_ = "battleship_xml.xml";
        

        /// <summary>
        /// Constructeur de la classe xml_crunch qui lit et renvoie un ModeDeJeu
        /// </summary>
        public xml_crunch(String nomFichier)
        {
            NomFichier_ = nomFichier;
            //initialisation de lobjet configure xml et initialisation du Xml Reader
            XmlReaderSettings configurationReader = new XmlReaderSettings();

            //Validation du xml par l'entremise de'un fichier .xsd, trouver sur stack overflow fait par Pascal Vaillancourt
            configurationReader.ValidationType = ValidationType.Schema;
            configurationReader.ValidationFlags |= XmlSchemaValidationFlags.ProcessInlineSchema;
            configurationReader.ValidationFlags |= XmlSchemaValidationFlags.ProcessSchemaLocation;
            configurationReader.ValidationFlags |= XmlSchemaValidationFlags.ReportValidationWarnings;
            //confirmation par XSD que le fichier xml est bien formaté
            configurationReader.ValidationEventHandler += new ValidationEventHandler(ValidationCallBack);
            
            //Assignation des objets nécessaire pour la classe 
            reader = XmlReader.Create(NomFichier_, configurationReader);
            piece = new Piece();
            //Assignation d'une liste de description de pièce qui contient les coordonées des cases des pièces, leur nom ainsi que l'emplacement de l'imager visuel 
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

        /// <summary>
        /// Analyse le xml avec un fichier xsd pour valider le format du fichier xml
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private static void ValidationCallBack(object sender, ValidationEventArgs args)
        {
            if (args.Severity == XmlSeverityType.Warning)
                Console.WriteLine("\tWarning: Matching schema not found.  No validation occurred." + args.Message);
            else
            {
                Console.WriteLine("\tValidation error: " + args.Message);
                MessageBox.Show("Error in .XSD validation oopsi");
            }
                
        }

        //variables pour différentié chacune des pièce dans les tableaux prédéfini
        private int indexPieces_ = -1;
        /// <summary>
        /// lit le xml
        /// </summary>
        private void xmlreader()
        {
            //Boucle jusqu'a temps qu'il n'ai plus de ligne dans le xml
            while (reader.Read())
            {
                try
                {
                     //Change au prochain element du xml
                reader.MoveToElement();
                switch (reader.Name)
                {
                    //cherche dans le fichier xml un nom de modeDeJeu
                    case "modeDeJeu":
                        if (reader.HasAttributes)
                            nomDuModeDeJeu = reader["nomDeJeu"];
                        indexPieces_ = -1;
                        break;
                    //cherche une taille du tableau de jeu le fichier xml
                    case "taille":
                        //TODO Separer les tailles
                        dataModeDeJeu[1] = reader.ReadElementContentAsString();
                        break;
                    //cherche l'emplacement visuel le fichier xml
                    case "path":
                        if (reader.HasAttributes)
                            dataModeDeJeu[2] = reader["emplacement"];
                        break;
                    //cherche des description de pièces le fichier xml
                    case "pieces":
                        if (reader.HasAttributes)
                        {
                            indexPieces_++;
                            piecesDeJeu_[indexPieces_] = reader["ship"];
                        }
                        break;
                    //cherche des cases de pièces le fichier xml pour une pièce
                    case "cases":
                        casesDeJeu_[indexPieces_] = reader.ReadElementContentAsString();
                        break;
                    //cherche la description de la pièce dans  le fichier xml
                    case "description":
                        descriptionDeJeu_[indexPieces_] = reader.ReadElementContentAsString();
                        separationXY(indexPieces_);      //Separation x y des differentes cases
                        getPiece();                  //Ajoute la case l'endroit de l'image et le nom du ship dans La description de pieces
                        break;
                    default:
                        break;
                    }
                }
                catch(IndexOutOfRangeException ex)
                {
                    MessageBox.Show("Erreur dans le XML ");
                }
               
            }    
        }

        /// <summary>
        /// sépare les x et y de notre string préablement acquisitionnés dans e fichier xml
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

            //gestion d'erreur lorsque qu'une coordonnée n'est pas valide ex: des lettres et ou caractères spéciaux
            try
            {
                piecesX_ = new int[longeurDeBuffer];
                piecesY_ = new int[longeurDeBuffer];

                for (i = 0; i < longeurDeBuffer; i++)
                {
                    X = tempString[i].Substring(0, 1);  //commence au caractère 0 avec une longueur de 1 caractère
                    Y = tempString[i].Substring(2);     //commence au caractrère 2 et termine après, car c'est normalement le dernier caractères de la string

                    // convertit les coordonnées qui sont en string en int16
                    piecesX_[i] = Convert.ToInt16(X);
                    piecesY_[i] = Convert.ToInt16(Y);
                }

            }
            catch(FormatException ex)
            {
                //s'il y a une erreur un messageBox apparait
                MessageBox.Show(ex.Message);        
            }
          

        }
        
        /// <summary>
        /// créer une liste de CaseDeJeu avec une positionX, positionY et créer une DescriptionDePiece avec ses paramètres
        /// </summary>
        /// <returns>Mode de Jeu</returns>
        public void getPiece()
        {
            int i = 0;
            List<CaseDeJeux> cases = new List<CaseDeJeux>();

            for (i = 0; i < piecesX_.Length; i++)
            {
                //À chaque case de jeu d'une pièce il faut l'ajouté dans une liste de case de jeu pour une pièce pour le nombre de cases pour la pièce
                CaseDeJeux c = new CaseDeJeux(piecesX_[i], piecesY_[i]);
                cases.Add(c);
            }

            //création d l'objet description de pièces avec ses paramètres
            descriptionDesPieces.Add(new DescriptionPiece(cases, piecesDeJeu_[indexPieces_], descriptionDeJeu_[indexPieces_])); 
        }


        /// <summary>
        /// Méthode qui renvoie au serveur un ModeDeJeu selon le constructeur dans la classe ModeDeJeu
        /// </summary>
        /// <returns></returns>
        public ModeDeJeu getModeDeJeu()
        {
            //lit l'xml qui créer le ModeDeJeu pour le retourné à la suite
            xmlreader();
            return new ModeDeJeu(10, 10, descriptionDesPieces, nomDuModeDeJeu);
        }


        /// <summary>
        /// Cette méthode trim les string vide d'un tablesu de string et retourne sont résultat
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
