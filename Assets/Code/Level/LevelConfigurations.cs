using System;
using Code.Level.Obstacles;
using UnityEngine;

namespace Code.Level
{
    [CreateAssetMenu(fileName = "LevelsConfiguration", menuName = "Configurations/LevelsConfiguration", order = 1)]
    public class LevelConfigurations : ScriptableObject
    {
        [SerializeField] private LevelConfig[] _levels;

        public LevelConfig[] Levels => Levels;
    }
    
    [Serializable]
    public class LevelConfig
    {
        [SerializeField] private Obstacle.Type[] _obstacles;

        public Obstacle.Type[] Obstacles => _obstacles;
    }
}