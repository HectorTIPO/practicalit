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
    /// Логика взаимодействия для WHOD.xaml
    /// </summary>
    public partial class WHOD : Window
    {
        public int _id;
        public WHOD( int id)
        {
            InitializeComponent();

            _id = id;

            int find = id;

            var context = new Appdbcontext();

            var user = context.Users.SingleOrDefault(x => x.id == id);

            string Finde = user.login;

           HelloUser.Text = "Здравствуйте, " + Finde + "!";
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Environment.Exit(0);
        }


        private void Change_Click_1(object sender, RoutedEventArgs e)
        {
            lk lk = new (_id);
            lk.Show();
            this.Hide();
        }
    }
}
