using Demo130423.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks.Dataflow;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Demo130423.Windows
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Window
    {
        public Authorization()
        {
            InitializeComponent();
            Assets.Classes.Navigation.auth = this;
            Assets.Classes.Connection.con.Open();
        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            if (Login.Text.Length != 0 && Password.Text.Length != 0)
            {
                User user = App.context.User.ToList().Find(u => u.UserLogin == Login.Text && u.UserPassword == Password.Text);
                if (user != null)
                {
                    Assets.Classes.UserdData.ID = user.UserId.ToString();
                    Assets.Classes.UserdData.FIO = user.UserSurname.ToString() + " " + user.UserName.ToString() + " " + user.UserPatronymic.ToString();
                    Assets.Classes.UserdData.Role = user.UserRole.ToString();
                    if (user.UserRole.ToString() == "1")
                    {
                        Admin.Products win = new Admin.Products();
                        win.Show();
                        this.Hide();
                    }
                    else if (user.UserRoleNavigation.RoleName.ToString() == "2")
                    {
                        Manager.Products win = new Manager.Products();
                        win.Show();
                        this.Hide();
                    }
                    else if (user.UserRoleNavigation.RoleName.ToString() == "3")
                    {
                        Client.Products win = new Client.Products();
                        win.Show();
                        this.Hide();
                    }
                }
            }
            else
                MessageBox.Show("Вы должны заполнить все поля!");
        }

        private void GuestEnter_Click(object sender, RoutedEventArgs e)
        {
            Client.Products win = new Client.Products();
            win.Show();
            this.Hide();
        }
    }
}
