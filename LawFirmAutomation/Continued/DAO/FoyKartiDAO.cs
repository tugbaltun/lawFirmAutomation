using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using Continued.Entity;
using System.Data.SqlClient;
using System.Configuration;

namespace Continued.DAO
{
    public class FoyKartiDAO:FoyKarti
    {
        public static FoyKarti Select(string sqlquery, FoyKarti users)
        {
            DataTable table = DataConnect.Connect(sqlquery);
            FoyKarti user = new FoyKarti();
            user.No = Convert.ToInt32(table.Rows[0]["No"].ToString());
            user.Yetkili = table.Rows[0]["Yetkili"].ToString();
            user.Tarih = Convert.ToDateTime(table.Rows[0]["Tarih"].ToString());
            user.Icerik = table.Rows[0]["Icerik"].ToString();
            user.Sonuc = table.Rows[0]["Sonuc"].ToString();
            user.Durum = table.Rows[0]["Durum"].ToString();
            //user.Durum = Convert.ToBoolean(table.Rows[0]["Durum"].ToString());
            return user;
        }

        public static List<FoyKarti> Listele(string sqlquery, FoyKarti users)
        {
            DataTable table = DataConnect.Connect(sqlquery);
            //DataTable table = DataConnect.bringTable(sqlquery);
            List<FoyKarti> userList = new List<FoyKarti>();
            foreach (DataRow item in table.Rows)
            {
                FoyKarti user = new FoyKarti();
                user.No = Convert.ToInt32(item["No"].ToString());
                user.Yetkili = item["Yetkili"].ToString();
                user.Tarih = Convert.ToDateTime(item["Tarih"].ToString());
                user.Icerik = item["Icerik"].ToString();
                user.Sonuc = item["Sonuc"].ToString();
                user.Durum = item["Durum"].ToString();
                userList.Add(user);
            }
            return userList;
        }
    }
}
