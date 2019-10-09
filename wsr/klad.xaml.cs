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
    /// Логика взаимодействия для klad.xaml
    /// </summary>
    public partial class klad : Window
    {
        int IdUser;
        public klad(int iduser)
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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ClothList cl = new ClothList(IdUser);
            cl.Show();
            this.Close();
        }
        private void sklad_Click(object sender, RoutedEventArgs e)
        {
            sklad sk = new sklad(IdUser);
            sk.Show();
            this.Close();
        }

        private void furniture_Click(object sender, RoutedEventArgs e)
        {
            FurnitureList furnitureList = new FurnitureList(IdUser);
            furnitureList.Show();
            this.Close();
        }
    }
}
