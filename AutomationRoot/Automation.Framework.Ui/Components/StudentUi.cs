using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automation.Api.Components;
using Automation.Core.Components;
using Automation.Core.Logging;
using OpenQA.Selenium;

namespace Automation.Framework.Ui.Components
{
    public class StudentUi : FluentUi, IStudent
    {
        private readonly IWebElement _dataRow;
        private string _firstName;
        private string _lastName;
        private DateTime _enrollmentDate;

        private StudentUi(IWebDriver driver, ILogger logger) : base(driver, logger)
        {
        }

        public StudentUi(IWebDriver driver, IWebElement dataRow) : this(driver, new TraceLogger())
        {
            this._dataRow = dataRow;
            Build(dataRow);
        }

        // actions

        public object Edit()
        {
            throw new NotImplementedException();
        }

        public object Details()
        {
            throw new NotImplementedException();
        }

        public object Delete()
        {
            throw new NotImplementedException();
        }

        // data
        public string FirstName()
        {
            return _firstName;
        }

        public string LastName()
        {
            return _lastName;
        }
        public DateTime EnrollmentDate()
        {
            return _enrollmentDate;
        }

        // processing
        private void Build(IWebElement dataRow)
        {
            _lastName = dataRow.FindElement(By.XPath("./td[1]")).Text.Trim();
            _firstName = dataRow.FindElement(By.XPath("./td[2]")).Text.Trim();

            // parse date
            var dateString = dataRow.FindElement(By.XPath("./td[3]")).Text.Trim();
            DateTime.TryParse(dateString, out _enrollmentDate);

        }
    }
}
