using UnityEngine;
using UnityEngine.EventSystems;

namespace Makingfun.UnityWidgets
{
    public class ToolTip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] string message;
        [SerializeField] ToolTipUIBaseTextMeshPro toolTipUI;

        void Awake()
        {
            Debug.Log("Making fun widget starting");
            toolTipUI.SetMessage(message);
        }

        public void OnPointerEnter(PointerEventData eventData) => ToolTipManager.ShowText(toolTipUI, message);

        public void OnPointerExit(PointerEventData eventData) => toolTipUI.Hide();
    }
}
