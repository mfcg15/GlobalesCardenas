using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField] private float distanceRay = 2f;
    [SerializeField] private GameObject shootOrigen;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private int shootCooldown = 3;
    [SerializeField] private float timerShoot = 0;
    private bool canShoot = true;


    enum Gun { A, B};
    [SerializeField] Gun choose;

    void Start()
    {
        
    }

    void Update()
    {

        switch (choose)
        {
            case Gun.A:
                if (canShoot)
                {
                    RaycastShoot();
                }
                else
                {
                    timerShoot += Time.deltaTime;
                }

                if (timerShoot > shootCooldown)
                {
                    canShoot = true;
                }

                break;

            case Gun.B:
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    RaycastShootPlayer();
                }

                break;

            default:
                Debug.Log("Accion no encontrada");
                break;
        }

    }

    private void RaycastShoot()
    {
        RaycastHit hit;

        if (Physics.Raycast(shootOrigen.transform.position, shootOrigen.transform.TransformDirection(Vector3.right), out hit, distanceRay))
        {
            if (hit.transform.tag == "Player")
            {
                GameObject b = Instantiate(bulletPrefab, shootOrigen.transform.position, bulletPrefab.transform.rotation);
                canShoot = false;
                timerShoot = 0;
                b.GetComponent<Rigidbody>().AddForce(shootOrigen.transform.TransformDirection(Vector3.right) * 10f, ForceMode.Impulse);
           }
        }

    }


    private void RaycastShootPlayer()
    {
        RaycastHit hit;

        if (Physics.Raycast(shootOrigen.transform.position, shootOrigen.transform.TransformDirection(Vector3.up), out hit, distanceRay))
        {
            GameObject b = Instantiate(bulletPrefab, shootOrigen.transform.position, bulletPrefab.transform.rotation);
            b.GetComponent<Rigidbody>().AddForce(shootOrigen.transform.TransformDirection(Vector3.up) * 10f, ForceMode.Impulse);
        }

    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(shootOrigen.transform.position, shootOrigen.transform.TransformDirection(Vector3.right) * distanceRay);

        Gizmos.color = Color.blue;
        Gizmos.DrawRay(shootOrigen.transform.position, shootOrigen.transform.TransformDirection(Vector3.up) * distanceRay);
    }
}
