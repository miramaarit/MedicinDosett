using MedicinDosett.Models;
using MedicinDosett.ViewModels;

namespace MedicinDosett.Views;

public partial class DayPage : ContentPage
{
	public DayPage(string medicinType)
	{
		InitializeComponent();

        if (medicinType == "pappa")
        {
            BindingContext = PappaViewModels.Inst();
        }
        else if (medicinType == "mamma")
        {
            BindingContext = MammaViewModels.Inst();
        }
    }

    private async void OnPappaClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Views.PappaPage("pappa"));
    }
    

    private async void OnMammaClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MammaPage("mamma"));
    }
}