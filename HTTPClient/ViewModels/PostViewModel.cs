using CommunityToolkit.Mvvm.ComponentModel;
using HTTPClient.Models;
using HTTPClient.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HTTPClient.ViewModels
{
    public partial class PostViewModel : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<Post> posts;

        public ICommand getPostsCommand { get; }

        public PostViewModel()
        {
            getPostsCommand = new Command(getPosts);
        }
        public async void getPosts()
        {
            PostService postsService = new PostService();
            posts = await postsService.getPost();
        }
    }
}
