namespace despiertaVive.Views
{
    using System;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PanelPage : ContentPage
	{

        string translatedNumber;

        public PanelPage ()
		{
			InitializeComponent ();
		}

        void OnTranslate(object sender, EventArgs e)
        {
            translatedNumber = PhonewordTranslator.ToNumber(phoneNumberText.Text);
            if (!string.IsNullOrWhiteSpace(translatedNumber))
            {
                callButton.IsEnabled = true;
                callButton.Text = "Llamar " + translatedNumber;
            }
            else
            {
                callButton.IsEnabled = false;
                callButton.Text = "Llamar";
            }
        }

        async void OnCall(object sender, EventArgs e)
        {
            if (await this.DisplayAlert(
                    "Confirmación",
                    "¿Le gustaria llamar a " + translatedNumber + "?",
                    "Si",
                    "No"))
            {
                var dialer = DependencyService.Get<IDialer>();
                if (dialer != null)
                    dialer.Dial(translatedNumber);
            }
        }
    }
}