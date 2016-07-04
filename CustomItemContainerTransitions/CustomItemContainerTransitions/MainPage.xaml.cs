using CustomItemContainerTransitions.DataAccess;
using CustomItemContainerTransitions.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace CustomItemContainerTransitions
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private ObservableCollection<UserProfile> users;

        public MainPage()
        {
            this.InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            RandomUserRepository c = new RandomUserRepository();
            var r = await c.GetRandomUsersAsync();
            this.users = new ObservableCollection<UserProfile>(r);

            await Task.Delay(2000);
            this.UsersList.ItemsSource = this.users;
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            this.users.RemoveAt(0);
        }
    }
}
