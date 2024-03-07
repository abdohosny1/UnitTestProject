using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IdealWeightCalculator.Tests
{
    [TestClass]
    public class TestInitializer
    {

        [AssemblyInitialize]
        //يتنفذ مرة واحدة 
        public static void AssemblyInitialize(TestContext context)
        {
            Console.WriteLine("in Assembly Initialze");
        }

        [AssemblyCleanup]
        //يتم تنفذيها بعد الانتهاء من تنفيظ كل ال test
        public static void AssemblyCleanup() { }
    }
}
