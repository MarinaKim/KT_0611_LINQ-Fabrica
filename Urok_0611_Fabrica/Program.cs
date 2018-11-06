using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Configuration;
using System.Data.Common;
using System.Data.OleDb;


namespace AdoLesson6
{
    public class Equipment
    {
        public int intEquipmentID { get; set; }
        public int intGarageRoom { get; set; }

        public int intMAnufactureID { get; set; }
        public int intModelID { get; set; }
        public int strManuYear { get; set; }

        public override string ToString()
        {
            string str = string.Format("intEquipmentID:{0}\n\t intGarageRoom:{1}\n\t  intMAnufactureID:{2}\n\t intModelID:{3}\n\t strManuYear:{4}\n\t", intEquipmentID, intGarageRoom, intMAnufactureID, intModelID, strManuYear);
            return base.ToString();
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            //получить фабрику
            string factory = ConfigurationManager.AppSettings["factory"];

            DbProviderFactory provider = DbProviderFactories.GetFactory(factory);

            //использование фабрики для получения соединения
            DbConnection con = provider.CreateConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            //Создать команду
            DbCommand cmd = provider.CreateCommand();
            cmd.CommandText = ConfigurationManager.AppSettings["newEquipment"];
            cmd.Connection = con;

            //Открыть соединение получить данные
            using (con)
            {
                con.Open();
                DbDataReader reader = cmd.ExecuteReader();
                List<Equipment> newEquipment = new List<Equipment>();


                while (reader.Read())
                {
                    Equipment equipment = new Equipment();
                    equipment.intGarageRoom = Convert.ToInt32(reader["intEquipmentID"]);
                    equipment.intGarageRoom = Convert.ToInt32(reader["intGarageRoom"]);
                    equipment.intMAnufactureID = Convert.ToInt32(reader["intManufactureID"]);
                    equipment.intModelID = Convert.ToInt32(reader["intModelID"]);
                    equipment.strManuYear = Convert.ToInt32(reader["strManuYear"]);

                    Console.WriteLine("Гаражный номер: {0}\n\t серийный номер: {1}\n", reader["intGarageRoom"], reader["strSerialNo"]);
                }
            }
        }
    }
}












