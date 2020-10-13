using System.Collections.Generic;

namespace Refactoring.Web.Services.Interfaces {
    public interface IRandomHelper {
        T GetRandomValueFromList<T>(IEnumerable<T> items);
    }
}