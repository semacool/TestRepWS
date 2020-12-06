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
using WpfApp2.DataBase;
using WpfApp2.HelpClass;
using WpfApp2.Views;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void AuthClick(object sender, RoutedEventArgs e)
        {
            var login = this.login.Text;
            var password = this.password.Password;
            Laborants user = null;
            await Task.Run(() =>
            {
                using(var db = new MedicDb()) 
                {
                     user = db.Laborants.ToList().Find(l=> l.Login == login && l.Password == password);
                }
            });

            if(user == null) 
            {
                HelpMb.MessageBoxError("Ошибка аунтификации", "Неверный логин или пароль!");
                return;
            }

            new MenuView().ShowDialog();
        }
    }
}
