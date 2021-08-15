using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamageCheck : MonoBehaviour
{
    public GameObject BulletObj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.layer == 8)
        {
            Destroy(BulletObj);
        }
        if (other.gameObject.layer == 9)
        {
            Destroy(BulletObj);
        }
        Debug.Log(other.gameObject.name);
    }

   
}
