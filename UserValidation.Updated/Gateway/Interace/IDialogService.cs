using System;
using System.Threading.Tasks;

namespace UserValidatation.Updated.Gateway.Interface
{
    public interface IDialogService
    {
         Task ShowErrorAsync(string message, string title, string buttonText);
    }
}
