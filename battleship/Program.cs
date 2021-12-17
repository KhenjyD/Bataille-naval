using System;

namespace battleship
{
    class Program
    {

        static void Main(string[] args)
        {
            Map map = new Map(new int[10, 10]);
            Ship[] allShip = new Ship[4];
            map.InitMap();
            map.DisplayMap();

            Console.WriteLine("Placer vos 4 navires sur les cases disponibles de taille 2, 3, 4 et 6 de long:");
            Console.WriteLine("Choisir Ligne:");
            Console.WriteLine("Choisir Colonne:");
            Console.WriteLine("Choisir Direction (Vertical = 0, Horizontal = 1):");
        }
    }
}
