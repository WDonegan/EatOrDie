using System;
using System.Collections.Generic;
using EatOrDie.Testing;
using Unity.Mathematics;
using UnityEngine;
using Object = UnityEngine.Object;

namespace EatOrDie.Common
{
    public class GameObjectPool : IDisposable
    {
        private readonly Queue<GameObject> poolQue;

        public GameObjectPool(GameObject prefab, Transform parentTf, int capacity)
        {
            poolQue = new Queue<GameObject>(capacity);

            for (var i = capacity; i > 0; i--)
            {
                var preSpawn = Object.Instantiate(prefab, Vector3.zero, quaternion.identity, parentTf);
                preSpawn.SetActive(false);
                
                Enqueue(preSpawn);
            }
        }

        public void Enqueue(GameObject item) => poolQue.Enqueue(item);

        public GameObject Dequeue() => poolQue.Dequeue();
        
        public void Dispose() => poolQue.Clear();

    }
}