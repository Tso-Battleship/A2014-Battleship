/**
 * @file   FormatteurActions.cs
 * @author Jérémie Daigneault/Olivier Arsenault
 * @date   12-dec 2014
 * @brief  Formatteur de trame pour la communication entre les clients et le serveur
 * @brief  Fonction qui sort l'information des differentes trames
 * @version 1.0 : Première version
 *
 * Matériel:
 *   Interface de programmation: Microsoft Visual Studio
 *   Système de développement: PC avec Windows 7
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip_2014
{
    public static class FormatteurActions
    {
        /*String PIECES
            MODEJE
            MAJ
            DESPiece*/

        /// <summary>
        /// Fonction qui construis un objet de position de pieces 
        /// </summary>
        /// <param name="p">l'objet piece qui contient tout ses parametre</param>
        /// <param name="nomJoueur">Le nom du joueur a qui appartient les pieces</param>
        /// <returns>une trame contenant le nom du joueur, le nom de la pieces, sa position X et Y et sa rotation</returns>
        public static String genererActionEnvoiPositionPiece(String nomJoueur, Piece p)
        {
            String retour = "";

            retour += Commun.TRAME_ACTION + Commun.DELEMITEUR_DEBUT_DATA + Commun.ACTION_PLACER_PIECES + Commun.DELEMITEUR_FIN_DONNEE; // ACTION:PIECES;
            retour += Commun.TRAME_JOUEUR + Commun.DELEMITEUR_DEBUT_DATA + nomJoueur + Commun.DELEMITEUR_FIN_DONNEE;                   // JOUEUR:nomJoueur;
            retour += Commun.DATA_NOM_PIECE + Commun.DELEMITEUR_DEBUT_DATA + p.Nom + Commun.DELEMITEUR_FIN_DONNEE;                     // NOMPIECE:p.Nom;
            retour += Commun.DATA_POINT_X + Commun.DELEMITEUR_DEBUT_DATA + p.PositionX + Commun.DELEMITEUR_FIN_DONNEE;                 // X:x;
            retour += Commun.DATA_POINT_Y + Commun.DELEMITEUR_DEBUT_DATA + p.PositionY + Commun.DELEMITEUR_FIN_DONNEE;                 // Y:y;
            retour += Commun.ACTION_ROTATION + Commun.DELEMITEUR_DEBUT_DATA + p.RotationPiece + Commun.DELEMITEUR_FIN_DONNEE;          // ROTATION:p.RotationPieces;

            // Exemple de resultat : ACTION:PIECES;JOUEUR:JOHN;NOMPIECE:Patrol Boat;X:4;Y:3;ROTATION:Haut;

            return retour;
        }

        /// <summary>
        /// Fonction qui contruis une confirmation pour le commencement du placement de pieces 
        /// </summary>
        /// <param name="nomJoueur1">Nom du joueur qui sera le premier à jouer</param>
        /// <param name="nomJoueur2">Nom du joueur qui sera le deuxieme à jouer</param>
        /// <returns>un trame de confirmation que les joueurs peuvent placer leur pieces, l'orde dans lequel ils joueront ainsi que le nom de leur adversaire respectif</returns>
        public static String genererCommencerPlacement(String nomJoueur1, String nomJoueur2)
        {
            String retour = "";

            retour += Commun.TRAME_ACTION + Commun.DELEMITEUR_DEBUT_DATA + Commun.ACTION_COMMENCER_PLACEMENT + Commun.DELEMITEUR_FIN_DONNEE; //ACTION:PLACEMENT;
            retour += Commun.TRAME_JOUEUR + Commun.DELEMITEUR_DEBUT_DATA + nomJoueur1 + Commun.DELEMITEUR_FIN_DONNEE;                        //JOUEUR:nomJoueur1;
            retour += Commun.TRAME_JOUEUR + Commun.DELEMITEUR_DEBUT_DATA + nomJoueur2 + Commun.DELEMITEUR_FIN_DONNEE;                        //JOUEUR:nomJoueur1;

            // Exemple de resultat : ACTION:PLACEMENT;JOUEUR:JOHN;JOUEUR:BOB;

            return retour;
        }

        /// <summary>
        /// Fonction qui construis une confirmation que la partie est commencé 
        /// </summary>
        /// <param name="nomJoueur">Confirmation du joueur qui commencera</param>
        /// <returns>Une trame qui contient l'instruction de debut de la partie et le nom de celui qui commence</returns>
        public static String genererCommencerPartie(String nomJoueur)
        {
            String retour = "";

            retour += Commun.TRAME_ACTION + Commun.DELEMITEUR_DEBUT_DATA + Commun.ACTION_COMMENCER_PARTIE + Commun.DELEMITEUR_FIN_DONNEE;   //ACTION:DEBUT;
            retour += Commun.TRAME_JOUEUR + Commun.DELEMITEUR_DEBUT_DATA + nomJoueur + Commun.DELEMITEUR_FIN_DONNEE;                        //JOUEUR:nomJoueur;

            // Exemple de resultat : ACTION:DEBUT;JOUEUR:JOHN;

            return retour;
        }

        /// <summary>
        /// Fonction qui construis une trame contenant le mode de jeu 
        /// </summary>
        /// <param name="MODEJEU">Objet ModeDeJeu qui contient le nom du mode la taille X et Y de la grille de jeu et le nombre de pieces</param>
        /// <returns>Une trame qui contient les information sur le mode de jeu qui doivent etre envoyer aux joueurs</returns>
        public static String genererActionEnvoiModeDeJeu(ModeDeJeu MODEJEU)
        {
            String retour = "";

            retour += Commun.TRAME_ACTION + Commun.DELEMITEUR_DEBUT_DATA + Commun.ACTION_MODE_DE_JEU + Commun.DELEMITEUR_FIN_DONNEE; // ACTION:MODEJEU;
            retour += Commun.DATA_NOM_MODE + Commun.DELEMITEUR_DEBUT_DATA + modeDeJeu.NomModeDeJeu + Commun.DELEMITEUR_FIN_DONNEE;   // NOMMODE:NomModeDeJeu;
            retour += Commun.DATA_POINT_X + Commun.DELEMITEUR_DEBUT_DATA + modeDeJeu.TailleX + Commun.DELEMITEUR_FIN_DONNEE;         // X:TailleX;
            retour += Commun.DATA_POINT_Y + Commun.DELEMITEUR_DEBUT_DATA + modeDeJeu.TailleY + Commun.DELEMITEUR_FIN_DONNEE;         // Y:TailleX;
            retour += Commun.DATA_NBRE + Commun.DELEMITEUR_DEBUT_DATA + modeDeJeu.Pieces.Count + Commun.DELEMITEUR_FIN_DONNEE;       // NBR:Pieces.Count;

            // Exemple de resultat : ACTION:MODEJEU;NOMMODE:Original BattleShip;X:10;Y:10;NBR:5;

            return retour;
        }

        /// <summary>
        /// Fonction qui construis une trame contenant les descriptions des pieces 
        /// </summary>
        /// <param name="p">DescriptionPiece qui contient tout les information concernant les pieces </param>
        /// <returns>Une trame qui contient le nom de la piece, le nom de sont fichier image et le nombre de case sur la piece</returns>
        public static String genererActionEnvoiPieces(DescriptionPiece p)
        {
            String retour = "";

            retour += Commun.TRAME_ACTION + Commun.DELEMITEUR_DEBUT_DATA + Commun.ACTION_PLACER_PIECES + Commun.DELEMITEUR_FIN_DONNEE;  // ACTION:PIECES;
            retour += Commun.DATA_NOM_PIECE + Commun.DELEMITEUR_DEBUT_DATA + p.Nom + Commun.DELEMITEUR_FIN_DONNEE;                      // NOMPIECE:Nom;
            retour += Commun.DATA_PATH + Commun.DELEMITEUR_DEBUT_DATA + p.PathVisuels + Commun.DELEMITEUR_FIN_DONNEE;                   // PATH:PathVisuels;   
            retour += Commun.DATA_NBRE + Commun.DELEMITEUR_DEBUT_DATA + p.CasesDeJeu.Count + Commun.DELEMITEUR_FIN_DONNEE;              // NBR:CasesDeJeu.Count;

            // Exemple de resultat : ACTION:PIECES;NOMPIECE:Patrol Boat;PATH:PatrolBoat.png;NBR:2;

            return retour;
        }

        /// <summary>
        /// Fonction qui construis une trame qui contient la position des pieces 
        /// </summary>
        /// <param name="nomPiece">Le nom de la pieces </param>
        /// <param name="caseDeJeu">les cases de la pieces determiner</param>
        /// <returns>Trame contenatle nom de la piece en question, sa position et X et en Y </returns>
        public static String genererActionEnvoiCases(String nomPiece, CaseDeJeux caseDeJeu)
        {
            String retour = "";

            retour += Commun.TRAME_ACTION + Commun.DELEMITEUR_DEBUT_DATA + Commun.ACTION_CASE_DE_JEU + Commun.DELEMITEUR_FIN_DONNEE;
            retour += Commun.DATA_NOM_PIECE + Commun.DELEMITEUR_DEBUT_DATA + nomPiece + Commun.DELEMITEUR_FIN_DONNEE;
            retour += Commun.DATA_POINT_X + Commun.DELEMITEUR_DEBUT_DATA + caseDeJeu.OffsetX + Commun.DELEMITEUR_FIN_DONNEE;
            retour += Commun.DATA_POINT_Y + Commun.DELEMITEUR_DEBUT_DATA + caseDeJeu.OffsetY + Commun.DELEMITEUR_FIN_DONNEE;

            // Exemple de resultat : ACTION:CASEDEJEU;NOMPIECE:Patrol Boat;X:4;Y:2;

            return retour;
        }

        /// <summary>
        /// Fonction qui construis une trame de mise a jour des grilles de jeu 
        /// </summary>
        /// <param name="nomJoueur">Le joueur qui à effectué le dernier tir</param>
        /// <param name="x">La position en x du dernier tir</param>
        /// <param name="y">La position en y du dernier tir</param>
        /// <param name="touche">Le tir a oui ou non toucher un bateau (True un bateau est touché, False tir dans l'eau)</param>
        /// <param name="coule">Le tir a oui ou non coulé un bateau(True un bateau est coulé, False aucun bateau coulé)</param>
        /// <returns>Une trame comportant les information necessaire a la mise a jour des grille de jeu : le tireur, la position du tir, et ses consequences sur le jeu</returns>
        public static String genererActionMiseAJour(String nomJoueur, int x, int y, bool touche, bool coule)
        {
            String retour = "";

            retour += Commun.TRAME_ACTION + Commun.DELEMITEUR_DEBUT_DATA + Commun.ACTION_MISE_A_JOUR + Commun.DELEMITEUR_FIN_DONNEE;            // ACTION:MAJ;
            retour += Commun.TRAME_JOUEUR + Commun.DELEMITEUR_DEBUT_DATA + nomJoueur + Commun.DELEMITEUR_FIN_DONNEE;                            // JOUEUR:nomJoueur;
            retour += Commun.DATA_POINT_X + Commun.DELEMITEUR_DEBUT_DATA + Convert.ToString(x) + Commun.DELEMITEUR_FIN_DONNEE;                  // X:x;
            retour += Commun.DATA_POINT_Y + Commun.DELEMITEUR_DEBUT_DATA + Convert.ToString(y) + Commun.DELEMITEUR_FIN_DONNEE;                  // Y:y;
            retour += Commun.ACTION_BATEAU_TOUCHE + Commun.DELEMITEUR_DEBUT_DATA + Convert.ToString(touche) + Commun.DELEMITEUR_FIN_DONNEE;     // TOUCHE:touche;
            retour += Commun.ACTION_BATEAU_COULE + Commun.DELEMITEUR_DEBUT_DATA + Convert.ToString(coule) + Commun.DELEMITEUR_FIN_DONNEE;       // COULE:coule;

            // Exemple de resultat : ACTION:MAJ;JOUEUR:JOHN;X:4;Y:2;TOUCHE:True;COULE:False;

            return retour;
        } 

        /// <summary>
        /// Fonction qui construis une trame qui cofimre la connexion d'un joueur
        /// </summary>
        /// <param name="nomJoueur">Le nom que le jouer a choisi lors de sa connexion</param>
        /// <returns>une trame contenat le nom que le joueur a choisi</returns>
        public static String genererActionConnection(String nomJoueur)
        {
            String retour = "";

            retour += Commun.TRAME_ACTION + Commun.DELEMITEUR_DEBUT_DATA + Commun.ACTION_CONNECTION + Commun.DELEMITEUR_FIN_DONNEE; //ACTION:CONNECT;
            retour += Commun.TRAME_JOUEUR + Commun.DELEMITEUR_DEBUT_DATA + nomJoueur + Commun.DELEMITEUR_FIN_DONNEE;                //JOUEUR:nomJoueur;

            // Exemple de resultat : ACTION:CONNECT;JOUEUR:JOHN;

            return retour;
        }

        /// <summary>
        /// Fonction qui construis une trame qui cofimre la deconnexion d'un joueur
        /// </summary>
        /// <param name="nomJoueur">Le nom que le jouer a choisi lors de sa deconnexion</param>
        /// <returns>une trame contenat le nom que le joueur a choisi</returns>
        public static String genererActionDeconnection(String nomJoueur)
        {
            String retour = "";

            retour += Commun.TRAME_ACTION + Commun.DELEMITEUR_DEBUT_DATA + Commun.ACTION_FERMETURE + Commun.DELEMITEUR_FIN_DONNEE; //ACTION:DISCONNECT;
            retour += Commun.TRAME_JOUEUR + Commun.DELEMITEUR_DEBUT_DATA + nomJoueur + Commun.DELEMITEUR_FIN_DONNEE;               //JOUEUR:nomJoueur;

            // Exemple de resultat : ACTION:DISCONNECT;JOUEUR:JOHN;

            return retour;
        }

        /// <summary>
        /// Fonction qui construis une trame correspondant les informations le tir 
        /// </summary>
        /// <param name="nomJoueur">Le nom que le jouer a choisi lors de sa deconnexion</param>
        /// <param name="x">la position du tir en x</param>
        /// <param name="y">la position du tir en y</param>
        /// <returns>Un mode de jeu sans descriptions de pieces</returns>
        public static String genererActionTir(String nomJoueur, int x, int y)
        {
            String retour = "";

            retour += Commun.TRAME_ACTION + Commun.DELEMITEUR_DEBUT_DATA + Commun.ACTION_TIR + Commun.DELEMITEUR_FIN_DONNEE;        // ACTION:TIR;
            retour += Commun.TRAME_JOUEUR + Commun.DELEMITEUR_DEBUT_DATA + nomJoueur + Commun.DELEMITEUR_FIN_DONNEE;                // JOUEUR:nomJoueur;
            retour += Commun.DATA_POINT_X + Commun.DELEMITEUR_DEBUT_DATA + Convert.ToString(x) + Commun.DELEMITEUR_FIN_DONNEE;      // X:x;
            retour += Commun.DATA_POINT_Y + Commun.DELEMITEUR_DEBUT_DATA + Convert.ToString(y) + Commun.DELEMITEUR_FIN_DONNEE;      // Y:y;

            // Exemple de resultat : ACTION:TIR;JOUEUR:JOHN;X:3;Y:6;

            return retour;
        }

        /// <summary>
        /// Fonction qui construis une trame pour confirme la fin de la partie 
        /// </summary>
        /// <param name="nomJoueur">Nom du joueur gagnant</param>
        /// <returns>une trame contenant le nom du jouer gagnant</returns>
        public static String genererActionFin(String nomJoueur)
        {
            String retour = "";

            retour += Commun.TRAME_ACTION + Commun.DELEMITEUR_DEBUT_DATA + Commun.ACTION_FIN_DE_PARTIE + Commun.DELEMITEUR_FIN_DONNEE;  // ACTION:FIN;
            retour += Commun.TRAME_JOUEUR + Commun.DELEMITEUR_DEBUT_DATA + nomJoueur + Commun.DELEMITEUR_FIN_DONNEE;                    // JOUEUR:nomJoueur; 

            // Exemple de resultat : ACTION:FIN;JOUEUR:JOHN;

            return retour;
        }

        /// <summary>
        /// Fonction qui obtient le nom du joueur 1 au travers d'une trame donné 
        /// </summary>
        /// <param name="trame">La trame recue qui contient entre autre le nom du joueur 2</param>
        /// <returns>le nom du joueur 1</returns>
        public static String obtenirJoueur(String trame)
        {
            String nomJoueur = "";

            string[] splitTrameAction;
            string[] splitJoueur;
            splitTrameAction = trame.Split(';').ToArray();
            splitJoueur = splitTrameAction[1].Split(':').ToArray();
            nomJoueur = splitJoueur[1];

            return nomJoueur;
        }

        /// <summary>
        /// Fonction qui obtient le nom du joueur2 au travers d'une trame donné 
        /// </summary>
        /// <param name="trame">La trame recue qui contient entre autre le nom du joueur 2</param>
        /// <returns>le nom du joueur 2</returns>
        public static String obtenirJoueur2(String trame)
        {
            String nomJoueur2 = "";

            string[] splitTrameAction;
            string[] splitJoueur2;
            splitTrameAction = trame.Split(';').ToArray();
            splitJoueur2 = splitTrameAction[2].Split(':').ToArray();
            nomJoueur2 = splitJoueur2[1];

            return nomJoueur2;
        }

        /// <summary>
        /// Fonction qui obtient le nom du fichier visuel au travers d'une trame donné 
        /// </summary>
        /// <param name="trame">La trame recue qui contient entre autre le nom du fichier visuel</param>
        /// <returns>le nom du fichier visuel </returns>
        public static String obtenirPathVisuel(String trame)
        {
            String path = "";

            string[] splitTrameAction;
            string[] splitpath;
            splitTrameAction = trame.Split(';').ToArray();
            splitpath = splitTrameAction[2].Split(':').ToArray();
            path = splitpath[1];

            return path;
        }

        /// <summary>
        /// Fonction qui obtient le mode de jeu au travers d'une trame donné 
        /// </summary>
        /// <param name="trame">La trame recue qui contient entre autre le mode de jeu</param>
        /// <returns>le mode de jeu</returns>
        public static ModeDeJeu obtenirModeJeu(String trame, ref int nbreBateaux)
        {
            String nomDuMode = "";
            int tailleX = 0 , tailleY  = 0;

            String[] split = trame.Split(Commun.DELEMITEUR_FIN_DONNEE);
            foreach (String s in split)
                if(s.Length > 0)
                {
                    String head = getActionFromTrame(s);                    
                    switch(head)
                    {
                        case Commun.DATA_NOM_MODE:
                            nomDuMode = getDataFromTrame(s);
                            break;
                        case Commun.DATA_POINT_X:
                            tailleX = Convert.ToInt32(getDataFromTrame(s));
                            break;
                        case Commun.DATA_POINT_Y:
                            tailleY = Convert.ToInt32(getDataFromTrame(s));
                            break;
                        case Commun.DATA_NBRE:
                            nbreBateaux = Convert.ToInt32(getDataFromTrame(s));
                            break;

                    }
                }
            return new ModeDeJeu(tailleX, tailleY, new List<DescriptionPiece>(), nomDuMode);
        }

        /// <summary>
        /// Fonction qui obtient la description d'un piece au travers d'une trame donné 
        /// </summary>
        /// <param name="trame">La trame recue qui contient entre autre la description d'un piece</param>
        /// <returns>La description d'un piece</returns>
        public static DescriptionPiece obtenirDescriptionDePiece(String trame, ref int nbreCases)
        {
            String path = "", nom = "";
            String[] split = trame.Split(Commun.DELEMITEUR_FIN_DONNEE);

            foreach (String s in split)
                if(s.Length > 0)
                {
                    String head = getActionFromTrame(s);                    
                    switch(head)
                    {
                        case Commun.DATA_PATH:
                            path = getDataFromTrame(s);
                            break;
                        case Commun.DATA_NOM_PIECE:
                            nom = getDataFromTrame(s);
                            break;
                        case Commun.DATA_NBRE:
                            nbreCases = Convert.ToInt32(getDataFromTrame(s));
                            break;

                    }
                }
            return new DescriptionPiece(new List<CaseDeJeux>(), path, nom);
        }

        /// <summary>
        /// Fonction qui obtient les cases X et Y au travers d'une trame donné 
        /// </summary>
        /// <param name="trame">La trame recue qui contient entre autre les cases X et Y</param>
        /// <returns>Les cases X et Y</returns>
        public static CaseDeJeux obtenirCaseDeJeu(String trame)
        {
            int x = 0, y = 0;
            String[] split = trame.Split(Commun.DELEMITEUR_FIN_DONNEE);

            foreach (String s in split)
                if (s.Length > 0)
                {
                    String head = getActionFromTrame(s);
                    switch (head)
                    {
                        case Commun.DATA_POINT_X:
                            x = Convert.ToInt32(getDataFromTrame(s));
                            break;
                        case Commun.DATA_POINT_Y:
                            y = Convert.ToInt32(getDataFromTrame(s));
                            break;

                    }
                }
            return new CaseDeJeux(x, y);
        }

        /// <summary>
        /// Fonction qui obtient le nombre de bateau au travers d'une trame donné 
        /// </summary>
        /// <param name="trame">La trame recue qui contient entre autre lle nombre de bateau</param>
        /// <returns>Le nombre de bateau</returns>
        public static int obtenirNbBateau(String trame)
        {
            int nbBateau;

            string[] splitTrameAction;
            string[] splitNbBateau;
            splitTrameAction = trame.Split(';').ToArray();
            splitNbBateau = splitTrameAction[3].Split(':').ToArray();
            nbBateau = Convert.ToInt16(splitNbBateau[1]);

            return nbBateau;
        }

        /// <summary>
        /// Fonction qui obtient la position en X au travers d'une trame donné 
        /// </summary>
        /// <param name="trame">La trame recue qui contient entre autre la position en X</param>
        /// <returns>la position en X</returns>
        public static int obtenirX(String trame)
        {
            int X;

            string[] splitTrameAction;
            string[] splitX;
            splitTrameAction = trame.Split(';').ToArray();
            splitX = splitTrameAction[2].Split(':').ToArray();
            X = Convert.ToInt16(splitX[1]);

            return X;
        }

        /// <summary>
        /// Fonction qui obtient la position en Y au travers d'une trame donné 
        /// </summary>
        /// <param name="trame">La trame recue qui contient entre autre la position en Y</param>
        /// <returns>La position en Y</returns>
        public static int obtenirY(String trame)
        {
            int Y;

            string[] splitTrameAction;
            string[] splitY;
            splitTrameAction = trame.Split(';').ToArray();
            splitY = splitTrameAction[3].Split(':').ToArray();
            Y = Convert.ToInt16(splitY[1]);

            return Y;
        }

        /// <summary>
        /// Fonction qui obtient la valeur de touche(true ou false) au travers d'une trame donné 
        /// </summary>
        /// <param name="trame">La trame recue qui contient entre autre la valeur de touche(true ou false)</param>
        /// <returns>La valeur de touche(true ou false)</returns>
        public static bool obtenirTouche(String trame)
        {
            bool touche;

            string[] splitTrameAction;
            string[] splitTouche;
            splitTrameAction = trame.Split(';').ToArray();
            splitTouche = splitTrameAction[4].Split(':').ToArray();
            touche = Convert.ToBoolean(splitTouche[1]);

            return touche;
        }

        /// <summary>
        /// Fonction qui obtient la valeur de coule(true ou false) au travers d'une trame donné 
        /// </summary>
        /// <param name="trame">La trame recue qui contient entre autre la valeur de coule(true ou false)</param>
        /// <returns>La valeur de coule(true ou false)</returns>
        public static bool obtenirCoule(String trame)
        {
            bool coule;

            string[] splitTrameAction;
            string[] splitCoule;
            splitTrameAction = trame.Split(';').ToArray();
            splitCoule = splitTrameAction[4].Split(':').ToArray();
            coule = Convert.ToBoolean(splitCoule[1]);

            return coule;
        }

        /// <summary>
        /// Fonction qui obtient le nom de la pieces au travers d'une trame donné 
        /// </summary>
        /// <param name="trame">La trame recue qui contient entre autre le nom de la pieces</param>
        /// <returns>Le nom de la pieces</returns>
        public static string obtenirNomPiece(String trame)
        {
            string nomPiece;

            string[] splitTrameAction;
            string[] splitNomPiece;
            splitTrameAction = trame.Split(';').ToArray();
            splitNomPiece = splitTrameAction[2].Split(':').ToArray();
            nomPiece = splitNomPiece[1];

            return nomPiece;
        }

        /// <summary>
        /// Fonction qui obtient l'offset en X au travers d'une trame donné 
        /// </summary>
        /// <param name="trame">La trame recue qui contient entre autre l'offset en X</param>
        /// <returns>l'offset en X</returns>
        public static int obtenirOffX(String trame)
        {
            int offX;

            string[] splitTrameAction;
            string[] splitX;
            splitTrameAction = trame.Split(';').ToArray();
            splitX = splitTrameAction[3].Split(':').ToArray();
            offX = Convert.ToInt16(splitX[1]);

            return offX;
        }

        /// <summary>
        /// Fonction qui obtient l'offset en Y au travers d'une trame donné 
        /// </summary>
        /// <param name="trame">La trame recue qui contient entre autre l'offset en Y</param>
        /// <returns>l'offset en Y</returns>
        public static int obtenirOffY(String trame)
        {
            int offY;

            string[] splitTrameAction;
            string[] splitY;
            splitTrameAction = trame.Split(';').ToArray();
            splitY = splitTrameAction[4].Split(':').ToArray();
            offY = Convert.ToInt16(splitY[1]);

            return offY;
        }

        /// <summary>
        /// Fonction qui obtient la rotation de la piece au travers d'une trame donné 
        /// </summary>
        /// <param name="trame">La trame recue qui contient entre autre la rotation de la piece</param>
        /// <returns>La rotation de la piece</returns>
        public static string obtenirRotation(String trame)
        {
            string rotation;

            string[] splitTrameAction;
            string[] splitRotation;
            splitTrameAction = trame.Split(';').ToArray();
            splitRotation = splitTrameAction[3].Split(':').ToArray();
            rotation = splitRotation[1];

            return rotation;
        }

        /// <summary>
        /// Obtiens l'action dans le début de la trame recue, permet de faire la distinction entre le trames
        /// </summary>
        /// <param name="trame">La trame recues</param>
        /// <returns>La valeur qui détermine l'action</returns>
        public static string obtenirAction(String trame)
        {
            return trame.Substring(trame.IndexOf(Commun.DELEMITEUR_DEBUT_DATA) + 1, (trame.IndexOf(Commun.DELEMITEUR_FIN_DONNEE) - trame.IndexOf(Commun.DELEMITEUR_DEBUT_DATA) - 1));
        }

        /// <summary>
        /// Obtiens l'action dans le début de la trame recue, permet de faire la distinction entre le trames
        /// </summary>
        /// <param name="trame">La trame recues</param>
        /// <returns>La valeur qui détermine l'action</returns>
        private static String getActionFromTrame(String partieDeTrame)
        {
            return partieDeTrame.Substring(0, partieDeTrame.IndexOf(Commun.DELEMITEUR_DEBUT_DATA));
        }

        /// <summary>
        /// Permet de prendre une trame sous le format TYPEDATA:DATA et d'en sortir DATA
        /// </summary>
        /// <param name="partieDeTrame">la partie de trame a analyser</param>
        /// <returns>le data dans la trame</returns>
        private static String getDataFromTrame(String partieDeTrame)
        {
            return partieDeTrame.Substring(partieDeTrame.IndexOf(Commun.DELEMITEUR_DEBUT_DATA) + 1);
        }
    }
}