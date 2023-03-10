using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPongManagmantSystem.Service.Common
{
    public static class CreateJsonFile
    {
        public static void CreateAsync(string text) 
        {
            string path = "files/file.json";
            File.WriteAllText(path, text);
        }
    }
}
