using System;
using UnityEngine;

namespace UI
{
    [Serializable]
    public class RectanglePositions
    {
        [SerializeField] private float _left;
        [SerializeField] private float _top;
        [SerializeField] private float _right;
        [SerializeField] private float _bottom;

        public float Left => _left;
        public float Top => _top;
        public float Right => _right;
        public float Bottom => _bottom;
    }
}