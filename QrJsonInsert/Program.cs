using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using static DataLibrary.BusinessLogic.QrProcessor;

namespace QrJsonInsert
{
    internal class Program
    {
        [DllImport(@"C:\Users\mesih\source\repos\QrDetector\Release\QrDetector.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern System.IntPtr read_qr(string s, out IntPtr strings, out int count);
        static void Main(string[] args)
        {
            List<string> qrStrings = new List<string>();
            while (!Console.KeyAvailable)
            {
                IntPtr stringsPtr;
                int count;
                try
                {
                    read_qr("E:/Unity Projects/UAV_QR_Decode/Records/out.png", out stringsPtr, out count);
                }
                catch (Exception)
                {
                    //Console.WriteLine("Null\n");
                    continue;
                }

                string[] strings = ConvertToStringArray(stringsPtr, count);
                foreach (string s in strings)
                {
                    if (!qrStrings.Contains(s))
                    {
                        qrStrings.Add(s);
                        try
                        {
                            QrModel qrModel = JsonConvert.DeserializeObject<QrModel>(s, new JsonSerializerSettings { DateFormatString = "dd.MM.yyyy" });
                            CreateQr(qrModel.GUID, qrModel.PID, qrModel.Description, qrModel.Quantity, qrModel.Source, qrModel.Destinition, qrModel.Date);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Database hatasi");
                            //throw e;
                        }
                        Console.WriteLine(s);
                    }
                }


                FreeStrings(stringsPtr, count); 
            }
        }

        // Define a helper method to convert the string array
        public static string[] ConvertToStringArray(IntPtr strings, int count)
        {
            string[] result = new string[count];
            IntPtr[] pointers = new IntPtr[count];

            Marshal.Copy(strings, pointers, 0, count);

            for (int i = 0; i < count; i++)
            {
                result[i] = Marshal.PtrToStringAnsi(pointers[i]);
            }

            return result;
        }

        public static void FreeStrings(IntPtr strings, int count)
        {
            IntPtr[] pointers = new IntPtr[count];
            Marshal.Copy(strings, pointers, 0, count);

            for (int i = 0; i < count; i++)
            {
                Marshal.FreeCoTaskMem(pointers[i]);
            }

            Marshal.FreeCoTaskMem(strings);
        }
    }
}
