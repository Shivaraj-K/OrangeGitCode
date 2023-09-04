using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeHRM.Utilities
{
    public  class JsonRead
    {
        public static String ReaderJsonDataId()
        {
            //C:\Users\SHIVARAJ GUTTEDAR\OrangeGit\Configauration\Data.json
            //C:\Users\SHIVARAJ GUTTEDAR\source\repos\OrangeHRM\bin\Debug\net6.0\
            // C: \Users\SHIVARAJ GUTTEDAR\source\repos\OrangeHRM\Configauration\Data.json
            Console.WriteLine(AppDomain.CurrentDomain.BaseDirectory+"666");
            String path = AppDomain.CurrentDomain.BaseDirectory;
            String p = File.ReadAllText(path.Replace("bin\\Debug\\net6.0\\", "Configauration\\Data.json"));
            var jsonObject = JToken.Parse(p);
            String id = jsonObject.SelectToken("id").Value<String>();
            return id;
        }
    }
}
