using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public int Health { get; set; }
    public int CurrentHealth { get; set; }

    public float speed;

    private Animator anim;
    private Transform target;

    private bool isMoving = false;


    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
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

        LookAtPlayer();
    }

    void LookAtPlayer()
    {
        // Get the angle
        Vector3 norTar = (target.position - transform.position).normalized;
        float angle = Mathf.Atan2(norTar.y, norTar.x) * Mathf.Rad2Deg;

        // Rotate object to angle
        Quaternion rotation = new Quaternion();
        rotation.eulerAngles = new Vector3(0, 0, angle);
        transform.rotation = rotation;
    }

}
