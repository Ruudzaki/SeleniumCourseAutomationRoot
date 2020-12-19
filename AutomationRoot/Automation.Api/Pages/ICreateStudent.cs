using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automation.Api.Components;

namespace Automation.Api.Pages
{
    public interface ICreateStudent : IStudentDetails, ICreate<IStudents>, IBack<IStudents>
    {
        ICreateStudent FirstName(string firstName);

        ICreateStudent LastName(string lastName);

        ICreateStudent EnrollmentDate(DateTime enrollmentDate);
    }
}
