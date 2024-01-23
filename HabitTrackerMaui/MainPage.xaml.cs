namespace HabitTrackerMaui;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
	}

	private void OnActionChosen(object sender, EventArgs e)
	{
		Button btn = (Button)sender;

		switch(btn.Text)
		{
			case "Insert":
				Navigation.PushAsync(new InsertRecord());
				break;
			case "Update":
				Navigation.PushAsync(new UpdateRecords());
				break;
			case "View":
				Navigation.PushAsync(new ViewRecords());
				break;
		}

	}
}

