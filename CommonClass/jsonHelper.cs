using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonClass
{
    public class jsonHelper
    {
        public static T ReadJsonFile<T>(string path)
        {
            T data;
            try
            {
                StreamReader file = File.OpenText(path);
                JsonTextReader reader = new JsonTextReader(file);
                JValue jsonObject = (JValue)JToken.ReadFrom(reader);
                data = JsonConvert.DeserializeObject<T>(jsonObject.Value.ToString());
                file.Close();

            }
            catch(Exception err)
            {
                return default(T);
            }
            return data;
        }
        public static bool WriteJsonFile(string path, object data)
        {
            try
            {
                if (!File.Exists(path)) 
                {
                    File.Create(path);
                }
                string json = File.ReadAllText(path);
                string output = Newtonsoft.Json.JsonConvert.SerializeObject(JsonConvert.SerializeObject(data), Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(path, output);
            }
            catch (Exception err)
            {
                return false;
            }
            return true;
        }
    }
}
