using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Media.Imaging;

namespace ArenaGameWPF
{
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        int level_monster;
        int type_monster;
        double[] damages; //Array to save the damage being done to hero and monster
        readonly Monsters monsterObject = new Monsters();
        public MonsterStats monster = new MonsterStats();
        public HeroStats hero = new HeroStats();
        readonly static Random random_number_generator = new Random();
        readonly MainWindow myMainWindow = (MainWindow)Application.Current.MainWindow;
        public GameWindow(HeroStats hero_stats)
        {
            InitializeComponent();
            GameAction_Textbox.Text = "";
            GameAction_Textbox.Text += "Base Stats for Level 1";
            GameAction_Textbox.Text += $"\nNo. - Name     - Health (Low-High) - Attack (Low-High) - Defense (Low-High) - Monster EXP (Low-High)";
            GameAction_Textbox.Text += $"\n1   - {monsterObject.snake_Stats.NameofMonster}       -       {monsterObject.snake_Stats.Health * 8 / 10} - {monsterObject.snake_Stats.Health * 12 / 10}             -         {monsterObject.snake_Stats.Attack * 8 / 10} - {monsterObject.snake_Stats.Attack * 12 / 10}            -       {monsterObject.snake_Stats.Defense * 8 / 10} - {monsterObject.snake_Stats.Defense * 12 / 10}             -         {monsterObject.snake_Stats.EXP * 8 / 10} - {monsterObject.snake_Stats.EXP * 12 / 10} ";
            GameAction_Textbox.Text += $"\n2   - {monsterObject.dragon_Stats.NameofMonster}     -       {monsterObject.dragon_Stats.Health * 8 / 10} - {monsterObject.dragon_Stats.Health * 12 / 10}             -        {monsterObject.dragon_Stats.Attack * 8 / 10} - {monsterObject.dragon_Stats.Attack * 12 / 10}          -       {monsterObject.dragon_Stats.Defense * 8 / 10} - {monsterObject.dragon_Stats.Defense * 12 / 10}          -         {monsterObject.dragon_Stats.EXP * 8 / 10} - {monsterObject.dragon_Stats.EXP * 12 / 10} ";
            GameAction_Textbox.Text += $"\n3   - {monsterObject.scorpion_Stats.NameofMonster}   -       {monsterObject.scorpion_Stats.Health * 8 / 10} - {monsterObject.scorpion_Stats.Health * 12 / 10}             -       {monsterObject.scorpion_Stats.Attack * 8 / 10} - {monsterObject.scorpion_Stats.Attack * 12 / 10}            -       {monsterObject.scorpion_Stats.Defense * 8 / 10} - {monsterObject.scorpion_Stats.Defense * 12 / 10}            -         {monsterObject.scorpion_Stats.EXP * 8 / 10} - {monsterObject.scorpion_Stats.EXP * 12 / 10} ";
            hero = hero_stats;
            HeroLevel_Label.Content = $"Hero Level: {hero.Level}";
            HeroEXP_Label.Content = $"Hero EXP: {hero.EXP}";
            HeroName_Label.Content = $"Hero Name: {hero.NameofHero}";
            MakeResetAvailableAfterGame();
            Hero_Image.Source = new BitmapImage(new Uri(@"\Resources\Hero\Default\HeroPixelArt 64 pixel.png", UriKind.Relative));
        }
        private void MakeResetAvailableAfterGame()
        {
            Proceed_Button.Visibility = Visibility.Visible;
            MonsterLevel_Textbox.Visibility = Visibility.Visible;
            MonsterType_Label.Visibility = Visibility.Visible;
            MonsterLevel_Label.Visibility = Visibility.Visible;
            MonsterType_Textbox.Visibility = Visibility.Visible;
            FuncAttack_Button.Visibility = Visibility.Hidden;
            FuncDefend_Button.Visibility = Visibility.Hidden;
            FuncHeal_Button.Visibility = Visibility.Hidden;
            FuncRetreat_Button.Visibility = Visibility.Hidden;
            Monster_Image.Source = null;
        }
        public void SetImageSource(string source)
        {
            Monster_Image.Source = new BitmapImage(new Uri(source, UriKind.Relative));
        }

