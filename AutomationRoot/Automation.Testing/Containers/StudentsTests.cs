﻿using System.Collections.Generic;
using Automation.Testing.Cases;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace Automation.Testing.Containers
{
    [TestClass]
    public class StudentsTests
    {
        [DataTestMethod]
        [DataRow(
            "{'driver':'CHROME','keyword':'Alexander','application':'https://gravitymvctestapplication.azurewebsites.net/Student'}")]
        public void SearchStudentUiTest(string testParams)
        {
            //generate test-parameters
            var parameters = JsonConvert.DeserializeObject<Dictionary<string, object>>(testParams);

            // execute with parameters
            var actual = new SearchStudents().WithTestParams(parameters).Execute().Actual;

            // assert results 
            Assert.IsTrue(actual);
        }

        [DataTestMethod]
        [DataRow(
            "{'driver':'CHROME','firstName':'csharp','lastName':'student','application':'https://gravitymvctestapplication.azurewebsites.net/Student'}")]
        public void CreateStudentUiTest(string testParams)
        {
            //generate test-parameters
            var parameters = JsonConvert.DeserializeObject<Dictionary<string, object>>(testParams);

            // execute with parameters
            var actual = new CreateStudent().WithTestParams(parameters).Execute().Actual;

            // assert results 
            Assert.IsTrue(actual);
        }

        [DataTestMethod]
        [DataRow(
            "{'driver':'CHROME','keyword':'Alexander','application':'https://gravitymvctestapplication.azurewebsites.net/Student'}")]
        public void StudentDetailsTest(string testParams)
        {
            //generate test-parameters
            var parameters = JsonConvert.DeserializeObject<Dictionary<string, object>>(testParams);

            // execute with parameters
            var actual = new StudentDetails().WithTestParams(parameters).Execute().Actual;

            // assert results 
            Assert.IsTrue(actual);
        }
    }
}