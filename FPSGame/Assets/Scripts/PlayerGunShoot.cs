using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGunShoot : MonoBehaviour
{
    public GameObject Cam;
    RaycastHit hit1;
    RaycastHit hit2;
    public GameObject HitPoint;

    public GameObject GunHole;

    public Vector3 Gundir;
    public float GunHitDist;

    public GameObject Bullet;
    public float ShootDelay = 0.1f;
    public float ShootDebugTime = 1f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        guntarget();
        Shoot();
    }

    void guntarget()
    {
        if (Physics.Raycast(Cam.transform.position, Cam.transform.forward, out hit1))
        {

            HitPoint.SetActive(true);


            Debug.DrawRay(Cam.transform.position, Cam.transform.forward * hit1.distance, Color.green);
            HitPoint.transform.position = hit1.point;

            Gundir = (hit1.point - GunHole.transform.position).normalized;
            GunHitDist = Vector3.Distance(GunHole.transform.position, HitPoint.transform.position);

            Debug.DrawRay(GunHole.transform.position, Gundir * GunHitDist, Color.red);

            //if(Physics.Raycast(GunHole.transform.position,))
        }
        else
        {
            Debug.DrawRay(Cam.transform.position, Cam.transform.forward * 1000f, Color.green);
            HitPoint.SetActive(false);
        }
    }

    void Shoot()
    {
        if (Input.GetMouseButton(0))
        {
            if (StatManager.instance.CanGunShoot)
            {
                if (ShootDebugTime >= ShootDelay)
                {
                    ShootDebugTime = 0;
                    Instantiate(Bullet, GunHole.transform.position, Quaternion.LookRotation(Gundir));
                    
                }
                
            }
            
        }
        ShootDebugTime += Time.deltaTime;
    }
}
