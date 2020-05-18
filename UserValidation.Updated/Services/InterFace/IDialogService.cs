using System;
using System.Threading.Tasks;

namespace UserValidatation.Updated.Services.InterFace
{
    public interface IDialogService
    {
         Task ShowErrorAsync(string message, string title, string buttonText);
    }
}
