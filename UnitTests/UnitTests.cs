using MemoryWordGame;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace UnitTests
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void ReadFromTextFileNullValue()
        {
            Assert.ThrowsException<ArgumentNullException>(() => Program.ReadFromTextFile(null));
        }
        [TestMethod]
        public void ReadFromTextFileFileDoesntExist()
        {
            Assert.ThrowsException<FileNotFoundException>(() => Program.ReadFromTextFile(AppDomain.CurrentDomain.BaseDirectory +"exception.txt"));
        }
        [TestMethod]
        public void ReadFromTextFileWrongExtension()
        {
            Assert.ThrowsException<InvalidDataException>(() => Program.ReadFromTextFile(AppDomain.CurrentDomain.BaseDirectory + "test.doc"));
        }
    }
}
