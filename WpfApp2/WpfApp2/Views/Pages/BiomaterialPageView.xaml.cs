using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Http;
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
using WpfApp2.HelpClass;

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
            Material = new Materials() { Clients = Clients.Input as Clients };
            await Task.Run(() => {

                HelpDb.Add<Materials>(Material);
            });
        }

        public BiomaterialPageView(Materials material)
        {
            Material = material;
            InitializeComponent();
            this.Loaded += BiomaterialPageView_Loaded;
            SaveBtn.Click += UpdateBtn_Click;

        }

        private async void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            Material.Clients = Clients.Input as Clients;
            Material.IdClient = (Clients.Input as Clients).Id;

            await Task.Run(() => {

                HelpDb.Update<Materials>(Material);

            });
        }

        private async void BiomaterialPageView_Loaded(object sender, RoutedEventArgs e)
        {
            List<Clients> clients = null;
            await Task.Run( async () => {
                clients = await HelpHttpClient.getList(HelpHttpClient.GETCLIENTS);
            });

            Clients.SetCollection(clients);
            if (Material != null) 
            {
                Clients.SetCollection(clients, Material.Clients);
            }
        }

        private void ExitClick(object sender, RoutedEventArgs e)
        {
            (App.Current as App).ExitFromWindow();
        }

        private void CloseClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
