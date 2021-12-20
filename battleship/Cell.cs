using System;
using System.Collections.Generic;
using System.Text;

namespace battleship
{
    class Cell
    {
        public int id, state;

        public Cell (int id, int state)
        {
            this.id = id;
            this.state = state;
        }
    }
}
