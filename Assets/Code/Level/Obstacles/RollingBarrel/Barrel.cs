using UnityEngine;

namespace Code.Level.Obstacles.RollingBarrel
{
    public class Barrel : MonoBehaviour
    {
        [SerializeField] private float _velocity;
        [SerializeField] private Rigidbody _rigidbody;
        private RollingBarrel _rollingBarrel;

        public void StartBarrel(Vector3 spawnPosition, Vector3 finalPosition, Quaternion rotation, RollingBarrel rollingBarrel)
        {
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.angularVelocity = Vector3.zero;
            _rollingBarrel = rollingBarrel;
            transform.position = spawnPosition;
            transform.localRotation = rotation;
            gameObject.SetActive(true);
            _rigidbody.velocity = (finalPosition - spawnPosition).normalized * _velocity;
        }

        private void Update()
        {
            _rigidbody.velocity = _rigidbody.velocity.normalized * _velocity;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Despawn"))
            {
                _rollingBarrel.ReturnBarrel(this);
            }
        }
    }
}