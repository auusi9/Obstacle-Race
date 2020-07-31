using Code.Level.ObstaclePath;
using UnityEngine;

namespace Code.Player
{
    public class PlayerJump : MonoBehaviour
    {
        [SerializeField] private float _jumpAngle = 45f;
        [SerializeField] private Player _player;

        private Vector3 _initialVelocity;
        private Vector3 _initalPosition;
        private float _initalTime;
        private float _initialY;
        private PathPosition _target;
        
        public void Jump(PathPosition target)
        {
            _initalPosition = transform.position;
            _initialVelocity = InitialVelocity(target.position);
            _initalTime = Time.time;
            _target = target;
        }

        private void Update()
        {
            Vector3 position;

            float t = Time.time - _initalTime;
            
            position.x = _initialVelocity.x * t;
            position.z = _initialVelocity.z * t;
            position.y = _initialVelocity.y * t + (Physics.gravity.y * Mathf.Pow(t, 2)/2) ;

            transform.position = _initalPosition + position;
            
            Vector3 finalPosition = _target.position;
            finalPosition.y = _initialY;

            if (Vector3.Distance(finalPosition, transform.position) < 1f)
            {
                _player.enabled = true;
                enabled = false;
            }
        }

        Vector3 InitialVelocity(Vector3 target)
        {
            Vector3 dir = target - transform.position;
            float h = dir.y; 
            dir.y = 0;
            float dist = dir.magnitude;  
            float a = _jumpAngle * Mathf.Deg2Rad;  
            dir.y = dist * Mathf.Tan(a);  
            dist += h / Mathf.Tan(a);  
            
            float vel = Mathf.Sqrt(dist * Physics.gravity.magnitude / Mathf.Sin(2 * a));
            return vel * dir.normalized;
        }
    }
}