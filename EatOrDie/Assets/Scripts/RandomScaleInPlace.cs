using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace EatOrDie
{
    public class RandomScaleInPlace : MonoBehaviour, iRNGesus
    {
        [SerializeField] private float minimumSize, maximumSize;
        private Transform tf;

        private void Awake() => tf = GetComponent<Transform>();
        private void Start() => RNGesus();
        public void RNGesus()
        {
            var lScale = tf.localScale;
            lScale.y = Random.Range(minimumSize, maximumSize);
            lScale.x = Random.Range(-10, 10) > 0 ? -1 : 1;
            tf.localScale = lScale;
        }
    }
}