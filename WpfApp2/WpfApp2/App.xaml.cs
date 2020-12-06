using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        public void ExitFromWindow() 
        {
            foreach(Window w in Current.Windows)
            {
                if (w != Current.MainWindow)
                    w.Close();
            }
        }
    }
}
