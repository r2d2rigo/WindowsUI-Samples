using CustomItemContainerTransitions.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomItemContainerTransitions.ViewModels
{
    public class CompositionTransitionModel
    {
        public string Name { get; set; }
        public ItemCompositionTransitionBase Transition { get; set; }
    }
}
