using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGameWPF
{
    class Functions
    {
        
        readonly static Random random_number_generator = new Random();
        public static int FuncConfuse()
        {
            if (random_number_generator.NextDouble()>0.9) //10% chance to get confused for three turns
            {
                return 3;
            }
            else
            {
                return 0;
            }    
        }
        public static double CalculateDamage(double attack, double defense)
        {
            double damage = attack * attack / (attack + defense) * ((random_number_generator.NextDouble() * 40.0 + 215) / 235);
            return damage;
        }
        public static double[] FuncAttack(HeroStats hero, MonsterStats monster)
        {
            double[] damage_dealt = new double[] { CalculateDamage(monster.Attack,hero.Defense) , CalculateDamage(hero.Attack, monster.Defense) }; // Index 1 - Damage to Hero Index 2 - Damage to Monster
            return damage_dealt;
        }
        public static double[] FuncDefend(HeroStats hero, MonsterStats monster)
        {
            double[] damage_dealt = new double[] { 1, 0 };// Index 1 - Damage to Hero Index 2 - Damage to Monster
            return damage_dealt;
        }
        public static double[] FuncHeal(HeroStats hero, MonsterStats monster)
        {
            double[] damage_dealt = new double[] { hero.Attack , CalculateDamage(monster.Attack, hero.Defense) , 0 }; // Index 1 - Damage to Hero Index 2 - Damage to Monster
            return damage_dealt;
        }
        public static double[] FuncFailedRetreat(HeroStats hero, MonsterStats monster)
        {
            double[] damage_dealt = new double[] { CalculateDamage(monster.Attack, hero.Defense), 0 }; // Index 1 - Damage to Hero Index 2 - Damage to Monster
            return damage_dealt;
        }
    }
}
