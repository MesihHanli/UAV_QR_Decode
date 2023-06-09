using DataLibrary.DataAccess;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.BusinessLogic
{
    public static class QrProcessor
    {
        public static int CreateQr(string guid, int pid, string description, int quantity, int source, int destinition, DateTime date)
        {
            QrModel data = new QrModel
            {
                GUID = guid,
                PID = pid,
                Description = description,
                Quantity = quantity,
                Source = source,
                Destinition = destinition,
                Date = date
            };

            string sql = @"insert into dbo.Qr (GUID, PID, Description, Quantity, Source, Destinition, Date)
                            values (@GUID, @PID, @Description, @Quantity, @Source, @Destinition, @Date);";

            return SqlDataAccess.SaveData(sql, data);
        }

        public static List<QrModel> LoadQr()
        {
            string sql = @"select GUID, PID, Description, Quantity, Source, Destinition, Date from dbo.Qr;";

            return SqlDataAccess.LoadData<QrModel>(sql);
        }
        public static List<CombinedQrModel> LoadCombinedQr()
        {
            string sql = @"SELECT PName, Description, Quantity, sc.cname as SourceCity, dc.cname as DestinitionCity, Date
                            FROM dbo.Qr
                            LEFT JOIN dbo.Product ON Qr.pid = Product.pid
                            LEFT JOIN dbo.City sc ON Qr.Source = sc.cid
                            LEFT JOIN dbo.City dc ON Qr.Destinition = dc.cid;";

            return SqlDataAccess.LoadData<CombinedQrModel>(sql);
        }

        public static List<CombinedQrModel> LoadCombinedQr(string searchPhrase)
        {
            string sql = $@"SELECT PName, Description, Quantity, sc.cname as SourceCity, dc.cname as DestinitionCity, Date
                            FROM dbo.Qr
                            LEFT JOIN dbo.Product ON Qr.pid = Product.pid
                            LEFT JOIN dbo.City sc ON Qr.Source = sc.cid
                            LEFT JOIN dbo.City dc ON Qr.Destinition = dc.cid
                            WHERE PName like '%{searchPhrase}%' or Description like '%{searchPhrase}%' or Quantity like '%{searchPhrase}%'
                             or sc.cname like '%{searchPhrase}%' or dc.cname like '%{searchPhrase}%' or Date like '%{searchPhrase}%';";
            return SqlDataAccess.LoadData<CombinedQrModel>(sql);
        }
    }
}
