using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Reflection;
using System.Linq.Expressions;

namespace dbConsoleApp
{
    internal class Program
    {
        public string connString = "Data Source=.;Initial Catalog=dotNetLab;User ID=sa;Password=123456";
        public SqlConnection conn;
        public Program()
        {
            conn = new SqlConnection(connString);
        }

        void DisplayData()
        {
            string sql = "select * from AddressBook";
            SqlCommand cmd = new SqlCommand(sql, conn);
            List<AddressBook> list = new List<AddressBook>();
            conn.Open();
            SqlDataReader dr =cmd.ExecuteReader();
            while (dr.Read())
            {
                AddressBook addressBook = new AddressBook();
                addressBook.ID=(int)dr["ID"];
                addressBook.Mobile = dr["Mobile"].ToString();
                addressBook.Address = dr["Address"].ToString();
                addressBook.Name = dr["Name"].ToString();
                list.Add(addressBook);

            }
            Console.WriteLine("Data are as follow : ");
            foreach(AddressBook address in list)
            {
                 Console.WriteLine(address.ID+" "+ address.Name + " "+address.Mobile + " "+address.Address);
            }
            conn.Close();
        }

        void InsertData()
        {
            string name, address, number;

            Console.WriteLine("Name :");
            name = Console.ReadLine();

            Console.WriteLine("Address :");
            address = Console.ReadLine();

            Console.WriteLine("Number :");
            number = Console.ReadLine();
            string sql = "insert into AddressBook values('" + name + "','" + address + "','" + number + "')";
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            Console.WriteLine("Data inserted");
        }

        Boolean checkID()
        {

        }
        static void Main(string[] args)
        {
            Program p= new Program();
            int go = 1;

            while (go==1)
            {
                int opt;
                Console.WriteLine("1 for insert, 2 for select, 3 for update, 4 for delete");
                opt = Int32.Parse(Console.ReadLine());
                switch (opt)
                {
                    case 1:
                        p.InsertData();
                        Console.WriteLine("press 1 to continue 0 to exit : ");
                        go = Int32.Parse(Console.ReadLine());
                        break;
                    case 2:
                        p.DisplayData();
                        Console.WriteLine("press 1 to continue 0 to exit : ");
                        go = Int32.Parse(Console.ReadLine());
                        break;
                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }
            }
        }
    }

    public class AddressBook
    {
        public int ID { get; set; }
        public String Name { get; set; }
        public String Address { get; set; }
        public String Mobile { get; set; }
    }
}
