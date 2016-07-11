using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace CustomItemContainerTransitions.Controls
{
    /// <summary>
    /// Custom content presenter that will be used as the root object of the <see cref="GridView"/>/<see cref="ListView"/>.
    /// If it has a custom transition attached, it will be fired when the control loads.
    /// </summary>
    public class CompositionContentPresenter : ContentPresenter
    {
        public static readonly DependencyProperty ItemCompositionTransitionProperty = DependencyProperty.Register(
            "ItemCompositionTransition",
            typeof(ItemCompositionTransitionBase),
            typeof(CompositionContentPresenter),
            new PropertyMetadata(null));

        /// <summary>
        /// Custom Composition transition, if any.
        /// </summary>
        public ItemCompositionTransitionBase ItemCompositionTransition
        {
            get { return (ItemCompositionTransitionBase)this.GetValue(ItemCompositionTransitionProperty); }
            set { this.SetValue(ItemCompositionTransitionProperty, value); }
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public CompositionContentPresenter()
        {
            this.Loaded += CompositionContentPresenter_Loaded;
            this.Unloaded += CompositionContentPresenter_Unloaded;
        }

        /// <summary>
        /// When the control ends loading, it fires the animation if there is any.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CompositionContentPresenter_Loaded(object sender, RoutedEventArgs e)
        {
            if (this.ItemCompositionTransition != null)
            {
                this.ItemCompositionTransition.Animate(this);
            }
        }

        /// <summary>
        /// Unsubscribe from event handlers on unload.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CompositionContentPresenter_Unloaded(object sender, RoutedEventArgs e)
        {
            this.Loaded -= CompositionContentPresenter_Loaded;
            this.Unloaded -= CompositionContentPresenter_Unloaded;
        }
    }
}
