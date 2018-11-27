using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kaizen.Assessment.UnitTest
{
    [TestClass]
    public class AssessmentA
    {
        [TestMethod]
        public void TestA1()
        {
            Assert.AreNotSame(typeof(Object), typeof(Human).BaseType);
        }

        [TestMethod]
        public void TestA2()
        {
            Assert.IsTrue(typeof(Human).BaseType.IsAbstract);
        }

        [TestMethod]
        public void TestA3()
        {
            Assert.AreSame(typeof(Human).GetMethod("ToString").DeclaringType, typeof(Human));
        }

        [TestMethod]
        public void TestA4()
        {
            Assert.AreNotSame(typeof(Object), typeof(Human).BaseType);

            Assert.AreSame(typeof(Human).BaseType.GetMethod("GetDetails").DeclaringType, typeof(Human).BaseType);
        }

        [TestMethod]
        public void TestA5()
        {
            var properties = typeof (Human).BaseType.GetProperties().ToList();

            Assert.IsTrue(properties.Count > 0);

            Assert.IsTrue(properties.FirstOrDefault(x => x.Name.Equals("Name")) != null);
            Assert.IsTrue(properties.FirstOrDefault(x => x.Name.Equals("Age")) != null);
        }

        [TestMethod]
        public void ABonus1()
        {
            var baseType = typeof (Human).BaseType;
            Assert.IsTrue(baseType != null);
            {
                var interfaces = baseType.GetInterfaces();
                Assert.IsTrue(interfaces != null && interfaces.Any());
            }
        }
    }
}
