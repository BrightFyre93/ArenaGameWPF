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
        public double Agility;
        public int EXP;
        public int Level;
        public int turnConfusedStatus; //0 - No Effect //Number of Turns - Effect active for
        public int turnPoisonedStatus;   //0 - No Effect //Number of Turns - Effect active for
        public int turnStunnedStatus;    //0 - No Effect //Number of Turns - Effect active for
        public int turnBurnedStatus;     //0 - No Effect //Number of Turns - Effect active for
        public int turnFrozenStatus;     //0 - No Effect //Number of Turns - Effect active for
        public int turnAttackUpStatus;   //0 - No Effect //Number of Turns - Effect active for
        public int turnHealthUpStatus;   //0 - No Effect //Number of Turns - Effect active for
        public int turnDefenseUpStatus;  //0 - No Effect //Number of Turns - Effect active for
        public int turnAgilityUpStatus;  //0 - No Effect //Number of Turns - Effect active for
    }
    public class Hero
    {

        public static HeroStats SetHero(HeroStats temphero)
        {
            HeroStats hero = new HeroStats() {
                Health = 100.0 * temphero.Level,
                Attack = 10.0 * temphero.Level,
                Defense = 10.0 * temphero.Level,
                Agility = 10.0 * temphero.Level,
                Level = temphero.Level,
                EXP = temphero.EXP,
                NameofHero = temphero.NameofHero,
                turnConfusedStatus = temphero.turnConfusedStatus,
                turnPoisonedStatus = temphero.turnPoisonedStatus,
                turnStunnedStatus = temphero.turnStunnedStatus,
                turnBurnedStatus = temphero.turnBurnedStatus,
                turnFrozenStatus = temphero.turnFrozenStatus,
                turnAttackUpStatus = temphero.turnAttackUpStatus,
                turnHealthUpStatus = temphero.turnHealthUpStatus,
                turnDefenseUpStatus = temphero.turnDefenseUpStatus,
                turnAgilityUpStatus = temphero.turnAgilityUpStatus

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
