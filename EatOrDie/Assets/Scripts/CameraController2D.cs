using System;
using UnityEngine;

namespace EatOrDie
{
    public class CameraController2D : MonoBehaviour
    {
        [SerializeField] private Transform player;
        [SerializeField] private float smoothTime = 0.5f;
        [SerializeField] private int cameraZ = -10;
        
        private Vector2 cameraVelocity = Vector2.zero;

        private void FixedUpdate()
        {
            Vector2 cameraPosition = transform.position;
            Vector2 playerPosition = player.position;

            var newPosition = Vector2.SmoothDamp(cameraPosition, playerPosition, ref cameraVelocity, smoothTime);
            newPosition.y = newPosition.y > -1.75f ? newPosition.y : -1.75f;
            
            transform.position = new Vector3(newPosition.x, newPosition.y, cameraZ);
        }
    }
}