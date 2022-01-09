using System;

namespace Yılgünsaatall
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            DateTime tarih = DateTime.Now;
            Console.WriteLine(tarih.ToLongDateString());  // D.
            Console.WriteLine(tarih.ToLongTimeString());  // T.
            Console.WriteLine(tarih.ToShortDateString()); // d.
            Console.WriteLine(tarih.ToShortTimeString()); // t.
            Console.WriteLine(tarih.ToString());
        }
    }
}