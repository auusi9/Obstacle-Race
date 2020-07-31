using UnityEngine;

namespace Code.Level.ObstaclePath
{
    public class PathPoint : MonoBehaviour
    {
        [SerializeField] private Type _type;

        public Type GetPathType()
        {
            return _type;
        }

        public enum Type
        {
            POINT,
            LINE,
            JUMPPOINT
        }
    }
}