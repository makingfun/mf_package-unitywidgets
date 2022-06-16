using TMPro;
using UnityEngine;
using static Makingfun.UnityWidgets.UnityExtensions;

namespace Makingfun.UnityWidgets
{
    public class ToolTipUIBaseTextMeshPro : MonoBehaviour, ToolTipUIBase
    {
        [SerializeField] TextMeshProUGUI messageText;

        static Vector3 DefaultPosition => Vector3.zero;

        public void Show(string message)
        {
            messageText.text = message;
            ShowTooltip();
        }

        public void ShowWithDirection(string message, Direction direction)
        {
            messageText.text = message;
            SetTooltipPosition(direction);
            ShowTooltip();
        }

        public void Hide() => gameObject.SetActive(false);
        
        void ShowTooltip() => gameObject.SetActive(true);

        void SetTooltipPosition(Direction direction)
        {
            var tooltipRectTransform = gameObject.GetComponent<RectTransform>();
            var directionVector = GetVectorFrom(direction);
            
            tooltipRectTransform.pivot = directionVector;
            tooltipRectTransform.anchorMin = directionVector;
            tooltipRectTransform.anchorMax = directionVector;
            tooltipRectTransform.anchoredPosition = DefaultPosition;
        }

        void Awake() => Hide();
    }
}