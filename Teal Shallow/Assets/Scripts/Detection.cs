using UnityEngine;

namespace Assets.Scripts
{
    public class Detection : MonoBehaviour
    {
        public EnemyController enemyController;

        void OnTriggerStay2D(Collider2D collider)
        {
            if (collider.gameObject.tag == "Player")
            {
                enemyController.LookAtPlayer();
                enemyController.ChasePlayer();
            }
        }

    }
}
