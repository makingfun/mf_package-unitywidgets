using System.Collections.Generic;
using UnityEngine;

namespace Makingfun.UnityWidgets
{
    public static class UnityExtensions
    {
        static readonly Dictionary<Direction, Vector2> DirectionVectors = new Dictionary<Direction, Vector2>
        {
            { Direction.Up , new Vector2(0.5f, 1)},
            { Direction.Down , new Vector2(0.5f, 0)},
            { Direction.Left , new Vector2(0f, 0.5f)},
            { Direction.Right , new Vector2(1f, 0.5f)},
        };

        public static Vector2 GetVectorFrom(Direction direction) => DirectionVectors[direction];
    }
}