using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automation.Testing.Cases;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Automation.Testing.Containers
{
    [TestClass]
    public class StudentsTests
    {
        [TestMethod]
        public void SearchStudentUiTest()
        {
            var actual = new SearchStudents().Execute().Actual;
            Assert.IsTrue(actual);
        }
    }
}
