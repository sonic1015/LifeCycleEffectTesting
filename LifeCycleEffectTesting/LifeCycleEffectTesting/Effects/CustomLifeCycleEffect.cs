using System;
using Xamarin.Forms;

namespace LifeCycleEffectTesting.Effects
{
    public class CustomLifeCycleEffect : RoutingEffect
    {

        public event EventHandler Loaded;

        public event EventHandler Unloaded;

        public CustomLifeCycleEffect() : base($"LifeCycleEffectTesting.{nameof(CustomLifeCycleEffect)}")
        {
        }

        public void RaiseLoadedEvent(Element element)
        {
            Loaded?.Invoke(element, EventArgs.Empty);
        }

        public void RaiseUnloadedEvent(Element element)
        {
            Unloaded?.Invoke(element, EventArgs.Empty);
        }
    }
}