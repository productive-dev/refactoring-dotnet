using System;
using System.Collections.Generic;
using System.Linq;
using Refactoring.Web.Services.Interfaces;

namespace Refactoring.Web.Services.Helpers {
    public class RandomHelper : IRandomHelper {
        public T GetRandomValueFromList<T>(IEnumerable<T> items) {
            var random = new Random();
            var enumerable = items.ToList();
            var randomIndex = random.Next(enumerable.Count);
            return enumerable[randomIndex];
        }
    }
}