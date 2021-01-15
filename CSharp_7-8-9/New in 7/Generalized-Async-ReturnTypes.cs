using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//prior to C#-7 generally async methods have to return void or Task<T>
//now it can also return eg: valuetype<T>. this is good for preventing the allocation of a task when the result is already available.

namespace CSharp_7_8_9.New_in_7
{
     public class Generalized_Async_ReturnTypes
    {
        public static async Task<long> GetDirSize(string dir)
        {
            if (!Directory.EnumerateFileSystemEntries(dir).Any())
                return 0;//here it creates a task even though it not needed

            return await Task.Run(() => Directory.GetFiles(dir, "*.*", SearchOption.AllDirectories).Sum(f => new FileInfo(f).Length));
        }

        //PREFER
        public static async ValueTask<long> GetDirSize1(string dir)
        {
            if (!Directory.EnumerateFileSystemEntries(dir).Any())
                return 0;//prevents creation of task due to ValueTask<long> 

            return await Task.Run(() => Directory.GetFiles(dir, "*.*", SearchOption.AllDirectories).Sum(f => new FileInfo(f).Length));
        }

        public static void Run()
        {
            Console.WriteLine(GetDirSize(@"C:\Temp").Result);
            Console.WriteLine(GetDirSize1(@"C:\Temp").Result);
        }
    }
}
