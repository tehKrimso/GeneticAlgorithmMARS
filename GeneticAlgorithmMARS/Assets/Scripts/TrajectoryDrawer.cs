using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class TrajectoryDrawer : MonoBehaviour
    {
        public Color TrajectoryColor;
        
        private RoboticAgent _selfAgent;
        private LineRenderer _lineRenderer;

        private void Start()
        {
            _selfAgent = GetComponentInParent<RoboticAgent>();
            _lineRenderer = GetComponent<LineRenderer>();
            _lineRenderer.material.SetColor("_Color", TrajectoryColor);
        }

        private void Update()
        {
            _lineRenderer.positionCount = _selfAgent.trajectory.ToArray().Length;
            _lineRenderer.SetPositions(_selfAgent.trajectory.ToArray());
        }
    }
}