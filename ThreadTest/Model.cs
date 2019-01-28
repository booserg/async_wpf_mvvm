using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadTest
{
    public class Model
    {
        public int DoWork()
        {
            var result = 0;

            for(int i = 0; i < 3; i++)
            {
                Thread.Sleep(1000);
                result = i;
            }

            return result;
        }
    }
}
