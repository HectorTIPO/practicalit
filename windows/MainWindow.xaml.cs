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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace fominPraktika
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void regBTN_Click(object sender, RoutedEventArgs e)
        {
            Window1 window1 = new Window1();
            window1.Show();
            this.Hide();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Environment.Exit(0);
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            var login = LOGIN.Text;
            var password = PASSWORD.Text;
            var context = new Appdbcontext();
            var user = context.Users.SingleOrDefault(x => x.login == login && x.password == password);
            if (user is  null) 
            {
                MessageBox.Show("Неправильный логин или пароль!");
                return;
            }
            MessageBox.Show("Вы успешно вошли в аккаунт!");
        }
    }
}
