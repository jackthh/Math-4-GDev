using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;


namespace _Math_4_GDev.Part_1
{
    public class CoordinateConverter : MonoBehaviour
    {
        public Transform localCoordinate;
        public Vector2 originalWorldPoint;
        public Vector2 originalLocalPoint;


        [Button(ButtonSizes.Large)] public void WorldToLocal()
        {
            var worldOffset = originalWorldPoint - new Vector2(localCoordinate.position.x, localCoordinate.position.y);
            var localX = Vector3.Dot(localCoordinate.right, worldOffset);
            var localY = Vector3.Dot(localCoordinate.up, worldOffset);

            Debug.Log($"Local Pos: {new Vector2(localX, localY)}");
        }


        [Button(ButtonSizes.Large)] public void LocalToWorld()
        {
            //  NOTE: To convert root point in world space in to local space 
            var worldOffset = -localCoordinate.position;
            var localX = Vector3.Dot(localCoordinate.right, worldOffset);
            var localY = Vector3.Dot(localCoordinate.up, worldOffset);

            var worldRootInLocal = new Vector2(localX, localY);
            var originalLocalPointInWorld = originalLocalPoint - worldRootInLocal;

            Debug.Log($"World Pos: {new Vector2(originalLocalPointInWorld.x, originalLocalPointInWorld.y)}");
        }
    }
}