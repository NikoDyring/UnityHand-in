using UnityEngine;

namespace Assets.Scripts
{
    public class EnemyController : MonoBehaviour
    {

        public int Health { get; set; }
        public int CurrentHealth { get; set; }

        public float speed;
        public Animator anim;

        public bool isMoving = false;
        public Transform target;


        void Start()
        {
            anim = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void LookAtPlayer()
        {
            // Get the angle
            Vector3 norTar = (target.position - transform.position).normalized;
            var angle = Mathf.Atan2(norTar.y, norTar.x) * Mathf.Rad2Deg;

            // Rotate object to angle
            Quaternion rotation = new Quaternion { eulerAngles = new Vector3(0, 0, angle) };
            transform.rotation = rotation;
        }

        public void ChasePlayer()
        {

            if ((!(Vector2.Distance(transform.position, target.position) > 1)))
            {
                isMoving = false;
                anim.SetBool("isMoving", isMoving);
                return;
            }

            isMoving = true;
            anim.SetBool("isMoving", isMoving);
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }


    }
}
