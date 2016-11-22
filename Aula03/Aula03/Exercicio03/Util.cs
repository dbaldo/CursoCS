using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio03
{
    public class Util
    {
        public static void Perform<T>(Action<T> act, 
                params T[] arr)
        {
            foreach(var elem in arr)
            {
                act(elem);
            }
        }
    }
}
