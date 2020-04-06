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
        public double Health;
        public double Attack;
        public double Defense;
        public double Agility;
        public int EXP;
        public int Level;
        public int turnConfusedStatus; //0 - No Effect //Number of Turns - Effect active for
        public int turnPoisonedStatus;   //0 - No Effect //Number of Turns - Effect active for
        public int turnStunnedStatus;    //0 - No Effect //Number of Turns - Effect active for
        public int turnBurnedStatus;     //0 - No Effect //Number of Turns - Effect active for
        public int turnFrozenStatus;     //0 - No Effect //Number of Turns - Effect active for
        public int turnAttackUpStatus;   //0 - No Effect //Number of Turns - Effect active for
        public int turnHealthUpStatus;   //0 - No Effect //Number of Turns - Effect active for
        public int turnDefenseUpStatus;  //0 - No Effect //Number of Turns - Effect active for
        public int turnAgilityUpStatus;  //0 - No Effect //Number of Turns - Effect active for
    }
    class Monsters
    {
        public Monsters()
        {

        }
        readonly static Random random_number_generator = new Random();
        public MonsterStats snake_Stats = new MonsterStats()
        {
            NameofMonster = "Snake",
            Health = 50.0,
            Attack = 10.0,
            EXP = 20,
            Defense = 8.0,
            Agility = 10.0,
            turnConfusedStatus = 0,
            turnPoisonedStatus = 0,
            turnStunnedStatus = 0,
            turnBurnedStatus = 0,
            turnFrozenStatus = 0,
            turnAttackUpStatus = 0,
            turnHealthUpStatus = 0,
            turnDefenseUpStatus = 0,
            turnAgilityUpStatus = 0
        };
        public MonsterStats dragon_Stats = new MonsterStats()
        {
            NameofMonster = "Dragon",
            Health = 80.0,
            Attack = 8.0,
            EXP = 30,
            Defense = 9.0,
            Agility = 9.0,
            turnConfusedStatus = 0,
            turnPoisonedStatus = 0,
            turnStunnedStatus = 0,
            turnBurnedStatus = 0,
            turnFrozenStatus = 0,
            turnAttackUpStatus = 0,
            turnHealthUpStatus = 0,
            turnDefenseUpStatus = 0,
            turnAgilityUpStatus = 0
        };
        public MonsterStats scorpion_Stats = new MonsterStats()
        {
            NameofMonster = "Scorpion",
            Health = 30.0,
            Attack = 20.0,
            EXP = 25,
            Defense = 7.0,
            Agility = 8.0,
            turnConfusedStatus = 0,
            turnPoisonedStatus = 0,
            turnStunnedStatus = 0,
            turnBurnedStatus = 0,
            turnFrozenStatus = 0,
            turnAttackUpStatus = 0,
            turnHealthUpStatus = 0,
            turnDefenseUpStatus = 0,
            turnAgilityUpStatus = 0
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
                return @"\Resources\Default\DefaultPixelArt 64 pixels.png";
            }
        }
        public MonsterStats PickMonster(int level, int type)
        {
            MonsterStats monster = new MonsterStats();
                    if (type == 1) //Snake
                    {
                        monster.NameofMonster = snake_Stats.NameofMonster;
                        monster.Health = ((random_number_generator.NextDouble()/2.5 + 0.8)*snake_Stats.Health) * level;
                        monster.Attack = ((random_number_generator.NextDouble()/2.5 + 0.8)*snake_Stats.Attack) * level;
                        monster.EXP = random_number_generator.Next(snake_Stats.EXP*8/10, snake_Stats.EXP*12/10) * level;
                        monster.Defense = ((random_number_generator.NextDouble() / 2.5 + 0.8) * snake_Stats.Defense) * level;
                        monster.Level = level;
                    }
                    else if (type == 2) //Dragon
                    {
                        monster.NameofMonster = snake_Stats.NameofMonster;
                        monster.Health = ((random_number_generator.NextDouble() / 2.5 + 0.8) * dragon_Stats.Health) * level;
                        monster.Attack = ((random_number_generator.NextDouble() / 2.5 + 0.8) * dragon_Stats.Attack) * level;
                        monster.EXP = random_number_generator.Next(dragon_Stats.EXP * 8 / 10, dragon_Stats.EXP * 12 / 10) * level;
                        monster.Defense = ((random_number_generator.NextDouble() / 2.5 + 0.8) * dragon_Stats.Defense) * level;
                        monster.Level = level;
                    }
                    else if (type == 3) //Scorpion
                    {
                        monster.NameofMonster = snake_Stats.NameofMonster;
                        monster.Health = ((random_number_generator.NextDouble() / 2.5 + 0.8) * scorpion_Stats.Health) * level;
                        monster.Attack = ((random_number_generator.NextDouble() / 2.5 + 0.8) * scorpion_Stats.Attack) * level;
                        monster.EXP = random_number_generator.Next(scorpion_Stats.EXP * 8 / 10, scorpion_Stats.EXP * 12 / 10) * level;
                        monster.Defense = ((random_number_generator.NextDouble() / 2.5 + 0.8) * scorpion_Stats.Defense) * level;
                        monster.Level = level;
                    }
            return monster;
        }
    }
}
