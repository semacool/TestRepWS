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
using WpfApp2.DataBase;
using System.Data.Entity;

namespace WpfApp2.Views
{
    /// <summary>
    /// Interaction logic for BiomaterialView.xaml
    /// </summary>
    public partial class BiomaterialView : Window
    {
        public BiomaterialView()
        {
            InitializeComponent();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {

            List<Materials> materials = null;
            await Task.Run(() => {
                using(var db = new MedicDb()) 
                {
                    materials = db.Materials.Include( m => m.Clients).ToList();
                }
            });

            MyList.ItemsSource = materials;
        }

        private void Additem(object sender, RoutedEventArgs e)
        {

        }
    }
}
