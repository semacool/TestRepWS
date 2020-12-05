using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace WpfApp2.UserControls
{
    /// <summary>
    /// Interaction logic for SelectedInput.xaml
    /// </summary>
    public partial class SelectedInput : UserControl
    {

        public string Title 
        {
            get => title.Text;
            set => title.Text = value;
        }
        public object Input
        {
            get
            {
                CheckNull(input.Text);
                CheckPattern(input.Text);
                return input.SelectedItem;
            }
        }

        public bool NotNull { get; set; }
        public string Pattern  { get; set; }

        public SelectedInput()
        {
            InitializeComponent();
        }

        public void SetCollection<T>(List<T> items, T item = null) where T : class,IEntity
        {
            input.ItemsSource = items;
            if(item != null)
                input.SelectedItem = items.Find(e=> e.Id == item.Id);
        }

        private void CheckNull(string input) 
        {
            if (input == "" || string.IsNullOrWhiteSpace(input))
                throw new Exception($"{Title} - не может быть пустым");
        }

        private void CheckPattern(string input)
        {
            if (Pattern == null) return;
            if (!Regex.IsMatch(input,Pattern))
                throw new Exception($"{Title} - имеет неверный формат");
        }

    }
}
