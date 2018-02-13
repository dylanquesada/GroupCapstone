using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace GroupCapstone.HelperClasses
{
    static public class KeyReader
    {
        static public string LoadJson()
        {
            
            using (StreamReader r = new StreamReader(@"c:\ApiKey.JSON")) 
            {
                string json = r.ReadToEnd();
                return json;

            }
        }
    }
}