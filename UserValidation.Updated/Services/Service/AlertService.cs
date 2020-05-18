using System;
using System.Threading.Tasks;
using UserValidatation.Updated.Services.InterFace;
using Xamarin.Forms;

namespace UserValidatation.Updated.Services.Service
{
    public class AlertService:IDialogService
    {
        #region METHODS

        public async Task ShowErrorAsync(string message, string title, string buttonText)
        {
            await Application.Current.MainPage.DisplayAlert(title, message, buttonText);
        }

        #endregion
    }
}
