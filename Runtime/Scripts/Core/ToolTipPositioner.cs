using UnityEngine;

namespace Makingfun.UnityWidgets.Scripts.Core
{
    public class ToolTipPositioner
    {
        RectTransform tooltipRectTransform;
        
        readonly Vector3[] tooltipCorners = new Vector3[4];
        readonly Vector3[] casterCorners = new Vector3[4];
        readonly RectTransform casterRectTransform;
        
        Vector3 CasterPosition => casterRectTransform.transform.position;

        public ToolTipPositioner(GameObject caster) => 
            casterRectTransform = caster.GetComponent<RectTransform>();

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

        bool IsPassHalfScreen() => CasterPosition.x < Screen.width / 2;
        
        bool IsBelowHalfScreen() => CasterPosition.y > Screen.height / 2;

        void SetCorners()
        {
            tooltipRectTransform.GetWorldCorners(tooltipCorners);
            casterRectTransform.GetWorldCorners(casterCorners);
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