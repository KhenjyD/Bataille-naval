using System;
using System.Collections.Generic;
using System.Text;

namespace battleship
{
    class Program
    {

        static void Main(string[] args)
        {
            Map playerOneMap = new Map(new int[10, 10]);
            Map playerTwoMap = new Map(new int[10, 10]);
            playerOneMap.InitMap();
            playerTwoMap.InitMap();
            Player playerOne = new Player(1, new List<Ship>(), playerOneMap, playerTwoMap);
            Player playerTwo = new Player(1, new List<Ship>(), playerTwoMap, playerOneMap);
            playerOne.InitPlayerShipOnMap();
            playerTwo.InitPlayerShipOnMap();

            while (true)
            {
                playerOne.DisplayEnemyMap();
                playerOne.DisplayPlayerMap();
                playerOne.AttackEnemyShip();
            }
        }
    }
}
