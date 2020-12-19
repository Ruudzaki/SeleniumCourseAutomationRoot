using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automation.Api.Components;
using Automation.Api.Pages;
using Automation.Core.Components;
using Automation.Core.Logging;
using OpenQA.Selenium;

namespace Automation.Framework.Ui.Pages
{
    public class StudentsUi : FluentUi, IStudents
    {
        public StudentsUi(IWebDriver driver) : base(driver)
        {
        }

        public StudentsUi(IWebDriver driver, ILogger logger) : base(driver, logger) {
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
            throw new NotImplementedException();
        }

        public IStudents FindByName(string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IStudent> Students()
        {
            throw new NotImplementedException();
        }
    }
}
