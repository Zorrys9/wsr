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
    /// Логика взаимодействия для delFurniture.xaml
    /// </summary>
    public partial class delFurniture : Window
    {
        int IdUser;
        DataTable dt = new DataTable();
        UserContext db = new UserContext();
        public delFurniture(int iduser)
        {
            InitializeComponent();
            IdUser = iduser;
            dt.Columns.Add("Артикул");
            dt.Columns.Add("Ширина");
            dt.Columns.Add("Длина");
            dt.Columns.Add("Количество");
            dellist.ItemsSource = dt.DefaultView;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string[] listfur = new string[4];

            for (int i = 0; i < dellist.Items.Count - 1; i++)
            {
                listfur = db.ArrayItem(i, dt);

                string art = listfur[0];
                double width = double.Parse(listfur[1]);
                double length = double.Parse(listfur[2]);
                int count = int.Parse(listfur[3]);

                var select = db.kladFurniture.Where(kladFur => kladFur.furniture == art && kladFur.length == length && kladFur.width == width);

                if (select.Count() != 0)
                {
                    int Id = select.FirstOrDefault().Id;

                    kladFurniture klad = db.kladFurniture.Find(Id);
                    if(klad.count >= count)
                    {
                        klad.count -= count;
                        db.kladFurniture.Create();
                        db.SaveChanges();
                        MessageBox.Show("Списание товаров прошло успешно");
                        furnitureSklad furnitureSklad = new furnitureSklad(IdUser);
                        furnitureSklad.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Запрошенного количества нет на складе");
                    }


                }
                else
                {
                    MessageBox.Show("Такого товара не существует");
                }
            }

        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            furnitureSklad furnitureSklad = new furnitureSklad(IdUser);
            furnitureSklad.Show();
            this.Close();
        }
    }
}
