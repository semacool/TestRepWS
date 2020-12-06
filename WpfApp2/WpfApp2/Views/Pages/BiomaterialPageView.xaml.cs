using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace WpfApp2.Views.Pages
{
    /// <summary>
    /// Interaction logic for BiomaterialPageView.xaml
    /// </summary>
    public partial class BiomaterialPageView : Window
    {
        Materials Material;
        public BiomaterialPageView()
        {
            InitializeComponent();
            this.Loaded += BiomaterialPageView_Loaded;
            SaveBtn.Click += AddBtn_Click;
        }

        private async void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            await Task.Run(() => {

                using (var db = new MedicDb())
                {
                    db.Materials.Add(new Materials() { Clients = SelectedClients.Input as Clients });
                }
            });
        }

        public BiomaterialPageView(Clients clients)
        {
            InitializeComponent();
            this.Loaded += BiomaterialPageView_Loaded;
            SaveBtn.Click += UpdateBtn_Click;

        }

        private async void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            Material.Clients = SelectedClients.Input as Clients;
            Material.IdClient = (SelectedClients.Input as Clients).Id;

            await Task.Run(() => {

                using (var db = new MedicDb())
                {
                    db.Entry(Material).State = EntityState.Modified;
                }
            });
        }

        private async void BiomaterialPageView_Loaded(object sender, RoutedEventArgs e)
        {
            List<Clients> clients = null;
            await Task.Run(() => {

                using (var db = new MedicDb())
                {
                    clients = db.Clients.ToList();
                }
            });
            SelectedClients.SetCollection(clients, Material.Clients);
        }
    }
}
