using System;
using Windows.UI.Xaml;

namespace CustomItemContainerTransitions.Controls
{
    /// <summary>
    /// Base class for implementing transitions. It has a <see cref="DependencyProperty"/> for the animation's duration
    /// and an <see cref="Animate(UIElement)"/> method; overriding this in derived classes will allow us to provide
    /// custom animations.
    /// </summary>
    public abstract class ItemCompositionTransitionBase : DependencyObject
    {
        public static readonly DependencyProperty DurationProperty = DependencyProperty.Register(
            "Duration",
            typeof(Duration),
            typeof(ItemCompositionTransitionBase),
            new PropertyMetadata(new Duration(TimeSpan.Zero)));

        /// <summary>
        /// Duration for the animation.
        /// </summary>
        public Duration Duration
        {
            get { return (Duration)this.GetValue(DurationProperty); }
            set { this.SetValue(DurationProperty, value); }
        }

        /// <summary>
        /// Applies the animation to the target <see cref="UIElement"/>.
        /// </summary>
        /// <param name="container"></param>
        public abstract void Animate(UIElement container);
    }
}
