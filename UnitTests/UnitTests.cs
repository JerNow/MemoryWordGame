using MemoryWordGame;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTests
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void ReadFromFileNullValue()
        {
            Assert.ThrowsException<ArgumentNullException>(() => Program.ReadFromFile(null));
        }
    }
}
