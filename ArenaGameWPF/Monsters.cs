using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGameWPF
{
    class Monsters
    {
        static int[] PickMonster(int level)
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
