using System;

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
