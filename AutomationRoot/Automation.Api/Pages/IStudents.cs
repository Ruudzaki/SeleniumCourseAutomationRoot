using System.Collections.Generic;
using Automation.Api.Components;
using Automation.Core.Components;

namespace Automation.Api.Pages
{
    public interface IStudents : IFluent, IPageNavigator<IStudents>, IMenu, ICreate<ICreateStudent>
    {
        IStudents FindByName(string name);
        IEnumerable<IStudent> Students();
    }
}