using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automation.Api.Pages;
using Automation.Core.Components;
using Automation.Core.Logging;
using OpenQA.Selenium;

namespace Automation.Framework.Ui.Pages
{
    public class CreateStudentUi : FluentUi, ICreateStudent
    {
        public CreateStudentUi(IWebDriver driver, ILogger logger) : base(driver, logger)
        {
        }

        public CreateStudentUi(IWebDriver driver) : base(driver)
        {
        }

        public string FirstName()
        {
            throw new NotImplementedException();
        }

        public string LastName()
        {
            throw new NotImplementedException();
        }

        public DateTime EnrollmentDate()
        {
            throw new NotImplementedException();
        }

        public IStudents Create()
        {
            throw new NotImplementedException();
        }

        public IStudents BackToList()
        {
            throw new NotImplementedException();
        }

        public ICreateStudent FirstName(string firstName)
        {
            throw new NotImplementedException();
        }

        public ICreateStudent LastName(string lastName)
        {
            throw new NotImplementedException();
        }

        public ICreateStudent EnrollmentDate(DateTime enrollmentDate)
        {
            throw new NotImplementedException();
        }
    }
}
