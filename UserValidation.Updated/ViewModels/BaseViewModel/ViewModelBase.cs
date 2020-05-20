using System;
using System.ComponentModel;
using UserValidation.Updated.Gateway.Interace;
using UserValidation.Updated.Gateway.Service;

namespace UserValidation.Updated.ViewModels.BaseViewModel
{
    public class ViewModelBase: INotifyPropertyChanged
    {
        #region PROPERTIES

        public event PropertyChangedEventHandler PropertyChanged;
       

        #endregion

        #region CONSTRUCTION

        public ViewModelBase()
        {
        }

        #endregion

        #region METHODS

        protected void OnPropertyChanged(string PropertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(PropertyName));
            }
        }

        #endregion
    }
}
