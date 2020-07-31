using System.Collections.Generic;
using Code.Level.Obstacles;
using UnityEngine;

namespace Code.Level
{
    public class Level : MonoBehaviour
    {
        private Queue<Obstacle> _obstacles;

        private Obstacle _currentObstacle;

        private void StartLevel(Obstacle[] levelObstacles)
        {
            _obstacles = new Queue<Obstacle>(levelObstacles);
            _currentObstacle = _obstacles.Dequeue();
        }

        private void StartCurrentObstacle()
        {
            _currentObstacle.ObstacleCompleted += ObstacleCompleted;
        }

        private void ObstacleCompleted()
        {
            _currentObstacle.ObstacleCompleted -= ObstacleCompleted;
            _currentObstacle = _obstacles.Dequeue();
        }
    }
}
