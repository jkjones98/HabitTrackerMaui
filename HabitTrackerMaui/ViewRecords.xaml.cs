using System.Runtime.InteropServices.ObjectiveC;

namespace HabitTrackerMaui;

public partial class ViewRecords : ContentPage
{
    public ViewRecords()
    {
        InitializeComponent();
        habitGrid.ItemsSource = App.HabitTrackRepository.ShowAllRuns();
    }

    private void OnDelete(object sender, EventArgs e)
    {
        Button button = (Button)sender;

        App.HabitTrackRepository.Delete((int)button.BindingContext);

        habitGrid.ItemsSource = App.HabitTrackRepository.ShowAllRuns();
    }
}