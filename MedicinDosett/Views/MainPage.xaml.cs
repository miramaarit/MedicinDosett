using MedicinDosett.ViewModels;

namespace MedicinDosett
{
    public partial class MainPage : ContentPage
    {
        
       
        public MainPage()
        {
            InitializeComponent();
        
        }

        private async void OnPappaClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Views.PappaPage("pappa"));
        }

        private async void OnMammaClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Views.MammaPage("mamma")); // Hej
        }
    }

}
