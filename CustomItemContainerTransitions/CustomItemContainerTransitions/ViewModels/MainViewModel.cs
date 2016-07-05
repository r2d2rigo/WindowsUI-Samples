using CustomItemContainerTransitions.Controls;
using CustomItemContainerTransitions.DataAccess;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomItemContainerTransitions.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<UserProfile> users;
        public ObservableCollection<UserProfile> Users
        {
            get { return this.users; }
            set
            {
                if (this.users != value)
                {
                    this.users = value;
                    this.RaisePropertyChanged(nameof(Users));
                }
            }
        }

        private ObservableCollection<CompositionTransitionModel> transitions;
        public ObservableCollection<CompositionTransitionModel> Transitions
        {
            get { return this.transitions; }
            private set
            {
                if (this.transitions != value)
                {
                    this.transitions = value;
                    this.RaisePropertyChanged(nameof(Transitions));
                }
            }
        }

        private CompositionTransitionModel activeTransition;
        public CompositionTransitionModel ActiveTransition
        {
            get { return this.activeTransition; }
            set
            {
                if (this.activeTransition != value)
                {
                    this.activeTransition = value;
                    this.RaisePropertyChanged(nameof(ActiveTransition));
                }
            }
        }

        public MainViewModel()
        {
            this.Transitions = new ObservableCollection<CompositionTransitionModel>()
            {
                new CompositionTransitionModel()
                {
                    Name = "Slide in",
                    Transition = new SlideInCompositionTransition() { Duration = new Windows.UI.Xaml.Duration(TimeSpan.FromMilliseconds(250)) }
                },
                new CompositionTransitionModel()
                {
                    Name = "Pop in",
                    Transition = new PopInCompositionTransition() { Duration = new Windows.UI.Xaml.Duration(TimeSpan.FromMilliseconds(250)) }
                },
                new CompositionTransitionModel()
                {
                    Name = "Flip over",
                    Transition = new FlipOverCompositionTransition() { Duration = new Windows.UI.Xaml.Duration(TimeSpan.FromMilliseconds(400)) }
                },
            };

            this.ActiveTransition = this.Transitions.First();

            this.LoadUsers();
        }

        public void LoadUsers()
        {
            var repository = new RandomUserRepository();
            var results = repository.GetRandomUsers();

            this.Users = new ObservableCollection<UserProfile>(results);
        }

        private void RaisePropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
