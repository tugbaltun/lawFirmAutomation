using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Continued.Entity;
using System.Data;
using System.Data.SqlClient;

namespace Continued
{
    public static class DataConnect
    {
        public static DataTable IU(string sqlquery, FoyKarti user)//Bağlantı methodu
        {
            SqlConnection conn = new SqlConnection("Data Source = .\\ ; Initial Catalog = dbProject; Integrated Security = SSPI; Persist Security Info = False;");
            SqlDataAdapter adapter;
            DataTable dataTable = new DataTable();
            SqlCommand cmd = new SqlCommand(sqlquery, conn);
            adapter = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@No", user.No);
            cmd.Parameters.AddWithValue("@Yetkili", user.Yetkili);
            if(user.Tarih.ToString()!= "1.01.0001 00:00:00") cmd.Parameters.AddWithValue("@Tarih", user.Tarih);
            cmd.Parameters.AddWithValue("@Icerik", user.Icerik);
            cmd.Parameters.AddWithValue("@Sonuc", user.Sonuc);
            cmd.Parameters.AddWithValue("@Durum", user.Durum ?? (object)DBNull.Value);
            adapter.Fill(dataTable);
            return dataTable;
        }

        public static DataTable Connect(string sqlquery)//Delete ve parametre içermeyenler için
        {
            SqlConnection conn = new SqlConnection("Data Source = .\\ ; Initial Catalog = dbProject; Integrated Security = SSPI; Persist Security Info = False;");
            SqlDataAdapter adapter;
            DataTable dataTable = new DataTable();
            SqlCommand cmd = new SqlCommand(sqlquery, conn);
            adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dataTable);
            return dataTable;
        }
    }
}
