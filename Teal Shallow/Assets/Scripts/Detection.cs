using UnityEngine;

namespace Assets.Scripts
{
    public class Detection : MonoBehaviour
    {
        public EnemyController enemyController;

        void OnTriggerStay2D(Collider2D col2d)
        {
            if (col2d.gameObject.tag == "Player")
            {
                enemyController.chasePlayer = true;
            }
        }

        void OnTriggerExit2D(Collider2D col2d)
        {
            if (col2d.gameObject.tag == "Player")
            {
                enemyController.chasePlayer = false;
            }
        }

    }
}
