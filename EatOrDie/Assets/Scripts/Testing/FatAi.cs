using System;
using UnityEngine;

namespace EatOrDie.Testing
{
    public class FatAi : MonoBehaviour
    {
        private GameObject player;

        private void Start()
        {
            player = GameObject.FindWithTag("Player");
        }

        
    }
}