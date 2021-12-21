using System;
using System.Collections.Generic;
using System.Text;

namespace battleship
{
    class Cell
    {
        public int id, state;

        /* Cellule de la carte avec sont état */
        public Cell (int id, int state)
        {
            this.id = id;
            this.state = state;
        }
    }
}
