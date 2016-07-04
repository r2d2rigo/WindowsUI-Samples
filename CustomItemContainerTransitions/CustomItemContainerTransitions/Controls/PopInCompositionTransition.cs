using System.Numerics;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Hosting;

namespace CustomItemContainerTransitions.Controls
{
    public class PopInCompositionTransition :  ItemCompositionTransitionBase
    {
        public override void Animate(UIElement container)
        {
            var visual = ElementCompositionPreview.GetElementVisual(container);
            var compositor = visual.Compositor;

            var firstControlPoint = new Vector2(0.0f, 0.5f);
            var secondControlPoint = new Vector2(0.5f, 1.0f);

            var easingFunction = compositor.CreateCubicBezierEasingFunction(firstControlPoint, secondControlPoint);

            var scaleAnimation = compositor.CreateVector3KeyFrameAnimation();
            scaleAnimation.Duration = this.Duration.TimeSpan;
            scaleAnimation.InsertKeyFrame(0.0f, new Vector3(0.5f, 0.5f, 0.5f), easingFunction);
            scaleAnimation.InsertKeyFrame(1.0f, new Vector3(1.0f, 1.0f, 1.0f), easingFunction);

            var opacityAnimation = compositor.CreateScalarKeyFrameAnimation();
            opacityAnimation.Duration = this.Duration.TimeSpan;
            opacityAnimation.InsertKeyFrame(0.0f, 0.0f, easingFunction);
            opacityAnimation.InsertKeyFrame(1.0f, 1.0f, easingFunction);

            visual.AnchorPoint = new Vector2(0.5f, 0.5f);
            visual.StartAnimation(nameof(visual.Scale), scaleAnimation);
            visual.StartAnimation(nameof(visual.Opacity), opacityAnimation);
        }
    }
}
