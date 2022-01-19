using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sule.BoatStack
{
    public class ObstacleMovement : MonoBehaviour
    {
        private Vector3 startingPosition;
        public Vector3 movementVector;
        float movementFactor;
        public float period = 2f;
        void Start()
        {
            startingPosition = transform.position;
        }

        // Update is called once per frame
        void Update()
        {
            if (period <= Mathf.Epsilon)
            {
                return;
            }
            float cycles = Time.time / period;
            const double tau = Math.PI * 2;
            float rawSinWave = Convert.ToSingle(Math.Sin(cycles * tau));

            movementFactor = (rawSinWave + 1f) / 2f;
            Vector3 offset = movementVector * movementFactor;
            transform.position = startingPosition + offset;
        }
    }
}
