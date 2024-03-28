using fominPraktika.classes;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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
            var RPASS = REPEATPASSWORD1.Text;
            var email = EMAIL.Text;
            var context = new Appdbcontext();
            var user_exists = context.Users.FirstOrDefault(x => x.login == Login);
          
            if (user_exists is not null)
            {
                MessageBox.Show("Такой пользователь уже существует");
                return;
            }
            var user = new user { login = Login, password = Pass, email = email };

           
            errorLog.Visibility = Visibility.Hidden;
            errorPass.Visibility = Visibility.Hidden;
            errorPass.Visibility = Visibility.Hidden;
            errorPass1.Visibility = Visibility.Hidden;
            errorPass2.Visibility = Visibility.Hidden;
            if (Login.Length >= 1)
            {
                errorLog.Text = "";
                if (email.Contains("@") && email.Contains("."))
                {
                    errorEmail.Text = "";

                    if (Pass.Length >= 6)
                    {
                        errorPass.Text = "";
                        if (Pass.Any(Char.IsPunctuation))
                        {
                            errorPass1.Text = "";
                            if (Pass == RPASS)
                            {
                                errorPass2.Text = "";
                                context.Users.Add(user);
                                context.SaveChanges();
                                MessageBox.Show("Welcome to the club, body");
                            }
                            else
                            {
                                errorPass2.Text = "Пароли должны совпадать";
                                errorPass2.Visibility = Visibility.Visible;
                                

                            }
                        }
                        else
                        {
                            errorPass1.Text = "В пароле должны быть специальные символы";
                            errorPass1.Visibility = Visibility.Visible;

                        }
                    }
                    else
                    {
                        errorPass.Text = "Пароль должен состоять из 6 символов";
                        errorPass.Visibility = Visibility.Visible;

                    }

                }

                else
                {
                    errorEmail.Text = "В почте должны содержаться @ и .";


                }
            }
            else
            {
                errorLog.Text = "Такой логин уже существует";

            }
        }
      
    }
}
