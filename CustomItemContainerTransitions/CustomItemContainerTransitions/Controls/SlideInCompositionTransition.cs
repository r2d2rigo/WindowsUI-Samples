using System.Numerics;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Hosting;

namespace CustomItemContainerTransitions.Controls
{
    /// <summary>
    /// Custom transition animation for making items appear in an horizontal slide in motion.
    /// As an improvement, the slide in axis and direction could be done through dependency properties.
    /// </summary>
    public sealed class SlideInCompositionTransition :  ItemCompositionTransitionBase
    {
        /// <summary>
        /// Applies the animation to the target <see cref="UIElement"/>.
        /// </summary>
        /// <param name="container"></param>
        public override void Animate(UIElement container)
        {
            // Get Composition visual.
            var visual = ElementCompositionPreview.GetElementVisual(container);
            var compositor = visual.Compositor;

            var firstControlPoint = new Vector2(0.0f, 0.5f);
            var secondControlPoint = new Vector2(0.5f, 1.0f);

            // Create cubic easing function from the control points specified.
            var easingFunction = compositor.CreateCubicBezierEasingFunction(firstControlPoint, secondControlPoint);
 
            // Animation for the offset change (horizontal slide in).
            var offsetAnimation = compositor.CreateVector3KeyFrameAnimation();
            offsetAnimation.Duration = this.Duration.TimeSpan;
            offsetAnimation.InsertKeyFrame(0.0f, new Vector3(150.0f, 0.0f, 0.0f), easingFunction);
            offsetAnimation.InsertKeyFrame(1.0f, new Vector3(0.0f, 0.0f, 0.0f), easingFunction);
 
            // Animation for the opacity change (appear).
            var opacityAnimation = compositor.CreateScalarKeyFrameAnimation();
            opacityAnimation.Duration = this.Duration.TimeSpan;
            opacityAnimation.InsertKeyFrame(0.0f, 0.0f, easingFunction);
            opacityAnimation.InsertKeyFrame(1.0f, 1.0f, easingFunction);
 
            // Start the slide in and appear animations.
            visual.StartAnimation(nameof(visual.Offset), offsetAnimation);
            visual.StartAnimation(nameof(visual.Opacity), opacityAnimation);
        }
    }
}
