using System.Numerics;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Hosting;

namespace CustomItemContainerTransitions.Controls
{
    public sealed class SlideInCompositionTransition :  ItemCompositionTransitionBase
    {
        public SlideInCompositionTransition()
        {
        }

        public override void Animate(UIElement container)
        {
            var visual = ElementCompositionPreview.GetElementVisual(container);
            var compositor = visual.Compositor;

            var firstControlPoint = new Vector2(0.0f, 0.5f);
            var secondControlPoint = new Vector2(0.5f, 1.0f);

            var easingFunction = compositor.CreateCubicBezierEasingFunction(firstControlPoint, secondControlPoint);
 
            var offsetAnimation = compositor.CreateVector3KeyFrameAnimation();
            offsetAnimation.Duration = this.Duration.TimeSpan;
            offsetAnimation.InsertKeyFrame(0.0f, new Vector3(150.0f, 0.0f, 0.0f), easingFunction);
            offsetAnimation.InsertKeyFrame(1.0f, new Vector3(0.0f, 0.0f, 0.0f), easingFunction);
 
            var opacityAnimation = compositor.CreateScalarKeyFrameAnimation();
            opacityAnimation.Duration = this.Duration.TimeSpan;
            opacityAnimation.InsertKeyFrame(0.0f, 0.0f, easingFunction);
            opacityAnimation.InsertKeyFrame(1.0f, 1.0f, easingFunction);
 
            visual.StartAnimation(nameof(visual.Offset), offsetAnimation);
            visual.StartAnimation(nameof(visual.Opacity), opacityAnimation);
        }
    }
}
