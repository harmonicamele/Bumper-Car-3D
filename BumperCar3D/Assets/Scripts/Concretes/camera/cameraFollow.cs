using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public float smoothing;
    public float rotsmoothing;
    public Transform player;
    
  

    
    void FixedUpdate()
    {

        if (player!=null)
        {

            transform.position = Vector3.Lerp(transform.position, player.position, smoothing);
            transform.rotation = Quaternion.Slerp(transform.rotation, player.rotation, rotsmoothing);


            transform.rotation = Quaternion.Euler(new Vector3(0, player.rotation.eulerAngles.y, 0));
        }
       
    }
}
