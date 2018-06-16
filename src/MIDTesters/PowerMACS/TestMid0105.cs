﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.PowerMACS;

namespace MIDTesters.PowerMACS
{
    [TestClass]
    public class TestMid0105 : MidTester
    {
        [TestMethod]
        public void Mid0105Revision1()
        {
            string pack = @"002001050011        ";
            var mid = _midInterpreter.Parse(pack);

            Assert.AreEqual(typeof(MID_0105), mid.GetType());
            Assert.AreEqual(pack, mid.Pack());
        }

        [TestMethod]
        public void Mid0105Revision2()
        {
            string pack = @"003001050021        4294967295";
            var mid = _midInterpreter.Parse<MID_0105>(pack);

            Assert.AreEqual(typeof(MID_0105), mid.GetType());
            Assert.IsNotNull(mid.DataNumberSystem);
            Assert.AreEqual(pack, mid.Pack());
        }

        [TestMethod]
        public void Mid0105Revision3()
        {
            string pack = @"003101050031        42949672951";
            var mid = _midInterpreter.Parse<MID_0105>(pack);

            Assert.AreEqual(typeof(MID_0105), mid.GetType());
            Assert.IsNotNull(mid.DataNumberSystem);
            Assert.IsNotNull(mid.SendOnlyNewData);
            Assert.AreEqual(pack, mid.Pack());
        }

        [TestMethod]
        public void Mid0105Revision4()
        {
            string pack = @"003101050041        32949672951";
            var mid = _midInterpreter.Parse<MID_0105>(pack);

            Assert.AreEqual(typeof(MID_0105), mid.GetType());
            Assert.IsNotNull(mid.DataNumberSystem);
            Assert.IsNotNull(mid.SendOnlyNewData);
            Assert.AreEqual(pack, mid.Pack());
        }
    }
}