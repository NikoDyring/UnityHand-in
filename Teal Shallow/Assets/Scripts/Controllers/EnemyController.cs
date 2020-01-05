using UnityEngine;

namespace Assets.Scripts
{
    public class EnemyController : MonoBehaviour
    {

        public int maxHealth;
        public int currentHealth;

        public float speed;
        public Animator anim;

        public bool isMoving = false;
        public bool chasePlayer;
        public GameObject targetObject;
        private Transform target;
        private Bullet bullet;

        public AudioClip[] fleshSounds;


        void Start()
        {
            anim = GetComponent<Animator>();
            targetObject = GameObject.FindGameObjectWithTag("Player");
            target = targetObject.transform;
            currentHealth = maxHealth;
        }

        void Update()
        {
            if (chasePlayer)
            {
                isMoving = true;
                ChasePlayer();
                LookAtPlayer();
            }

            isMoving = false;

            if (currentHealth <= 0)
            {
                Destroy(gameObject);
            }
        }

        /// <summary>
        /// Faces the sprite towards the player when called.
        /// </summary>
        public void LookAtPlayer()
        {
            // Get the angle
            Vector3 norTar = (target.position - transform.position).normalized;
            var angle = Mathf.Atan2(norTar.y, norTar.x) * Mathf.Rad2Deg;

            // Rotate object to angle
            Quaternion rotation = new Quaternion { eulerAngles = new Vector3(0, 0, angle) };
            transform.rotation = rotation;
        }

        /// <summary>
        /// Chases the player when called.
        /// </summary>
        public void ChasePlayer()
        {

            if ((!(Vector2.Distance(transform.position, target.position) > .4f)))
            {
                
                anim.SetBool("isMoving", isMoving);
                return;
            }

            isMoving = true;
            anim.SetBool("isMoving", isMoving);
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }

        void OnCollisionEnter2D(Collision2D col2d)
        {
            if (col2d.gameObject.tag == "Bullet")
            {
                bullet = col2d.gameObject.GetComponent<Bullet>();
                AudioSource.PlayClipAtPoint(fleshSounds[Random.Range(0,3)], gameObject.transform.position);
                currentHealth -= bullet.damage;
            }

            if (col2d.gameObject.tag == "Player")
            {
                Debug.Log($"Attack! {col2d.gameObject.name}");
            }
        }


    }
}
