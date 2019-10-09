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
    /// Логика взаимодействия для inventItem.xaml
    /// </summary>
    public partial class inventItem : Window
    {
        DataTable dt = new DataTable();
        UserContext db = new UserContext();
        string Predm;
        DateTime Data;
        double Diff;
        int IdUser;
        public inventItem(string predm, string data, double diff, int iduser)
        {
            InitializeComponent();
            Predm = predm;
            Data = DateTime.Parse(data);
            Diff = diff;
            IdUser = iduser;
        }

        private void DataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            dt.Columns.Add("Артикул");
            dt.Columns.Add("Наименование");
            dt.Columns.Add("Длина");
            dt.Columns.Add("Ширина");
            dt.Columns.Add("Количество на складе");
            dt.Columns.Add("Количество по документами");

            var sel = db.inventory.Where(selInv => selInv.date == Data && selInv.difference == Diff);
            var idInv = sel.FirstOrDefault().Id;
            if(Predm == "Ткань")
            {
                var select = db.inventoryItem.Join(db.cloth,
                    invIt => invIt.articul,
                    clth => clth.Id,
                    (invIt, clth) => new
                    {
                        Articul = invIt.articul,
                        Name = clth.name,
                        Length = invIt.length,
                        Width = invIt.width,
                        CountToSklad = invIt.countToSklad,
                        CountToDoc = invIt.countToDoc,
                        idInv = invIt.Idinv
                    }).Where(invIt => invIt.idInv == idInv);
                foreach(var item in select)
                {
                    dt.Rows.Add(item.Articul, item.Name, item.Length, item.Width, item.CountToSklad, item.CountToDoc);
                }
                itemlist.ItemsSource = dt.DefaultView;
            }
            else if(Predm == "Фурнитура")
            {
                var select = db.inventoryItem.Join(db.furniture,
                    invIt => invIt.articul,
                    Furnit => Furnit.Id,
                    (InvIt, Furnit) => new
                    {
                        Articul = InvIt.articul,
                        Name = Furnit.name,
                        Length = InvIt.length,
                        Width = InvIt.width,
                        CountToSklad = InvIt.countToSklad,
                        CountToDoc = InvIt.countToDoc,
                        idInv = InvIt.Idinv
                    }).Where(inventIt => inventIt.idInv == idInv);
                foreach(var item in select)
                {
                    dt.Rows.Add(item.Articul, item.Name, item.Length, item.Width, item.CountToSklad, item.CountToDoc);
                }
                itemlist.ItemsSource = dt.DefaultView;
            }


         
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            var ok = db.inventory.Where(inv => inv.date == Data && inv.difference == Diff);
            ok.FirstOrDefault().verific = 1;
            db.inventory.Create();
            db.SaveChanges();
            invent invent = new invent(IdUser);
            invent.Show();
            this.Close();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            invent invent = new invent(IdUser);
            invent.Show();
            this.Close();

        }

        private void Itemlist_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
