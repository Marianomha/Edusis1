using System;
using WPF_Desktop.Shared;
using WPF_Desktop.Store;

namespace WPF_Desktop.Navigation;

public class NavigationService<TViewModel> : INavigationService
    where TViewModel : ViewModel
{
    private readonly Func<TViewModel> _viewModelFactory;
    private readonly NavigationStore _navigationStore;


    public NavigationService(Func<TViewModel> viewModelFactory, NavigationStore navigationStore)
    {
        _viewModelFactory = viewModelFactory;
        _navigationStore = navigationStore;
    }

    public void Navigate()
    {
        _navigationStore.ViewModelActual = _viewModelFactory();
    }
}
