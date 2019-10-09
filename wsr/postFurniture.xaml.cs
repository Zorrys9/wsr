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
    /// Логика взаимодействия для postFurniture.xaml
    /// </summary>
    public partial class postFurniture : Window
    {
        UserContext db = new UserContext();
        DataTable dt = new DataTable();
        int IdUser;
        public postFurniture(int iduser)
        {
            IdUser = iduser;
            InitializeComponent();
            dt.Columns.Add("Артикул");
            dt.Columns.Add("Ширина");
            dt.Columns.Add("Длина");
            dt.Columns.Add("Количество");
            dt.Columns[4].DefaultValue = "";
            postFur.ItemsSource = dt.DefaultView;
     

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string[] listFur = new string[4];


            for(int i=0; i< postFur.Items.Count-1; i++)
            {
                listFur = db.ArrayItem(i, dt);

                string art = listFur[0];
                double width = double.Parse(listFur[1]);
                double length = double.Parse(listFur[2]);
                double count = double.Parse(listFur[3]);

                var select = db.kladFurniture.Where(kladFur => kladFur.furniture == art && kladFur.length == length && kladFur.width == width);

                if(select.Count() != 0)
                {
                     count += select.FirstOrDefault().count;
                    int Id = select.FirstOrDefault().Id;

                    kladFurniture update = db.kladFurniture.Find(Id);
                    update.count = count;
                    db.kladFurniture.Create();
                    db.SaveChanges();

                }
                else
                {
                    kladFurniture item = new kladFurniture();
                    item.furniture = art;
                    item.length = length;
                    item.width = width;
                    item.count = count;
                    var insert = db.kladFurniture.Add(item);
                    db.SaveChanges();
                }
            }
            MessageBox.Show("Товары успешно добавлены на склад");
            furnitureSklad furnitureSklad = new furnitureSklad(IdUser);
            furnitureSklad.Show();
            this.Close();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            furnitureSklad furniture = new furnitureSklad(IdUser);
            furniture.Show();
            this.Close();
        }

    }
}
