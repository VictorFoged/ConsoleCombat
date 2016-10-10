using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCombat
{
    class Program
    {
        public static Player player = new Player();
        public static Map Town = new Map();
        
        public static Map Town1 = new Map(new int[] { 1, 0 });
        public static Map currentMap = Town;
        public static string dialouge = "";
        static void Main(string[] args)
        {
            World.MapList.Add(Town);
            while(1 < 2)
            {
                currentMap.genMap(currentMap.map);
                currentMap.removePlayer();
                move(Console.ReadKey().KeyChar, currentMap);
                currentMap.placePlayer();
            }
            
        }


        static void move(char key, Map map) //Function for changing player coordinates and triggering events.
        {


            switch (key) //Switch statement for WASD and e + i.
                         //If non valid key is pressed, it loops again, making all monsters move.
            {
                case 'w':
                    //Check of space to the north is free, if free add one to player coordinate y (My Map is upside down, so it subtracts one)
                    if (map.map[player.playerY - 1][player.playerX] == " " || map.map[player.playerY - 1][player.playerX] == "|" || map.map[player.playerY - 1][player.playerX] == "_")
                    {
                        player.playerY = player.playerY - 1;

                    }

                    else if (map.map[player.playerY - 1][player.playerX] == "M") //Collision Check, if you walk into the monster
                    {
                        player.HP = player.HP - 1;
                    }
                    else if (map.map[player.playerY - 1][player.playerX] == "0") //Walk into tail
                    {
                        player.HP = player.HP - 2;
                    }


                    player.lastDir = 'w'; //Which way you character is currently facing, used for event handling in 'e'
                    break;
                //Repeat for asd.
                case 'a':
                    if (map.map[player.playerY][player.playerX - 1] == " " || map.map[player.playerY][player.playerX - 1] == "|" || map.map[player.playerY][player.playerX - 1] == "_")
                    {
                        player.playerX = player.playerX - 1;

                    }

                    else if (map.map[player.playerY][player.playerX - 1] == "M")
                    {
                        player.HP = player.HP - 1;
                    }
                    else if (map.map[player.playerY][player.playerX - 1] == "0")
                    {
                        player.HP = player.HP - 2;
                    }

                    player.lastDir = 'a';
                    break;
                case 's':
                    if (map.map[player.playerY + 1][player.playerX] == " " || map.map[player.playerY + 1][player.playerX] == "|" || map.map[player.playerY + 1][player.playerX] == "_")
                    {
                        player.playerY = player.playerY + 1;

                    }

                    else if (map.map[player.playerY + 1][player.playerX] == "M")
                    {
                        player.HP = player.HP - 1;
                    }
                    else if (map.map[player.playerY + 1][player.playerX] == "0")
                    {
                        player.HP = player.HP - 2;
                    }

                    player.lastDir = 's';
                    break;
                case 'd':
                    if (map.map[player.playerY][player.playerX + 1] == " " || map.map[player.playerY][player.playerX + 1] == "|" || map.map[player.playerY][player.playerX + 1] == "_")
                    {
                        player.playerX = player.playerX + 1;

                    }

                    else if (map.map[player.playerY][player.playerX + 1] == "M")
                    {
                        player.HP = player.HP - 1;
                    }
                    else if (map.map[player.playerY][player.playerX + 1] == "0")
                    {
                        player.HP = player.HP - 2;
                    }
                    player.lastDir = 'd';
                    break;
                case 'e':
                    switch (player.lastDir)
                    {

                        case 'w':

                            break;
                        case 'a':

                            break;
                        case 's':

                            break;
                        case 'd':

                            break;
                    }
                    break;


            }
        }
    }
}
