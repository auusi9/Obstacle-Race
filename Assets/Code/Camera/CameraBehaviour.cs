using UnityEngine;

namespace Code.Camera
{
    public class CameraBehaviour : MonoBehaviour
    {
        [SerializeField] private Transform _player;
        private Vector3 _offset;
        
        public void SetNewAnchor(Transform newAnchor)
        {
            transform.position = newAnchor.position;
            transform.rotation = newAnchor.rotation;
            _offset = _player.position - newAnchor.position;
        }

        private void Update()
        {
            transform.position = _player.position - _offset;
        }
    }
}