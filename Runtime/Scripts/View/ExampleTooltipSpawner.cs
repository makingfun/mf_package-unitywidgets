using UnityEngine;

namespace Makingfun.UnityWidgets.Scripts.GameDevScripts
{
    public class ExampleTooltipSpawner : TooltipSpawner
    {
        [SerializeField] string title;
        [SerializeField] string message;
        
        protected override void UpdateTooltip(GameObject tooltip)
        {
            var itemTooltip = tooltip.GetComponent<ItemTooltip>();
            if (!itemTooltip) return;
            
            itemTooltip.Setup(title, message);
        }

        protected override bool CanCreateTooltip() => true;
    }
}