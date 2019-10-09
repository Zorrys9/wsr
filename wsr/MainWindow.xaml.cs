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

namespace wsr
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int IdUser;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            register reg = new register();
            reg.Show();
            this.Close();
        }

        private void Inp_Click(object sender, RoutedEventArgs e)
        {
            if(login.Text=="" || password.Text == "")
            {
                MessageBox.Show("Вы заполнили не все поля");
                if (login.Text == "") { login.BorderBrush = System.Windows.Media.Brushes.Red; }
                if (password.Text == "") { password.BorderBrush = System.Windows.Media.Brushes.Red; }

            }
            else
            {
                using(UserContext db = new UserContext())
                {
                    try
                    {
                        var select = db.Users.Where(u => u.login == login.Text || u.password == password.Text);
                        IdUser = select.FirstOrDefault().Id; 
                        string rol = select.FirstOrDefault().rolles;
                        switch (rol)
                        {
                            case "Директор":
                                Director dir = new Director(IdUser);
                                dir.Show();
                                this.Close();
                                break;
                            case "Заказчик":
                                Client cl = new Client(IdUser);
                                cl.Show();
                                this.Close();
                                break;
                            case "Менеджер":
                                Manager mngr = new Manager(IdUser);
                                mngr.Show();
                                this.Close();
                                break;
                            case "Кладовщик":
                                klad kld = new klad(IdUser);
                                kld.Show();
                                this.Close();
                                break;
                        }
                    }
                    catch
                    {
                        var select = db.Users.Where(u => u.login == login.Text);
                        try
                        {
                            string passw = select.FirstOrDefault().password;
                            if(passw != password.Text) { MessageBox.Show("Неверно введен пароль!"); }
                        }
                        catch
                        {
                            MessageBox.Show("Такого пользователя не существует");
                        }
                    }
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            klad kld = new klad(IdUser);
            kld.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Director director = new Director(IdUser);
            director.Show();
            this.Close();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Client client = new Client(IdUser);
            client.Show();
            this.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Manager manager = new Manager(IdUser);
            manager.Show();
            this.Close();
        }
    }
}
