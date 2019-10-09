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
    /// Логика взаимодействия для inventoryCloth.xaml
    /// </summary>
    public partial class inventoryCloth : Window
    {
       
        DataTable dt = new DataTable();
        UserContext db = new UserContext();
        string nameItem;
        int IdUser;
        public inventoryCloth(string name, int iduser)
        {
            InitializeComponent();
            nameItem = name;
            IdUser = iduser;
           
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dt.Columns.Add("Артикул");
            dt.Columns.Add("Ширина");
            dt.Columns.Add("Длина");
            dt.Columns.Add("Количество на складе");

            inventoryClothList.AutoGenerateColumns = true; 
            inventoryClothList.ItemsSource = dt.DefaultView;
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            clothSklad clothSkl = new clothSklad(IdUser);
            if (nameItem == "Ткань")
            {
                clothSkl.Show();
                this.Close();
            }
            else if(nameItem == "Фурнитура")
            {
                furnitureSklad furnitureSklad = new furnitureSklad(IdUser);
                furnitureSklad.Show();
                this.Close();
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string[] listInventory = new string[4];
            int cntDoc = 0;
            for(int i = 0; i < inventoryClothList.Items.Count - 1; i++)
            {
                listInventory =  db.ArrayItem(i, dt);
                cntDoc += int.Parse(listInventory[3]);
            }
            var select = db.kladCloth;
            int cntSkl = 0;

            foreach (kladCloth cloth in select)
            {
                cntSkl += cloth.count;
            }
            int diff = cntDoc - cntSkl;
            DateTime dat = DateTime.Parse(DateTime.Now.ToString("dd MMMM yyyy"));
            inventoryItog inventoryItog = new inventoryItog { date =  dat, item = nameItem, difference = diff};
            db.inventory.Add(inventoryItog);
            db.SaveChanges();
            var select2 = db.inventory.Where(inv=> inv.date == dat && inv.difference == diff && inv.item == nameItem);
            for (int i = 0; i < inventoryClothList.Items.Count - 1; i++)
            {
                listInventory = db.ArrayItem(i, dt);
                inventoryItem inventoryItm = new inventoryItem();
                inventoryItm.articul = listInventory[0];
                inventoryItm.length = double.Parse(listInventory[2]);
                inventoryItm.width = double.Parse(listInventory[3]);
                inventoryItm.Idinv = select2.FirstOrDefault().Id; 
                inventoryItm.countToDoc = cntDoc;
                inventoryItm.countToSklad = cntSkl;
                db.inventoryItem.Add(inventoryItm);

            }
            db.SaveChanges();
            clothSklad clothSkl = new clothSklad(IdUser);
            MessageBox.Show("Инвентаризация успешно сохранена");
            clothSkl.Show();
            this.Close();
        }
    }
}
