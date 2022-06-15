using TMPro;
using UnityEngine;

namespace Makingfun.UnityWidgets
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class ToolTipUIBaseTextMeshPro : MonoBehaviour, ToolTipUIBase
    {
        
        [SerializeField] TextMeshProUGUI messageText;

        public void Show(string message)
        {
            messageText.text = message;
            gameObject.SetActive(true);
        }

        public void ShowWithDirection(string message, Direction direction)
        {
            throw new System.NotImplementedException();
        }

        public void Hide() => gameObject.SetActive(false);

        void Awake() => Hide();
    }
}