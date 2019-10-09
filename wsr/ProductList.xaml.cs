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
    /// Логика взаимодействия для ProductList.xaml
    /// </summary>
    public partial class ProductList : Window
    {
        DataTable dt = new DataTable();
        UserContext db = new UserContext();
        int IdUser;

        public ProductList(int iduser)
        {
            InitializeComponent();
            IdUser = iduser;
        }

        private void ListProduct_Loaded(object sender, RoutedEventArgs e)
        {
            dt.Columns.Add("Артикул");
            dt.Columns.Add("Название");
            dt.Columns.Add("Ширина");
            dt.Columns.Add("Длина");
            dt.Columns.Add("Картинка");
            dt.Columns.Add("Комментарии");

            var select = db.Product;
            foreach(Product product in select)
            {
                dt.Rows.Add(product.Id, product.name, product.width, product.length, product.image, product.comment);
            }
            listProduct.ItemsSource = dt.DefaultView;

        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            Director director = new Director(IdUser);
            director.Show();
            this.Close();
        }
    }
}
