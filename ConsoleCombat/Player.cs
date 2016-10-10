using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCombat
{
    class Player
    {
        public int HP = 10;
        public int playerX = 2; //Location in map
        public int playerY = 5;
        public char lastDir = 'd';
        public int[] playerCord = { 0, 0 }; //Decides which map
        public static List<Item> Inventory = new List<Item>();
    }
}
