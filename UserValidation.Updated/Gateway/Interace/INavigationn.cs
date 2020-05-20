using System;
using System.Threading.Tasks;
using UserValidation.Updated.ViewModels.BaseViewModel;

namespace UserValidation.Updated.Gateway.Interace
{
    public interface INavigationn
    {
         Task PushAsync(ViewModelBase viewModel);
         void SetInitialPage(object viewModel);
    }
}
