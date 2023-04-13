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

namespace Demo130423.Windows.Admin
{
    /// <summary>
    /// Логика взаимодействия для Products.xaml
    /// </summary>
    public partial class Products : Window
    {
        public string ID;
        public Products()
        {
            InitializeComponent();
            LoadData();
            Assets.Classes.Navigation.products = this;
            List<Manufacturer> mfs = App.context.Manufacturer.ToList();
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

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            AddProduct win = new AddProduct();
            win.Show();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            //try
            //{
                MySql.Data.MySqlClient.MySqlCommand com = new MySql.Data.MySqlClient.MySqlCommand("DELETE FROM Product WHERE ProductArticleNumber = '" + ID + "'", Assets.Classes.Connection.con);
                com.ExecuteNonQuery();
                MessageBox.Show("Продукт удалён!");
                LoadData();
            //}
            //catch
            //{
            //    MessageBox.Show("Невозможно удалить продукт: он есть в одном из заказов!");
            //}
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Assets.Classes.Navigation.auth.Show();
        }
    }
}
