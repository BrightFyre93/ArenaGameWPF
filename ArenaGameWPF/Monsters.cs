using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;



namespace ArenaGameWPF
{
    public class MonsterStats
    {
        public string NameofMonster;
        public int Health;
        public int Attack;
        public int EXP;
    }
    class Monsters
    {
        public Monsters()
        {

        }
        public readonly static Random random_number_generator = new Random();
        public MonsterStats snake_Stats = new MonsterStats()
        {
            NameofMonster = "Snake",
            Health = 50,
            Attack = 10,
            EXP = 20
        };
        public MonsterStats dragon_Stats = new MonsterStats()
        {
            NameofMonster = "Dragon",
            Health = 80,
            Attack = 8,
            EXP = 30
        };
        public MonsterStats scorpion_Stats = new MonsterStats()
        {
            NameofMonster = "Scorpion",
            Health = 30,
            Attack = 20,
            EXP = 25
        };
        public static string SetImageSource(int type)
        {
            if (type == 1) //Snake
            {
                return @"\Resources\Monster\Snake\SnakePixelArt 64 pixels.png";
            }
            else if (type == 2) //Dragon
            {
                return @"\Resources\Monster\Dragon\DragonPixelArt 64 pixels.png";
            }
            else if(type == 3)//Scorpion
            {
                return @"\Resources\Monster\Scorpion\ScorpionPixelArt 64 pixels.png";
            }
            else//Default
            {
                return @"\Resources\Monster\Default\DefaultPixelArt 64 pixels.png";
            }
        }
        public MonsterStats PickMonster(int level, int type)
        {
            MonsterStats monster = new MonsterStats();
                    if (type == 1) //Snake
                    {
                        monster.NameofMonster = snake_Stats.NameofMonster;
                        monster.Health = random_number_generator.Next(snake_Stats.Health*8/10, snake_Stats.Health*12/10) * level;
                        monster.Attack = random_number_generator.Next(snake_Stats.Attack*8/10, snake_Stats.Attack*12*10) * level;
                        monster.EXP = random_number_generator.Next(snake_Stats.EXP*8/10, snake_Stats.EXP*12/10) * level;
                    }
                    else if (type == 2) //Dragon
                    {
                        monster.NameofMonster = dragon_Stats.NameofMonster;
                        monster.Health = random_number_generator.Next(dragon_Stats.Health * 8 / 10, dragon_Stats.Health * 12 / 10) * level;
                        monster.Attack = random_number_generator.Next(dragon_Stats.Attack * 8 / 10, dragon_Stats.Attack * 12 * 10) * level;
                        monster.EXP = random_number_generator.Next(dragon_Stats.EXP * 8 / 10, dragon_Stats.EXP * 12 / 10) * level;
                    }
                    else if (type == 3) //Scorpion
                    {
                        monster.NameofMonster = scorpion_Stats.NameofMonster;
                        monster.Health = random_number_generator.Next(scorpion_Stats.Health * 8 / 10, scorpion_Stats.Health * 12 / 10) * level;
                        monster.Attack = random_number_generator.Next(scorpion_Stats.Attack * 8 / 10, scorpion_Stats.Attack * 12 * 10) * level;
                        monster.EXP = random_number_generator.Next(scorpion_Stats.EXP * 8 / 10, scorpion_Stats.EXP * 12 / 10) * level;
                    }
            return monster;
        }
    }
}
