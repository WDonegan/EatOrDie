using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace EatOrDie
{
    public class RandomSpriteSwapper : MonoBehaviour, iRNGesus
    {
        [SerializeField] private List<Sprite> spriteBin;
        private SpriteRenderer sr;

        private void Awake() => sr = GetComponent<SpriteRenderer>();
        private void Start() => RNGesus();
        public void RNGesus()
        {
            var rnJesus = Random.Range(0, spriteBin.Count);
            sr.sprite = spriteBin[rnJesus];
        }
    }
}