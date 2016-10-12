using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCombat
{
    class World
    {
        private static List<Map> MapList = new List<Map>();

        public static void addMapToList(Map m)
        {
            MapList.Add(m);
        }

        public static List<Map> getList()
        {
            return MapList;
        }


    }
}
