namespace MedicinDosett.Views;

public partial class ChatGPTPage : ContentPage
{
    public ChatGPTPage(string medicinName)
    {
        InitializeComponent();
        BindingContext = new ViewModels.ChatGPTManager( medicinName);
       
    }

  

    private async void OnMainPageClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
    }

    private async void OnMammaClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MammaPage("mamma"));
    }

    private async void OnPappaClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new PappaPage("pappa"));    
    }
}
