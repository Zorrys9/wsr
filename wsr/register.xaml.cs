using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace wsr
{
    /// <summary>
    /// Логика взаимодействия для register.xaml
    /// </summary>
    public partial class register : Window
    {
        public register()
        {
            InitializeComponent();
        }

        private void Reg_Click(object sender, RoutedEventArgs e)
        {

            if (login.Text == "" || password.Text == "" || roll.Text == "")
            {
                MessageBox.Show("Вы заполнили не все поля!");
                if (login.Text == "")
                {
                    login.BorderBrush = System.Windows.Media.Brushes.Red;
                }
                if (password.Text == "")
                {
                    password.BorderBrush = System.Windows.Media.Brushes.Red;
                }
                if (roll.Text == "")
                {
                    roll.BorderBrush = System.Windows.Media.Brushes.Red;
                }

            }
            else
            {
                string fio = "";
                if (fam.Text != "" || nam.Text != "") {fio = fam.Text + " " + nam.Text; }
                using (UserContext db = new UserContext())
                {
                    User us1 = new User {login = login.Text, password = password.Text, rolles = roll.Text };
                    db.Users.Add(us1);
                    db.SaveChanges();
                }
                MessageBox.Show("Вы успешно зарегистрированы!!");
                this.Close();
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();

        }

        private void Login_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
