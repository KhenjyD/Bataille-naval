using System;

namespace battleship
{
    class Map
    {
        public Cell[,] map;

        public Map(Cell[,] map)
        {
            this.map = map;
        }

        /*Initialise la carte*/
        public void InitMap()
        {
            for (int row = 0; row < map.GetLength(0); row++)
            {
                for (int colomn = 0; colomn < map.GetLength(1); colomn++)
                {
                    map[row, colomn] = new Cell(0,0);
                }
            }
        }

        /* Affiche la carte avec ses valeurs */
        public void DisplayMap()
        {
            Console.WriteLine("    A  B  C  D  E  F  G  H  I  J");
            for (int row = 0; row < 10; row++)
            {
                if(row == 9)
                {
                    Console.Write((row + 1) + " "); 
                }
                else
                {
                    Console.Write(" " + (row + 1) + " ");
                }
                
                for (int colomn = 0; colomn < 10; colomn++)
                {
                    if(map[row, colomn].state == 0)
                    {
                        Console.Write("[ ]");
                    }
                    else if (map[row, colomn].state == 1)
                    {
                        Console.Write("[#]");
                    }
                    else if (map[row, colomn].state == -1)
                    {
                        Console.Write("[x]");
                    }
                    else
                    {
                        Console.Write("[~]");
                    }


                }
                Console.Write("\n");
            }
        }

        /* Placer un navire sur la carte */
        public void PutShipOnMap(Ship ship, int coordX, int coordY)
        {
            if(ship.direction == 0)
            {
                for(int size = 0; size < ship.size; size++, coordX++)
                {
                    map[coordX, coordY].id = ship.id;
                    map[coordX,coordY].state = 1;
                }
            }
            else
            {
                for (int size = 0; size < ship.size; size++, coordY++)
                {
                    map[coordX, coordY].id = ship.id;
                    map[coordX, coordY].state = 1;
                }
            }
        }

        /* Vérifier si une case est disponible */
        public bool VerifyCoordOnMap(int coordX, int coordY, int direction, int size)
        {
            bool available = true;

            for (int i = 0; i < size; i++)
            {
                if ( coordX < 0 || coordX > 9 || coordY < 0 || coordY > 9)
                {
                    available = false;
                    break;
                }
                else if(map[coordX, coordY].state != 0)
                {
                    available = false;
                    break;
                }

                if (direction == 0)
                {
                    coordX++;
                }
                else
                {
                    coordY++;
                }
            }

            return available;
        }
    }
}
