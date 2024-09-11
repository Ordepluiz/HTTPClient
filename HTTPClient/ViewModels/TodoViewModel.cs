using CommunityToolkit.Mvvm.ComponentModel;
using HTTPClient.Models;
using HTTPClient.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace HTTPClient.ViewModels
{
    public partial class TodosViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<Todos> todos;

        public ICommand getTodosCommand { get; }

        public TodosViewModel()
        {
            getTodosCommand = new Command(async () => await getTodos());
        }

        public async Task getTodos()
        {
            TodosService todosService = new TodosService();
            todos = await todosService.getTodos();
        }
    }
}
