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


        private Vector2 GetWorldToLocal(Vector2 _worldPos)
        {
            var worldOffset = _worldPos - new Vector2(localCoordinate.position.x, localCoordinate.position.y);
            var localX = Vector3.Dot(localCoordinate.right, worldOffset);
            var localY = Vector3.Dot(localCoordinate.up, worldOffset);

            return new Vector2(localX, localY);
        }


        [Button(ButtonSizes.Large)] public void WorldToLocal()
        {
            Debug.Log($"Local Pos: {GetWorldToLocal(originalWorldPoint)}");
        }


        [Button(ButtonSizes.Large)] public void LocalToWorld()
        {
            // //  NOTE: To convert root point in world space in to local space 
            // var worldOffset = -localCoordinate.position;
            // var localX = Vector3.Dot(localCoordinate.right, worldOffset);
            // var localY = Vector3.Dot(localCoordinate.up, worldOffset);
            //
            // var worldRootInLocal = new Vector2(localX, localY);
            // var originalLocalPointInWorld = originalLocalPoint - worldRootInLocal;
            //
            // Debug.Log($"World Pos: {new Vector2(originalLocalPointInWorld.x, originalLocalPointInWorld.y)}");


            //  NOTE:   Local pos in world coordinate axis but still local root
            var worldXSameRoot = Vector3.Dot(GetWorldToLocal(localCoordinate.position + Vector3.right), originalLocalPoint);
            var worldYSameRoot = Vector3.Dot(GetWorldToLocal(localCoordinate.position + Vector3.up), originalLocalPoint);

            //  NOTE:   Add local coordinate root position in world space
            var result = new Vector2(worldXSameRoot + localCoordinate.position.x, worldYSameRoot + localCoordinate.position.y);

            Debug.Log($"World Pos: {result}");
        }


        [Button(ButtonSizes.Large)] public void LocalToWorldSmarter()
        {
            var worldOffset = localCoordinate.right * originalLocalPoint.x + localCoordinate.up * originalLocalPoint.y;

            Debug.Log($"World Pos: {localCoordinate.position + worldOffset}");
        }
    }
}