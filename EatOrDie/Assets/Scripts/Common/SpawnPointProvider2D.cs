using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = Unity.Mathematics.Random;

namespace EatOrDie.Common
{
    public class SpawnPointProvider2D
    {
        private readonly Bounds2D bounds;
        private readonly int nearCameraRange;
        private readonly Transform cameraTf;
        private Random rNg;
        
        public SpawnPointProvider2D(int upper, int lower, int left, int right, int cameraBuffer, ref Transform cameraTransform)
        {
            bounds = new Bounds2D(upper, lower, left, right);
            
            nearCameraRange = cameraBuffer;
            cameraTf = cameraTransform;
            
            rNg = new Random(Utilities.GetSeed());
        }

        
        private int cameraX;
        private MinMax<int> camBuffer;
        
        public float2 GetSpawnPoint()
        {
            cameraX = (int)cameraTf.position.x;
            camBuffer = new MinMax<int>
            {
                Min = cameraX - nearCameraRange,
                Max = cameraX + nearCameraRange
            };

            // TODO: Implement spawn point tracking, and 'loose' track after a period of time.
            
            return GetPointInSpawnZone();
        }

        private float2 GetPointInSpawnZone()
        {
            float2 rngPoint;
            var reps = 0;

            do
            {
                rngPoint = rNg.NextFloat2(bounds.Ul, bounds.Lr);
                reps++;
            } while (IsPointNearCamera(rngPoint) && reps < 5);

            return rngPoint;
        }

        private bool IsPointNearCamera(float2 point)
            => point.x > camBuffer.Min && point.x < camBuffer.Max;
    }
} 