using System;
using System.Collections.Generic;
using System.Text;

namespace battleship
{
    class Map
    {
        public int[,] map;

        public Map(int[,] map)
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
                    map[row, colomn] = 0;
                }
            }
        }

        /* Affiche la carte avec ses valeurs */
        public void DisplayMap()
        {
            Console.WriteLine("   0  1  2  3  4  5  6  7  8  9");
            for (int row = 0; row < 10; row++)
            {
                Console.Write(row + " "); //TO DO: remplacer chiffre par des lettres
                for (int colomn = 0; colomn < 10; colomn++)
                {
                    Console.Write("[" + map[row, colomn] + "]");
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
                    map[coordX,coordY] = 1;
                }
            }
            else
            {
                for (int size = 0; size < ship.size; size++, coordY++)
                {
                    map[coordX, coordY] = 1;
                }
            }
        }

        /* Vérifier si une case est disponible */
        public bool VerifyCoordOnMap(int coordX, int coordY)
        {
            bool available;

            if(map[coordX,coordY] != 0)
            {
                available = false;
            }
            else
            {
                available = true;
            }

            return available;
        }
    }
}
