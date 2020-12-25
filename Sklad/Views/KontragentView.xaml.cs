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
using System.Windows.Shapes;

namespace Sklad.Views
{
    /// <summary>
    /// Логика взаимодействия для Kontragent.xaml
    /// </summary>
    public partial class KontragentView : Window
    {
        public KontragentView()
        {
            InitializeComponent();
            DataContext = new Kontragent();
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            Global.db.kontragents.Add((Kontragent)DataContext);
            Global.db.SaveChanges();
        }
    }
}
