﻿using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Automation.Core.Components;
using Automation.Framework.RestApi.Pages;
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
            "{" +
            "'driver':'CHROME'," +
            "'keyword':'Alexander'," +
            "'application':'https://gravitymvctestapplication.azurewebsites.net/Student'," +
            "'fluent':'Automation.Core.Components.FluentUi'," +
            "'students':'Automation.Framework.Ui.Pages.StudentsUi'" +
            "}")]
        [DataRow(
            "{" +
            "'driver':'HTTP'," +
            "'keyword':'Alexander'," +
            "'application':'https://gravitymvctestapplication.azurewebsites.net'," +
            "'fluent':'Automation.Core.Components.FluentRest'," +
            "'students':'Automation.Framework.RestApi.Pages.StudentsRest'" +
            "}")]
        public void SearchStudentTest(string testParams)
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
            "" +
            "{" +
            "'driver':'CHROME'," +
            "'firstName':'csharp ui'," +
            "'lastName':'student'," +
            "'application':'https://gravitymvctestapplication.azurewebsites.net/Student'," +
            "'fluent':'Automation.Core.Components.FluentUi'," +
            "'students':'Automation.Framework.Ui.Pages.StudentsUi'" +
            "}" +
            "")]
        [DataRow(
            "" +
            "{" +
            "'driver':'HTTP'," +
            "'firstName':'csharp api'," +
            "'lastName':'student'," +
            "'application':'https://gravitymvctestapplication.azurewebsites.net'," +
            "'fluent':'Automation.Core.Components.FluentRest'," +
            "'students':'Automation.Framework.RestApi.Pages.StudentsRest'" +
            "}" +
            "")]
        public void CreateStudentTest(string testParams)
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
            "{" +
            "'driver':'CHROME'," +
            "'keyword':'Alexander'," +
            "'application':'https://gravitymvctestapplication.azurewebsites.net/Student'," +
            "'fluent':'Automation.Core.Components.FluentUi'," +
            "'students':'Automation.Framework.Ui.Pages.StudentsUi'" +
            "}")]
        [DataRow(
            "{" +
            "'driver':'HTTP'," +
            "'keyword':'Alexander'," +
            "'application':'https://gravitymvctestapplication.azurewebsites.net'," +
            "'fluent':'Automation.Core.Components.FluentRest'," +
            "'students':'Automation.Framework.RestApi.Pages.StudentsRest'" +
            "}")]
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