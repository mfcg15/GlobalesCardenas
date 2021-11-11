using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] float speed = 3f;
    private float rotacion = 35f;
    private Animator anim;
    private float x, y;
    GameObject player;
    bool placePlayer = false;

    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.Find("Player");
    }

    void Update()
    {
        MoveTowards();
        LookAtPlayer();
    }

    private void MoveTowards()
    {
        Vector3 direction = (player.transform.position - transform.position).normalized;

        if ((Vector3.Distance(player.transform.position, transform.position) > 5f))
        {
            anim.SetFloat("SpeedY", 0f);
        }
        else
        {

            if (Vector3.Distance(player.transform.position, transform.position) <= 1.5f)
            {
                anim.SetFloat("SpeedY", 0f);
                placePlayer = true;
            }
            else
            {
                transform.position += speed * direction * Time.deltaTime;
                anim.SetFloat("SpeedY", 1f);
                placePlayer = false;
            }

            if (placePlayer == true)
            {
                anim.SetBool("isShoot", true);
            }
            else
            {
                anim.SetBool("isShoot", false);
            }

        }
    }

    private void LookAtPlayer()
    {
        Vector3 direction = player.transform.position - transform.position;
        Quaternion newRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, rotacion * Time.deltaTime);
    }
}
