using MVCQrCode.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLibrary;
using static DataLibrary.BusinessLogic.QrProcessor;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using Microsoft.SqlServer.Server;
using Newtonsoft.Json.Converters;
using System.ComponentModel;


namespace MVCQrCode.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //ReadJsonFile(@"C:\Users\mesih\Desktop\qr.json");
            //Console.ReadKey();

            var data = LoadCombinedQr();
            List<CombinedQrModel> qrList = new List<CombinedQrModel>();
            foreach (var row in data) 
            {
                qrList.Add(new CombinedQrModel
                {
                    PName = row.PName,
                    Description = row.Description,
                    Quantity = row.Quantity,
                    SourceCity = row.SourceCity,
                    DestinitionCity = row.DestinitionCity,
                    Date = row.Date
                });
            }
            return View(qrList);
        }
        [HttpPost]
        public ActionResult Index(string searchPhrase)
        {
            var data = LoadCombinedQr(searchPhrase);
            List<CombinedQrModel> qrList = new List<CombinedQrModel>();
            foreach (var row in data)
            {
                qrList.Add(new CombinedQrModel
                {
                    PName = row.PName,
                    Description = row.Description,
                    Quantity = row.Quantity,
                    SourceCity = row.SourceCity,
                    DestinitionCity = row.DestinitionCity,
                    Date = row.Date
                });
            }
            return View(qrList);
        }

        [NonAction]
        private void ReadJsonFile(string filePath)
        {
            try
            {
                int ctr = 0;
                string jsonString;
                jsonString = System.IO.File.ReadAllText(filePath);
                List<QrModel> qrList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<QrModel>>(jsonString, new JsonSerializerSettings { DateFormatString = "dd.MM.yyyy" });
                foreach (var qr in qrList)
                {
                    ctr += CreateQr(qr.GUID, qr.PID, qr.Description, qr.Quantity, qr.Source, qr.Destinition, qr.Date);
                }
                ctr++;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}