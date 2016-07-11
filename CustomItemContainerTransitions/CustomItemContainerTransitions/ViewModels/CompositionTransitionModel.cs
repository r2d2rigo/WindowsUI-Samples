using CustomItemContainerTransitions.Controls;

namespace CustomItemContainerTransitions.ViewModels
{
    /// <summary>
    /// Basic model class used for binding different transition types to a ComboBox.
    /// </summary>
    public class CompositionTransitionModel
    {
        /// <summary>
        /// Name of the transition.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Actual transition animation.
        /// </summary>
        public ItemCompositionTransitionBase Transition { get; set; }
    }
}
