namespace Employee_CRUD_APP;

public partial class NewPage1 : ContentPage
{
	public NewPage1()
	{
		InitializeComponent();
	}

    //THIS IS THE ADD EMPLOYEE PAGE - I MESSED UP THE NAMES!!!

    //METHODS FOR NAVIGATION 
    
    //Navigate to Main Page 
    async void NavigateTo(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
    }

    //Navigate to Settings 
    async void NavSettings(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Settings());
    }

    //OTHER METHODS 

    //Create Last Selection Employee Object
    Employee lastSelection;

    //The last selected employee from the list
    private void employeeList_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        lastSelection = e.CurrentSelection[0] as Employee;

        nameEntry.Text = lastSelection.Name;
    }

    //Add Employee
    private async void Button_Clicked(object sender, EventArgs e)
    {
        statusMessage.Text = "";
        
        if (!string.IsNullOrEmpty(nameEntry.Text))
        {
            await App.EmployeeRepo.SaveEmployeeAsync(new Employee
            {
                Name = nameEntry.Text,
                Surname = SurnameEntry.Text,
                Email = EmailEntry.Text
            });

            nameEntry.Text = string.Empty;
            SurnameEntry.Text = string.Empty;
            EmailEntry.Text = string.Empty;
        }

        statusMessage.Text = App.EmployeeRepo.statusMessage;
    }
}