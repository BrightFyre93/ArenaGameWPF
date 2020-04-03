using System;
using System.Windows;
using Microsoft.Win32;
using System.IO;
using System.Text;

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
        //Creating an object for New Inventory
        public object[] currentInventory = new object[81];

        // Specify a name for your using Environment for My Documents.
        readonly static string myDocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        // To create a string that specifies the path to a subfolder under your 
        // top-level folder, add a name for the subfolder to folderName.
        readonly static string gameDirectory = System.IO.Path.Combine(myDocumentsPath, "ArenaGameWPF");

        public MainWindow()
        {
            InitializeComponent();
        }
            public void SetHeroName()
        {
            hero.NameofHero = Name_Textbox.Text;
        }
        public void SetInventoryAtClose(object[] newInventory)
        {
            currentInventory = newInventory;
        }
        private void Start_Journey(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Name_Textbox.Text))
            {
                MessageBox.Show("Please enter a valid name");
                return;
            }
            SetHeroName();
            GameWindow NewGame = new GameWindow(hero);
            NewGame.Show();
        }
        public static void Get_Hero_Values(HeroStats temphero)
        {
            hero.EXP = temphero.EXP;
            hero.Level = temphero.Level;
        }

        private void Save_Button_Click(object sender, RoutedEventArgs e)
        {
            SetHeroName();
            if (string.IsNullOrWhiteSpace(hero.NameofHero))
            {
                MessageBox.Show("Enter a name before saving.");
                return;
            }

            // Create the directory.
            //        myDocuments
            //            ArenaGameWPF
            if (System.IO.Directory.Exists(gameDirectory))
            {
                // Do Nothing
            }
            else
            {
                System.IO.Directory.CreateDirectory(gameDirectory);
            }
            SaveFileDialog saveFile = new SaveFileDialog
            {
                InitialDirectory = gameDirectory,
                Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*",
                FileName = $"{hero.NameofHero}.txt"
            };
            if (saveFile.ShowDialog() == true)
            {
                string path_of_file = saveFile.FileName;
                string info = $"Hero_Name:{hero.NameofHero}\nHero_Level:{hero.Level}\nHero_EXP:{hero.EXP}";
                File.WriteAllText(path_of_file, info);
            }
        }

        private void Load_Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog
            {
                InitialDirectory = gameDirectory,
                Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*",
                FileName = $"{hero.NameofHero}.txt"
            };
            if (openFile.ShowDialog() == true)
            {
                string[] fileLines = File.ReadAllLines(openFile.FileName);
                hero.NameofHero = fileLines[0].Substring((fileLines[0].IndexOf(':'))+1);
                hero.Level = Convert.ToInt32(fileLines[1].Substring((fileLines[1].IndexOf(':')) + 1));
                hero.EXP = Convert.ToInt32(fileLines[2].Substring((fileLines[2].IndexOf(':')) + 1));
                Name_Textbox.Text = hero.NameofHero;
            }
        }
    }
}

