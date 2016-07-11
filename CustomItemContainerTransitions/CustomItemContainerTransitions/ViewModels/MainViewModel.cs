using CustomItemContainerTransitions.Controls;
using CustomItemContainerTransitions.DataAccess;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using Windows.UI.Xaml;

namespace CustomItemContainerTransitions.ViewModels
{
    /// <summary>
    /// ViewModel class for holding the user data that will be bound to the sample list and the available and active
    /// Composition transitions.
    /// </summary>
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<UserProfile> users;

        /// <summary>
        /// Sample user profiles.
        /// </summary>
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

        /// <summary>
        /// Available transitions.
        /// </summary>
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

        /// <summary>
        /// Selected transitions.
        /// </summary>
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

        /// <summary>
        /// Initialize the ViewModel.
        /// </summary>
        public MainViewModel()
        {
            // Instantiate one of each of the implemented Composition transitions.
            this.Transitions = new ObservableCollection<CompositionTransitionModel>()
            {
                new CompositionTransitionModel()
                {
                    Name = "Slide in",
                    Transition = new SlideInCompositionTransition() { Duration = new Duration(TimeSpan.FromMilliseconds(250)) }
                },
                new CompositionTransitionModel()
                {
                    Name = "Pop in",
                    Transition = new PopInCompositionTransition() { Duration = new Duration(TimeSpan.FromMilliseconds(250)) }
                },
                new CompositionTransitionModel()
                {
                    Name = "Flip over",
                    Transition = new FlipOverCompositionTransition() { Duration = new Duration(TimeSpan.FromMilliseconds(400)) }
                },
            };

            // Set the Slide In as the default selected transition.
            this.ActiveTransition = this.Transitions.First();

            // Load user data.
            this.LoadUsers();
        }

        // Loads the data from the repository and initializes the collection.
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
