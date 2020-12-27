using Sklad.Entity;
using Sklad.Models;
using Sklad.Models.Documents;
using Sklad.Views;
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
            Global.db.SaveChanges();
            dgTovari.ItemsSource = Global.db.tovari.ToList();
            dgSotuvlar.ItemsSource = Global.db.dokumentProdajs.ToList();
        }
        public MainWindow()
        {
            InitializeComponent();
            Global.db = new dbContext();
        }

        
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Refresh();
        }

        private void miAdd_Click(object sender, RoutedEventArgs e)
        {
            var win = new TovarElement();
            win.ShowDialog();
            Refresh();
        }

        private void miEdit_Click(object sender, RoutedEventArgs e)
        {
            if(dgSotuvlar.CurrentCell.Item!=null)
            {
                var win = new TovarElement((Tovar)dgTovari.SelectedItem);
                win.ShowDialog();
                Refresh();
            }
        }

        private void miDel_Click(object sender, RoutedEventArgs e)
        {
            Global.db.tovari.Remove((Tovar)dgTovari.SelectedItem);
            Refresh();
        }

        private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            miEdit_Click(null,null);
        }

        private void miKontragent_Click(object sender, RoutedEventArgs e)
        {
            var win = new KontragentView();
            win.ShowDialog();
            
            Refresh();
        }

        private void miAddSotuv_Click(object sender, RoutedEventArgs e)
        {
            var win = new SotuvView();
            win.ShowDialog();

            Refresh();
        }

        private void miOtchet_Click(object sender, RoutedEventArgs e)
        {
            var win = new XisobotView();
            win.ShowDialog();

        }

        private void MiXaridor_Click(object sender, RoutedEventArgs e)
        {
            var win = new XaridorView();
            win.ShowDialog();
        }

        private void miSklad_Click(object sender, RoutedEventArgs e)
        {
            var win = new SkladView();
            win.ShowDialog();
        }

        private void miEdit1_Click(object sender, RoutedEventArgs e)
        {
            if(dgSotuvlar.CurrentCell.Item!=null)
            {
                var win = new SotuvView((DokumentProdaj)dgSotuvlar.CurrentCell.Item);
                win.ShowDialog();

                Refresh();
            }
                
        }

        private void dgSotuvlar_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            miEdit1_Click(null, null);
        }

        private void miDelete1_Click(object sender, RoutedEventArgs e)
        {
            if (dgSotuvlar.CurrentCell.Item != null)
                Global.db.dokumentProdajs.Remove((DokumentProdaj)dgSotuvlar.CurrentCell.Item);
        }
    }
}
