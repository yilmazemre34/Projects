using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MbisSystem.Model.Model;
using System.Data.Sql;
using System.Data.SqlClient;

namespace deneme.Tools
{
    public class isatama
    {
        static int sayac = 1;

        public static bool isata (Isler isler)
        {
            IsTakipEntities db = new IsTakipEntities();           
            bool atandi = false;
            if (sayac == 6)
            {
                sayac = 1;
            }
            isler.Atanan = sayac;
            var atananperson = db.Personels.Where(x => x.PersonelID == sayac).FirstOrDefault();
            isler.AtananIsim = atananperson.PersonelAd;
            atananperson.IsSayisi = atananperson.IsSayisi+1;
            db.Islers.Add(isler);
            db.Database.ExecuteSqlCommand("update Personel set Durum = 1 where PersonelID=@p1", new SqlParameter("@p1", sayac));
            db.SaveChanges();
            sayac++;
            atandi = true;
            

            return atandi;
        }
        
    }
}