        private Boolean CheckforConfusion(int turnConfusedStatus)
        {
            if (turnConfusedStatus != 0) //If Monster is in confused state
            {
                if (random_number_generator.NextDouble() > 0.5)
                {
                    return true;
                }
            }
            return false;
        }
        private void TurnSubtract() //Update the turns for the hero and monsters
        {
            //Hero
            hero.turnConfusedStatus = (hero.turnConfusedStatus != 0) ? hero.turnConfusedStatus - 1 : 0;
            hero.turnAgilityUpStatus = (hero.turnAgilityUpStatus != 0) ? hero.turnAgilityUpStatus - 1 : 0;
            hero.turnAttackUpStatus = (hero.turnAttackUpStatus != 0) ? hero.turnAttackUpStatus - 1 : 0;
            hero.turnBurnedStatus = (hero.turnBurnedStatus != 0) ? hero.turnBurnedStatus - 1 : 0;
            hero.turnDefenseUpStatus = (hero.turnDefenseUpStatus != 0) ? hero.turnDefenseUpStatus - 1 : 0;
            hero.turnFrozenStatus = (hero.turnFrozenStatus != 0) ? hero.turnFrozenStatus - 1 : 0;
            hero.turnHealthUpStatus = (hero.turnHealthUpStatus != 0) ? hero.turnHealthUpStatus - 1 : 0;
            hero.turnPoisonedStatus = (hero.turnPoisonedStatus != 0) ? hero.turnPoisonedStatus - 1 : 0;
            hero.turnStunnedStatus = (hero.turnStunnedStatus != 0) ? hero.turnStunnedStatus - 1 : 0;
            //Monster
            monster.turnConfusedStatus = (monster.turnConfusedStatus != 0) ? monster.turnConfusedStatus - 1 : 0;
            monster.turnAgilityUpStatus = (monster.turnAgilityUpStatus != 0) ? monster.turnAgilityUpStatus - 1 : 0;
            monster.turnAttackUpStatus = (monster.turnAttackUpStatus != 0) ? monster.turnAttackUpStatus - 1 : 0;
            monster.turnBurnedStatus = (monster.turnBurnedStatus != 0) ? monster.turnBurnedStatus - 1 : 0;
            monster.turnDefenseUpStatus = (monster.turnDefenseUpStatus != 0) ? monster.turnDefenseUpStatus - 1 : 0;
            monster.turnFrozenStatus = (monster.turnFrozenStatus != 0) ? monster.turnFrozenStatus - 1 : 0;
            monster.turnHealthUpStatus = (monster.turnHealthUpStatus != 0) ? monster.turnHealthUpStatus - 1 : 0;
            monster.turnPoisonedStatus = (monster.turnPoisonedStatus != 0) ? monster.turnPoisonedStatus - 1 : 0;
            monster.turnStunnedStatus = (monster.turnStunnedStatus != 0) ? monster.turnStunnedStatus - 1 : 0;
        }
        private void CheckForDrops()
        {
            Inventory tempInventory = new Inventory(null,null, null);
            foreach (object item in tempInventory.inventoryItems)
            {
                if(item is InventoryConsumable)
                {
                    double droprate = ((InventoryConsumable)item).dropRate;
                    if (random_number_generator.NextDouble()>droprate)
                    {
                        myMainWindow.currentInventory.Add(item);
                    }
                }
            }

        }
        private void UpdateDamages(double[] damages, string TypeofFunc)
        {
            //Hero
            while (true)
            {
                if(CheckforConfusion(hero.turnConfusedStatus))
                {
                    if(TypeofFunc == "Attack")
                    {
                        hero.Health -= damages[1];
                        GameAction_Textbox.Text += $"\nHero hurt itself in its confusion.";
                    }
                    else if(TypeofFunc == "Defend")
                    {
                        hero.Health -= damages[1];
                        GameAction_Textbox.Text += $"\nHero hurt itself in its confusion.";
                    }
                    else if(TypeofFunc == "Heal")
                    {
                        monster.Health += damages[0];
                        GameAction_Textbox.Text += $"\nHero healer the monster in its confusion.";
                    }
                    else if(TypeofFunc == "Retreat")
                    {
                        hero.Health -= damages[1];
                        GameAction_Textbox.Text += $"\nHero failed the retreat.";
                    }
                    break;
                }
                else
                {
                    if (TypeofFunc == "Attack")
                    {
                        monster.Health -= damages[1];
                        GameAction_Textbox.Text += $"\nHero did {String.Format("{0:0.00}", damages[1])} damage to Monster.";
                    }
                    else if (TypeofFunc == "Defend")
                    {
                        monster.Health -= damages[1];
                        GameAction_Textbox.Text += $"\nHero defended.";
                    }
                    else if (TypeofFunc == "Heal")
                    {
                        hero.Health = (hero.Health + damages[0] > (hero.Level *100)? hero.Level * 100 : hero.Health + damages[0]);
                        GameAction_Textbox.Text += $"\nHero healed his/her health by {String.Format("{0:0.00}", damages[0])} points.";
                    }
                    else if (TypeofFunc == "Retreat")
                    {
                        monster.Health -= damages[1];
                        GameAction_Textbox.Text += "\nHero retreat failed.";
                    }
                    break;
                }
            }


            //Monster
            while (true)
            {
                if (CheckforConfusion(monster.turnConfusedStatus))
                {
                    monster.Health -= damages[0];
                    GameAction_Textbox.Text += $"\nMonster hurt itself in its confusion.";
                    break;
                }
                else
                {
                    hero.Health -= damages[0];
                    GameAction_Textbox.Text += $"\nMonster did {String.Format("{0:0.00}", damages[0])} damage to Hero.";
                    break;

                }
            }
        }
        public void Fight(double[] damages, string TypeofFunc)
        {
            UpdateDamages(damages,TypeofFunc);
            TurnSubtract();
            if (monster.Health < 0)
            {
                GameAction_Textbox.Text += $"\nCurrent HP:\nHero - {String.Format("{0:0.00}", hero.Health)} \nMonster - 0";
            }
            else
            {
                GameAction_Textbox.Text += $"\nCurrent HP:\nHero - {String.Format("{0:0.00}", hero.Health)} \nMonster - {String.Format("{0:0.00}", monster.Health)}";
            }
            if (hero.Health <= 0)
            {
                GameAction_Textbox.Text += "\nDrats! You lost!";
                CheckForDrops();
                MakeResetAvailableAfterGame();
            }
            else if (monster.Health <= 0)
            {
                GameAction_Textbox.Text += "\nCongrats! You've won!";
                hero.EXP += monster.EXP;
                MakeResetAvailableAfterGame();
            }
            GameAction_Textbox.ScrollToEnd();
            HeroStats tempHero = Hero.CheckHeroLevel(hero.EXP, hero.Level);
            hero.EXP = tempHero.EXP;
            hero.Level = tempHero.Level;
            HeroLevel_Label.Content = $"Hero Level: {hero.Level}";
            HeroEXP_Label.Content = $"Hero EXP: {hero.EXP}";
        }
        private void ProceedButton_Click(object sender, RoutedEventArgs e)
        {
            hero = Hero.SetHero(hero);
            try
            {
                level_monster = Convert.ToInt32(MonsterLevel_Textbox.Text);
                if (level_monster < 1)
                {
                    GameAction_Textbox.Text += "\nPlease input a level.";
                }
            }
            catch (Exception)
            {
                GameAction_Textbox.Text += "\nPlease input a level greater than 1.";
            }
            try
            {
                type_monster = Convert.ToInt32(MonsterType_Textbox.Text);
                if (type_monster < 1 || type_monster > 3)
                {
                    GameAction_Textbox.Text += "\nPlease input a level from 1 - 3.";
                }
                else
                {
                    monster = monsterObject.PickMonster(level_monster, type_monster);
                    string imageSource = Monsters.SetImageSource(type_monster);
                    Monster_Image.Source = new BitmapImage(new Uri(imageSource, UriKind.Relative));
                    Proceed_Button.Visibility = Visibility.Hidden;
                    MonsterLevel_Textbox.Visibility = Visibility.Hidden;
                    MonsterType_Textbox.Visibility = Visibility.Hidden;
                    MonsterType_Label.Visibility = Visibility.Hidden;
                    MonsterLevel_Label.Visibility = Visibility.Hidden;
                    GameAction_Textbox.Text += $"\nCurrent HP:\nHero - {String.Format("{0:0.00}", hero.Health)} \nMonster - {String.Format("{0:0.00}", monster.Health)}";
                    FuncAttack_Button.Visibility = Visibility.Visible;
                    FuncDefend_Button.Visibility = Visibility.Visible;
                    FuncHeal_Button.Visibility = Visibility.Visible;
                    FuncRetreat_Button.Visibility = Visibility.Visible;
                }
            }
            catch (Exception)
            {
                GameAction_Textbox.Text += "\nPlease input a type from 1 - 3.";
            }
        }

        private void FuncAttack_Button_Click(object sender, RoutedEventArgs e)
        {
            damages = Functions.FuncAttack(hero, monster);
            Fight(damages,"Attack");
        }
        private void FuncDefend_Button_Click(object sender, RoutedEventArgs e)
        {
            damages = Functions.FuncDefend(hero, monster);
            Fight(damages,"Defend");
        }
        private void FuncHeal_Button_Click(object sender, RoutedEventArgs e)
        {
            double[] sepdamage = Functions.FuncHeal(hero, monster);
            Fight(sepdamage,"Heal");
        }
        private void FuncRetreat_Button_Click(object sender, RoutedEventArgs e)
        {
            if (random_number_generator.Next(101) > 5)
            {
                GameAction_Textbox.Text += "\nHero successfully retreated.";
                MakeResetAvailableAfterGame();
            }
            else
            {
                damages = Functions.FuncFailedRetreat(hero, monster);
                Fight(damages,"Retreat");
            }
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            MainWindow.Get_Hero_Values(hero);
        }
        private void FuncInventory_Button_Click(object sender, RoutedEventArgs e)
        {
            Inventory newInventoryWindow = new Inventory(myMainWindow.currentInventory, hero, monster);
            newInventoryWindow.Show();
        }
    }
}
