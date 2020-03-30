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
        public static int[] CheckHeroLevel(int EXP,int level)
        {
            int level_requirements = level * 100 + level * (level - 1) * 25; // Calculation of Sum of Arithmetic Progression with first term = 100 EXP and increase in EXP = 50 EXP
            if (level_requirements < EXP)
            {
                EXP -= level_requirements;
                level += 1;
            }
            int[] heroEXPLevel = new int[] {EXP, level };
            return heroEXPLevel;
        }
    }
}
