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
    public class FlipOverCompositionTransition : ItemCompositionTransitionBase
    {
        public FlipOverCompositionTransition()
        {
        }

        public override void Animate(UIElement container)
        {
            var visual = ElementCompositionPreview.GetElementVisual(container);
            var compositor = visual.Compositor;

            var firstControlPoint = new Vector2(0.0f, 0.0f);
            var secondControlPoint = new Vector2(0.5f, 1.0f);

            var easingFunction = compositor.CreateCubicBezierEasingFunction(firstControlPoint, secondControlPoint);

            var rotateAnimation = compositor.CreateScalarKeyFrameAnimation();
            rotateAnimation.Duration = this.Duration.TimeSpan;
            rotateAnimation.InsertKeyFrame(0.0f, 180.0f, easingFunction);
            rotateAnimation.InsertKeyFrame(1.0f, 0.0f, easingFunction);

            var opacityAnimation = compositor.CreateScalarKeyFrameAnimation();
            opacityAnimation.Duration = this.Duration.TimeSpan;
            opacityAnimation.InsertKeyFrame(0.0f, 0.0f, easingFunction);
            opacityAnimation.InsertKeyFrame(1.0f, 1.0f, easingFunction);

            visual.RotationAxis = new Vector3(1.0f, 0.0f, 0.0f);
            visual.BackfaceVisibility = CompositionBackfaceVisibility.Hidden;
            visual.CenterPoint = new Vector3((float)container.RenderSize.Width / 2.0f, (float)container.RenderSize.Height / 2.0f, 0.0f);
            visual.StartAnimation(nameof(visual.RotationAngleInDegrees), rotateAnimation);
            visual.StartAnimation(nameof(visual.Opacity), opacityAnimation);
        }
    }
}
