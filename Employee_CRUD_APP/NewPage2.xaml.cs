using System.Diagnostics;

namespace Employee_CRUD_APP;

public partial class NewPage2 : ContentPage
{
	public NewPage2()
	{
		InitializeComponent();
	}

    //THIS IS THE DELETE EMPLOYEE PAGE - I MESSED UP THE NAMES!!!

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
    }

    //Get Employee List 
    private async void Button_Clicked(object sender, EventArgs e)
    {
        employeeList.ItemsSource = await App.EmployeeRepo.GetEmployeeAsync();
    }

    //Delete Employee
    private async void Button_Clicked_1(object sender, EventArgs e)
    {
        if (lastSelection != null)
        {

            await App.EmployeeRepo.DeleteEmployeeAsync(lastSelection);
            employeeList.ItemsSource = await App.EmployeeRepo.GetEmployeeAsync();
            await DisplayAlert("Alert", "Employee Deleted!", "OK");
        }
    }
}