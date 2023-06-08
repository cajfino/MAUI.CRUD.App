namespace Employee_CRUD_APP;

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

		//Add statements for adding EmployeeRepository as a singleton?
		string dbPath = FileAccessHelper.GetLocalFilePath("employee.db3");
        
		builder.Services.AddSingleton<EmployeeRepository>(s => ActivatorUtilities.CreateInstance<EmployeeRepository>(s, dbPath));

        return builder.Build();
	}
}
