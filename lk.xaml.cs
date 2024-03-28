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
    /// Логика взаимодействия для lk.xaml
    /// </summary>
    public partial class lk : Window
    {
        public string UserLogin1 { get; }
        public int ide = new int();
        public lk( int id )
        {
            InitializeComponent();
            ide = id;

            var context = new Appdbcontext();

            var user = context.Users.SingleOrDefault(x => x.id == ide);

            string x = Convert.ToString(ide);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WHOD whoD = new WHOD(ide);
            whoD.Show();
            this.Hide();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string EMail = Mail.Text;


            if (Pass.Text.Length <= 0 && Mail.Text.Length <= 0)
            {

                MessageBox.Show("Вы ничего не ввели!");
            }
            else
            {
                if (Pass.Text.Length >= 1 && Mail.Text.Length <= 0)
                {
                    if (Pass.Text.Length > 6  && Pass.Text.Any(char.IsPunctuation))
                    {
                        var userId = Convert.ToInt32(ide);

                        var context = new Appdbcontext(); ;

                        var user = context.Users.Find(userId);

                        string Passik = Pass.Text;

                        user.password = Passik;
                        context.SaveChanges();

                        MessageBox.Show("Пароль успешно изменен!");
                    }
                    else
                    {
                        MessageBox.Show("Пароль должен отвечать следующим требованиям:" +
                        "\n• Длина не менее 6 символов" +
                       "Включать в себя спец. символы");
                    }
                }
                if (Pass.Text.Length <= 0 && Mail.Text.Length >= 1)
                {
                    if (Mail.Text.Contains("@") && Mail.Text.Contains("."))
                    {
                        var userId = Convert.ToInt32(ide);

                        var context = new Appdbcontext();

                        var user = context.Users.Find(userId);

                        string Milo = Mail.Text;

                        user.email = Milo;
                        context.SaveChanges();

                        MessageBox.Show("Почта успешно изменена!");
                    }
                    else
                    {
                        MessageBox.Show("Неверно введен e-mail!");
                    }
                }
                if (Pass.Text.Length >= 1 && Mail.Text.Length >= 1)
                {
                    if (Pass.Text.Length > 6 && Pass.Text.Any(char.IsPunctuation))
                    {
                        if (Mail.Text.Contains("@") && Mail.Text.Contains("."))
                        {
                            var userId = ide;

                            var context = new Appdbcontext();

                            var user = context.Users.SingleOrDefault(x => x.id == ide);

                            user.password = Pass.Text;
                            user.email = Mail.Text;
                            context.SaveChanges();
                            MessageBox.Show("Почта и пароль успешно изменены!");
                        }
                        else
                        {
                            MessageBox.Show("Неверно введен e-mail!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Пароль должен отвечать следующим требованиям:" +
                       "\n• Длина не менее 6 символов" +
                      "Включать в себя спец. символы");
                    }
                }
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}

