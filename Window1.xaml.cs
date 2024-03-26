using fominPraktika.classes;
using System;
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

namespace fominPraktika
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Hide();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var Login = LOGIN1.Text;
            var Pass = PASSWORD1.Text;
            var context = new Appdbcontext();
            var user_exists = context.Users.FirstOrDefault(x => x.login == Login);
            if (user_exists is not null)
            {
                MessageBox.Show("Такой пользователь уже существует");
                return;
            }
            var user = new user { login = Login, password = Pass };

            context.Users.Add(user);
            context.SaveChanges();
            MessageBox.Show("Welcome to the club, body");
        }
    }
}
