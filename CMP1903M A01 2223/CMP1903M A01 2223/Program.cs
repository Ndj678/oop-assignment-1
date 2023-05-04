using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{
    class Program
    {
        static void Main(string[] args)
        {
            PackTests.testFisherYates();
            PackTests.testRiffle();
            PackTests.testDeal();
            PackTests.testDealCard(10);
        }
    }
}
