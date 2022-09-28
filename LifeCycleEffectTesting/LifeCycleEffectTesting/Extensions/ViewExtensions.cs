using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Xml.Linq;
using LifeCycleEffectTesting.Effects;
using Xamarin.Forms;

namespace LifeCycleEffectTesting.Extensions;

public static class ViewExtensions
{
    public static void InitializeConnectionToParent(this VisualElement element)
    {
        var elementName = element.GetType().Name;

        if (element is Page page)
        {
            Debug.WriteLine($"{elementName} is already a page.");
        }

        var customLifeCycleEffect = new CustomLifeCycleEffect();
        var badTimerCheckingFlag = false;

        customLifeCycleEffect.Loaded += (sender, args) =>
        {
            badTimerCheckingFlag = true;

            if (element.Parent == null)
            {
                throw new NullReferenceException($"{elementName} does not have a parent ???.");
            }

            var current = element.Parent;

            while (current is not Page)
            {
                current = current.Parent;

                if (current == null)
                    throw new NullReferenceException($"How can {elementName} be loaded and not have a parent in hierarchy ???.");
            }

            var pageName = element.GetType().Name;

            Debug.WriteLine($"{elementName} is a child of {pageName}.");
        };

        element.Effects.Add(customLifeCycleEffect);

        Task.Factory.StartNew(async () =>
        {
            await Task.Delay(3000);
            if (!badTimerCheckingFlag)
            {
                Debug.WriteLine($"WTF??? we never loaded {elementName}.");
            }
        });
    }
}