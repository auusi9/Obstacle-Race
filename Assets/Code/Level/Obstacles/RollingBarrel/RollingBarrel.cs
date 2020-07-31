using Code.Utils;
using UnityEngine;

namespace Code.Level.Obstacles.RollingBarrel
{
    public class RollingBarrel : MonoBehaviour
    {
        [SerializeField] private GameObject _barrelPrefab;
        [SerializeField] private Transform _spawnPosition;
        [SerializeField] private Transform _finalPosition;
        [SerializeField] private int _initialPoolSize;
        [SerializeField] private float _spawnTime;

        private ComponentPool<Barrel> _barrelPool;
        private float _lastBarrelSpawned;

        private void Start()
        {
            _barrelPool = new ComponentPool<Barrel>(_initialPoolSize, _barrelPrefab, transform);
        }

        private void Update()
        {
            if (HasToSpawnNewBarrel())
            {
                SpawnBarrel();
                _lastBarrelSpawned = Time.time;
            }
        }

        private bool HasToSpawnNewBarrel()
        {
            return _spawnTime < Time.time - _lastBarrelSpawned;
        }

        private void SpawnBarrel()
        {
            Barrel barrel = _barrelPool.GetComponent();
            barrel.StartBarrel(_spawnPosition.position, _finalPosition.position, _barrelPrefab.transform.localRotation,this);
        }

        public void ReturnBarrel(Barrel barrel)
        {
            _barrelPool.ReturnMono(barrel);
        }
    }
}