using HabitTrackerMaui.Data;

namespace HabitTrackerMaui;

public partial class App : Application
{
	public static HabitTrackRepository HabitTrackRepository {get; private set;}
	public App(HabitTrackRepository habitTrackRepository)
	{
		InitializeComponent();

		MainPage = new AppShell();

		HabitTrackRepository = habitTrackRepository;
	}
}
