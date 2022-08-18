using System;
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
        [SerializeField] Direction tooltipPosition = Direction.Default;

        GameObject tooltip;

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

        void OnDestroy() => ClearTooltip();

        void OnDisable() => ClearTooltip();

        void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
        {
            var parentCanvas = GetComponentInParent<Canvas>();

            if (tooltip && !CanCreateTooltip()) 
                ClearTooltip();

            if (!tooltip && CanCreateTooltip()) 
                tooltip = Instantiate(tooltipPrefab, parentCanvas.transform);

            if (tooltip)
            {
                UpdateTooltip(tooltip);
                PositionTooltip();
            }
        }

        void IPointerExitHandler.OnPointerExit(PointerEventData eventData) => ClearTooltip();

        void PositionTooltip()
        {
            if (tooltipPosition == Direction.Default)
                PickPosition();
            else
                ForcePosition(tooltipPosition);
        }

        void PickPosition()
        {
            Canvas.ForceUpdateCanvases();

            var tooltipCorners = new Vector3[4];
            tooltip.GetComponent<RectTransform>().GetWorldCorners(tooltipCorners);
            var slotCorners = new Vector3[4];
            GetComponent<RectTransform>().GetWorldCorners(slotCorners);

            var position = transform.position;
            var below = position.y > Screen.height / 2;
            var right = position.x < Screen.width / 2;
            var slotCorner = GetCornerIndex(below, right);
            var tooltipCorner = GetCornerIndex(!below, !right);

            tooltip.transform.position = slotCorners[slotCorner] - tooltipCorners[tooltipCorner] + 
                                         tooltip.transform.position;
        }

        void ForcePosition(Direction direction)
        {
            Canvas.ForceUpdateCanvases();
            tooltip.transform.position = transform.position;
            
            var tooltipRectTransform = tooltip.GetComponent<RectTransform>();
            var tooltipRectangle = tooltipRectTransform.rect;
            var casterRectangle = GetComponent<RectTransform>().rect;
            var movingDeltaY = tooltipRectangle.height / 2 + casterRectangle.height / 2;
            var movingDeltaX = tooltipRectangle.width / 2 + casterRectangle.width / 2;
            
            var anchoredPosition = tooltipRectTransform.anchoredPosition;
        
            switch (direction)
            {
                case Direction.Default:
                    break;
                case Direction.Up:
                    tooltipRectTransform.anchoredPosition = new Vector2(anchoredPosition.x, 
                        anchoredPosition.y + movingDeltaY);
                    break;
                case Direction.Down:
                    tooltipRectTransform.anchoredPosition = new Vector2(anchoredPosition.x,
                        anchoredPosition.y - movingDeltaY);
                    break;
                case Direction.Left:
                    tooltipRectTransform.anchoredPosition = new Vector2(anchoredPosition.x - movingDeltaX, anchoredPosition.y);
                    break;
                case Direction.Right:
                    tooltipRectTransform.anchoredPosition = new Vector2(anchoredPosition.x + movingDeltaX, anchoredPosition.y);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
            }
        }

        void ClearTooltip()
        {
            if (tooltip) 
                Destroy(tooltip.gameObject);
        }

        static int GetCornerIndex(bool below, bool right) =>
            below switch
            {
                true when !right => 0,
                false when !right => 1,
                false when true => 2,
                _ => 3
            };
    }
}