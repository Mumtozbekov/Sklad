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
    /// Логика взаимодействия для TovarElement.xaml
    /// </summary>
    public partial class TovarElement : Window
    {
        public TovarElement()
        {
            InitializeComponent();
            DataContext = new Tovar();
        } 
        public TovarElement(Tovar tovar)
        {
            InitializeComponent();
            DataContext = tovar;
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            Global.db.tovari.AddOrUpdate((Tovar)DataContext);
            Global.db.SaveChanges();
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cbKontragent.ItemsSource = Global.db.kontragents.ToList();
        }
    }
}
