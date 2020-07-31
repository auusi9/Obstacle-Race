using Code.Camera;
using Code.Level.ObstaclePath;
using Code.Level.Obstacles;
using UnityEngine;

namespace Code.Player
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private CameraBehaviour _camera;
        [SerializeField] private Level.Level _level;
        [SerializeField] private Obstacle _currentObstacle;
        [SerializeField] private PlayerJump _jump;
        [SerializeField] private TrailRenderer _trail;
        [SerializeField] private float _maxMove;

        private ObstaclePath _obstaclePath;
        private PathPosition _currentPathPoint;
        private float _intialY;

        private void Start()
        {
            enabled = false;
            _intialY = transform.position.y;
        }

        private void StartObstacle()
        {
            _obstaclePath = _currentObstacle.Path;
            _currentPathPoint = _obstaclePath.GetInitialDestination();
            _camera.SetNewAnchor(_currentObstacle.CameraAnchor, _currentPathPoint.position);
            enabled = true;
            _jump.enabled = false;
        }
        
        public void RestartObstacle()
        {
            StartObstacle();
            SetPositionToCurrentPathPoint();
        }

        private void SetPositionToCurrentPathPoint()
        {
            Vector3 finalPosition = _currentPathPoint.position;
            finalPosition.y = _intialY;
            transform.position = finalPosition;
            _trail.Clear();
        }

        private void Update()
        {
            Vector3 finalPosition = _currentPathPoint.position;
            finalPosition.y = _intialY;

            if (HasArrivedToDestination(finalPosition))
            {
                 PathPosition newPathPosition = _obstaclePath.GetNextDestination(_currentPathPoint);
                 if (_currentPathPoint.Equals(newPathPosition))
                 {
                     NewObstacle();
                     return;
                 }

                 _currentPathPoint = newPathPosition;
                 
                if (HasToJump())
                {
                    Jump();
                    return;
                }
                
                finalPosition = _currentPathPoint.position;
                finalPosition.y = transform.position.y;
            }

            if (Input.GetMouseButton(0))
            {
                transform.position = Vector3.MoveTowards(transform.position, finalPosition, _maxMove * Time.deltaTime);
            }
        }

        private bool HasArrivedToDestination(Vector3 finalPosition)
        {
            return Vector3.Distance(finalPosition, transform.position) < _maxMove * Time.deltaTime;
        }

        private bool HasToJump()
        {
            return _currentPathPoint.PathType == PathPoint.Type.JUMPPOINT;
        }

        private void Jump()
        {
            _currentPathPoint = _obstaclePath.GetNextDestination(_currentPathPoint);

            _jump.Jump(_currentPathPoint);
            _jump.enabled = true;
            enabled = false;
        }

        private void OnDrawGizmosSelected()
        {
            if (!Application.isPlaying)
            {
                return;
            }
            
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(_currentPathPoint.position, 1f);
        }

        public void NewObstacle()
        {
            _currentObstacle = _level.NextObstacle;

            if (_currentObstacle == null)
            {
                Debug.Log("LevelCompleted");
                _level.RestartLevel();
                return;
            }
            
            StartObstacle();
        }
        
        public void RestartLevel()
        {
            NewObstacle();
            SetPositionToCurrentPathPoint();
        }
    }
}