using MongoDB.Driver;
using Microsoft.Maui.Controls.Compatibility.Platform;
using MedicinDosett.Models;
using MedicinDosett.ViewModels;

namespace MedicinDosett.Views;

public partial class MedicinAdminPage : ContentPage	
{
	public Models.MammaMedicin MammaMedicin { get; set; }

	public MedicinAdminPage(Models.MammaMedicin mammaMedicin)
	{
		InitializeComponent();
     
        MammaMedicin = mammaMedicin;

       
    }

    public async void OnClickedSaveMedicin(object sender, EventArgs e)
    {
        if (MammaMedicin == null)
        {

            Models.MammaMedicin mammaMedicins = new Models.MammaMedicin()
            {
                Id = Guid.NewGuid(),
    			Name = MedicinNameEntry.Text,
    			Dose = DoseEntry.Text,
    			Info = InfoEntry.Text,
    			Time = TimeEntry.Text,
    		};
            await Data.DB.MedicinCollection().InsertOneAsync(mammaMedicins);
            await MammaViewModels.Inst().UpdateMammaMedicinsFromDb();
        }
       

        await Navigation.PushAsync(new MammaPage("mamma"));


    }

    
}