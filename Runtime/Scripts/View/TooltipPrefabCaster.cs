using UnityEngine;
using UnityEngine.EventSystems;

namespace Makingfun.UnityWidgets
{
    public class TooltipPrefabCaster : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] string message;
        [SerializeField] GameObject prefab;
        [SerializeField] Transform spawn;
        [SerializeField] Direction spawnPosition;
        
        ToolTipUIBase prefabTooltipBase;

        public void OnPointerEnter(PointerEventData eventData)
        {
            prefabTooltipBase ??= CreateTooltipFromPrefab();
            prefabTooltipBase.ShowWithDirection(message, spawnPosition);
        }

        ToolTipUIBase CreateTooltipFromPrefab() => 
            Instantiate(prefab, Vector3.zero, Quaternion.identity, spawn).GetComponent<ToolTipUIBase>();

        public void OnPointerExit(PointerEventData eventData) => prefabTooltipBase.Hide();
    }
}