using System;
using System.Collections.Generic;
using System.Linq;
using Code.Level.ObstaclePath;
using UnityEngine;

namespace Code.Level.ObstaclePath
{
    public class ObstaclePath : MonoBehaviour
    {
        [SerializeField] private PathPoint[] _path;
        [SerializeField] private float _tolerance = 0.1f;

        private List<PathPosition> _pathPositions = new List<PathPosition>();

        private void Awake()
        {
            _pathPositions = new List<PathPosition>();
            foreach (PathPoint pathPoint in _path)
            {
                switch (pathPoint.GetPathType())
                {                    
                    case PathPoint.Type.LINE:
                        CreatePathPointsForLine(pathPoint);
                        break;
                    case PathPoint.Type.POINT:
                    case PathPoint.Type.JUMPPOINT:
                        PathPosition pathPosition;
                        pathPosition.position = pathPoint.transform.position;
                        pathPosition.PathType = pathPoint.GetPathType();
                        _pathPositions.Add(pathPosition);
                        break;
                }
            }
        }

        private void CreatePathPointsForLine(PathPoint pathPoint)
        {
            LineRenderer lineRenderer = pathPoint.LineRenderer;
            Vector3[] positions = new Vector3[lineRenderer.positionCount];
            lineRenderer.GetPositions(positions);

            foreach (Vector3 position in positions)
            {
                PathPosition pathPosition;
                pathPosition.position = (lineRenderer.localToWorldMatrix * position);
                pathPosition.position += pathPoint.transform.position;
                pathPosition.PathType = pathPoint.GetPathType();
                _pathPositions.Add(pathPosition);
            }
        }

        public PathPosition GetNextDestination(PathPosition pathPosition)
        {
            for (int i = 0; i < _pathPositions.Count; i++)
            {
                if (pathPosition.Equals(_pathPositions[i]) && i < _pathPositions.Count - 1)
                {
                    return _pathPositions[++i];
                }
            };

            return _pathPositions[_pathPositions.Count - 1];
        }
        
        public PathPosition GetInitialDestination()
        {
            return _pathPositions[0];
        }

        private void OnDrawGizmosSelected()
        {
            if (_pathPositions == null)
            {
                return;
            }
            Gizmos.color = Color.blue;

            foreach (PathPosition position in _pathPositions)
            {
                Gizmos.DrawWireSphere(position.position, 1f);
            }
        }
    }
    
    [Serializable]
    public struct PathPosition
    {
        public PathPoint.Type PathType;
        public Vector3 position;
        
        public bool Equals(PathPosition pathPosition)
            => position == pathPosition.position;
    }
}