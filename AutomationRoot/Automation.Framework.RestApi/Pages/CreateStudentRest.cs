using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Automation.Api.Components;
using Automation.Api.Pages;
using Automation.Core.Components;
using Automation.Core.Logging;

namespace Automation.Framework.RestApi.Pages
{
    public class CreateStudentRest : FluentRest, ICreateStudent
    {
        public CreateStudentRest(HttpClient httpClient, ILogger logger) : base(httpClient, logger)
        {
        }

        public CreateStudentRest(HttpClient httpClient) : base(httpClient)
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
