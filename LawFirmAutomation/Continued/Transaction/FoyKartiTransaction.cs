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
using Continued.DAO;

namespace Continued.Transaction
{
    public class FoyKartiTransaction
    {
        public void Add(FoyKarti user)
        {
            DataConnect.IU("Insert Into FoyKarti(Yetkili, Tarih, Icerik, Sonuc, Durum) Values( @Yetkili,@Tarih,@Icerik,@Sonuc, @Durum)", user);
        }

        public List<FoyKarti> List(FoyKarti users)
        {
            return DAO.FoyKartiDAO.Listele("Select * from FoyKarti", users);
        }

        public List<FoyKarti> List(string sqlquery, FoyKarti user)
        {
            return DAO.FoyKartiDAO.Listele(sqlquery, user);
        }

        public void Update(FoyKarti user, int no)
        {
            // string sql = "Select * from FoyKarti Where Id = " + id + " ";
            string sqlquery = "Update FoyKarti Set Yetkili = @Yetkili, Tarih = @Tarih, Icerik = @Icerik, Sonuc = @Sonuc, Durum = @Durum Where No=" + no;
            DataConnect.IU(sqlquery, user);
        }

        public FoyKarti Select(string sqlquery, FoyKarti users)
        {
            return DAO.FoyKartiDAO.Select(sqlquery, users);
        }

        public void Delete(FoyKarti user, int no)
        {
            string sqlquery = "Delete from FoyKarti Where No = " + no;
            DataConnect.Connect(sqlquery);
        }
    }
}
