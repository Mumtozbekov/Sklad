using Sklad.Entity;
using Sklad.Models.Documents;
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
using System.Windows.Shapes;

namespace Sklad.Views
{
    /// <summary>
    /// Логика взаимодействия для XisobotView.xaml
    /// </summary>
    public partial class XisobotView : Window
    {
        public void CalculateSum()
        {
            double sum = 0;
            foreach (var i in dg.ItemsSource)
                sum += (double)((DokumentProdaj)i).Summa;

            lbSumma.Content = sum.ToString();
        }
        public XisobotView()
        {
            InitializeComponent();
            dg.ItemsSource = Global.db.dokumentProdajs.ToList();

        }

        private void Data_ot_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if(Data_do.SelectedDate!=null && Data_ot.SelectedDate!=null)
            {
            dg.ItemsSource = Global.db.dokumentProdajs.ToList().Where(x => x.Sana >= Data_ot.SelectedDate && x.Sana <= Data_do.SelectedDate);
            CalculateSum();
            }
        }

        private void btnFiltrOtmen_Click(object sender, RoutedEventArgs e)
        {
            Data_do.SelectedDate =  Data_ot= null;
            dg.ItemsSource = Global.db.dokumentProdajs.ToList();
            CalculateSum();

        }

        private void dg_Loaded(object sender, RoutedEventArgs e)
        {
            CalculateSum();

        }
    }
}
