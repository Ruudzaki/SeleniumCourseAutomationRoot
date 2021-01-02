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
using Newtonsoft.Json;

namespace Automation.Framework.RestApi.Pages
{
    public class CreateStudentRest : FluentRest, ICreateStudent
    {
        // constants
        private const string F_NAME = "firstMidName";
        private const string L_NAME = "lastName";
        private const string E_DATE = "enrollmentDate";

        private readonly IDictionary<string, object> _requestBody;
        public CreateStudentRest(HttpClient httpClient, ILogger logger) : base(httpClient, logger)
        {
            _requestBody = new Dictionary<string, object>();
        }

        public CreateStudentRest(HttpClient httpClient) : this(httpClient, new TraceLogger())
        {
            
        }

        public string FirstName()
        {
            return _requestBody.ContainsKey(F_NAME) ? $"{_requestBody[F_NAME]}" : string.Empty;
        }

        public string LastName()
        {
            return _requestBody.ContainsKey(L_NAME) ? $"{_requestBody[L_NAME]}" : string.Empty;
        }

        public DateTime EnrollmentDate()
        {
            return _requestBody.ContainsKey(E_DATE) ? DateTime.Parse($"{_requestBody[E_DATE]}") : default;
        }

        public IStudents Create()
        {
            var jsonRequest = JsonConvert.SerializeObject(_requestBody);
            var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
            HttpClient.PostAsync("/api/Students", content).GetAwaiter().GetResult();

            return new StudentsRest(HttpClient, Logger);
        }

        public IStudents BackToList()
        {
            return new StudentsRest(HttpClient, Logger);
        }

        public ICreateStudent FirstName(string firstName)
        {
            _requestBody[F_NAME] = firstName;
            return this;
        }

        public ICreateStudent LastName(string lastName)
        {
            _requestBody[L_NAME] = lastName;
            return this;
        }

        public ICreateStudent EnrollmentDate(DateTime enrollmentDate)
        {
            _requestBody[E_DATE] = enrollmentDate.ToString("yyyy-MM-ddThh:mm:ss");
            return this;
        }
    }
}
