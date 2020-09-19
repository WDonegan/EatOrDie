using System;
using Unity.Mathematics;

namespace EatOrDie.Common
{
    public class Utilities
    {
        public static uint GetSeed()
        {
            var dt = DateTime.Now;
            return (uint) math.floor((dt.Year * dt.DayOfYear * dt.Month * dt.Minute) + dt.Millisecond);
        }
    }
}