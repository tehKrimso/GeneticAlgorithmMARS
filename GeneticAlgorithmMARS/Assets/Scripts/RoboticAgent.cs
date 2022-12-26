using System;
using System.Collections.Generic;
using UnityEngine;

public class RoboticAgent : MonoBehaviour
{
        public Vector3 StartPosition;
        public Vector3 TargetPosition;
        public List<Vector3> trajectory = new List<Vector3>();

        private int currentTargetPointIndex = 1;

        private float delta = 0.1f;

        private bool finished;


        private void Update()
        {
                Move();
                CheckDestination();
        }

        private void Move()
        {

                Vector3.RotateTowards(transform.rotation.eulerAngles, trajectory[currentTargetPointIndex], 0.1f * Time.deltaTime,
                        0);

                Vector3 direction = (trajectory[currentTargetPointIndex] - gameObject.transform.position).normalized;

                gameObject.transform.position += direction * delta * Time.deltaTime;
        }

        private void CheckDestination()
        {
                if (Vector3.Distance(gameObject.transform.position, trajectory[currentTargetPointIndex]) < delta)
                        currentTargetPointIndex++;

                if (currentTargetPointIndex == trajectory.Count)
                        finished = true;
        }
}