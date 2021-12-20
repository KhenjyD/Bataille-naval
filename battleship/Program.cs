using System;
using System.Collections.Generic;


namespace battleship
{
    class Program
    {
        static void Main(string[] args)
        {
            Map playerOneMap = new Map(new Cell[10, 10]);
            Map playerTwoMap = new Map(new Cell[10, 10]);
            playerOneMap.InitMap();
            playerTwoMap.InitMap();
            Player playerOne = new Player(1, new List<Ship>(), 0, playerOneMap, playerTwoMap);
            Player playerTwo = new Player(1, new List<Ship>(), 0, playerTwoMap, playerOneMap);
            playerOne.InitPlayerShipOnMap();
            playerTwo.InitPlayerShipOnMap();

            while (true)
            {
                playerOne.DisplayEnemyMap();
                playerOne.DisplayPlayerMap();
                playerOne.AttackEnemyShip(playerTwo);
                playerOne.WinEval(playerTwo);
            }
        }
    }
}
