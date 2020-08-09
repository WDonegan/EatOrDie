using System;
using UnityEngine;
using UnityEngine.U2D;

namespace EatOrDie
{
    [ExecuteAlways]
    public class SpriteShapeTest : MonoBehaviour
    {
        public SpriteShapeController shapeController;

        private void Awake()
        {
            shapeController = GetComponent<SpriteShapeController>();
        }

        public void Start()
        {
            
            
        }

        public void OnDrawGizmos()
        {
            var firstPoint = transform.localToWorldMatrix.MultiplyPoint(shapeController.spline.GetPosition(0));
            var secondPoint = transform.localToWorldMatrix.MultiplyPoint(shapeController.spline.GetPosition(1));

            var direction = (secondPoint - firstPoint).normalized;

            Debug.DrawLine(firstPoint, secondPoint, Color.blue, 0.05f);
            
            Debug.DrawRay(secondPoint, direction, Color.yellow, 0.05f);
            
            
        }
    }
}