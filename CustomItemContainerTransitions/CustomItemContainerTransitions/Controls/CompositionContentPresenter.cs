using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace CustomItemContainerTransitions.Controls
{
    public class CompositionContentPresenter : ContentPresenter
    {
        public static readonly DependencyProperty ItemCompositionTransitionProperty = DependencyProperty.Register(
            "ItemCompositionTransition",
            typeof(ItemCompositionTransitionBase),
            typeof(CompositionContentPresenter),
            new PropertyMetadata(null));

        public ItemCompositionTransitionBase ItemCompositionTransition
        {
            get { return (ItemCompositionTransitionBase)this.GetValue(ItemCompositionTransitionProperty); }
            set { this.SetValue(ItemCompositionTransitionProperty, value); }
        }

        public CompositionContentPresenter()
        {
            this.Loaded += CompositionContentPresenter_Loaded;
            this.Unloaded += CompositionContentPresenter_Unloaded;
        }

        private void CompositionContentPresenter_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (this.ItemCompositionTransition != null)
            {
                this.ItemCompositionTransition.Animate(this);
            }
        }

        private void CompositionContentPresenter_Unloaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            this.Loaded -= CompositionContentPresenter_Loaded;
            this.Unloaded -= CompositionContentPresenter_Unloaded;
        }
    }
}
