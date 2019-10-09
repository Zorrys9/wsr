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
    /// Логика взаимодействия для clothSklad.xaml
    /// </summary>
    public partial class clothSklad : Window
    {
        int IdUser;
        public clothSklad(int iduser)
        {
            InitializeComponent();
            IdUser = iduser;
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Skladcl_Loaded(object sender, RoutedEventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Рулон");
            dt.Columns.Add("Наименование ткани");
            dt.Columns.Add("Ширина");
            dt.Columns.Add("Длина");
            dt.Columns.Add("Количество");
            UserContext db = new UserContext();
            
                     var select = db.cloth.Join(db.kladCloth,
                    cl=> cl.Id,
                    kc => kc.cloth,
                    (cl,kc) => new
                    {
                        Id = kc.Id,
                        cloth = cl.name,
                        width = kc.width,
                        length = kc.length,
                        count = kc.count
                    });

                foreach (var scl in select)
                {
                    dt.Rows.Add(scl.Id, scl.cloth, scl.width, scl.length, scl.count);
                }
                skladcl.ItemsSource = dt.DefaultView;
        }

        private void Post_Click(object sender, RoutedEventArgs e)
        {
            postcloth pc = new postcloth(IdUser);
            pc.Show();
            this.Close();
        }
        private void del_Click(object sender, RoutedEventArgs e)
        {
            delcloth dc = new delcloth(IdUser);
            dc.Show();
            this.Close();
        }
        private void exit_Click(object sender, RoutedEventArgs e)
        {
            sklad skl = new sklad(IdUser);
            skl.Show();
            this.Close();
        }

        private void inv_Click(object sender, RoutedEventArgs e)
        {
            inventoryCloth invcl = new inventoryCloth("Ткань", IdUser);
            invcl.Show();
            this.Close();
        }
    }
}
