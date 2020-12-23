﻿using Automation.Api.Components;
using Automation.Api.Pages;
using Automation.Core.Components;
using Automation.Core.Logging;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Framework.Ui.Pages
{
    public class StudentDetailsUi : FluentUi, IStudentDetails
    {
        public StudentDetailsUi(IWebDriver driver) : base(driver)
        {
        }

        public StudentDetailsUi(IWebDriver driver, ILogger logger) : base(driver, logger)
        {
        }

        public DateTime EnrollmentDate()
        {
            throw new NotImplementedException();
        }

        public IEnrollment[] Enrollments()
        {
            throw new NotImplementedException();
        }

        public string FirstName()
        {
            throw new NotImplementedException();
        }

        public string LastName()
        {
            throw new NotImplementedException();
        }
    }
}
