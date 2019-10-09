using System;
using System.Collections.Generic;
using System.Data;
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
    /// Логика взаимодействия для ClothList.xaml
    /// </summary>
    public partial class ClothList : Window
    {
        int IdUser;
        public ClothList(int iduser)
        {
            InitializeComponent();
            IdUser = iduser;
        }

        private void Listcloth_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Listcloth_Loaded(object sender, RoutedEventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Артикул");
            dt.Columns.Add("Наименование");
            dt.Columns.Add("Цвет");
            dt.Columns.Add("Рисунок");
            dt.Columns.Add("Состав");
            dt.Columns.Add("Ширина");
            dt.Columns.Add("Длина");
            dt.Columns.Add("Цена");
            listcloth.ItemsSource = dt.DefaultView;
            listcloth.Width = 1000;
            
            listcloth.MaxWidth = this.Width - 200;
            using (UserContext db = new UserContext())
            {
                var select = db.cloth;
                foreach (Cloth cloth in select)
                { 
                    dt.Rows.Add(cloth.Id, cloth.name,cloth.color, cloth.figure,cloth.contnt,cloth.width,cloth.length,cloth.sale);
                }

            }
            listcloth.ItemsSource = dt.DefaultView;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            klad klad = new klad(IdUser);
            klad.Show();
            this.Close();
        }

        private void sklad_Click(object sender, RoutedEventArgs e)
        {
            clothSklad sklad = new clothSklad(IdUser);
            sklad.Show();
            this.Close();
        }
    }
}
