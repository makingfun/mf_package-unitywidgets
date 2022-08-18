using UnityEngine;

namespace Makingfun.UnityWidgets.Scripts.Core
{
    public class ToolTipPositioner
    {
        RectTransform tooltipRectTransform;
        
        readonly Vector3 casterPosition;
        readonly Vector3[] casterCorners = new Vector3[4];
        readonly RectTransform casterRectTransform;
        readonly Vector3[] tooltipCorners = new Vector3[4];

        public ToolTipPositioner(GameObject caster)
        {
            casterRectTransform = caster.GetComponent<RectTransform>();
            casterPosition = casterRectTransform.transform.position;
        }

        public void SetTooltip(GameObject tooltip) => 
            tooltipRectTransform = tooltip.GetComponent<RectTransform>();

        public Vector3 GetRelativePosition()
        {
            Canvas.ForceUpdateCanvases();
            SetCorners();

            var below = IsBelowHalfScreen();
            var right = IsPassHalfScreen();
            var casterCornerIndex = GetCornerIndex(below, right);
            var tooltipCornerIndex = GetCornerIndex(!below, !right);

            return casterCorners[casterCornerIndex] - tooltipCorners[tooltipCornerIndex] + 
                   tooltipRectTransform.transform.position;
        }

        public Vector3 GetPositionFromDirection(Direction tooltipDirection)
        {
            Canvas.ForceUpdateCanvases();
            tooltipRectTransform.transform.position = casterRectTransform.position;
            tooltipRectTransform.anchoredPosition = UpdateAnchoredTo(tooltipDirection);
            return tooltipRectTransform.transform.position;
        }

        Vector2 UpdateAnchoredTo(Direction tooltipDirection)
        {
            var movingDeltaY = GetMovingDeltaY(tooltipRectTransform.rect, casterRectTransform.rect);
            var movingDeltaX = GetMovingDeltaX(tooltipRectTransform.rect, casterRectTransform.rect);
            var anchoredPosition = tooltipRectTransform.anchoredPosition;
            
            return tooltipDirection switch
            {
                Direction.Up => new Vector2(anchoredPosition.x, anchoredPosition.y + movingDeltaY),
                Direction.Down => new Vector2(anchoredPosition.x, anchoredPosition.y - movingDeltaY),
                Direction.Left => new Vector2(anchoredPosition.x - movingDeltaX, anchoredPosition.y),
                Direction.Right => new Vector2(anchoredPosition.x + movingDeltaX, anchoredPosition.y),
                _ => anchoredPosition
            };
        }

        void SetCorners()
        {
            tooltipRectTransform.GetWorldCorners(tooltipCorners);
            casterRectTransform.GetWorldCorners(casterCorners);
        }

        bool IsPassHalfScreen() => casterPosition.x < Screen.width / 2;

        bool IsBelowHalfScreen() => casterPosition.y > Screen.height / 2;

        static float GetMovingDeltaX(Rect tooltipRectangle, Rect casterRectangle) => 
            tooltipRectangle.width / 2 + casterRectangle.width / 2;

        static float GetMovingDeltaY(Rect tooltipRectangle, Rect casterRectangle) => 
            tooltipRectangle.height / 2 + casterRectangle.height / 2;

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