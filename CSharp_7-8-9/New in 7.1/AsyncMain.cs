using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_7_8_9.New_in_7._1
{
    public class AsyncMain
    {
        private static string _url = "http://google.com/robots.txt";
        public static async Task Run()
        {
            Console.WriteLine(await new HttpClient().GetStringAsync(_url));
        }
    }
}
