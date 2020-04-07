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
        public static List<object> FuncUseInventoryConsumable(int selecteditem,HeroStats hero, MonsterStats monster,InventoryConsumable item, List<object> currentInventory)
        {
            List<object> temp_list = new List<object>();
            switch (item.ItemIndex)
            {
                case 11:
                    monster.turnConfusedStatus = item.effectTurns;
                    if(item.numberofuses == 1) //Remove item from current inventory if one use item
                    {
                        currentInventory.RemoveAt(selecteditem);
                    }
                    break;
                default:
                    break;
            }
            temp_list[0] = hero;
            temp_list[1] = monster;
            temp_list[2] = currentInventory;
            return temp_list;
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
