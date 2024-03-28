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
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace fominPraktika
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int loginVzlom = 0;
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
        
        private async void loginButton_Click(object sender, RoutedEventArgs e)
        {
            var login = LOGIN.Text;
            var password = PASSWORD.Text;
            LOGIN.Text = login;
            var context = new Appdbcontext();
            var user = context.Users.SingleOrDefault(x => (x.login == login || x.email == login) && x.password == password);

            if (user is null)
            {
                MessageBox.Show("Неправильный логин или пароль!");
                
                if (loginVzlom >= 3)
            {
                DisableControls();
                MessageBox.Show("Вы заблокированы на 15 секунд!");
                await Task.Delay(15000);
                EnableControls();
                MessageBox.Show("Разблокированы.\nПопробуйте снова!");
                loginVzlom = 0;
            }
            else
            {
                loginVzlom++;
                ErrorBtn.Visibility = Visibility.Visible;
                ErrorBox.Text = "Неправильный логин или пароль!\nПопробуйте снова!";
                LOGIN.BorderThickness = new Thickness(3);
                LOGIN.BorderBrush = Brushes.Red;

                PASSWORD.BorderThickness = new Thickness(3);
                PASSWORD.BorderBrush = Brushes.Red;

                passwordbox.BorderThickness = new Thickness(3);
                passwordbox.BorderBrush = Brushes.Red;

               

                ErrorBtn.Visibility = Visibility.Visible;

                LOGIN.IsEnabled = false;
                PASSWORD.IsEnabled = false;
                passwordbox.IsEnabled = false;
                loginButton.IsEnabled = false;
                GLAZ.IsEnabled = false;
                GLAZ2.IsEnabled = false;
                regBTN.IsEnabled = false;
                    return;
            }
            }
           

                MessageBox.Show("Вы успешно вошли в аккаунт!");

            int id = user.id;
            WHOD whod = new WHOD(id);
            whod.Show();
            this.Hide();

        }

        private void GLAZ_Click(object sender, RoutedEventArgs e)
        {
            PASSWORD.Text = passwordbox.Password;
            passwordbox.Password = PASSWORD.Text;
            PASSWORD.Visibility = Visibility.Visible;
            passwordbox.PasswordChar = '*';
            GLAZ.Visibility = Visibility.Hidden;
            GLAZ2.Visibility = Visibility.Visible;

        }

        private void GLAZ2_Click(object sender, RoutedEventArgs e)
        {
            passwordbox.Password = PASSWORD.Text;
            PASSWORD.Visibility = Visibility.Hidden;
            GLAZ2.Visibility = Visibility.Hidden;
            GLAZ.Visibility = Visibility.Visible;
            passwordbox.Visibility = Visibility.Visible;
        }

        private void DisableControls()
        {
            LOGIN.IsEnabled = false;
            PASSWORD.IsEnabled = false;
           
            loginButton.IsEnabled = false;
            regBTN.IsEnabled = false;
            GLAZ.IsEnabled = false;
            GLAZ2.IsEnabled = false;
        }

        private void EnableControls()
        {
           LOGIN.IsEnabled = true;
            PASSWORD.IsEnabled = true;
            
            loginButton.IsEnabled = true;
            regBTN.IsEnabled = true;
            GLAZ.IsEnabled = true;
            GLAZ2.IsEnabled = true;
        }

        private void ErrorBtn_Click(object sender, RoutedEventArgs e)
        {
            ErrorBox.Text = "";
            ErrorBtn.Visibility = Visibility.Hidden;
            loginButton.IsEnabled = true;

            LOGIN.BorderBrush = Brushes.Transparent;
            PASSWORD.BorderBrush = Brushes.Transparent;
            passwordbox.BorderBrush = Brushes.Transparent;
           

            LOGIN.IsEnabled = true;
            PASSWORD.IsEnabled = true;
            passwordbox.IsEnabled = true;
            loginButton.IsEnabled = true;
            GLAZ.IsEnabled = true;
            GLAZ2.IsEnabled = true;
            regBTN.IsEnabled = true;
        }
    }
}
