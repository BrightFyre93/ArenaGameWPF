using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace ArenaGameWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        static void Main()
        {
            int exp_hero = 0;
            int level_hero = 1;
            int level_monster;
            while (true)
            {
                Console.WriteLine("Would you like to start a new game? Input Y/Yes or N/No");
                string input_start = Console.ReadLine();
                if (input_start == "Yes" || input_start == "Y")
                {
                    int[] hero = SetHero(level_hero);
                    Console.WriteLine("Pick Level for Monster from 1 - 100:");
                    for (; ; )
                    {
                        try
                        {
                            level_monster = Convert.ToInt32(Console.ReadLine());
                            if (level_monster < 1 || level_monster > 100)
                            {
                                Console.WriteLine("Please input a number from 1 - 100.");
                            }
                            else
                            {
                                break;
                            }
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Please enter a number between 1 - 100.");
                        }
                    }

                    int[] monster = PickMonster(level_monster);
                    int[] damages; //Array to save the damage being done to hero and monster
                    while (hero[0] > 0)
                    {
                        Console.WriteLine($"Current HP:\nHero - {hero[0]} \nMonster - {monster[0]}");
                        Console.WriteLine("Choose whether to Attack/attack or Heal/heal or Defend/defend or Retreat/retreat: ");
                        string input_function = Console.ReadLine();
                        if (input_function == "Attack" || input_function == "attack")
                        {
                            damages = FuncAttack(hero, monster);
                        }
                        else if (input_function == "Defend" || input_function == "defend")
                        {
                            damages = FuncDefend(hero, monster);
                        }
                        else if (input_function == "Heal" || input_function == "heal")
                        {
                            damages = FuncHeal(hero, monster);
                        }
                        else if (input_function == "Retreat" || input_function == "retreat")
                        {
                            if (random_number_generator.Next(101) > 5)
                            {
                                Console.WriteLine("Hero successfully retreated");
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Hero retreat failed.");
                                damages = FuncFailedRetreat(hero, monster);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Please enter a valid function.");
                            continue;
                        }
                        hero[0] = damages[0];
                        monster[0] = damages[1];
                        if (monster[0] <= 0)
                        {
                            Console.WriteLine("Congrats you've won!");
                            exp_hero += monster[2];
                            Console.ReadKey();
                            break;
                        }
                    }

                }
                else if (input_start == "No" || input_start == "N")
                {
                    Console.WriteLine("Hope you have a good day!");
                    Console.ReadKey();
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter a valid input.");
                }
                int level_requirements = level_hero / 2 * (2 * 100 + (level_hero - 1) * 50); // Calculation of Sum of Arithmetic Progression with first term = 100 EXP and increase in EXP = 50 EXP
                if (level_requirements < exp_hero)
                {
                    exp_hero -= level_requirements;
                    level_hero += 1;
                }
            }
        }
    }
    }
}
