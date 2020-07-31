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
            _barrelPool = new ComponentPool<Barrel>(_initialPoolSize, _barrelPrefab, transform, _barrelPrefab.transform.rotation);
        }

        private void Update()
        {
            if (_spawnTime < Time.time - _lastBarrelSpawned)
            {
                SpawnBarrel();
                _lastBarrelSpawned = Time.time;
            }
        }

        private void SpawnBarrel()
        {
            Barrel barrel = _barrelPool.GetComponent();
            barrel.StartBarrel(_spawnPosition.position, _finalPosition.position, this);
        }

        public void ReturnBarrel(Barrel barrel)
        {
            _barrelPool.ReturnMono(barrel);
        }
    }
}