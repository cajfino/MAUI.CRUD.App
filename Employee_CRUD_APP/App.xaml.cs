using System.Security.Cryptography.X509Certificates;

namespace Employee_CRUD_APP;

public partial class App : Application
{
    //Add a public static EmployeeRepository property 
    public static EmployeeRepository EmployeeRepo { get; private set; }
    
	public App(EmployeeRepository repo)
	{
		InitializeComponent();

		MainPage = new AppShell();

		//Initialze the EmployeeRepository property with the EmployeeRepository singleteon object
		EmployeeRepo = repo; 
	}
}
