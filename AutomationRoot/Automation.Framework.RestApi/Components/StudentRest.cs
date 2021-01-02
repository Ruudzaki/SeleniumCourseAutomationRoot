using Automation.Api.Components;
using Automation.Api.Pages;
using Automation.Core.Components;
using Automation.Core.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Automation.Framework.RestApi.Pages;
using Newtonsoft.Json.Linq;

namespace Automation.Framework.RestApi.Components
{
    public class StudentRest : FluentRest, IStudent
    {
        private readonly JToken _dataRow;
        private int _id;
        private string _firstName;
        private string _lastName;
        private DateTime _enrollmentDate;

        public StudentRest(HttpClient httpClient, JToken dataRow) : this(httpClient, new TraceLogger())
        {
            _dataRow = dataRow;
            Build(dataRow);
        }

        public StudentRest(HttpClient httpClient, ILogger logger) : base(httpClient, logger)
        {
        }

        public object Delete()
        {
            throw new NotImplementedException();
        }

        public IStudentDetails Details()
        {
            return new StudentDetailsRest(HttpClient, Logger, _id);
        }

        public object Edit()
        {
            throw new NotImplementedException();
        }

        public DateTime EnrollmentDate()
        {
            return _enrollmentDate;
        }

        public string FirstName()
        {
            return _firstName;
        }

        public string LastName()
        {
            return _lastName;
        }

        private void Build(JToken dataRow)
        {
            _firstName = $"{dataRow["firstMidName"]}";
            _lastName = $"{dataRow["lastName"]}";
            _enrollmentDate = DateTime.Parse($"{dataRow["enrollmentDate"]}");
            int.TryParse($"{dataRow["id"]}", out _id);
        }
    }
}
