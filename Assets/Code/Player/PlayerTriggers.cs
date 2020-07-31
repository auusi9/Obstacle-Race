using UnityEngine;

namespace Code.Player
{
    public class PlayerTriggers : MonoBehaviour
    {
        [SerializeField] private Player _player;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Obstacle"))
            {
                _player.RestartObstacle();
            }
        }
    }
}