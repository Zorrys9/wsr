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
    /// Логика взаимодействия для delcloth.xaml
    /// </summary>
    public partial class delcloth : Window
    {
        DataTable dt = new DataTable();
        UserContext db = new UserContext();
    
        int IdUser;
        public delcloth(int iduser)
        {
            InitializeComponent();
            IdUser = iduser;

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
          
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            clothSklad cs = new clothSklad(IdUser);
            cs.Show();
        }

        private void inpsave_Click(object sender, RoutedEventArgs e)
        {
            string[] list = new string[4];
            for (int i = 0; i < listcloth.Items.Count - 1; i++)
            {
                             
                list = db.ArrayItem(i, dt);

                string art = list[0];
                double wdth = double.Parse(list[1]);
                double lngth = double.Parse(list[2]);
                int cnt = int.Parse(list[3]);

                var select = db.kladCloth.Where(kcl => kcl.cloth==art && kcl.width == wdth && kcl.length == lngth);
                if(select.Count() != 0)
                {
                    if (select.FirstOrDefault().count >= cnt)
                    {
                        cnt = select.FirstOrDefault().count - cnt ;

                        kladCloth item = db.kladCloth.Find(select.FirstOrDefault().Id);
                        item.count = cnt;
                        db.kladCloth.Create();
                        db.SaveChanges();
                        MessageBox.Show("Данные успешно обновлены");
                        clothSklad cs = new clothSklad(IdUser);
                        cs.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Запрошенного количества товара нет на складе");
                    }
                    
                    

                }
                else
                {
                    MessageBox.Show("Одного из товаров не существует");
                }

            }

        }

        private void Listcloth_Loaded(object sender, RoutedEventArgs e)
        {
            dt.Columns.Add("Артикул");
            dt.Columns.Add("Ширина");
            dt.Columns.Add("Длина");
            dt.Columns.Add("Количество");
            listcloth.ItemsSource = dt.DefaultView;
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            clothSklad cs = new clothSklad(IdUser);
            cs.Show();
            this.Close();
        }
    }
}
