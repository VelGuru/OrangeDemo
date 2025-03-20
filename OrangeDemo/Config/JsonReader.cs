using OrangeDemo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace OrangeDemo.Config
{
    public class JsonReader
    {

        public static LoginDTO LoadLoginData(string Data)
        {
            LoginDTO logindata= JsonSerializer.Deserialize<LoginDTO>(Data);
            return logindata;
        }
    }
}
