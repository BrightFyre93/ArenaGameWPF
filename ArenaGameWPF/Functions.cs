using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGameWPF
{
    class Functions
    {
        public static int[] FuncAttack(int[] hero, int[] monster)
        {
            int[] damage_dealt = new int[] {monster[1], hero[1] }; // Index 1 - Damage to Hero Index 2 - New Monster Health
            return damage_dealt;
        }
        public static int[] FuncDefend(int[] hero, int[] monster)
        {
            int[] damage_dealt = new int[] { 1, 0 }; // Index 1 - New Hero Health Index 2 - New Monster Health
            return damage_dealt;
        }
        public static int[] FuncHeal(int[] hero, int[] monster)
        {
            int[] damage_dealt = new int[] { - hero[1] + monster[1], 0 }; // Index 1 - New Hero Health Index 2 - New Monster Health
            return damage_dealt;
        }
        public static int[] FuncFailedRetreat(int[] hero, int[] monster)
        {
            int[] damage_dealt = new int[] { monster[1], 0 }; // Index 1 - New Hero Health Index 2 - New Monster Health
            return damage_dealt;
        }
    }
}
