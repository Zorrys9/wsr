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
    /// Логика взаимодействия для sklad.xaml
    /// </summary>
    public partial class sklad : Window
    {
        int IdUser;
        public sklad(int iduser)
        {
            InitializeComponent();
            IdUser = iduser;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            klad kl = new klad(IdUser);
            kl.Show();
            this.Close();
        }

        private void clth_Click(object sender, RoutedEventArgs e)
        {
            clothSklad cs = new clothSklad(IdUser);
            cs.Show();
            this.Close();
        }

        private void frnt_Click(object sender, RoutedEventArgs e)
        {
            furnitureSklad fs = new furnitureSklad(IdUser);
            fs.Show();
            this.Close();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
        }
    }
}
