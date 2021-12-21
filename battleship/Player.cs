using System;
using System.Collections.Generic;
using System.Text;

namespace battleship
{
    class Player
    {
        public int id;
        public List<Ship> playerShip;
        public int shipSank;
        public Map playerMap;
        public Map enemyMap;

        public Player(int id, List<Ship> playerShip, int shipSank, Map playerMap, Map enemyMap)
        {
            this.id = id;
            this.playerShip = playerShip;
            this.shipSank = shipSank;
            this.playerMap = playerMap;
            this.enemyMap = enemyMap;
        }

        /* Vérifiez si les coordonnées d'attaque sont correct et si une case a déjà été attaquer */
        public bool VerifyCoordAttack(int coordX, int coordY)
        {
            bool available;

            if(enemyMap.map[coordX, coordY].state == 0 || enemyMap.map[coordX, coordY].state == 1)
            {
                available = true;
            }
            else
            {
                available = false;
            }

            return available;
        }

        /* Attaquer les navires du  joueur adverse */
        public void AttackEnemyShip(Player enemy)
        {
            int coordX, coordY;
            byte[] ascii;

            while(true)
            {
                try
                {
                    Console.WriteLine("Entrez coordonnées pour attaqué un navire.");
                    Console.WriteLine("Entrez coordonné ligne:");
                    coordX = int.Parse(Console.ReadLine());
                    coordX--;

                    Console.WriteLine("Entrez coordonné colonne:");
                    ascii = Encoding.ASCII.GetBytes(Console.ReadLine().ToLower());
                    coordY = ascii[0] - 97;

                    if (!VerifyCoordAttack(coordX, coordY))
                    {
                        Console.WriteLine("Cette case est hors de la carte ou a déjà été attaquer.");
                    }
                    else
                    {
                        break;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Coordonnées erronées. Recommencer.");
                }
            }

            if (enemyMap.map[coordX, coordY].state == 1)
            {
                enemyMap.map[coordX, coordY].state = -1;
                Console.WriteLine("Touché !");
                foreach(Ship ship in playerShip)
                {
                    if(ship.id == enemyMap.map[coordX, coordY].id)
                    {
                        ship.size--;
                        if(ship.size == 0)
                        {
                            Console.WriteLine("Coulé !");
                            enemy.shipSank++;
                        }
                    }
                }
            }
            else
            {
                enemyMap.map[coordX, coordY].state = 2;
                Console.WriteLine("Raté !");
            }
        }

        /* Afficher la carte du joueur */
        public void DisplayPlayerMap()
        {
            Console.WriteLine("    A  B  C  D  E  F  G  H  I  J");
            for (int row = 0; row < 10; row++)
            {
                if (row == 9)
                {
                    Console.Write((row + 1) + " ");
                }
                else
                {
                    Console.Write(" " + (row + 1) + " ");
                }

                for (int colomn = 0; colomn < 10; colomn++)
                {
                    if (playerMap.map[row, colomn].state == 0)
                    {
                        Console.Write("[ ]");
                    }
                    else if (playerMap.map[row, colomn].state == 1)
                    {
                        Console.Write("[#]");
                    }
                    else if (playerMap.map[row, colomn].state == -1)
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

        /* Afficher la carte du joueur adverse */
        public void DisplayEnemyMap()
        {
            Console.WriteLine("    A  B  C  D  E  F  G  H  I  J");
            for (int row = 0; row < 10; row++)
            {
                if (row == 9)
                {
                    Console.Write((row + 1) + " ");
                }
                else
                {
                    Console.Write(" " + (row + 1) + " ");
                }

                for (int colomn = 0; colomn < 10; colomn++)
                {
                    if (enemyMap.map[row, colomn].state == 0 || enemyMap.map[row, colomn].state == 1)
                    {
                        Console.Write("[ ]");
                    }
                    else if (enemyMap.map[row, colomn].state == -1)
                    {
                        Console.Write("[x]");
                    }
                    else if(enemyMap.map[row, colomn].state == 2)
                    {
                        Console.Write("[~]");
                    }
                }
                Console.Write("\n");
            }
        }

        /* Créer et place les navires du joueur sur sa carte*/ //à corriger
        public void InitPlayerShipOnMap()
        {
            List<int> shipSize = new List<int> { 2 }; //{ 2, 3, 4, 6 }
            int coordX, coordY, direction, size;
            byte[] ascii;

            DisplayPlayerMap();
            Console.WriteLine("Placer vos 4 navires sur les cases disponibles de taille 2, 3, 4 et 6 de long:");
            for (int nShip = 0; nShip < 1; nShip++) //nship = 4
            {
                while (true)
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
                        coordX--;

                        Console.WriteLine("Choisir Colonne:");
                        ascii = Encoding.ASCII.GetBytes(Console.ReadLine().ToLower());
                        coordY = ascii[0] - 97;

                        Console.WriteLine("Choisir Direction (Vertical = 0, Horizontal = 1):");
                        direction = int.Parse(Console.ReadLine());

                        if (!playerMap.VerifyCoordOnMap(coordX, coordY, direction, size))
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
                        Console.WriteLine("Coordonnées erronées. Recommencer.");
                    }
                }


                Ship newShip = new Ship(size, direction, nShip);
                playerMap.PutShipOnMap(newShip, coordX, coordY);

                playerShip.Add(newShip);
                DisplayPlayerMap();
            }
        }

        /* Vérifie si le joueur a gagné après chaque coup*/
        public void WinEval(Player enemy, int turn)
        {
            if (enemy.shipSank == enemy.playerShip.Count)
            {
                Console.WriteLine("Le Joueur " + id + " a gagné en " + turn + " !");
                Environment.Exit(0);
            }
        }
    }
}
