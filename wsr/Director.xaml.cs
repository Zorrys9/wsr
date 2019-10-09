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

namespace wsr
{
    /// <summary>
    /// Логика взаимодействия для Director.xaml
    /// </summary>
    public partial class Director : Window
    {
        int IdUser;
        public Director(int iduser)
        {
            InitializeComponent();
            IdUser = iduser;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }

        private void invent_Click(object sender, RoutedEventArgs e)
        {
            invent invent = new invent(IdUser);
            invent.Show();
            this.Close();
        }

        private void unit_Click(object sender, RoutedEventArgs e)
        {
            Unit unit = new Unit(IdUser);
            unit.Show();
            this.Close();
        }

        private void Product_Click(object sender, RoutedEventArgs e)
        {
            ProductList productList = new ProductList(IdUser);
            productList.Show();
            this.Close();
        }

        private void sklad_Click(object sender, RoutedEventArgs e)
        {
            sklad sklad = new sklad(IdUser);
            sklad.Show();
            this.Close();
        }
    }
}
