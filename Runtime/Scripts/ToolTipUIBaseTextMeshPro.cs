using TMPro;
using UnityEngine;

namespace Makingfun.UnityWidgets
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class ToolTipUIBaseTextMeshPro : MonoBehaviour, ToolTipUIBase
    {
        
        [SerializeField] TextMeshProUGUI messageText;

        public void SetMessage(string message) => messageText.text = message;

        public void Show() => gameObject.SetActive(true);
        
        public void Hide() => gameObject.SetActive(false);

        void Awake() => Hide();
    }
}