namespace despiertaVive.ViewModels
{
    using System.Collections.ObjectModel;
    using System.Collections.Generic;
    using Services;
    using Xamarin.Forms;

    public class despiertaViveViewModel : BaseViewModel
    {

        #region Services
        private ApiService apiService;
        #endregion

        #region Methods 
        private async void LoaddespiertaVive()
        {
            var connection = await this.apiService.CheckConnection();

            if (!connection.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    connection.Message,
                    "Aceptar");
                await Application.Current.MainPage.Navigation.PopAsync();
                return;
            }
        }
        #endregion
    }
}
