using Sklad.Entity;
using Sklad.Models;
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

namespace Sklad
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public void Refresh()
        {
            list.ItemsSource = Global.db.tovari.ToList();

        }
        public MainWindow()
        {
            InitializeComponent();
            Global.db = new dbContext();
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {

            //add_Group.Visibility =
            //    add_Item.Visibility = Visibility.Visible;
            //Global.db.tovari.Add(new Tovar()
            //{
            //    Name = "name",
            //    ShtrixKod = "654654654",
            //    Quantity = 20

            //}) ;
            //Global.db.SaveChanges();
            //Refresh();
        }

        private void remove_Click(object sender, RoutedEventArgs e)
        {
            Global.db.tovari.Remove((Tovar)list.SelectedItem);
            Global.db.SaveChanges();


            Refresh();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Refresh();
        }

        private void reload_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
