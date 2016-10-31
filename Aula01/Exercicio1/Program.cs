using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Q1");

            //int
            ushort a = 52130;
            Console.WriteLine("(ushort) a = {0}", a);
            sbyte b = -115;
            Console.WriteLine("(sbyte) b = {0}", a);
            uint c = 4825932;
            Console.WriteLine("(uint) c = {0}", c);
            byte d = 97;
            Console.WriteLine("(byte) d = {0}", d);
            short e = -1000;
            Console.WriteLine("(short) e = {0}", e);
            ushort f = 2000;
            Console.WriteLine("(ushort) f = {0}", f);
            byte g = 224;
            Console.WriteLine("(byte) g = {0}", g);
            ulong h = 970700000;
            Console.WriteLine("(ulong) h = {0}", h);
            byte i = 112;
            Console.WriteLine("(byte) i = {0}", i);
            sbyte j = -44;
            Console.WriteLine("(sbyte) j = {0}", j);
            int k = -1000000;
            Console.WriteLine("(int) k = {0}", k);
            ushort l = 1990;
            Console.WriteLine("(ushort) l = {0}", l);
            ulong m = 123456789123456789;
            Console.WriteLine("(ulong) m = {0}", m);

            //decimal
            Console.WriteLine("Q2");

            float n = 5;
            Console.WriteLine("(float) n = {0}", n);
            float o = -5.01f;
            Console.WriteLine("(float) o = {0}", o);
            double p = 34.567839023;
            Console.WriteLine("(double) p = {0}", p);
            float q = 12.345f;
            Console.WriteLine("(float) q = {0}", q);
            double r = 8923.1234567;
            Console.WriteLine("(double) r = {0}", r);
            decimal s = 3456.0911248759565421151256683467m;
            Console.WriteLine("(decimal) s = {0}", s);


            Console.WriteLine("Q3");
            int hexa = 0x100;
            Console.WriteLine("(hexa) = {0}  H{0:X}", hexa, hexa);

            Console.WriteLine("Q4");
            Console.WriteLine("Olá! \r\n Mundo C#");

        }
    }
}
