namespace Employee_CRUD_APP;

public partial class MainPage : ContentPage
{

    public MainPage()
    {
        InitializeComponent();
        //employeeList.ItemsSource = App.EmployeeRepo.GetEmployeeAsync();
    }

    //METHODS FOR NAVIGATION

    //Navigate to NewPage1: Add New Employee
    async void NavigateTo(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new NewPage1());
    }

    //Navigate to NewPage2: Delete Employee
    async void Button_Clicked_2(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new NewPage2());
    }

    //Navigate to NewPage3: UpdateEmployee
    async void Button_Clicked_1(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new NewPage3());
    }

    //Navigate to Settings 
    async void NavSettings(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Settings());
    }

    //OTHER METHODS

    //View Current Employee List 
    private async void Button_Clicked(object sender, EventArgs e)
    {
        employeeList.ItemsSource = await App.EmployeeRepo.GetEmployeeAsync();
    }

    
}

