using ERPConsumeAPI.Model;
using ERPConsumeAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ERPConsumeAPI.Views
{
    /// <summary>
    /// Interaction logic for ClientesView.xaml
    /// </summary>
    public partial class ClientesView : Window
    {
        public ClientesView()
        {
            InitializeComponent();
            DataContext = new ClientesViewModel();
        }
    }
}
