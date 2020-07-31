using UnityEngine;
using UnityEngine.Events;

namespace Code.Level.Obstacles
{
    public class Obstacle : MonoBehaviour
    {
        [SerializeField] private Transform _cameraPosition;
        [SerializeField] private ObstaclePath.ObstaclePath _path;

        public event UnityAction ObstacleCompleted;
        
        
        public enum Type
        {
            ROLLING_BARRELS,
            SOMETHING
        }
    }
}
