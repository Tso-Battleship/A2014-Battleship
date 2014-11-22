using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip_2014
{
    enum Rotation
    {
        Haut = 0,
        Droite = 90,
        Bas = 180,
        Gauche = 270
    }

    struct sPoint
    {
        private int x_;
        public int X
        {
            get
            {
                return x_;
            }
            set
            {
                if (value < 100 && value >= 0)
                    x_ = value;
            }
        }

        private int y_;
        public int Y
        {
            get
            {
                return y_;
            }
            set
            {
                if (value < 100 && value >= 0)
                    y_ = value;
            }
        }
    }

    public class Commun
    {
    }
}
