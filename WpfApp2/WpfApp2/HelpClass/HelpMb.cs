using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp2.HelpClass
{
    class HelpMb
    {
        public static void MessageBoxError(string title = "Ошибка", string text = "Ошибка") 
        {
            MessageBox.Show(text, title,MessageBoxButton.OK, MessageBoxImage.Error);
        }
        public static void MessageBoxInfo(string title = "Информация", string text = "Информация")
        {
            MessageBox.Show(text, title, MessageBoxButton.OK, MessageBoxImage.Information);
        }
        public static MessageBoxResult MessageBoxQuestion(string title = "Вопрос", string text = "Вопрос")
        {
            return MessageBox.Show(text, title, MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
