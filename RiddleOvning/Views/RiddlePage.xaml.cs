using RiddleOvning.Models;
using RiddleOvning.ViewModels;

namespace RiddleOvning.Views;

public partial class RiddlePage : ContentPage
{

   


    public RiddlePage()
	{
		InitializeComponent();
	   BindingContext = new ViewModels.RiddlePageViewModel();

		
	}

	private async void OnClickedGetRiddle(object sender, EventArgs e)
	{

	
		await Navigation.PushAsync(new Views.RiddlePage());

	}

	private async void OnClickedGetAnswer(object sender, SelectedItemChangedEventArgs e)
	{
		var riddle = ((ListView)sender).SelectedItem as Models.Riddle;
		if (riddle != null)
		{
			var page = new AnswerPage();
			page.BindingContext = riddle;
			await Navigation.PushAsync(page);

		}
	}
	

}