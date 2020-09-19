using System;
using System.Collections;
using UnityEngine;
using UnityEngine.U2D;

namespace EatOrDie
{
    public class SpriteShapeTest : MonoBehaviour
    {
        public SpriteShapeController shapeController;
        public CircleCollider2D circleCollider2D;
        private void Awake()
        {
            shapeController = GetComponent<SpriteShapeController>();
            circleCollider2D = GetComponent<CircleCollider2D>();
        }

        private Vector2 restingPosition;
        public void Start() => restingPosition = shapeController.spline.GetPosition(1);

        private bool isAttacking = false;
        private bool isExtending = false;
        private bool isRetracting = false;
        private WaitForSeconds wait = new WaitForSeconds(0.01f);
        
        /// <summary>
        /// Will initialize an attack aimed at the given position, supplied as the worldPosition parameter.
        /// This is a public wrapper function, which calculates the local transform of the world position before
        /// passing it to a Extend & Retract coroutine, with two coroutine stubs, Extend & Retract.
        /// </summary>
        /// <param name="worldPosition"></param>
        public void Attack(Vector2 worldPosition)
        {
            if (isAttacking) return;
            
            isAttacking = true;
            
            var tf = transform;
            var dest = (Vector2) tf.worldToLocalMatrix.MultiplyPoint(worldPosition);
            
            StartCoroutine(ExtendAndRetract(restingPosition, dest));
        }

        public IEnumerator ExtendAndRetract(Vector2 origin, Vector2 dest)
        {
            yield return Extend(origin, dest);
            yield return Retract(origin, dest);
            
            isAttacking = false;
        }
        public IEnumerator Extend(Vector2 origin, Vector2 destination)
        {
            if (isExtending) yield break;
            isExtending = true;
            
            for (float i = 0; i <= 1; i += 0.05f)
            {
                var position = Vector2.Lerp(origin, destination, i);

                shapeController.spline.SetPosition(1, position);
                MoveCollider();
                
                yield return wait;
            }

            isExtending = false;
        }
        public IEnumerator Retract(Vector2 origin, Vector2 destination)
        {
            if (isRetracting) yield break;
            isRetracting = true;
            
            for (float i = 1; i >= 0; i -= 0.05f)
            {
                var position = Vector2.Lerp(origin, destination, i);

                shapeController.spline.SetPosition(1, position);
                MoveCollider();
                
                yield return wait;
            }
            
            isRetracting = false;
        }

        public void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log($"GO:{gameObject.name} COLLISION - OTH:{other.gameObject.name}");
        }


        private Matrix4x4 localToWorld, worldToLocal;
        private Vector3 firstPoint, secondPoint, direction;
        public void MoveCollider()
        {
            localToWorld = transform.localToWorldMatrix;
            worldToLocal = transform.worldToLocalMatrix;
            
            firstPoint = localToWorld.MultiplyPoint(shapeController.spline.GetPosition(0));
            secondPoint = localToWorld.MultiplyPoint(shapeController.spline.GetPosition(1));
        
            direction = secondPoint - firstPoint;
            
            circleCollider2D.radius = 0.15f;
            circleCollider2D.offset = worldToLocal.MultiplyPoint(secondPoint + direction.normalized * 0.15f);
        }
    }
}