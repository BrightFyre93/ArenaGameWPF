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
        MonsterStats monster = new MonsterStats();
        HeroStats hero = new HeroStats();
        readonly static Random random_number_generator = new Random();
        readonly MainWindow myMainWindow = (MainWindow)Application.Current.MainWindow;
        int turnCount = 0;
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
        public void Fight(double[] damages)
        {
            turnCount++;
            hero.Health -= damages[0];
            monster.Health -= damages[1];
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
            hero = Hero.SetHero(hero.Level, hero.EXP, hero.NameofHero);
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
            GameAction_Textbox.Text += $"\nHero did {String.Format("{0:0.00}", damages[1])} damage to Monster.";
            GameAction_Textbox.Text += $"\nMonster did {String.Format("{0:0.00}", damages[0])} damage to Hero.";
            Fight(damages);
        }
        private void FuncDefend_Button_Click(object sender, RoutedEventArgs e)
        {
            damages = Functions.FuncDefend(hero, monster);
            GameAction_Textbox.Text += $"\nHero defended.";
            GameAction_Textbox.Text += $"\nMonster did {String.Format("{0:0.00}", damages[0])} damage to Hero.";
            Fight(damages);
        }
        private void FuncHeal_Button_Click(object sender, RoutedEventArgs e)
        {
            double[] sepdamage = Functions.FuncHeal(hero, monster);
            GameAction_Textbox.Text += $"\nHero healed his/her health by {String.Format("{0:0.00}", sepdamage[0])} points.";
            GameAction_Textbox.Text += $"\nMonster did {String.Format("{0:0.00}", sepdamage[1])} damage to Hero.";
            damages = new double[] { sepdamage[1] - sepdamage[0], 0 }; //Converted from separate damage values to final damage values
            Fight(damages);
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
                GameAction_Textbox.Text += "\nHero retreat failed.";
                damages = Functions.FuncFailedRetreat(hero, monster);
                GameAction_Textbox.Text += $"\nMonster did {String.Format("{0:0.00}", damages[0])} damage to Hero.";
                Fight(damages);
            }

        }
        protected override void OnClosing(CancelEventArgs e)
        {
            MainWindow.Get_Hero_Values(hero);
        }
        private void FuncInventory_Button_Click(object sender, RoutedEventArgs e)
        {
            Inventory newInventoryWindow = new Inventory(myMainWindow.currentInventory);
            newInventoryWindow.Show();
        }
    }
}
