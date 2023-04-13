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
    /// Логика взаимодействия для AddProduct.xaml
    /// </summary>
    public partial class AddProduct : Window
    {
        public AddProduct()
        {
            InitializeComponent();
            List<Manufacturer> mfs = App.context.Manufacturer.ToList();
            foreach (Manufacturer m in mfs)
            {
                Manufacturer.Items.Add(m.Name);
            }

            List<Supplier> sups = App.context.Supplier.ToList();
            foreach (Supplier s in sups)
            {
                Supplier.Items.Add(s.Name);
            }

            List<Category> cats = App.context.Category.ToList();
            foreach (Category c in cats)
            {
                Category.Items.Add(c.Name);
            }
            List<Unit> units = App.context.Unit.ToList();
            foreach (Unit u in units)
            {
                Unit.Items.Add(u.Name);
            }

        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (Article.Text.Length != 0 && Title.Text.Length != 0 && Unit.Text.Length != 0 
                && Cost.Text.Length != 0 && MaxDiscount.Text.Length != 0 && Manufacturer.Text.Length != 0 
                && Supplier.Text.Length != 0 && Category.Text.Length != 0 && Discount.Text.Length != 0 
                && Stock.Text.Length != 0 && Description.Text.Length != 0)
            {
                try
                {
                    MySql.Data.MySqlClient.MySqlCommand com = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO `trade`.`product` " +
                        "(`ProductArticleNumber`, `ProductName`, `ProductUnit`, `ProductCost`, `ProductMaxDiscount`, `ProductManufacturer`, `ProductSupplier`, `ProductCategory`, " +
                        "`ProductDiscountAmount`, `ProductQuantityInStock`, `ProductDescription`) VALUES " +
                        "('" + Article.Text + "', '" + Title.Text + "', '" + (Unit.SelectedIndex + 1) + "', '" + Cost.Text + "', '" + MaxDiscount.Text + "', '" + (Manufacturer.SelectedIndex + 1) + "', " +
                        "'" + (Supplier.SelectedIndex + 1) + "', '" + (Category.SelectedIndex + 1) + "', '" + Discount.Text + "', '" + Stock.Text + "', '" + Description.Text + "');", Assets.Classes.Connection.con);
                    com.ExecuteNonQuery();
                    this.Close();
                Assets.Classes.Navigation.products.LoadData();
                }
                catch
                {
                    MessageBox.Show("Вы ввели неверные данные!");
                }
            }
            else
                MessageBox.Show("Вы должны заполнить все поля!");
        }
    }
}
