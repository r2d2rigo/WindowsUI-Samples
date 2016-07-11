using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Composition;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Hosting;
using Windows.UI.Xaml.Markup;
using Windows.UI.Xaml.Media;

namespace CustomItemContainerTransitions.Controls
{
    /// <summary>
    /// Custom transition animation for making items appear in a vertical 180 degrees flip over animation.
    /// </summary>
    public sealed class FlipOverCompositionTransition : ItemCompositionTransitionBase
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

            var firstControlPoint = new Vector2(0.0f, 0.0f);
            var secondControlPoint = new Vector2(0.5f, 1.0f);

            // Create cubic easing function from the control points specified.
            var easingFunction = compositor.CreateCubicBezierEasingFunction(firstControlPoint, secondControlPoint);

            // Animation for the angle change (flip over).
            var rotateAnimation = compositor.CreateScalarKeyFrameAnimation();
            rotateAnimation.Duration = this.Duration.TimeSpan;
            rotateAnimation.InsertKeyFrame(0.0f, 180.0f, easingFunction);
            rotateAnimation.InsertKeyFrame(1.0f, 0.0f, easingFunction);

            // Animation for the opacity change (appear).
            var opacityAnimation = compositor.CreateScalarKeyFrameAnimation();
            opacityAnimation.Duration = this.Duration.TimeSpan;
            opacityAnimation.InsertKeyFrame(0.0f, 0.0f, easingFunction);
            opacityAnimation.InsertKeyFrame(1.0f, 1.0f, easingFunction);

            // Set the rotation axis so the Visual rotates on the X (horizontal) axis.
            visual.RotationAxis = new Vector3(1.0f, 0.0f, 0.0f);

            // Hide Visual back face so we don't see the contents inverted while animating.
            visual.BackfaceVisibility = CompositionBackfaceVisibility.Hidden;

            // Set the center of the Visual on the center of the control - otherwise the Visual would rotate using
            // the top left corner as its anchor point.
            visual.CenterPoint = new Vector3((float)container.RenderSize.Width / 2.0f, (float)container.RenderSize.Height / 2.0f, 0.0f);

            // Start the flip over and appear animations.
            visual.StartAnimation(nameof(visual.RotationAngleInDegrees), rotateAnimation);
            visual.StartAnimation(nameof(visual.Opacity), opacityAnimation);
        }
    }
}
