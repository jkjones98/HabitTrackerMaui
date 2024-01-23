using HabitTrackerMaui.Data;

namespace HabitTrackerMaui;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		string dbPath = Path.Combine(FileSystem.AppDataDirectory, "runTracker.db");

		builder.Services.AddSingleton(s=>
			ActivatorUtilities.CreateInstance<HabitTrackRepository>(s, dbPath));

		return builder.Build();
	}
}
