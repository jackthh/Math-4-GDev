using System;
using UnityEditor;
using UnityEngine;


namespace _Math_4_GDev.Scripts
{
    /// <summary>
    /// Part 1 Assignment 1
    /// </summary>
    public class DistanceTrigger : MonoBehaviour
    {
        public Transform checkingTarget;
        public float checkingRadius;


        private void OnDrawGizmos()
        {
            var transformPosition = transform.position;
            var sqrtDistToTarget = Vector3.SqrMagnitude(checkingTarget.position - transformPosition);

            Handles.color = sqrtDistToTarget >= checkingRadius * checkingRadius ? Color.cyan : Color.red;


            Handles.DrawWireArc(transformPosition, Vector3.forward, Vector3.right, 360, checkingRadius);
        }
    }
}