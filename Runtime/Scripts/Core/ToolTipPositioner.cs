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
            tooltipRectTransform.anchoredPosition = UpdateAnchoredPosition(tooltipDirection, 
                tooltipRectTransform.anchoredPosition);
            return tooltipRectTransform.transform.position;
        }

        Vector2 UpdateAnchoredPosition(Direction tooltipDirection, Vector2 tooltipAnchoredPosition)
        {
            var movingDeltaY = GetMovingDeltaY(tooltipRectTransform.rect, casterRectTransform.rect);
            var movingDeltaX = GetMovingDeltaX(tooltipRectTransform.rect, casterRectTransform.rect);
            
            return tooltipDirection switch
            {
                Direction.Up => new Vector2(tooltipAnchoredPosition.x, tooltipAnchoredPosition.y + movingDeltaY),
                Direction.Down => new Vector2(tooltipAnchoredPosition.x, tooltipAnchoredPosition.y - movingDeltaY),
                Direction.Left => new Vector2(tooltipAnchoredPosition.x - movingDeltaX, tooltipAnchoredPosition.y),
                Direction.Right => new Vector2(tooltipAnchoredPosition.x + movingDeltaX, tooltipAnchoredPosition.y),
                _ => tooltipAnchoredPosition
            };
        }

        bool IsPassHalfScreen() => casterPosition.x < Screen.width / 2;

        bool IsBelowHalfScreen() => casterPosition.y > Screen.height / 2;

        void SetCorners()
        {
            tooltipRectTransform.GetWorldCorners(tooltipCorners);
            casterRectTransform.GetWorldCorners(casterCorners);
        }

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