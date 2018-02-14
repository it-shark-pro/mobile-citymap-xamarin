using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace CityMap.Services
{
    public interface INavigationService
    {
        void NavigateTo<TViewModel>(object navigationParameter);
    }

    public class NavigationService : INavigationService
    {
        private readonly IDictionary<Type, Func<object, Task>> _map;

        public NavigationService(IDictionary<Type, Func<object, Task>> map)
        {
            _map = map;
        }

        public void NavigateTo<TViewModel>(object navigationParameter)
        {
            var viewModelType = typeof(TViewModel);

            _map.TryGetValue(viewModelType, out Func<object, Task> navigationDelegate);

            navigationDelegate?.Invoke(navigationParameter);
        }
    }
}
