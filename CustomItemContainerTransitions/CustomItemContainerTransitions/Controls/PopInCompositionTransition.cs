using System.Numerics;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Hosting;

namespace CustomItemContainerTransitions.Controls
{
    /// <summary>
    /// Custom transition animation for making items appear in a pop in animation, growing in size from the center.
    /// </summary>
    public sealed class PopInCompositionTransition :  ItemCompositionTransitionBase
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

            var firstControlPoint = new Vector2(0.35f, 0.1f);
            var secondControlPoint = new Vector2(0.0f, 1.50f);

            // Create cubic easing function from the control points specified.
            var easingFunction = compositor.CreateCubicBezierEasingFunction(firstControlPoint, secondControlPoint);

            // Animation for the scale change (pop in).
            var scaleAnimation = compositor.CreateVector3KeyFrameAnimation();
            scaleAnimation.Duration = this.Duration.TimeSpan;
            scaleAnimation.InsertKeyFrame(0.0f, new Vector3(0.5f, 0.5f, 0.5f), easingFunction);
            scaleAnimation.InsertKeyFrame(1.0f, new Vector3(1.0f, 1.0f, 1.0f), easingFunction);

            // Animation for the opacity change (appear).
            var opacityAnimation = compositor.CreateScalarKeyFrameAnimation();
            opacityAnimation.Duration = this.Duration.TimeSpan;
            opacityAnimation.InsertKeyFrame(0.0f, 0.0f, easingFunction);
            opacityAnimation.InsertKeyFrame(1.0f, 1.0f, easingFunction);

            // Set the center of the Visual on the center of the control - this way the Visual will grow
            // proportionally horizontally and vertically.
            visual.CenterPoint = new Vector3((float)container.RenderSize.Width / 2.0f, (float)container.RenderSize.Height / 2.0f, 0.0f);

            // Start the pop in and appear animations.
            visual.StartAnimation(nameof(visual.Scale), scaleAnimation);
            visual.StartAnimation(nameof(visual.Opacity), opacityAnimation);
        }
    }
}
