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
        public int LowerBoundHealth;
        public int UpperBoundHealth;
        public int LowerBoundAttack;
        public int UpperBoundAttack;
        public int LowerBoundEXP;
        public int UpperBoundEXP;
    }
    public class SetMonster
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
            LowerBoundHealth = 40,
            UpperBoundHealth = 60,
            LowerBoundAttack = 8,
            UpperBoundAttack = 12,
            LowerBoundEXP = 15,
            UpperBoundEXP = 25
        };
        public MonsterStats dragon_Stats = new MonsterStats()
        {
            NameofMonster = "Dragon",
            LowerBoundHealth = 70,
            UpperBoundHealth = 90,
            LowerBoundAttack = 6,
            UpperBoundAttack = 10,
            LowerBoundEXP = 25,
            UpperBoundEXP = 35
        };
        public MonsterStats scorpion_Stats = new MonsterStats()
        {
            NameofMonster = "Scorpion",
            LowerBoundHealth = 30,
            UpperBoundHealth = 50,
            LowerBoundAttack = 15,
            UpperBoundAttack = 25,
            LowerBoundEXP = 20,
            UpperBoundEXP = 30
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
        public SetMonster PickMonster(int level, int type)
        {
            SetMonster monster = new SetMonster();
                    if (type == 1) //Snake
                    {
                        monster.NameofMonster = snake_Stats.NameofMonster;
                        monster.Health = random_number_generator.Next(snake_Stats.LowerBoundHealth, snake_Stats.UpperBoundHealth) * level;
                        monster.Attack = random_number_generator.Next(snake_Stats.LowerBoundAttack, snake_Stats.UpperBoundAttack) * level;
                        monster.EXP = random_number_generator.Next(snake_Stats.LowerBoundEXP, snake_Stats.UpperBoundEXP) * level;
                    }
                    else if (type == 2) //Dragon
                    {
                        monster.NameofMonster = dragon_Stats.NameofMonster;
                        monster.Health = random_number_generator.Next(dragon_Stats.LowerBoundHealth, dragon_Stats.UpperBoundHealth) * level;
                        monster.Attack = random_number_generator.Next(dragon_Stats.LowerBoundAttack, dragon_Stats.UpperBoundAttack) * level;
                        monster.EXP = random_number_generator.Next(dragon_Stats.LowerBoundEXP, dragon_Stats.UpperBoundEXP) * level;
                    }
                    else if (type == 3) //Scorpion
                    {
                        monster.NameofMonster = scorpion_Stats.NameofMonster;
                        monster.Health = random_number_generator.Next(scorpion_Stats.LowerBoundHealth, scorpion_Stats.UpperBoundHealth) * level;
                        monster.Attack = random_number_generator.Next(scorpion_Stats.LowerBoundAttack, scorpion_Stats.UpperBoundAttack) * level;
                        monster.EXP = random_number_generator.Next(scorpion_Stats.LowerBoundEXP, scorpion_Stats.UpperBoundEXP) * level;
                    }
            return monster;
        }
    }
}
