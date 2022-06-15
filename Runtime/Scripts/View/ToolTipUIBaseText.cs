using UnityEngine;
using UnityEngine.UI;

namespace Makingfun.UnityWidgets
{
    [RequireComponent(typeof(Text))]
    public class ToolTipUIBaseText : MonoBehaviour, ToolTipUIBase
    {
        [SerializeField] Text messageText;

        public void SetMessage(string message) => messageText.text = message;
        
        public void Show() => gameObject.SetActive(true);
        public void ShowWithDirection(Direction direction)
        {
            
        }

        void Awake() => Hide();

        void Hide() => gameObject.SetActive(false);
    }
}