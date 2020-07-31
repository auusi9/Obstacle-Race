using UnityEngine;

namespace Code.Level.ObstaclePath
{
    public class PathPoint : MonoBehaviour
    {
        [SerializeField] private Type _type;
        [Tooltip("Only for type line")]
        [SerializeField] private LineRenderer _lineRenderer;

        public LineRenderer LineRenderer => _lineRenderer;

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