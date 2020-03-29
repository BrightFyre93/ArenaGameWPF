using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGameWPF
{
    class Functions
    {
        static int[] FuncAttack(int[] hero, int[] monster)
        {
            int[] damage_dealt = new int[] { hero[0] - monster[1], monster[0] - hero[1] }; // Index 1 - New Hero Health Index 2 - New Monster Health
            Console.WriteLine($"Hero did {hero[1]} damage to Monster.");
            Console.WriteLine($"Monster did {monster[1]} damage to Hero.");
            return damage_dealt;
        }
        static int[] FuncDefend(int[] hero, int[] monster)
        {
            int[] damage_dealt = new int[] { hero[0] - 1, monster[0] }; // Index 1 - New Hero Health Index 2 - New Monster Health
            Console.WriteLine($"Hero defended.");
            Console.WriteLine("Monster did 1 damage to Hero.");
            return damage_dealt;
        }
        static int[] FuncHeal(int[] hero, int[] monster)
        {
            int[] damage_dealt = new int[] { hero[0] + hero[1] - monster[1], monster[0] }; // Index 1 - New Hero Health Index 2 - New Monster Health
            Console.WriteLine($"Hero healed his/her health by {hero[1]} points.");
            Console.WriteLine($"Monster did {monster[1]} damage to Hero.");
            return damage_dealt;
        }
        static int[] FuncFailedRetreat(int[] hero, int[] monster)
        {
            int[] damage_dealt = new int[] { hero[0] - monster[1], monster[0] }; // Index 1 - New Hero Health Index 2 - New Monster Health
            Console.WriteLine($"Monster did {monster[1]} damage to Hero.");
            return damage_dealt;
        }
    }
}
