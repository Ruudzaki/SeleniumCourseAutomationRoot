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
using Automation.Framework.RestApi.Components;
using Newtonsoft.Json.Linq;

namespace Automation.Framework.RestApi.Pages
{
    public class StudentsRest : FluentRest, IStudents
    {

        private readonly IEnumerable<IStudent> studentList;
        public StudentsRest(HttpClient httpClient) 
            : this(httpClient, new TraceLogger())
        {
        }

        public StudentsRest(HttpClient httpClient, ILogger logger) 
            : this(httpClient, logger, string.Empty)
        {
        }

        private StudentsRest(HttpClient httpClient, ILogger logger, string name)
            : base(httpClient, logger)
        {
            studentList = Build(name);
        }


        public ICreateStudent Create()
        {
            throw new NotImplementedException();
        }

        public IStudents FindByName(string name)
        {
            return new StudentsRest(HttpClient, Logger, name);
        }

        public T Menu<T>(string menuName)
        {
            throw new NotImplementedException();
        }

        public IStudents Next()
        {
            throw new NotImplementedException();
        }

        public int Page()
        {
            throw new NotImplementedException();
        }

        public int Pages()
        {
            throw new NotImplementedException();
        }

        public IStudents Previous()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IStudent> Students()
        {
            return studentList;
        }

        private IEnumerable<IStudent> Build(string name)
        {
            var response = HttpClient.GetAsync("/api/Students").GetAwaiter().GetResult();
            if (!response.IsSuccessStatusCode)
            {
                return new IStudent[0];
            }
            var responseBody = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            var students = JToken.Parse(responseBody).Select(i => new StudentRest(HttpClient, i));

            // filter results
            const StringComparison COMPARE = StringComparison.OrdinalIgnoreCase;
            return string.IsNullOrEmpty(name)
                ? students
                : students.Where(i => i.FirstName().Equals(name, COMPARE) || i.LastName().Equals(name, COMPARE));
        }
    }
}
