using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGameWPF
{
    class Monsters
    {
        public readonly static Random random_number_generator = new Random();
        public readonly static int[] snake = new int[] { 40, 60, 8, 12, 15, 25 }; //First index is Lower Bound Health, Second Index is Upper Bound Health, Third index is Lower Bound Attack, Fourth Index is Upper Bound Attack, Fifth index is Lower Bound EXP, Sixth Index is Upper Bound EXP
        public readonly static int[] dragon = new int[] { 70, 90, 6, 10, 25, 35 };
        public readonly static int[] scorpion = new int[] { 30, 50, 15, 25, 20, 30 };
        public static int[] PickMonster(int level)
        {
            int[] monster = new int[] { 0, 0, 0 }; //First index is Health, Second is Attack, Third is EXP
            while (true)
            {
                Console.WriteLine("Pick a Monster: ");
                Console.WriteLine($"No. - Name     - Health - Attack - Monster EXP  - For Level {level}");
                Console.WriteLine($"1   - Snake    - {snake[0] * level}     - {snake[1] * level} - {snake[2] * level}");
                Console.WriteLine($"2   - Dragon   - {dragon[0] * level}     - {dragon[1] * level} - {dragon[2] * level}");
                Console.WriteLine($"3   - Scorpion - {scorpion[0] * level}     - {scorpion[1] * level} - {scorpion[2] * level}");
                Console.WriteLine("Enter a number between 1 - 3:");
                try
                {
                    int selected_monster = Convert.ToInt32(Console.ReadLine());
                    if (selected_monster < 1 || selected_monster > 3)
                    {
                        Console.WriteLine("Please input a number from 1 - 3.");
                    }
                    else if (selected_monster == 1) //Snake
                    {
                        monster[0] = random_number_generator.Next(snake[0], snake[1]) * level;
                        monster[1] = random_number_generator.Next(snake[2], snake[3]) * level;
                        monster[2] = random_number_generator.Next(snake[4], snake[5]) * level;
                        break;
                    }
                    else if (selected_monster == 2) //Dragon
                    {
                        monster[0] = random_number_generator.Next(dragon[0], dragon[1]) * level;
                        monster[1] = random_number_generator.Next(dragon[2], dragon[3]) * level;
                        monster[2] = random_number_generator.Next(dragon[4], dragon[5]) * level;
                        break;
                    }
                    else if (selected_monster == 3) //Scorpion
                    {
                        monster[0] = random_number_generator.Next(scorpion[0], scorpion[1]) * level;
                        monster[1] = random_number_generator.Next(scorpion[2], scorpion[3]) * level;
                        monster[2] = random_number_generator.Next(scorpion[4], scorpion[5]) * level;
                        break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please input a number from 1-3.");
                }
            }
            return monster;
        }
    }
}
