using HTTPClient.ViewModels;

namespace HTTPClient.Views;

public partial class TodoView : ContentPage
{
    public TodoView()
    {
        InitializeComponent();
        BindingContext = new TodosViewModel();
    }
}