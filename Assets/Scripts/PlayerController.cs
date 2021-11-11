using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]float speed = 5.0f;
    private float rotacion = 35f;
    private Animator anim;
    private float x, y;

   
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        transform.Translate(0,0, y* Time.deltaTime * speed);
        transform.Rotate(0, x * Time.deltaTime * rotacion,0);

        anim.SetFloat("SpeedX", x);
        anim.SetFloat("SpeedY", y);


        if (Input.GetKeyUp(KeyCode.Space))
        {
            anim.SetBool("isShoot", true);
        }
        else
        {
            anim.SetBool("isShoot", false);
        }
    }

}
