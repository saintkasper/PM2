using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Demo130423.Assets.UserControls
{
    /// <summary>
    /// Логика взаимодействия для Product.xaml
    /// </summary>
    public partial class Product : UserControl
    {
        string ID;
        public Product(Models.Product product)
        {
            InitializeComponent();

            ID = product.ProductArticleNumber;
            Title.Text = product.ProductName;
            Description.Text = product.ProductDescription;
            Models.Manufacturer manuf = App.context.Manufacturer.ToList().Find(m => m.Manufacturerid == product.ProductManufacturer);
            Manufactorer.Text = manuf.Name;
            if (product.ProductQuantityInStock != 0)
                Stock.Text = product.ProductQuantityInStock.ToString() + " шт.";
            else
            {
                StockBack.Background = Red.Background;
                Stock.Text = "Нет на складе!";
            }

            if (product.ProductDiscountAmount == 0)
            {
                CostWhithoutDiscount.Text = product.ProductCost.ToString();
                CostWhithoutDiscount.TextDecorations = null;
                CostWhithDiscount.Visibility = Visibility.Hidden;
            }
            else
            {
                CostWhithoutDiscount.Text = product.ProductCost.ToString();
                CostWhithDiscount.Text = (product.ProductCost - (product.ProductCost * product.ProductDiscountAmount) / 100).ToString();
                if (product.ProductDiscountAmount >= 10)
                    CostWhithDiscount.Background = Green.Background;
            }

            if (product.ProductPhoto != null)
            {
                MemoryStream Image_AsStream = new MemoryStream(product.ProductPhoto);
                BitmapImage Image_AsBM = new BitmapImage();
                Image_AsBM.BeginInit();
                Image_AsBM.StreamSource = Image_AsStream;
                Image_AsBM.EndInit();
                Img.Source = Image_AsBM;
            }
            else
                Img.Source = Pic.Source;
        }

        private void StackPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Classes.Navigation.products.ID = ID;
            MessageBox.Show("Продукт выбран для удаления");
        }
    }
}
