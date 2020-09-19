using System;
using UnityEngine;

namespace EatOrDie.Testing
{
    public class FatCollisionProcessor : MonoBehaviour
    {
        public Action<GameObject> enQueueCallback;
        public void OnTriggerExit2D(Collider2D other)
        {
            Debug.Log($"GO:{gameObject.name} COLLISION - OTH:{other.gameObject.name}");
            
            var go = gameObject;
            
            if (other.gameObject.name != "Tounge") return;
            
            enQueueCallback(go);
        }
    }
}