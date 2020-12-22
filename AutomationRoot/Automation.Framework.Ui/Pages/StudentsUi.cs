using System;
using System.Collections.Generic;
using System.Linq;
using Automation.Api.Components;
using Automation.Api.Pages;
using Automation.Core.Components;
using Automation.Core.Logging;
using Automation.Extensions.Components;
using Automation.Framework.Ui.Components;
using OpenQA.Selenium;

namespace Automation.Framework.Ui.Pages
{
    public class StudentsUi : FluentUi, IStudents
    {

        public StudentsUi(IWebDriver driver) : base(driver)
        {
        }

        public StudentsUi(IWebDriver driver, ILogger logger) : base(driver, logger)
        {
        }

        public IStudents Next()
        {
            throw new NotImplementedException();
        }

        public IStudents Previous()
        {
            throw new NotImplementedException();
        }

        public int Pages()
        {
            throw new NotImplementedException();
        }

        public int Page()
        {
            throw new NotImplementedException();
        }

        public T Menu<T>(string menuName)
        {
            throw new NotImplementedException();
        }

        public ICreateStudent Create()
        {
            Driver.GetEnabledElement(By.XPath("//a[contains(@href,'/Student/Create')]")).Click();
            return new CreateStudentUi(Driver);
        }

        public IStudents FindByName(string name)
        {
            Driver.GetElement(By.XPath("//input[@id='SearchString']")).SendKeys(name);
            Driver.SubmitForm(0);
            return this;
        }

        public IEnumerable<IStudent> Students()
        {
            var students = Driver.GetElements(By.XPath("//tbody/tr"));
            return students.Select(i => new StudentUi(Driver, i));
        }
    }
}