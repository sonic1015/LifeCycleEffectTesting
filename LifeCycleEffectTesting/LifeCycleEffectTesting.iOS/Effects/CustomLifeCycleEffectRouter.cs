using Foundation;
using LifeCycleEffectTesting.Effects;
using System.ComponentModel;
using System;
using System.Linq;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using LifeCycleEffectTesting.iOS.Effects;

[assembly: ResolutionGroupName("LifeCycleEffectTesting")]
[assembly: ExportEffect(typeof(CustomLifeCycleEffectRouter), nameof(CustomLifeCycleEffect))]
//[assembly: ExportEffect(typeof(XctVariantLifeCycleEffectRouter), nameof(CustomLifeCycleEffect))]

namespace LifeCycleEffectTesting.iOS.Effects
{
    public class CustomLifeCycleEffectRouter : PlatformEffect
    {
        private const NSKeyValueObservingOptions ObservingOptions = NSKeyValueObservingOptions.Initial | NSKeyValueObservingOptions.OldNew | NSKeyValueObservingOptions.Prior;

        private UIView _nativeView;
        private CustomLifeCycleEffect _viewLifecycleEffect;
        private IDisposable _isLoadedObserverDisposable;

        protected override void OnAttached()
        {
            _viewLifecycleEffect = Element.Effects.OfType<CustomLifeCycleEffect>().FirstOrDefault();

            _nativeView = Control ?? Container;
            _isLoadedObserverDisposable = _nativeView?.AddObserver("superview", ObservingOptions, IsViewLoadedObserver);

            if (_nativeView?.Superview != null)
                _viewLifecycleEffect?.RaiseLoadedEvent(Element);
        }

        protected override void OnDetached()
        {
            _viewLifecycleEffect.RaiseUnloadedEvent(Element);
            _isLoadedObserverDisposable.Dispose();
        }

        private void IsViewLoadedObserver(NSObservedChange nsObservedChange)
        {
            if (!nsObservedChange.NewValue?.Equals(NSNull.Null) ?? false)
                _viewLifecycleEffect?.RaiseLoadedEvent(Element);
            else if (!nsObservedChange.OldValue?.Equals(NSNull.Null) ?? false)
                _viewLifecycleEffect?.RaiseUnloadedEvent(Element);
        }
    }

    public class XctVariantLifeCycleEffectRouter : PlatformEffect
    {
        private CustomLifeCycleEffect _lifeCycleEffect;

        protected override void OnAttached()
        {
            _lifeCycleEffect = Element.Effects.OfType<CustomLifeCycleEffect>().FirstOrDefault() ?? throw new ArgumentNullException($"The effect {nameof(CustomLifeCycleEffect)} can't be null.");

            Element.PropertyChanged += OnPropertyChanged;
        }

        void OnPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Renderer" && _lifeCycleEffect != null)
            {
                var result = Platform.GetRenderer((VisualElement)Element);

                if (result != null)
                    _lifeCycleEffect.RaiseLoadedEvent(Element);
                else
                {
                    _lifeCycleEffect.RaiseUnloadedEvent(Element);
                    _lifeCycleEffect = null;
                    Element.PropertyChanged -= OnPropertyChanged;
                }
            }
        }

        protected override void OnDetached()
        {
        }
    }
}