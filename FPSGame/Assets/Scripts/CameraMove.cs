using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject PlayerCamPos;
    public GameObject Player;
    public float MouseX;
    public float MouseY;
    public float Rot_X;
    public float Rot_y;
    public float AimSpeed;
    // Start is called before the first frame update

    void Start()
    {
        AimSpeed = StatManager.instance.AimSpeed;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        ToPlayer();
        Rotate();
    }

    void ToPlayer()
    {
        transform.position = PlayerCamPos.transform.position;
       
        
    }
    void Rotate()
    {
        MouseX = Input.GetAxis("Mouse X");
        MouseY = Input.GetAxis("Mouse Y");

        Rot_X = transform.rotation.eulerAngles.x + MouseY * -AimSpeed;
        Rot_y = transform.rotation.eulerAngles.y + MouseX * AimSpeed;

        
        if (Rot_X > 70f && Rot_X < 100f)
        {
            Rot_X = 70f;
        }
        else if (Rot_X < 290f && Rot_X > 260f)
        {
            Rot_X = 290f;
        }
        
        transform.rotation = Quaternion.Euler(Rot_X, Rot_y, transform.rotation.eulerAngles.z);
    }
}   
