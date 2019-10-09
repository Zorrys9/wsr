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
    /// Логика взаимодействия для furnitureSklad.xaml
    /// </summary>
    public partial class furnitureSklad : Window
    {
        DataTable dt = new DataTable();
        UserContext db = new UserContext();
        int IdUser;
        public furnitureSklad(int iduser)
        {
            InitializeComponent();
            IdUser = iduser;
        }

        private void DataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            string[] listfurniture = new string[4];
            dt.Columns.Add("Артикул");
            dt.Columns.Add("Наименование");
            dt.Columns.Add("Ширина");
            dt.Columns.Add("Длина");
            dt.Columns.Add("Количество");

            var select = db.kladFurniture.Join(db.furniture,
                klFur => klFur.furniture,
                Fur => Fur.Id,
                (klFur,Fur) => new
                {
                    Id = klFur.furniture,
                    name = Fur.name,
                    width = klFur.width,
                    length = klFur.length,
                    count = klFur.count
                });

            foreach(var klfur in select)
            {
                dt.Rows.Add(klfur.Id, klfur.name, klfur.width, klfur.length, klfur.count);
            }
            SkladFurniture.ItemsSource = dt.DefaultView;


        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            sklad sklad = new sklad(IdUser);
            sklad.Show();
            this.Close();
        }

        private void Post_Click(object sender, RoutedEventArgs e)
        {
            postFurniture postFurniture = new postFurniture(IdUser);
            postFurniture.Show();
            this.Close();
        }

        private void inv_Click(object sender, RoutedEventArgs e)
        {
            inventoryCloth invcl = new inventoryCloth("Фурнитура", IdUser);
            invcl.Show();
            this.Close();
        }

        private void spis_Click(object sender, RoutedEventArgs e)
        {
            delFurniture delFurniture = new delFurniture(IdUser);
            delFurniture.Show();
            this.Close();
        }
    }
}
