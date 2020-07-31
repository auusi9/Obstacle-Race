using System.Collections.Generic;
using Code.Level.Obstacles;
using UnityEngine;

namespace Code.Level
{
    public class Level : MonoBehaviour
    {
        [SerializeField] private Obstacle[] _obstaclesOnScene;
        private Queue<Obstacle> _obstacles;

        public Obstacle NextObstacle => _obstacles.Dequeue();

        private void Awake()
        {
            StartLevel(_obstaclesOnScene);
        }

        private void RestartLevel()
        {
            Awake();
        }

        private void StartLevel(Obstacle[] levelObstacles)
        {
            _obstacles = new Queue<Obstacle>(levelObstacles);
        }
    }
}
