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
        public double Health;
        public double Attack;
        public double Defense;
        public int EXP;
        public int Level;
    }
    public class Hero
    {

        public static HeroStats SetHero(int plevel,int pEXP)
        {
            HeroStats hero = new HeroStats() {
                Health = 100.0 * plevel,
                Attack = 10.0 * plevel,
                Defense = 10.0 * plevel,
                Level = plevel,
                EXP = pEXP
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
