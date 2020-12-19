using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automation.Api.Components;

namespace Automation.Api.Pages
{
    public interface IStudents : IPageNavigator<IStudents>, IMenu
    {
        IStudents FindByName(string name);
        IEnumerable<IStudent> Students();
    }
}
