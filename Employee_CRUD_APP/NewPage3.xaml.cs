using System.Xml.Linq;

namespace Employee_CRUD_APP;

public partial class NewPage3 : ContentPage
{
	public NewPage3()
	{
		InitializeComponent();
	}

    //THIS IS THE UPDATE EMPLOYEE PAGE - I MESSED UP THE NAMES!!!

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

    //Get last employee selected from list 
    Employee lastSelection;

    private void employeeList_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        lastSelection = e.CurrentSelection[0] as Employee;
        statusMessage.Text = (lastSelection.Name + " " + lastSelection.Surname);
        nameEntry.Text = lastSelection.Name;
        SurnameEntry.Text = lastSelection.Surname;
        EmailEntry.Text = lastSelection.Email;
    }

    //Get Employee List 
    private async void Button_Clicked(object sender, EventArgs e)
    {
        employeeList.ItemsSource = await App.EmployeeRepo.GetEmployeeAsync();
    }

    //Update Employee
    private async void Button_Clicked_1(object sender, EventArgs e)
    {
        if (lastSelection != null)
        {
            lastSelection.Name = nameEntry.Text;
            lastSelection.Surname = SurnameEntry.Text;
            lastSelection.Email = EmailEntry.Text;
            await App.EmployeeRepo.UpdateEmployeeAsync(lastSelection);
            employeeList.ItemsSource = await App.EmployeeRepo.GetEmployeeAsync();
        }
    }
}