namespace AR_JC_ProyectoP2;

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

        string dbPath = FileAccessHelper.GetLocalFilePath("log.db3");
        builder.Services.AddSingleton<LogRepository>(s => ActivatorUtilities.CreateInstance<LogRepository>(s, dbPath));

        return builder.Build();
	}
}
