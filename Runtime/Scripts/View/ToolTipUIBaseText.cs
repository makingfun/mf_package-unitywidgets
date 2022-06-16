using UnityEngine;
using UnityEngine.UI;

namespace Makingfun.UnityWidgets
{
    [RequireComponent(typeof(Text))]
    public class ToolTipUIBaseText : MonoBehaviour, ToolTipUIBase
    {
        [SerializeField] Text messageText;

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