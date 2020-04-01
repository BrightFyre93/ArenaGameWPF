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
        readonly static HeroStats hero = new HeroStats()
        {
            EXP = 0,
            Level = 1
        };
        
        public MainWindow()
        {
            InitializeComponent();
        }
        
        
        private void Start_Journey(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrWhiteSpace(Name_Textbox.Text))
            {
                MessageBox.Show("Please enter a valid name");
                return;
            }
            hero.NameofHero = Name_Textbox.Text;
            GameWindow NewGame = new GameWindow(hero);
            NewGame.Show();
        }
        public static void Get_Hero_Values(HeroStats temphero)
        {
            hero.EXP = temphero.EXP;
            hero.Level = temphero.Level;
        }
          
    }
    }

