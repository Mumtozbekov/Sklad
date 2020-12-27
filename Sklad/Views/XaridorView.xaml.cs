using Sklad.Entity;
using Sklad.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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
using System.Windows.Shapes;

namespace Sklad.Views
{
    /// <summary>
    /// Логика взаимодействия для Kontragent.xaml
    /// </summary>
    public partial class XaridorView : Window
    {

        public void Refresh()
        {
            Global.db.SaveChanges();
            dg.ItemsSource = Global.db.xaridors.ToList();
        }

        public XaridorView()
        {
            InitializeComponent();
            Refresh();
        }

        private void miAdd_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new Xaridor();
            ElementCard.Visibility = Visibility.Visible;
            miEdit.IsEnabled = miDelete.IsEnabled = dg.IsEnabled = false;
        }

        private void miSave_Click(object sender, RoutedEventArgs e)
        {
            if (tbName.Text != string.Empty)
            {
                Global.db.xaridors.AddOrUpdate((Xaridor)DataContext);
                miCancel_Click(null, null);
                Refresh();
            }
            else
                MessageBox.Show("Majburiy maydonlar to'ldirilmadi!");
        }

        private void miCancel_Click(object sender, RoutedEventArgs e)
        {
            DataContext = null;
            ElementCard.Visibility = Visibility.Collapsed;
            if (dg.SelectedItem != null)
                miEdit.IsEnabled = miDelete.IsEnabled = true;
            dg.IsEnabled = true;
        }

        private void miEdit_Click(object sender, RoutedEventArgs e)
        {
            DataContext = (Xaridor)dg.SelectedItem;
            ElementCard.Visibility = Visibility.Visible;
            miEdit.IsEnabled = miDelete.IsEnabled = dg.IsEnabled = false;
        }

        private void miDelete_Click(object sender, RoutedEventArgs e)
        {
            Global.db.xaridors.Remove((Xaridor)DataContext);
            Refresh();
        }

        private void dg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dg.SelectedIndex > -1) miDelete.IsEnabled = miEdit.IsEnabled = true;
        }
    }
}
