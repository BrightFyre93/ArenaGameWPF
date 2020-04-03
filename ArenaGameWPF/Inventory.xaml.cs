using System;
using System.Windows.Media;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;

namespace ArenaGameWPF
{
    /// <summary>
    /// Interaction logic for Inventory.xaml
    /// </summary>
    public class InventoryConsumable
    {
        public int ItemIndex; //Universal index for Items
        public string nameofItem;
        public string sourceImage;
        public string effectTarget; //User Effect, Monster Effect, UserEquipable
        public int effectTurns;//0 - for permanent, number of turns for others
        public float dropRate;// Defines the likelihood of the item being dropped at the end of a fight from 0-1
        public string effectStat;//Health, Attack, Defense, Agility
        public double effectStrength;// Amount the item affects the intended stat
        public int numberofuses;//Number of uses possible for the item - Unused for now
    }
    public class InventoryArmor
    {
        public int ItemIndex; //Universal index for Items
        public string nameofItem;
        public string sourceImage;
        public string armorType;//Weapon, Chest Armor, Boots, Pants, Gloves, Helmet
        public string primaryStat;//Health, Attack, Defense, Agility
        public double primaryStatEffect;//Amount of change to Primary Stat
        public string secondaryStat;//Health, Attack, Defense, Agility
        public double psecondayStatEffect;//Amount of change to Primary Stat
        public float dropRate;// Defines the likelihood of the item being dropped at the end of a fight from 0-1
        public float breakRate;//Chance for item to break while being used. Actual break rate will also be effected by number of turns item has been requipped.
    }
    public partial class Inventory : Window
    {
        int itemSelected;
        object[] inventoryInUse;
        readonly MainWindow myMainWindow = (MainWindow)Application.Current.MainWindow;
        public Inventory(object[] HeroInventory)
        {
            InitializeComponent();
            inventoryInUse = HeroInventory;
            DisplayInventoryItems();
            itemSelected = 0;
        }
        private void DisplayInventoryItems()
        {

        }
        private void SelectionColourChange(int item_number, string colorHex)
        {
            string RectangleName = $"Inventory_Item_{item_number}_Rectangle";
            Rectangle rect = (Rectangle)this.FindName(RectangleName);
            var converter = new BrushConverter();
            rect.Stroke = (Brush)converter.ConvertFromString(colorHex);
        }
        private void Image_MouseDown(object sender, MouseEventArgs e)
        {
            if (itemSelected != 0)
            {
                SelectionColourChange(itemSelected, "#FF000000");
            }
            Image img = sender as Image;
            string[] nameString = img.Name.Split('_');
            itemSelected = Convert.ToInt32(nameString[2]);
            if(itemSelected > inventoryInUse.Length)
            {
                itemSelected = 0;
            }
            else
            {
                SelectionColourChange(itemSelected, "#FF3399FF");
            }
        }
        private void UseItem_Button_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Delete_Button_Click(object sender, RoutedEventArgs e)
        {
            object[] tempinventory = inventoryInUse;
            if (itemSelected != 0)
            {
                if (MessageBox.Show("Are you sure you wish to delete this item?", "Inventory", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    try
                    {
                        for(int inventorycount = itemSelected;inventorycount < inventoryInUse.Length;inventorycount++)
                        {
                            inventoryInUse[inventorycount - 1] = inventoryInUse[inventorycount]; //Replacing the deleted item with the next item in the array
                            DisplayInventoryItems();
                        }
                    }
                    catch (IndexOutOfRangeException)
                    {
                        MessageBox.Show("An error occured while deleting the ite. Please try again later.");
                        inventoryInUse = tempinventory;
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select an item first.");
            }
        }
        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            myMainWindow.SetInventoryAtClose(inventoryInUse);
            this.Close();
        }
    }
}
