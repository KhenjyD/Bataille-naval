using System;
using System.Collections.Generic;
using System.Text;

namespace battleship
{
    class Ship
    {
        public int size, direction, id;
         /* Navire avec sa taille et sa direction */
        public Ship (int size, int direction, int id)
        {
            this.size = size;
            this.direction = direction;
            this.id = id;
        }
    }
}
