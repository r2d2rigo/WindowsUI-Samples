using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace CustomItemContainerTransitions.Controls
{
    public abstract class ItemCompositionTransitionBase : DependencyObject
    {
        public static readonly DependencyProperty DurationProperty = DependencyProperty.Register(
            "Duration",
            typeof(Duration),
            typeof(ItemCompositionTransitionBase),
            new PropertyMetadata(new Duration(TimeSpan.Zero)));

        public Duration Duration
        {
            get { return (Duration)this.GetValue(DurationProperty); }
            set { this.SetValue(DurationProperty, value); }
        }

        public virtual void Animate(UIElement container)
        {
        }
    }
}
