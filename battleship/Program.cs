using System;
using System.Collections.Generic;


namespace battleship
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Initialisation des cartes et des joueurs */
            int turn = 0;
            Map playerOneMap = new Map(new Cell[10, 10]);
            Map playerTwoMap = new Map(new Cell[10, 10]);
            playerOneMap.InitMap();
            playerTwoMap.InitMap();
            Player playerOne = new Player(1, new List<Ship>(), 0, playerOneMap, playerTwoMap);
            Player playerTwo = new Player(2, new List<Ship>(), 0, playerTwoMap, playerOneMap);
            playerOne.InitPlayerShipOnMap();
            playerTwo.InitPlayerShipOnMap();

            /* Déroulement du jeu */
            while (true)
            {
                turn++;
                if(turn % 2 == 1)
                {
                    playerOne.DisplayEnemyMap();
                    playerOne.DisplayPlayerMap();
                    playerOne.AttackEnemyShip(playerTwo);
                    playerOne.WinEval(playerTwo, turn);
                }
                else
                {
                    playerTwo.DisplayEnemyMap();
                    playerTwo.DisplayPlayerMap();
                    playerTwo.AttackEnemyShip(playerOne);
                    playerTwo.WinEval(playerOne, turn);
                }
            }
        }
    }
}
