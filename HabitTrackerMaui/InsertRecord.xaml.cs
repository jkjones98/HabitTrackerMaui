using System.Globalization;
using HabitTrackerMaui.Models;

namespace HabitTrackerMaui;

public partial class InsertRecord : ContentPage
{

    string date;
    int time;
    int distance;
    public InsertRecord()
    {
        InitializeComponent();

        MinutesRan.ClearButtonVisibility = ClearButtonVisibility.WhileEditing;
        InsertDateText.ClearButtonVisibility = ClearButtonVisibility.WhileEditing;
        DistanceRan.ClearButtonVisibility = ClearButtonVisibility.WhileEditing;
    }

    private void AddRecordToDb(object sender, EventArgs e)
    {
        if(InsertDateText.Text == null || MinutesRan.Text == null || DistanceRan.Text == null)
        {

                EmptyAnswerError.IsVisible = true;
        }
        else
        {
            date = CheckDateFormat(InsertDateText.Text);
            time = MinuteAndDistanceParser(MinutesRan.Text);
            distance = MinuteAndDistanceParser(DistanceRan.Text);
        }

        App.HabitTrackRepository.Insert(new RunTracker
        {
            DateRun = DateTime.Parse(date),
            MinutesRan = time,
            DistanceRan = distance
        });

        MinutesRan.Text = null;
        InsertDateText.Text = null;
        DistanceRan.Text = null;

        RtnMainMenu.IsVisible = true;

    }

    private string CheckDateFormat(string dateRun)
    {
        while(!DateTime.TryParseExact(dateRun, "dd-MM-yy", new CultureInfo("en-US"), DateTimeStyles.None, out _))
        {
                CheckDateFormat(dateRun);
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

}