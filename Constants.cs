using System;

namespace ApiTests
{
    public struct Constants
    {
         
        public const string environment = "stg"; //prd stg qa

        public const string eotServerName = "jsonplaceholder.typicode.com";
        
        public const string apiKey = "apiKey";    //DEV
        public const string protocol = "https";

        public static string timestamp = DateTime.Now.ToString("yyyyMMdd_hhmmss");
        public static DateTime now = DateTime.Now;

    }
}