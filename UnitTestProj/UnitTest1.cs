using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Utility;
namespace UnitTestProj
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Uint16ReverseTest()
        {
            UInt16 value1 = 0x0405;
            UInt16 value2 = 0x0504;

            Assert.AreEqual(value2, value1.Reverse());
            Assert.AreEqual(value1, value2.Reverse());
        }

        [TestMethod]
        public void Uint32ReverseTest()
        {
            UInt32 value1 = 0x12345678;
            UInt32 value2 = 0x78563412;

            Assert.AreEqual(value2, value1.Reverse());
            Assert.AreEqual(value1, value2.Reverse());
        } 

        [TestMethod]
        public void ConvertBytesToUInt16()
        {
            byte[] bytes = { 0x12, 0x34 };
            ushort word = 0x1234;

            Assert.AreEqual(word, bytes.ToUInt16());
        }

        [TestMethod]
        public void ConvertBytesToUInt32()
        {
            byte[] bytes = { 0x12, 0x34, 0x56, 0x78 };
            uint dword = 0x12345678;

            Assert.AreEqual(dword, bytes.ToUInt32());
        }

        [TestMethod]
        public void ConvertUInt16ToBytes()
        {
            byte[] bytes = { 0x12, 0x34 };
            ushort word = 0x1234;

            Assert.AreEqual(bytes.ToUInt16(), word.ToBytes().ToUInt16());
        }

        [TestMethod]
        public void ConvertUInt32ToBytes()
        {
            byte[] bytes = { 0x12, 0x34, 0x56, 0x78 };
            uint dword = 0x12345678;

            Assert.AreEqual(bytes.ToUInt32() , dword.ToBytes().ToUInt32());
        }

        [TestMethod]
        public void ConvertToHexString()
        {
            ushort word = 0x0034;
            string hexStr = "0034";
            Assert.AreEqual(hexStr, word.ToHexString(4));
        }
    }
}
