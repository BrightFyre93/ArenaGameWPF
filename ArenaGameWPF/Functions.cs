using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGameWPF
{
    class Functions
    {
        public static int[] FuncAttack(HeroStats hero, SetMonster monster)
        {
            int[] damage_dealt = new int[] {monster.Attack, hero.Attack }; // Index 1 - Damage to Hero Index 2 - Damage to Monster
            return damage_dealt;
        }
        public static int[] FuncDefend(HeroStats hero, SetMonster monster)
        {
            int[] damage_dealt = new int[] { 1, 0 };// Index 1 - Damage to Hero Index 2 - Damage to Monster
            return damage_dealt;
        }
        public static int[] FuncHeal(HeroStats hero, SetMonster monster)
        {
            int[] damage_dealt = new int[] { - hero.Attack + monster.Attack, 0 }; // Index 1 - Damage to Hero Index 2 - Damage to Monster
            return damage_dealt;
        }
        public static int[] FuncFailedRetreat(HeroStats hero, SetMonster monster)
        {
            int[] damage_dealt = new int[] { monster.Attack, 0 }; // Index 1 - Damage to Hero Index 2 - Damage to Monster
            return damage_dealt;
        }
    }
}
