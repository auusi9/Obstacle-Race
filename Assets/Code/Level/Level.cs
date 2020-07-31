using System.Collections.Generic;
using Code.Camera;
using Code.Level.Obstacles;
using UnityEngine;

namespace Code.Level
{
    public class Level : MonoBehaviour
    {
        [SerializeField] private Obstacle[] _obstaclesOnScene;
        [SerializeField] private Player.Player _player;
        [SerializeField] private GameObject _mainMenu;
        [SerializeField] private CameraBehaviour _camera;
        [SerializeField] private Transform _menuPosition;
        private Queue<Obstacle> _obstacles;

        public Obstacle NextObstacle => _obstacles.Count > 0 ?_obstacles.Dequeue() : null;

        private void Awake()
        {
            RestartLevel();
        }

        public void RestartLevel()
        {
            _mainMenu.SetActive(true);
            _camera.SetNewStaticAnchor(_menuPosition);
        }

        //Called from button
        public void StartLevel()
        {
            _mainMenu.SetActive(false);
            StartLevel(_obstaclesOnScene);
            _player.RestartLevel();
        }

        private void StartLevel(Obstacle[] levelObstacles)
        {
            _obstacles = new Queue<Obstacle>(levelObstacles);
        }
    }
}
