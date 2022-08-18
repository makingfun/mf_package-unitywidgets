using UnityEngine;
using UnityEngine.EventSystems;

namespace Makingfun.UnityWidgets.Scripts.Core
{
    /// <summary>
    /// Abstract base class that handles the spawning of a tooltip prefab at the
    /// correct position on screen relative to a cursor.
    /// 
    /// Override the abstract functions to create a tooltip spawner for your own
    /// data.
    /// </summary>
    public abstract class TooltipSpawner : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [Tooltip("The prefab of the tooltip to spawn.")]
        [SerializeField] GameObject tooltipPrefab;

        [Tooltip("Force a position to spawn the tooltip prefab.")]
        [SerializeField] Direction tooltipDirection = Direction.Default;

        GameObject tooltip;
        ToolTipPositioner toolTipPositioner;
        
        /// <summary>
        /// Called when it is time to update the information on the tooltip
        /// prefab.
        /// </summary>
        /// <param name="tooltip">
        /// The spawned tooltip prefab for updating.
        /// </param>
        protected abstract void UpdateTooltip(GameObject tooltip);
        
        /// <summary>
        /// Return true when the tooltip spawner should be allowed to create a tooltip.
        /// </summary>
        protected abstract bool CanCreateTooltip();

        void Start() => toolTipPositioner = new ToolTipPositioner(gameObject);

        void OnDestroy() => ClearTooltip();

        void OnDisable() => ClearTooltip();

        void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
        {
            var parentCanvas = GetComponentInParent<Canvas>();

            if (tooltip && !CanCreateTooltip()) 
                ClearTooltip();

            if (!tooltip && CanCreateTooltip())
            {
                tooltip = Instantiate(tooltipPrefab, parentCanvas.transform);
                toolTipPositioner.SetTooltip(tooltip);
            }

            if (tooltip)
            {
                UpdateTooltip(tooltip);
                PositionTooltip();
            }
        }

        void IPointerExitHandler.OnPointerExit(PointerEventData eventData) => ClearTooltip();

        void PositionTooltip() => tooltip.transform.position = IsPositionIsDefault() ?
            toolTipPositioner.GetRelativePosition() : 
            toolTipPositioner.GetPositionFromDirection(tooltipDirection);

        bool IsPositionIsDefault() => tooltipDirection == Direction.Default;

        void ClearTooltip()
        {
            if (tooltip) 
                Destroy(tooltip.gameObject);
        }
    }
}