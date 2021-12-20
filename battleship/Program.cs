using System;
using System.Collections.Generic;

namespace battleship
{
    class Program
    {

        static void Main(string[] args)
        {
            Map map = new Map(new int[10, 10]);
            List<Ship> allShip = new List<Ship>();
            List<int> shipSize = new List<int> { 2, 3, 4, 6 };
            int coordX, coordY, direction, size;
            map.InitMap();
            map.DisplayMap();

            Console.WriteLine("Placer vos 4 navires sur les cases disponibles de taille 2, 3, 4 et 6 de long:");
            for (int nShip = 0; nShip < 4; nShip++)
            {
                while(true)
                {
                    Console.WriteLine("Choisir navire par sa taille:");
                    try
                    {
                        size = int.Parse(Console.ReadLine());

                        if (!shipSize.Contains(size))
                        {
                            Console.WriteLine("Navire déjà placé ou inexistant.");
                        }
                        else
                        {
                            shipSize.Remove(size);
                            break;
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Navire déjà placé ou inexistant.");
                    }
                    
                }

                while (true)
                {
                    try
                    {
                        Console.WriteLine("Choisir Ligne:");
                        coordX = int.Parse(Console.ReadLine());

                        Console.WriteLine("Choisir Colonne:");
                        coordY = int.Parse(Console.ReadLine());

                        Console.WriteLine("Choisir Direction (Vertical = 0, Horizontal = 1):");
                        direction = int.Parse(Console.ReadLine());

                        if (!map.VerifyCoordOnMap(coordX, coordY, direction, size))
                        {
                            Console.WriteLine("Le navire ne peut pas être placé à ces coordonnées.");
                        }
                        else
                        {
                            break;
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Coordonnées erronées.");
                    }
                }
                

                Ship newShip = new Ship(size, direction);
                map.PutShipOnMap(newShip, coordX, coordY);

                allShip.Add(newShip);
                map.DisplayMap();
            }
        }
    }
}
