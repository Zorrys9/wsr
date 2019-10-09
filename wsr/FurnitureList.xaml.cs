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
    /// Логика взаимодействия для FurnitureList.xaml
    /// </summary>
    public partial class FurnitureList : Window
    {
        DataTable dt = new DataTable();
        UserContext db = new UserContext();
        int IdUser;

        public FurnitureList(int iduser)
        {
            InitializeComponent();
            IdUser = iduser;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dt.Columns.Add("Артикул");
            dt.Columns.Add("Наименование");
            dt.Columns.Add("Ширина");
            dt.Columns.Add("Длина");
            dt.Columns.Add("Тип");
            dt.Columns.Add("Цена");
            dt.Columns.Add("Изображение");
            dt.Columns.Add("Вес");

            var select = db.furniture;
            furnitureList.MaxWidth = this.Width - 200;
            foreach(Furniture fur in select)
            {
                dt.Rows.Add(fur.Id, fur.name, fur.width, fur.length, fur.type, fur.sale, fur.image, fur.weigth);
            }

            furnitureList.ItemsSource = dt.DefaultView;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            klad klad = new klad(IdUser);
            klad.Show();
            this.Close();
        }

        private void sklad_Click(object sender, RoutedEventArgs e)
        {
            furnitureSklad furnitureSklad = new furnitureSklad(IdUser);
            furnitureSklad.Show();
            this.Close();
        }
    }
}
