using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deadarea : MonoBehaviour
{
    public GameObject GameOver;
    public carController carcontol;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            GameOver.SetActive(true);
            carcontol.enabled = false;
        }
        if (collision.collider.CompareTag("Enemy"))
        {
            Destroy(collision.collider.gameObject, 1);


        }
    }
    
}
