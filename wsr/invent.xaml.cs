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
    /// Логика взаимодействия для invent.xaml
    /// </summary>
    public partial class invent : Window
    {
        UserContext db = new UserContext();
        DataTable dt = new DataTable();
        int IdUser;
        public invent(int iduser)
        {
            InitializeComponent();
            IdUser = iduser;
        }

        private void DataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            dt.Columns.Add("Дата проведения");
            dt.Columns.Add("Предмет");
            dt.Columns.Add("Разница");
            dt.Columns.Add("Утверждено");
            var select = db.inventory;
            string verif;
            foreach (inventoryItog itog in select)
            {
                if (itog.verific == 1) { verif = "Утверждено"; } else { verif = "Не утверждено"; }
                dt.Rows.Add(itog.date, itog.item, itog.difference,verif);
            }
            ListInvent.ItemsSource = dt.DefaultView;
        }

        private void ListInvent_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ListInvent_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            
        }

        private void ListInvent_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void ListInvent_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (ListInvent.SelectedCells.Count != 0) {
                var i = ListInvent.SelectedIndex;
                string data = dt.Rows[i].ItemArray[0].ToString();
                string predm = dt.Rows[i].ItemArray[1].ToString();
                double diff = double.Parse(dt.Rows[i].ItemArray[2].ToString());
                ListInvent.SelectedItem=null;
                inventItem inventItem = new inventItem(predm, data, diff, IdUser);
                inventItem.Show();
                this.Close();
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Director director = new Director(IdUser);
            director.Show();
            this.Close();
        }
    }
}
