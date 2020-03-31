using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGameWPF
{
    public class HeroStats
    {
        public string NameofHero;
        public int Health;
        public int Attack;
        public int Defense;
        public int EXP;
        public int Level;
    }
    public class Hero
    {

        public static HeroStats SetHero(int level)
        {
            HeroStats hero = new HeroStats() {
                Health = 100 * level,
                Attack = 10 * level
            }; 
            return hero;
        }
        public static HeroStats CheckHeroLevel(int inEXP,int inlevel)
        {
            int level_requirements = inlevel * 100 + inlevel * (inlevel - 1) * 25; // Calculation of Sum of Arithmetic Progression with first term = 100 EXP and increase in EXP = 50 EXP
            if (level_requirements < inEXP)
            {
                inEXP -= level_requirements;
                inlevel += 1;
            }
            HeroStats heroEXPLevel = new HeroStats() {
                EXP = inEXP,
                Level = inlevel };
            return heroEXPLevel;
        }
    }
}
