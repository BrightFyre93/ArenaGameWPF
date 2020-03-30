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
        public readonly static Random random_number_generator = new Random();
        int[] hero;
        int exp_hero = 0;
        int level_hero = 1;
        int level_monster;
        int type_monster;
        int[] monster;
        int[] damages; //Array to save the damage being done to hero and monster

        public MainWindow()
        {
            InitializeComponent();
        }
        private void MakeResetAvailableAfterGame()
        {

            FuncAttack_Button.Visibility = Visibility.Hidden;
            FuncDefend_Button.Visibility = Visibility.Hidden;
            FuncHeal_Button.Visibility = Visibility.Hidden;
            FuncRetreat_Button.Visibility = Visibility.Hidden;
            Info_Label.Content = "Would you like to start a new game?";
            StartGame_Button.Visibility = Visibility.Visible;
            Hero_Image.Source = null;
            Monster_Image.Source = null;
        }
        public void SetImageSource(string source)
        {
            Monster_Image.Source = new BitmapImage(new Uri(source, UriKind.Relative));
        }
        private void Start_Journey(object sender, RoutedEventArgs e)
        {
            HeroLevel_Label.Content = $"Hero Level: {level_hero}";
            HeroEXP_Label.Content = $"Hero EXP: {exp_hero}";
            hero = Hero.SetHero(level_hero);
            Hero_Image.Source = new BitmapImage(new Uri(@"\Resources\Hero\Default\HeroPixelArt 64 pixel.png", UriKind.Relative));
            Info_Label.Content = "Pick Monster Level and Type:";
            GameAction_Textbox.Text = "";
            GameAction_Textbox.Text += "Base Stats for Level 1";
            GameAction_Textbox.Text += $"\nNo. - Name     - Health (Low-High) - Attack (Low-High) - Monster EXP (Low-High)";
            GameAction_Textbox.Text += $"\n1   - Snake       -       {Monsters.snake[0]} - {Monsters.snake[1]}             -         {Monsters.snake[2]} - {Monsters.snake[3]}            -         {Monsters.snake[4]} - {Monsters.snake[5]} ";
            GameAction_Textbox.Text += $"\n2   - Dragon     -       {Monsters.dragon[0]} - {Monsters.dragon[1]}             -         {Monsters.dragon[2]} - {Monsters.dragon[3]}            -         {Monsters.dragon[4]} - {Monsters.dragon[5]} ";
            GameAction_Textbox.Text += $"\n3   - Scorpion   -       {Monsters.scorpion[0]} - {Monsters.scorpion[1]}             -       {Monsters.scorpion[2]} - {Monsters.scorpion[3]}            -         {Monsters.scorpion[4]} - {Monsters.scorpion[5]} ";
            Proceed_Button.Visibility = Visibility.Visible;
            MonsterLevel_Textbox.Visibility = Visibility.Visible;
            MonsterType_Label.Visibility = Visibility.Visible;
            MonsterLevel_Label.Visibility = Visibility.Visible;
            MonsterType_Textbox.Visibility = Visibility.Visible;
            StartGame_Button.Visibility = Visibility.Hidden;
 
        }
        public void FightFinish(int[] damages)
        {
            hero[0] -= damages[0];
            monster[0] -= damages[1];
            if (monster[0] < 0)
            {
                GameAction_Textbox.Text += $"\nCurrent HP:\nHero - {hero[0]} \nMonster - 0";
            }
            else
            {
                GameAction_Textbox.Text += $"\nCurrent HP:\nHero - {hero[0]} \nMonster - {monster[0]}";
            }
            if (hero[0] <= 0)
            {
                GameAction_Textbox.Text += "\nDrats! You lost!";
                MakeResetAvailableAfterGame();
            }
            else if (monster[0] <= 0)
            {
                GameAction_Textbox.Text += "\nCongrats! You've won!";
                exp_hero += monster[2];
                MakeResetAvailableAfterGame();
            }
            GameAction_Textbox.ScrollToEnd();
            int[] newEXPLEVEL = Hero.CheckHeroLevel(exp_hero, level_hero);
            exp_hero = newEXPLEVEL[0];
            level_hero = newEXPLEVEL[1];
            HeroLevel_Label.Content = $"Hero Level: {level_hero}";
            HeroEXP_Label.Content = $"Hero EXP: {exp_hero}";
        }
        private void ProceedButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                level_monster = Convert.ToInt32(MonsterLevel_Textbox.Text);
                if (level_monster < 1 || level_monster > 100)
                {
                    GameAction_Textbox.Text += "\nPlease input a level from 1 - 100.";
                }
            }
            catch (Exception)
            {
                GameAction_Textbox.Text += "\nPlease input a level from 1 - 100.";
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
                    monster = Monsters.PickMonster(level_monster, type_monster);
                    string imageSource = Monsters.SetImageSource(type_monster);
                    Monster_Image.Source = new BitmapImage(new Uri(imageSource, UriKind.Relative));
                    Proceed_Button.Visibility = Visibility.Hidden;
                    MonsterLevel_Textbox.Visibility = Visibility.Hidden;
                    MonsterType_Textbox.Visibility = Visibility.Hidden;
                    MonsterType_Label.Visibility = Visibility.Hidden;
                    MonsterLevel_Label.Visibility = Visibility.Hidden;
                    GameAction_Textbox.Text += $"\nCurrent HP:\nHero - {hero[0]} \nMonster - {monster[0]}";
                    Info_Label.Content = "Choose whether to Attack or Heal or Defend or Retreat: ";
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
            GameAction_Textbox.Text += $"\nHero did {damages[1]} damage to Monster.";
            GameAction_Textbox.Text += $"\nMonster did {damages[0]} damage to Hero.";
            FightFinish(damages);
        }
        private void FuncDefend_Button_Click(object sender, RoutedEventArgs e)
        {
            damages = Functions.FuncDefend(hero, monster);
            GameAction_Textbox.Text += $"\nHero defended.";
            GameAction_Textbox.Text += $"\nMonster did {damages[0]} damage to Hero.";
            FightFinish(damages);
        }
        private void FuncHeal_Button_Click(object sender, RoutedEventArgs e)
        {
            damages = Functions.FuncHeal(hero, monster);
            GameAction_Textbox.Text += $"\nHero healed his/her health by {hero[1]} points.";
            GameAction_Textbox.Text += $"\nMonster did {monster[1]} damage to Hero.";
            FightFinish(damages);
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
                GameAction_Textbox.Text += $"\nMonster did {damages[0]} damage to Hero.";
                FightFinish(damages);
            }

        }
    }
    }

