﻿using System;
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

namespace WpfApp2.UserControls
{
    /// <summary>
    /// Interaction logic for DateInput.xaml
    /// </summary>
    public partial class DateInput : UserControl
    {

        public string Title 
        {
            get => title.Text;
            set => title.Text = value;
        }
        public DateTime? Input
        {
            get
            {
                CheckNull(input.Text);
                CheckPattern(input.Text);
                return input.SelectedDate;
            }
            set
            {
                input.SelectedDate = value;
            }
        }

        public bool NotNull { get; set; }
        public string Pattern  { get; set; }

        public DateInput()
        {
            InitializeComponent();
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
