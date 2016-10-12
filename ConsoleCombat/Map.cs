using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCombat
{
    class Map
    {
        
        
        int xlen = 0;
        int ylen = 0;
        public int[] mapcord = { 0, 0 };
        public string[][] map = { };
        public ConsoleColor Background = ConsoleColor.Black;
        public ConsoleColor Foreground = ConsoleColor.White;
       

        public string[] l1 = { "#", "#", "#", "#", "#", "#", "#", "_", "#", "#", "#", "#", "#", "#", "#" };
        public string[] l2 = { "#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#" };
        public string[] l3 = { "#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#" };
        public string[] l4 = { "#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#" };
        public string[] l5 = { "#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#" };
        public string[] l6 = { "|", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "|" };
        public string[] l7 = { "#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#" };
        public string[] l8 = { "#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#" };
        public string[] l9 = { "#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#" };
        public string[] l10 ={ "#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#" };
        public string[] l11 ={ "#", "#", "#", "#", "#", "#", "#", "_", "#", "#", "#", "#", "#", "#", "#" };

        public Map(int[] mapcord)
        {
            this.mapcord = mapcord;
        }
        public Map()
        {

        }
        public void createMap()
        {

            map = new string[][] { l1, l2, l3, l4, l5, l6, l7, l8, l9, l10, l11 };
        }


        public void genMap(string[][] map) //Printing Map to Console
        {
            createMap();
            Console.Clear();
            Console.BackgroundColor = Background;
            Console.ForegroundColor = Foreground;
            xlen = this.map[0].Length;
            ylen = this.map.Length;

            for (int y = 0; y < ylen; y++) //11
            {
                for (int x = 0; x < xlen; x++) //15
                {
                    Console.Write(this.map[y][x]);
                }
                Console.Write("\n");

            }
            //Printing Info Below Map
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("HP: " + Program.player.HP);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("(" + Program.player.playerCord[0] + "," + Program.player.playerCord[1] + ")");
            Console.WriteLine(World.getList().Count);
            foreach (Map m in World.getList())
            {
                Console.WriteLine(m.mapcord[0] + " " + m.mapcord[1]);
            }
            
            Console.WriteLine("\n" + Program.dialouge);
        }
        public void placePlayer()

        {
            createMap();
            Map tMap;
            Player player = Program.player;
            switch (map[player.playerY][player.playerX]) //Placing the player "O" 
            {

                case " ":
                    map[player.playerY][player.playerX] = "O";
                    break;
                case "#":

                    break;
                case "|": //If you place player on door (|/_) check if he is on the left,right,top or bottom side of map

                    if (player.playerX > 3)
                    {
                        player.playerCord[0] = player.playerCord[0] + 1; //Change global playerCord unique for each map.
                        if(getMapByLoc(player.playerCord) != Program.Nulled && player.playerCord != Program.currentMap.mapcord)
                        {
                            locPlayer(); //Change currentMap to match playerCord

                            //Arrival Cords on fixed 15x11 grid
                            player.playerX = 1;
                            player.playerY = 5;

                            //Place Player General Order
                            Program.currentMap.genMap(Program.currentMap.map);

                            Program.currentMap.removePlayer();

                            Program.currentMap.placePlayer();

                            Program.currentMap.createMap();
                            clearDia();
                        }
                        else
                        {
                            World.addMapToList(new Map(player.playerCord));
                            tMap = getMapByLoc(player.playerCord);
                            tMap.ranGen();
                            locPlayer(); //Change currentMap to match playerCord

                            //Arrival Cords on fixed 15x11 grid
                            player.playerX = 1;
                            player.playerY = 5;

                            //Place Player General Order
                            Program.currentMap.genMap(Program.currentMap.map);

                            Program.currentMap.removePlayer();

                            Program.currentMap.placePlayer();

                            Program.currentMap.createMap();
                            clearDia();
                        }


                    }
                    else
                    {
                        player.playerCord[0] = player.playerCord[0] - 1; //Change global playerCord unique for each map.
                        if (getMapByLoc(player.playerCord) != Program.Nulled && player.playerCord != Program.currentMap.mapcord)
                        {
                            locPlayer(); //Change currentMap to match playerCord

                            //Arrival Cords on fixed 15x11 grid
                            player.playerX = 13;
                            player.playerY = 5;

                            //Place Player General Order
                            Program.currentMap.genMap(Program.currentMap.map);

                            Program.currentMap.removePlayer();

                            Program.currentMap.placePlayer();

                            Program.currentMap.createMap();
                            clearDia();
                        }
                        else
                        {
                            World.addMapToList(new Map(player.playerCord));
                            tMap = getMapByLoc(player.playerCord);
                            tMap.ranGen();
                            locPlayer(); //Change currentMap to match playerCord

                            //Arrival Cords on fixed 15x11 grid
                            player.playerX = 13;
                            player.playerY = 5;

                            //Place Player General Order
                            Program.currentMap.genMap(Program.currentMap.map);

                            Program.currentMap.removePlayer();

                            Program.currentMap.placePlayer();

                            Program.currentMap.createMap();
                            clearDia();

                        }

                    }
                    break;
                case "_":
                    if (player.playerY > 3)
                    {
                        player.playerCord[1] = player.playerCord[1] - 1; //Change global playerCord unique for each map.
                        if (getMapByLoc(player.playerCord) != Program.Nulled && player.playerCord != Program.currentMap.mapcord)
                        {
                            locPlayer(); //Change currentMap to match playerCord

                            //Arrival Cords on fixed 15x11 grid
                            player.playerX = 7;
                            player.playerY = 1;

                            //Place Player General Order
                            Program.currentMap.genMap(Program.currentMap.map);

                            Program.currentMap.removePlayer();

                            Program.currentMap.placePlayer();

                            Program.currentMap.createMap();
                            clearDia();
                        }
                        else
                        {
                            World.addMapToList(new Map(player.playerCord));
                            tMap = getMapByLoc(player.playerCord);
                            tMap.ranGen();

                            locPlayer(); //Change currentMap to match playerCord

                            //Arrival Cords on fixed 15x11 grid
                            player.playerX = 7;
                            player.playerY = 1;

                            //Place Player General Order
                            Program.currentMap.genMap(Program.currentMap.map);

                            Program.currentMap.removePlayer();

                            Program.currentMap.placePlayer();

                            Program.currentMap.createMap();
                            clearDia();
                        }

                    }
                    else
                    {
                        player.playerCord[1] = player.playerCord[1] + 1; //Change global playerCord unique for each map.
                        if (getMapByLoc(player.playerCord) != Program.Nulled && player.playerCord != Program.currentMap.mapcord)
                        {
                            locPlayer(); //Change currentMap to match playerCord

                            //Arrival Cords on fixed 15x11 grid
                            player.playerX = 7;
                            player.playerY = 9;

                            //Place Player General Order
                            Program.currentMap.genMap(Program.currentMap.map);

                            Program.currentMap.removePlayer();

                            Program.currentMap.placePlayer();

                            Program.currentMap.createMap();
                            clearDia();
                        }
                        else
                        {
                            Map gMap = new Map(player.playerCord);
                            gMap.ranGen();
                            World.addMapToList(gMap);
                            
                         //   tMap = getMapByLoc(player.playerCord);
                          //  tMap.ranGen();
                            
                            locPlayer(); //Change currentMap to match playerCord
                            
                            //Arrival Cords on fixed 15x11 grid
                            player.playerX = 7;
                            player.playerY = 9;

                            //Place Player General Order
                            Program.currentMap.genMap(Program.currentMap.map);

                            Program.currentMap.removePlayer();

                            Program.currentMap.placePlayer();

                            Program.currentMap.createMap();
                            clearDia();
                        }

                    }
                    break;
            }

        }
        public void removePlayer()
        {
            Player player = Program.player;
            map[player.playerY][player.playerX] = " ";
        }
        public void placeObject(int x, int y, string ob)
        {
            map[y][x] = ob;
        }
        public void locPlayer()
        {
            Player player = Program.player;
            if (player.playerCord != Program.currentMap.mapcord) //Checks if playerCord has changed
            {
                Program.currentMap = getMapByLoc(player.playerCord); //Search list for Map with same coordinates.
               

            }
            
        }
        public Map getMapByLoc(int[] cord)
        {
            foreach (Map i in World.getList()) //Search for map with certain coordinates
            {

                if (i.mapcord[0] == cord[0] && i.mapcord[1] == cord[1])
                {
                    return i;
                }
            }
            return Program.Nulled; //Wont be needed unless I fuck up

        }
        public void clearDia()
        {
            Program.dialouge = "";
        }


        public static string r;
        public static Random ran = new Random();
        public static string ranMake() //Creates character to be inserted at certain place on map
        {

            int n = ran.Next(0, 4);

            switch (n)
            {
                case 0: // Weighted with space in a 2:1 ratio.
                    r = " ";
                    break;
                case 1:
                    r = " ";
                    break;
                case 2:
                    r = "#";
                    break;
                case 3:
                    r = " ";
                    break;

            }

            return r;
        }

        public void ranGen() //Randomly generates map
        {
            createMap();
            int xlen;
            int ylen;

            xlen = 15;
            ylen = 10;

            for (int y = 1; y < ylen - 1; y++) //10
            {
                for (int x = 1; x < xlen - 1; x++) //15
                {
                    r = ranMake();
                    map[y][x] = r; //Go over every square on map and replace with random symbol (" " or "#")
                }


            }
        }

       


    }
}