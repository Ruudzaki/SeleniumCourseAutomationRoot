using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automation.Core.Components;
using Automation.Core.Testing;
using Automation.Framework.Ui.Pages;

namespace Automation.Testing.Cases
{
    public class CreateStudent : TestCase
    {
        public override bool AutomationTest(IDictionary<string, object> testParams) {
            //students to find
            var firstName = $"{testParams["firstName"]}";
            var lastName = $"{testParams["lastName"]}";

            //perform test case
            return new StudentsUi(Driver)
                .ChangeContext<StudentsUi>($"{testParams["application"]}")
                .Create()
                .FirstName(firstName)
                .LastName(lastName)
                .EnrollmentDate(DateTime.Now)
                .Create()
                .FindByName(firstName)
                .Students()
                .Any();
        }
    }
}
