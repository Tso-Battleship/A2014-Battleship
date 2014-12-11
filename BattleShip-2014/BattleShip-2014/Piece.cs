/**
 * @file   Piece.cs
 * @author Anthony Collard
 * @date   Décembre 2014
 * @brief  Contient les différentes variables, fonctions et getters setters pour créer et manipuler les pièces.
 * @version 1.1 : Version Fonctionnelle
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip_2014
{
    public class Piece : DescriptionPiece
    {

        private int positionX_, positionY_; //Variable membre de la Position de la pièce
        private Rotation rotation_;         //Variable de type rotation qui contient le sens du bateau(pièce)

        /*Les 5 constructeurs avec différents paramètres*/

        /*Constructeur par défault. Ne devrait pas être utilisé.*/
        public Piece()
        {

        }

        /*Création d'une pièce standalone sans description de pièce avec ou sans rotation*/
        public Piece(List<CaseDeJeux> Dcases,string name, string path, Rotation rotation)
        {
            cases_ = Dcases;
            nom_ = name;
            path_visuel_ = path;
            rotation_ = rotation;
        }

        public Piece(List<CaseDeJeux> Dcases, string name, string path)
        {
            cases_ = Dcases;
            nom_ = name;
            path_visuel_ = path;
            rotation_ = Rotation.Haut;
        }
        
        /*Création d'une pièce d'un type DescriptionPièce existant avec ou sans rotation*/
        public Piece(DescriptionPiece DPiece, int x, int y, Rotation rotation)
        {
            nom_ = DPiece.Nom;
            path_visuel_ = DPiece.PathVisuels;
            cases_ = DPiece.CasesDeJeu;
            positionX_ = x;
            positionY_ = y;
            rotation_ = rotation;
        }

        public Piece(DescriptionPiece DPiece, int x, int y)
        {
            nom_ = DPiece.Nom;
            path_visuel_ = DPiece.PathVisuels;
            cases_ = DPiece.CasesDeJeu;
            positionX_ = x;
            positionY_ = y;
            rotation_ = Rotation.Haut;
        }
    
/////////////////////////////////////////////////////////////////////////////////////////////

        /*Déclaration des getters et setters pour accéder aux variables de la classe.*/
        public int PositionX
        {
            get
            {
                return this.positionX_;
            }
            set
            {
                this.positionX_ = value;
            }

        }
        public int PositionY
        {
            get
            {
                return this.positionY_;
            }
            set
            {
                this.positionY_ = value;
            }

        }
        public Rotation RotationPiece
        {
            get
            {
                return this.rotation_;
            }
            /*set
            {
                this.rotation_ = value;
            }*/
        }

        ///////////////////////////////////////////////////////////////////////////////////////////// 

        /*
        * @Brief Fonction qui change le sens de rotation de la pièce
        * @Param none
        * @return N/A
        */
        public void tournerPiece()
        {
            List<CaseDeJeux> nouvellesCases = new List<CaseDeJeux>();
            foreach (CaseDeJeux casedejeu in cases_)
            {
                nouvellesCases.Add(new CaseDeJeux(casedejeu.OffsetY, casedejeu.OffsetX));
            }
            cases_ = nouvellesCases;

            if (rotation_ == Rotation.Droite)
            {
                rotation_ = Rotation.Haut;
            }
            else
                rotation_ = Rotation.Droite;
        }

        /*
        * @Brief Sert à vérifier si la piece existe dans la case visée
        * @Param int posx, int posy
        * @return bool
        */
        public bool caseExiste(int posx, int posy)
        {
            foreach (CaseDeJeux c in cases_)
            {
                if (positionX_ + c.OffsetX == posx && positionY_ + c.OffsetY == posy)                  
                    return true;
            }
            return false;
        }

        /*
        * @Brief Sert à vérifier si la piece à été touchée
        * @Param int posx, int posy
        * @return bool
        */
        public bool caseEstTouch(int posx, int posy)
        {
            foreach(CaseDeJeux c in cases_)
            {
                 if(positionX_ + c.OffsetX == posx && positionY_ + c.OffsetY == posy)
                 {
                     if (c.EstTouchee)
                         return true;
                 }                 
            }
            return false;
        }

        /*
        * @Brief Fonction qui applique le tir sur la piece
        * @Param int posx, int posy
        * @return none
        */
        public void tirerCase(int posx, int posy)
        {
            foreach (CaseDeJeux c in cases_)
            {                
                if (positionX_ + c.OffsetX == posx && positionY_ + c.OffsetY == posy)
                {
                    c.tirer();
                }
            }
        }

        /*
        * @Brief Vérifie si toutes les cases ont été touchées
        * @Param none
        * @return bool
        */
        public bool toutesCasesToucher()
        {
            foreach (CaseDeJeux c in cases_)
            {
                if (!c.EstTouchee)
                    return false;
            }
            return true;
        }
    }
}
