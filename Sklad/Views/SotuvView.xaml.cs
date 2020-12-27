using Sklad.Entity;
using Sklad.Models;
using Sklad.Models.Documents;
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
    /// Логика взаимодействия для SotuvView.xaml
    /// </summary>
    public partial class SotuvView : Window
    {

        public void Refresh()
        {
            dg.ItemsSource = Global.db.tovari.ToList();
        }
        public SotuvView()
        {
            InitializeComponent();
            DataContext = new DokumentProdaj();
            ((DokumentProdaj)DataContext).Tovars = new List<Tovar>();
            Refresh();
        }
        public SotuvView(DokumentProdaj dokumentProdaj)
        {
            InitializeComponent();
            DataContext = dokumentProdaj;
            Refresh();
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            Global.db.dokumentProdajs.AddOrUpdate((DokumentProdaj)DataContext);
            Close();
        }

        private void ToRight_Click(object sender, RoutedEventArgs e)
        {
            double count = 0;
            Double.TryParse(tbCount.Text,out count);

            var selected = (Tovar)dg.SelectedItem;
            var tovar =(Tovar)selected.Clone();
            if (count < tovar.Quantity)
            {
                selected.Quantity -= count;
                tovar.Quantity = count;
                ((DokumentProdaj)DataContext).Tovars.Add(tovar);
                dg1.Items.Refresh();

                ((DokumentProdaj)DataContext).Summa +=(double)( tovar.Narxi * tovar.Quantity);
                Global.db.SaveChanges();
                dg.Items.Refresh();
            }
            else
                MessageBox.Show("Tovar yetarli emas", "Xatolik!", MessageBoxButton.OK, MessageBoxImage.Error);
            DataContext = DataContext;
        }

        private void ToLeft_Click(object sender, RoutedEventArgs e)
        {

            var selected = (Tovar)dg1.SelectedItem; 
            foreach(var t in dg.ItemsSource)
            {
                if (((Tovar)t).Name == selected.Name)
                    ((Tovar)t).Quantity += selected.Quantity;
            }
            ((DokumentProdaj)DataContext).Tovars.Remove(selected);

            Refresh();
        }

        private void cbKategoriya_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dg.ItemsSource = Global.db.tovari.ToList().Where(x => x.Turi == cbKategoriya.SelectedItem.ToString());
        }

        private void btnFiltrOtmen_Click(object sender, RoutedEventArgs e)
        {
            cbKategoriya.Text = "";
            Refresh();
        }

        private void tbCount_TextInput(object sender, TextCompositionEventArgs e)
        {

            if (!Double.TryParse(e.Text, out _))
                e.Handled = true;
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cbSklad.ItemsSource = Global.db.sklads.ToList();
            cbXaridor.ItemsSource = Global.db.xaridors.ToList();
        }

        private void cbXaridor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = (Xaridor)cbXaridor.SelectedItem;
            ((DokumentProdaj)DataContext).Xaridor_m = item;
        }

        private void cbSklad_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = (Skladi)cbSklad.SelectedItem;
            ((DokumentProdaj)DataContext).Sklad_m = item;
        }
    }
}
