using Unity.Mathematics;

namespace EatOrDie.Common
{
    public struct Bounds2D
    {
        /// <summary>
        /// Raw bound values, returned corner points based on these values.
        /// </summary>
        private int minY, minX, maxY, maxX;

        /// <summary>
        /// Upper-Left position
        /// </summary>
        public int2 Ul => new int2(minX, maxY);
        
        /// <summary>
        /// Upper-Right position
        /// </summary>
        public int2 Ur => new int2(maxX, maxY);
        
        /// <summary>
        /// Lower-Left position
        /// </summary>
        public int2 Ll => new int2(minX, minY);
        
        /// <summary>
        /// Lower-Left position
        /// </summary>
        public int2 Lr => new int2(maxX, minY);

        public Bounds2D(int upper, int lower, int left, int right)
        {
            maxY = upper;
            minY = lower;
            minX = left;
            maxX = right;
        }

        public void Set(int upper, int lower, int left, int right)
        {
            maxY = upper;
            minY = lower;
            minX = left;
            maxX = right;
        }

        public bool PointInBounds(float2 point)
        {
            if (!(point.y > minY) || !(point.y < maxY)) return false;

            return point.x > minX && point.x < maxX;
        }
    }
}