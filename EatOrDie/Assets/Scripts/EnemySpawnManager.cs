using System;
using System.Collections;
using EatOrDie.Common;
using EatOrDie.Testing;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;

namespace EatOrDie
{
    public class EnemySpawnManager : MonoBehaviour
    {
        [SerializeField] private Transform cameraTf;
        [SerializeField] private GameObject prefab;
        [SerializeField] private int concurrentSpawns;
        
        [SerializeField] private int upperLimit;
        [SerializeField] private int lowerLimit;
        [SerializeField] private int leftLimit;
        [SerializeField] private int rightLimit;

        [SerializeField] private int cameraBufferZone;
        
        private int activeSpawns;
        
        private SpawnPointProvider2D spawnProvider;
        private GameObjectPool spawnPool;
        
        public void Start()
        {
            spawnProvider = new SpawnPointProvider2D(upperLimit, lowerLimit, leftLimit, rightLimit, cameraBufferZone, ref cameraTf);
            spawnPool = new GameObjectPool(prefab, transform, 10);
            
            activeSpawns = 0;
            
            StartCoroutine(DelayedSpawning());
        }


        private float2 spawnPoint;
        public void Update()
        {
            if (!readyToSpawn) return;
            
            StartCoroutine(DelayedSpawning());
            readyToSpawn = false;
        }

        private void OnDisable() => StopCoroutine(DelayedSpawning());

        private readonly WaitForSeconds waitForSpawnDelay = new WaitForSeconds(0.65f);
        private bool readyToSpawn = false;
        private IEnumerator DelayedSpawning()
        {
            if (activeSpawns >= concurrentSpawns) yield break;
            
            spawnPoint = spawnProvider.GetSpawnPoint();

            var spawn = spawnPool.Dequeue();
            spawn.transform.position = (Vector2)spawnPoint;
            spawn.GetComponent<FatCollisionProcessor>().enQueueCallback = Enqueue;
            spawn.SetActive(true);
            
            activeSpawns++;
            
            yield return waitForSpawnDelay;

            readyToSpawn = true;
        }

        private void Enqueue(GameObject go)
        {
            go.transform.position = Vector3.zero;
            go.SetActive(false);
            activeSpawns--;
            
            spawnPool.Enqueue(go);
        }
    }
}