using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace CustomItemContainerTransitions.Controls
{
    public class CompositionGridView : GridView
    {
        public static readonly DependencyProperty ItemCompositionTransitionProperty = DependencyProperty.Register(
            "ItemCompositionTransition",
            typeof(ItemCompositionTransitionBase),
            typeof(CompositionGridView),
            new PropertyMetadata(null));

        public ItemCompositionTransitionBase ItemCompositionTransition
        {
            get { return (ItemCompositionTransitionBase)this.GetValue(ItemCompositionTransitionProperty); }
            set { this.SetValue(ItemCompositionTransitionProperty, value); }
        }

        protected override void PrepareContainerForItemOverride(DependencyObject element, object item)
        {
            base.PrepareContainerForItemOverride(element, item);

            var uiElement = element as UIElement;

            if (this.ItemCompositionTransition != null && uiElement != null)
            {
                this.ItemCompositionTransition.Animate(uiElement);
            }
        }
    }
}
