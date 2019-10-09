using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wsr
{
    class UserContext : DbContext
    {
        public string[] ArrayItem(int i, DataTable dt)
        {
            string[] mass = new string[4];
            for (int j = 0; j < mass.Length; j++)
            {
                    mass[j] = dt.Rows[i].ItemArray[j].ToString();
            }

            return mass;
        }
        public UserContext()
            : base("DBconnection")
        { }
    public DbSet<User> Users { get;set; }
    public DbSet<Cloth> cloth { get;set; }
    public DbSet<Unitt> Units { get;set; }
    public DbSet<Furniture> furniture { get;set; }
    public DbSet<kladCloth> kladCloth { get;set; }
    public DbSet<Product> Product { get;set; }
    public DbSet<kladFurniture> kladFurniture { get;set; }
    public DbSet<OrderProduct> OrderProducts { get;set; }
    public DbSet<inventoryItog> inventory { get;set; }
    public DbSet<inventoryItem> inventoryItem { get;set; }
    }

    class User
    {
        public int Id { get; set; }
        public string fio { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public string rolles { get; set; }
    }
    class Cloth
    {
        public string Id { set; get; }
        public string name { get; set; }
        public string color { get; set; }
        public string figure { get; set; }
        public string contnt { get; set; }
        public double width { get; set; }
        public double length { get; set; }
        public decimal sale { get; set; }
    }
    class kladCloth
    {
        public int Id { get; set; }
        public string cloth { get; set; }
        public double width { get; set; }
        public double length { get; set; }
        public int count { get; set; }
        
    }
    class kladFurniture
    {
        public int Id { get; set; }
        public string furniture { get; set; }
        public double width { get; set; }
        public double length { get; set; }
        public double count { get; set; }

    }
    class inventoryItog
    {
        public int Id { get; set; }
        public DateTime date { get; set; }
        public string item { get; set; }
        public int difference { get; set; }
        public int verific { get; set; }
    }
    class inventoryItem
    {
        public int Id { get; set; }
        public int Idinv { get; set; }
        public string articul { get; set; }
        public int countToDoc { get; set; }
        public int countToSklad { get; set; }
        public double length { get; set; }
        public double width { get; set; }
    }
    class Furniture
    {
        public string Id { get; set; }
        public string name { get; set; }
        public double width { get; set; }
        public double length { get; set; }
        public string type { get; set; }
        public decimal sale { get; set; }
        public double weigth { get; set; }
        public object image { get; set; }
    }
   partial class Unitt
    {
        public int Id { get; set; }
        public string UnitName { get; set; }
        public int currentUnit { get; set; }
    }
    partial class Product
    {
        public string Id { get; set; }
        public string name { get; set; }
        public double width { get; set; }
        public double length { get; set; }
        public object image { get; set; }
        public string comment { get; set; }
    }
    class OrderProduct
    {
        public int Id { get; set; }
        public string product { get; set; }
        public int count { get; set; }
        public int client { get; set; }
    }

}
    
