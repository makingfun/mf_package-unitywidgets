using UnityEngine;
using UnityEngine.EventSystems;

namespace Makingfun.UnityWidgets
{
    public class ToolTip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] Transform spawn;
        [SerializeField] string message;
        [SerializeField] ToolTipUIBaseTextMeshPro toolTipUI;

        void Awake()
        {
            Debug.Log("Making fun widget starting");
            toolTipUI.SetMessage(message);
        }

        public void OnPointerEnter(PointerEventData eventData) => toolTipUI.Show();

        public void OnPointerExit(PointerEventData eventData) => toolTipUI.Hide();
    }
}
