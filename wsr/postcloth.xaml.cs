using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
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
    /// Логика взаимодействия для postcloth.xaml
    /// </summary>
    
    public partial class postcloth : Window
    {
        int IdUser;
        DataTable dt = new DataTable();
        UserContext db = new UserContext();
        
       
        public postcloth(int iduser)
        {
            InitializeComponent();
            IdUser = iduser;
            clothSklad cs = new clothSklad(IdUser);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string[] listcloth = new string[4];

            for (int i = 0; i < postCloth.Items.Count-1; i++)
            {
                listcloth = db.ArrayItem(i, dt);
                string art = listcloth[0];
                double wdth = double.Parse(listcloth[1]);
                double lngth = double.Parse(listcloth[2]);
                int cnt = int.Parse(listcloth[3]);

                var select = db.kladCloth.Where(kc => kc.cloth == art && kc.width == wdth && kc.length == lngth);
                if(select.Count() != 0)
                {
                    cnt += select.FirstOrDefault().count;
                    int id = select.FirstOrDefault().Id;

                    kladCloth update = db.kladCloth.Find(id);
                    update.count = cnt;
                    db.kladCloth.Create();
                    db.SaveChanges();
                }
                else
                {
                    kladCloth item = new kladCloth();
                    item.cloth = art;
                    item.count = cnt;
                    item.length = lngth;
                    item.width = wdth;
                    var insert = db.kladCloth.Add(item);
                    db.SaveChanges();
                   

                }
            }
            MessageBox.Show("Товары успешно добавлены на склад");
            clothSklad cs = new clothSklad(IdUser);
            cs.Show();
            this.Close();

        }

        private void Window_Closed(object sender, EventArgs e)
        {
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dt.Columns.Add("Артикул");
            dt.Columns.Add("Ширина");
            dt.Columns.Add("Длина");
            dt.Columns.Add("Количество");

            postCloth.AutoGenerateColumns = true;
            postCloth.ItemsSource = dt.DefaultView;

        }

        private void exit_Click_1(object sender, RoutedEventArgs e)
        {
            clothSklad cs = new clothSklad(IdUser);
            cs.Show();
            this.Close();
        }
    }
}
