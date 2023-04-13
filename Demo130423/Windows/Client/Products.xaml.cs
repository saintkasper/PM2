using Demo130423.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Demo130423.Windows.Client
{
    /// <summary>
    /// Логика взаимодействия для Products.xaml
    /// </summary>
    public partial class Products : Window
    {
        public Products()
        {
            InitializeComponent();
            List<Manufacturer> mfs = App.context.Manufacturer.ToList();
            LoadData();
            foreach (Manufacturer m in mfs)
            {
                Filtration.Items.Add(m.Name);
            }
        }

        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            LoadData();
        }

        private void Filtration_DropDownClosed(object sender, EventArgs e)
        {
            LoadData();
        }

        private void Asc_Checked(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void Desc_Checked(object sender, RoutedEventArgs e)
        {
            LoadData();
        }
        public void LoadData()
        {
            ProductsList.Children.Clear();
            List<Product> products = App.context.Product.ToList();
            if (Search.Text.Length != 0)
                products = products.Where(p => p.ProductName.Contains(Search.Text)).ToList();
            if (Asc.IsChecked != true)
                products = products.OrderBy(p => p.ProductName).ToList();
            else if (Desc.IsChecked != true)
                products = products.OrderByDescending(p => p.ProductName).ToList();
            if (Filtration.Text.Length != 0)
                products = products.Where(p => p.ProductManufacturerNavigation.Name == Filtration.Text).ToList();
            foreach (Product product in products)
                ProductsList.Children.Add(new Assets.UserControls.Product(product));
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Assets.Classes.Navigation.auth.Show();
        }
    }
}
