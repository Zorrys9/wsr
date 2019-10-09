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
    /// Логика взаимодействия для NewOrder.xaml
    /// </summary>
    public partial class NewOrder : Window
    {
        DataTable dt = new DataTable();
        UserContext db = new UserContext();
        int IdUser;
        public NewOrder(int iduser)
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

            var select = db.Product;

            foreach(var pr in select)
            {
                dt.Rows.Add(pr.Id, pr.name, pr.width, pr.length);
            }
            listProduct.ItemsSource = dt.DefaultView;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void NewOrdr_Click(object sender, RoutedEventArgs e)
        {
            int artId = listProduct.SelectedIndex;
            string art = dt.Rows[artId].ItemArray[0].ToString();
            int cnt = int.Parse(count.Text);

            OrderProduct item = new OrderProduct();
            item.product = art;
            item.count = cnt;
            MessageBox.Show(art);
        }
    }
}
