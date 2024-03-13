using MedicinDosett.Models;
using MedicinDosett.ViewModels;
using MongoDB.Driver;
using System.Windows.Input;

namespace MedicinDosett.Views;

public partial class MammaPage : ContentPage
{
   
	public MammaPage(string medicinType)
	{
		InitializeComponent();
        BindingContext = MammaViewModels.Inst();
        
	}
   

    private async void OnMorningClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Views.MorningPage("mamma"));
    }

    private async void OnDayClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Views.DayPage("mamma"));
    }

    private async void OnEveningclicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Views.EveningPage("mamma"));
    }

    private async void OnIfNecessaryClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Views.IfNecessaryPage("mamma"));
    }

    private async void OnMainPageClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
    }

    private async void OnMedicinAdminClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Views.MedicinAdminPage(null));
    }

    private async void OnListViewItemSelect(object sender, SelectedItemChangedEventArgs e)
    {

        var medicin = ((ListView)sender).SelectedItem as Models.MammaMedicin;


        if (medicin != null)
        {

            var page = new ChatGPTPage(medicin.Name);
            //page.BindingContext = medicin;
            await Navigation.PushAsync(page);
        }
    }

    private async void OnClickedDelete(object sender, EventArgs e)
    {
        var medicin = ((Button)sender).BindingContext as Models.MammaMedicin;

        if (medicin != null)
        {
            var filter = Builders<Models.MammaMedicin>.Filter.Eq(m => m.Id, medicin.Id);
            await Data.DB.MedicinCollection().DeleteOneAsync(filter);
             await MammaViewModels.Inst().UpdateMammaMedicinsFromDb();
            
            await Navigation.PushAsync(new MammaPage("mamma"));
        }
       



    }

   
}