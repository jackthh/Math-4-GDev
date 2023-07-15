using System;
using UnityEngine;


namespace _Math_4_GDev.Part_1
{
    public class LookRotationTrigger : MonoBehaviour
    {
        public Transform checkingTarget;
        public Vector2 threshold;


        private void OnDrawGizmos()
        {
            var targetPos = checkingTarget.position;
            var selfPos = transform.position;

            var dotProduct = GetDotProduct(targetPos, selfPos);
            if (dotProduct >= threshold.x && dotProduct <= threshold.y)
            {
                Gizmos.color = Color.green;
            }
            else
            {
                Gizmos.color = Color.red;
            }

            Gizmos.DrawLine(targetPos, targetPos + checkingTarget.forward);
        }


        private float GetDotProduct(Vector3 _targetPos, Vector3 _selfPos)
        {
            var targetToSelfDirection = (_selfPos - _targetPos).normalized;
            var targetForward = checkingTarget.forward;

            var result = Vector3.Dot(targetToSelfDirection, targetForward);

            return result;
        }
    }
}