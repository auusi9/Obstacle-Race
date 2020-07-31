using UnityEngine;

namespace Code.Level.Obstacles
{
    public class Obstacle : MonoBehaviour
    {
        [SerializeField] private Transform _cameraAnchor;
        [SerializeField] private ObstaclePath.ObstaclePath _path;

        public ObstaclePath.ObstaclePath Path => _path;
        public Transform CameraAnchor => _cameraAnchor;
        
        public enum Type
        {
            ROLLING_BARRELS,
            SOMETHING
        }
    }
}
