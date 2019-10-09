using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для Unit.xaml
    /// </summary>
    public partial class Unit : Window
    {
        UserContext db = new UserContext();
        int IdUser;
        public Unit(int iduser)
        {
            InitializeComponent();
            IdUser = iduser;
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Director director = new Director(IdUser);
            director.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string nameIn = @in.Text;
            string nameFrom = from.Content.ToString();
            double kf = 0;

            switch (nameFrom)
            {
                case "мм":
                    switch (nameIn)
                    {
                        case "м":
                            kf = 1000;
                            break;
                        case "см":
                            kf = 10;
                            break;
                        case "дм":
                            kf = 100;
                            break;
                    }
                    break;
                case "см":
                    switch (nameIn)
                    {
                        case "м":
                            kf = 100;
                            break;
                        case "мм":
                            kf = 0.1;
                            break;
                        case "дм":
                            kf = 10;
                            break;
                    }
                    break;
                case "дм":
                    switch (nameIn)
                    {
                        case "м":
                            kf = 10;
                            break;
                        case "см":
                            kf = 0.1;
                            break;
                        case "мм":
                            kf = 0.01;
                            break;
                    }
                    break;
                case "м":
                    switch (nameIn)
                    {
                        case "мм":
                            kf = 0.001;
                            break;
                        case "см":
                            kf = 0.1;
                            break;
                        case "дм":
                            kf = 0.01;
                            break;
                    }
                    break;
            }
            var kladFurniture = db.kladFurniture;
            if (kladFurniture.Count() != 0)
            {
                foreach (kladFurniture klFur in kladFurniture)
                {
                    klFur.length *= kf;
                    klFur.width *= kf;
                    db.kladFurniture.Create();
                }
            }
            var Furniture = db.furniture;
            if (Furniture.Count() != 0)
            {
                foreach (Furniture Fur in Furniture)
                {
                    Fur.length *= kf;
                    Fur.width *= kf;
                    Fur.weigth *= kf;
                    db.furniture.Create();
                }
            }
            var kladCloth = db.kladCloth;
            if (kladCloth.Count() != 0)
            {
                foreach (kladCloth klCloth in kladCloth)
                {
                    klCloth.length *= kf;
                    klCloth.width *= kf;
                    db.kladCloth.Create();
                }
            }
            var Cloth = db.cloth;
            if (Cloth.Count() != 0)
            {
                foreach (Cloth cloth in Cloth)
                {
                    cloth.length *= kf;
                    cloth.width *= kf;
                    db.cloth.Create();
                }
            }
            var InvItem = db.inventoryItem;
            if (InvItem.Count() != 0)
            {
                foreach (var Item in InvItem)
                {
                    Item.length *= kf;
                    Item.width *= kf;
                    db.inventoryItem.Create();
                }
            }
            var Product = db.Product;
            if (Product.Count() != 0)
            {
                foreach (var prod in Product)
                {
                    prod.length *= kf;
                    prod.width *= kf;
                    db.Product.Create();
                }
            }
            var UnitFrom = db.Units.Where(un => un.UnitName == nameFrom );
            var UnitIn = db.Units.Where(un => un.UnitName == nameIn );

            UnitFrom.FirstOrDefault().currentUnit = 0;
            UnitIn.FirstOrDefault().currentUnit = 1;
            
            

            db.SaveChanges();
            MessageBox.Show("Единица измерения успешно изменена");
            Director director = new Director(IdUser);
            director.Show();
            this.Close();
            

            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            from.Content = db.Units.Where(un => un.currentUnit == 1).FirstOrDefault().UnitName.ToString();

            var select = db.Units.Where(un=> un.currentUnit == 0);
            
            foreach(Unitt un in select)
            {    
                @in.Items.Add(un.UnitName);
                
            }

        }
    }
}
