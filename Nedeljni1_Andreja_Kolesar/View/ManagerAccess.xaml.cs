﻿using System;
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

namespace Nedeljni1_Andreja_Kolesar.View
{
    /// <summary>
    /// Interaction logic for ManagerAccess.xaml
    /// </summary>
    public partial class ManagerAccess : Window
    {
        public ManagerAccess()
        {
            InitializeComponent();
            this.DataContext = new ManagerAccessViewModel(this);
        }

        //private void textChangedEventHandler(object sender, TextChangedEventArgs args)
        //{
        //    string temp = txtQuantity.Text;
        //    if (Int32.TryParse(temp, out int quantity))
        //    {
        //        total.Content = (dish.price * quantity).ToString();
        //    }
        //    else
        //    {
        //        total.Content = "0";
        //    }
        //}
    }
}
