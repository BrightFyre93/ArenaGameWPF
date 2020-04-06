using System;
using System.Windows.Media;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;
using System.Collections.Generic;

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
        public double dropRate;// Defines the likelihood of the item being dropped at the end of a fight from 0-1
        public string effectStat;//Health, Attack, Defense, Agility
        public double effectStrength;// Amount the item affects the intended stat
        public string effectUnits;//Absoulte for Value,Percentage for Percentage stats
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
        public double secondayStatEffect;//Amount of change to Primary Stat
        public double dropRate;// Defines the likelihood of the item being dropped at the end of a fight from 0-1
    }
    public partial class Inventory : Window
    {
        readonly public List<object> inventoryItems = new List<object>();
        
        int itemSelected;
        List<object> inventoryInUse; //currentInventory object including Armor and Consumables
        readonly MainWindow myMainWindow = (MainWindow)Application.Current.MainWindow;
        public Inventory(List<object> HeroInventory)
        {
            InitializeComponent();
            inventoryInUse = HeroInventory;
            DisplayInventoryItems();
            itemSelected = 0;
            PopulateItems();
            InventoryCount();
        }
        private void PopulateItems()
        {
            //Potion
            InventoryConsumable Potion = new InventoryConsumable()
            {
                ItemIndex = 0,
                nameofItem = "Potion",
                sourceImage = @".\Resources\Items\POTION\Potion 64px.png",
                effectTarget = "User",
                effectTurns = 0,
                dropRate = 0.01,
                effectStat = "Health",
                effectStrength = 50.0,
                numberofuses = 1,
                effectUnits = "Absolute"
            };
            inventoryItems.Add(Potion);

            //Potion - Large
            InventoryConsumable PotionLarge = new InventoryConsumable()
            {
                ItemIndex = 1,
                nameofItem = "Potion - Large",
                sourceImage = @".\Resources\Items\POTION - LARGE\Potion - Large 64px.png",
                effectTarget = "User",
                effectTurns = 0,
                dropRate = 0.01,
                effectStat = "Health",
                effectStrength = 200.0,
                numberofuses = 1,
                effectUnits = "Absolute"
            };
            inventoryItems.Add(PotionLarge);

            //Attack Up
            InventoryConsumable AttackUp = new InventoryConsumable()
            {
                ItemIndex = 2,
                nameofItem = "Attack Up",
                sourceImage = @".\Resources\Items\ATK UP\ATK UP 64px.png",
                effectTarget = "User",
                effectTurns = 3,
                dropRate = 0.01,
                effectStat = "Attack",
                effectStrength = 10.0,
                numberofuses = 1,
                effectUnits = "Percentage"
            };
            inventoryItems.Add(AttackUp);

            //Health Up
            InventoryConsumable HealthUp = new InventoryConsumable()
            {
                ItemIndex = 3,
                nameofItem = "Health Up",
                sourceImage = @".\Resources\Items\HLTH UP\HLTH UP 64px.png",
                effectTarget = "User",
                effectTurns = 3,
                dropRate = 0.01,
                effectStat = "Health",
                effectStrength = 10.0,
                numberofuses = 1,
                effectUnits = "Percentage"
            };
            inventoryItems.Add(HealthUp);

            //Defense Up
            InventoryConsumable DefenseUp = new InventoryConsumable()
            {
                ItemIndex = 4,
                nameofItem = "Defense Up",
                sourceImage = @".\Resources\Items\DEF UP\DEF UP 64px.png",
                effectTarget = "User",
                effectTurns = 3,
                dropRate = 0.01,
                effectStat = "Defense",
                effectStrength = 10.0,
                numberofuses = 1,
                effectUnits = "Percentage"
            };
            inventoryItems.Add(DefenseUp);

            //Agility Up
            InventoryConsumable AgilityUp = new InventoryConsumable()
            {
                ItemIndex = 5,
                nameofItem = "Agility Up",
                sourceImage = @".\Resources\Items\AGI UP\AGI UP 64px.png",
                effectTarget = "User",
                effectTurns = 3,
                dropRate = 0.01,
                effectStat = "Agility",
                effectStrength = 10.0,
                numberofuses = 1,
                effectUnits = "Percentage"
            };
            inventoryItems.Add(AgilityUp);

            //Stun Heal
            InventoryConsumable StunHeal = new InventoryConsumable()
            {
                ItemIndex = 6,
                nameofItem = "Stun Heal",
                sourceImage = @".\Resources\Items\STUN HEAL\STUN HEAL 64px.png",
                effectTarget = "User",
                effectTurns = 0,
                dropRate = 0.01,
                effectStat = "Stunned",
                effectStrength = 0,
                numberofuses = 1,
                effectUnits = "Absolute"
            };
            inventoryItems.Add(StunHeal);

            //Poison Heal
            InventoryConsumable PoisonHeal = new InventoryConsumable()
            {
                ItemIndex = 7,
                nameofItem = "Poison Heal",
                sourceImage = @".\Resources\Items\POISON HEAL\POISON HEAL 64px.png",
                effectTarget = "User",
                effectTurns = 0,
                dropRate = 0.01,
                effectStat = "Poisoned",
                effectStrength = 0.0,
                numberofuses = 1,
                effectUnits="Absolute"
            };
            inventoryItems.Add(PoisonHeal);

            //Poison
            InventoryConsumable Poison = new InventoryConsumable()
            {
                ItemIndex = 8,
                nameofItem = "Poison",
                sourceImage = @".\Resources\Items\POISON\POISON 64px.png",
                effectTarget = "Monster",
                effectTurns = 0,
                dropRate = 0.01,
                effectStat = "Poisoned",
                effectStrength = 0.0,
                numberofuses = 1,
                effectUnits = "Absolute"
            };
            inventoryItems.Add(Poison);

            //Stun Berry
            InventoryConsumable StunBerry = new InventoryConsumable()
            {
                ItemIndex = 9,
                nameofItem = "Stun Berry",
                sourceImage = @".\Resources\Items\STUN BERRY\Stun Berry 64px.png",
                effectTarget = "Monster",
                effectTurns = 0,
                dropRate = 0.01,
                effectStat = "Stunned",
                effectStrength = 0.0,
                numberofuses = 1,
                effectUnits = "Absolute"
            };
            inventoryItems.Add(StunBerry);

            //Burn Heal
            InventoryConsumable BurnHeal = new InventoryConsumable()
            {
                ItemIndex = 10,
                nameofItem = "Burn Heal",
                sourceImage = @".\Resources\Items\BURN HEAL\BURN HEAL 64px.png",
                effectTarget = "User",
                effectTurns = 0,
                dropRate = 0.01,
                effectStat = "Burned",
                effectStrength = 0.0,
                numberofuses = 1,
                effectUnits = "Absolute"
            };
            inventoryItems.Add(BurnHeal);

            //Confuse Berry
            InventoryConsumable ConfuseBerry = new InventoryConsumable()
            {
                ItemIndex = 11,
                nameofItem = "Confuse Berry",
                sourceImage = @".\Resources\Items\CONFUSE BERRY\Confuse Berry 64px.png",
                effectTarget = "Monster",
                effectTurns = 0,
                dropRate = 0.01,
                effectStat = "Confused",
                effectStrength = 0.0,
                numberofuses = 1,
                effectUnits = "Absolute"
            };
            inventoryItems.Add(ConfuseBerry);

            //Confuse Heal
            InventoryConsumable ConfuseHeal = new InventoryConsumable()
            {
                ItemIndex = 12,
                nameofItem = "Confuse Heal",
                sourceImage = @".\Resources\Items\CONFUSE HEAL\CONFUSE HEAL 64px.png",
                effectTarget = "User",
                effectTurns = 0,
                dropRate = 0.01,
                effectStat = "Confused",
                effectStrength = 0.0,
                numberofuses = 1,
                effectUnits = "Absolute"
            };
            inventoryItems.Add(ConfuseHeal);

            //Ice Heal
            InventoryConsumable IceHeal = new InventoryConsumable()
            {
                ItemIndex = 13,
                nameofItem = "Ice Heal",
                sourceImage = @".\Resources\Items\ICE HEAL\ICE HEAL 64px.png",
                effectTarget = "User",
                effectTurns = 0,
                dropRate = 0.01,
                effectStat = "Frozen",
                effectStrength = 0.0,
                numberofuses = 1,
                effectUnits = "Absolute"
            };
            inventoryItems.Add(IceHeal);

        }
        private void DisplayInventoryItems()
        {
            var converter = new ImageSourceConverter();
            for ( int item = 0; item < inventoryInUse.Count;item++)
            {
                string ImgName = $"Inventory_Item_{item}_Image";
                Image img = (Image)this.FindName(ImgName);
                try
                {
                    if (inventoryInUse[item] is InventoryConsumable)
                    {
                        string source = ((InventoryConsumable)inventoryInUse[item]).sourceImage;
                        img.Source =(ImageSource)converter.ConvertFromString(source);
                    }
                    else if (inventoryInUse[item] is InventoryArmor)
                    {
                        string source = ((InventoryArmor)inventoryInUse[item]).sourceImage;
                        img.Source = (ImageSource)converter.ConvertFromString(source);
                    }
                }
                catch (Exception error)
                {
                    MessageBox.Show($"An error occurred while displaying the items.\n{error.Message}");
                    break;
                }
            }
        }
        private void InventoryCount()
        {
            ItemCount_Label.Content = $"Item Count: {inventoryInUse.Count}/81";
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
            if(itemSelected > inventoryInUse.Count)
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
            List<object> tempinventory = inventoryInUse;
            if (itemSelected != 0)
            {
                if (MessageBox.Show("Are you sure you wish to delete this item?", "Inventory", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    try
                    {
                        for(int inventorycount = itemSelected;inventorycount < inventoryInUse.Count;inventorycount++)
                        {
                            inventoryInUse[inventorycount - 1] = inventoryInUse[inventorycount]; //Replacing the deleted item with the next item in the array
                            DisplayInventoryItems();
                        }
                    }
                    catch (IndexOutOfRangeException error)
                    {
                        MessageBox.Show($"An error occured while deleting the item. Please try again later.\n{error.Message}");
                        inventoryInUse = tempinventory;
                    }
                    catch(Exception error)
                    {
                        MessageBox.Show($"An error occured while deleting the item. Please try again later.\n{error.Message}");
                        inventoryInUse = tempinventory;
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select an item first.");
            }
            InventoryCount();
        }
        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            myMainWindow.SetInventoryAtClose(inventoryInUse);
            this.Close();
        }
    }
}
