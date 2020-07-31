using UnityEngine;

namespace Code.Camera
{
    public class CameraBehaviour : MonoBehaviour
    {
        [SerializeField] private Transform _player;
        [SerializeField] private float _velocity = 10f;
        private Vector3 _offset;

        private Vector3 _desiredPosition;
        private Quaternion _desiredRotation;
        
        public void SetNewAnchor(Transform newAnchor, Vector3 _initialPosition)
        {
            _desiredPosition = newAnchor.position;
            _desiredRotation = newAnchor.rotation;
            _offset = _initialPosition - newAnchor.position;
        }
        
        public void SetNewStaticAnchor(Transform newAnchor)
        {
            _desiredPosition = newAnchor.position;
            _desiredRotation = newAnchor.rotation;
            _offset = _player.position - newAnchor.position;
        }

        private void Update()
        {
            _desiredPosition = _player.position - _offset;
            transform.position = Vector3.Lerp(transform.position, _desiredPosition, _velocity * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, _desiredRotation, _velocity * Time.deltaTime);
        }
    }
}