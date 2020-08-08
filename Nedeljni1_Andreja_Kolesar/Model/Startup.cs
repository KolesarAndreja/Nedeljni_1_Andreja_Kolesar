using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nedeljni1_Andreja_Kolesar.Model
{
    class Startup
    {
        public static string managerAccess;
        private Random rnd = new Random();
        string path = @"..\..\ManagerAccess.txt";
        public string managerString
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                char c;
                for(int i = 0; i < 8; i++)
                {
                    int random = rnd.Next(33, 123);
                    c = (char)random;
                    sb.Append(c);
                }
                return sb.ToString();
            }
        }
        public Startup()
        {
            //write manager string to txt and hold this string in static variable managerAccess
            managerAccess = managerString;
            File.AppendAllText(path, managerAccess + Environment.NewLine);
        }

    }
}
