using MedicinDosett.Models;
using MedicinDosett.ViewModels;
using MongoDB.Driver;

namespace MedicinDosett.Views;

public partial class PappaPage : ContentPage
{
    public PappaPage(string medicinType)
    {
        InitializeComponent();
        BindingContext = PappaViewModels.Inst();
    }

    private async void OnListViewItemSelect(object sender, SelectedItemChangedEventArgs e)
    {

        var medicin = ((ListView)sender).SelectedItem as Models.PappaMedicin;
        if (medicin != null)
        {
            var page = new ChatGPTPage(medicin.Name);
            await Navigation.PushAsync(page);
        }
    }

    private async void OnMorningClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Views.MorningPage("pappa"));
    }

    private async void OnDayClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Views.DayPage("pappa"));
    }

    private async void OnEveningclicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Views.EveningPage("pappa"));
    }

    private async void OnIfNecessaryClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Views.IfNecessaryPage("pappa"));
    }

    private async void OnMainPageClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());

    }


 
}