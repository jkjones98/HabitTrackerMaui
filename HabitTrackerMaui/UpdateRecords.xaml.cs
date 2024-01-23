using System.Globalization;
using HabitTrackerMaui.Models;

namespace HabitTrackerMaui;

public partial class UpdateRecords : ContentPage
{
    int id;
    string date;
    int time;
    int distance;
    public UpdateRecords()
    {
        InitializeComponent();
        habitGrid.ItemsSource = App.HabitTrackRepository.ShowAllRuns();
    }

    private void OnUpdate(object sender, EventArgs e)
    {
        
        if(InsertIdText.Text == null || InsertDateText.Text == null || MinutesRan.Text == null || DistanceRan.Text == null){
                EmptyAnswerError.IsVisible = true;
        }
        else{
            id = MinuteAndDistanceParser(InsertIdText.Text);
            date = CheckDateFormat(InsertDateText.Text);
            time = MinuteAndDistanceParser(MinutesRan.Text);
            distance = MinuteAndDistanceParser(DistanceRan.Text);
        }

        App.HabitTrackRepository.Update(new RunTracker
        {
            Id = id,
            DateRun = DateTime.Parse(date),
            MinutesRan = time,
            DistanceRan = distance
        });

        InsertIdText.Text = null;
        MinutesRan.Text = null;
        InsertDateText.Text = null;
        DistanceRan.Text = null;
        habitGrid.ItemsSource = App.HabitTrackRepository.ShowAllRuns();
    }

    private string CheckDateFormat(string dateRun)
    {
        while(!DateTime.TryParseExact(dateRun, "dd-MM-yy", new CultureInfo("en-US"), DateTimeStyles.None, out _))
        {

                DateFormatIncorrect.IsVisible = true;
        }

        return dateRun;
    }

    private int MinuteAndDistanceParser(string time)
    {
        int minutes;

        // Check if valid or not
        if(!Int32.TryParse(time, out minutes))
        {
            // Add error text section which is changed dependent on one of these three methods
        }

        return minutes;
    }

    private void ReturnToMainMenu(object sender, EventArgs e)
    {
        Navigation.PushAsync(new MainPage());
    }

    public void IdDoesNotExist()
    {
        IdNotExist.IsVisible = true;
    }
}