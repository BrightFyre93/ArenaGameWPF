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
    public partial class Inventory : Window
    {
        int itemSelected;
        public Inventory()
        {
            InitializeComponent();
            itemSelected = 0;
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
            SelectionColourChange(itemSelected, "#FF3399FF");
        }
        private void UseItem_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
