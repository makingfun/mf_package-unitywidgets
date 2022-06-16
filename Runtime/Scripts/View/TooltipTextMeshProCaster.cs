using UnityEngine;
using UnityEngine.EventSystems;

namespace Makingfun.UnityWidgets
{
    public class TooltipTextCaster : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] string message;
        [SerializeField] ToolTipUIBaseTextMeshPro toolTipUI;

        public void OnPointerEnter(PointerEventData eventData) => ToolTipManager.ShowText(toolTipUI, message);

        public void OnPointerExit(PointerEventData eventData) => toolTipUI.Hide();
    }
}
