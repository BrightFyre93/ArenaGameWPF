using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGameWPF
{
    public class Hero
    {
        public static int[] SetHero(int level)
        {
            int[] hero = new int[] { 100 * level, 10 * level }; //First index is Health, Second is Attack
            return hero;
        }
    }
}
