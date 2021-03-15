using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class carController : MonoBehaviour
{
    public GameObject gameOver;
    public float speed = 90f;
    public float turnSpeed = 5f;
    public GameObject cameraPivot;

    IPlayerInput _input;

    private float turnInput;
    public Rigidbody rb;
    public Transform wheel;
    private void Awake()
    {
        _input = new Pcinput();    
    }
    private void Start()
    {
        rb.centerOfMass = new Vector3(0, 0, 0);
    }

    public void GetInput()
    {

        turnInput = _input.Horizontal;

    }
    private void Update()
    {
        GetInput();
    }
    private void FixedUpdate()
    {
       
        
        rb.AddRelativeForce(new Vector3(Vector3.forward.x,0,Vector3.forward.z) * speed);
        Vector3 localvelocity = transform.InverseTransformDirection(rb.velocity);
        localvelocity.x = 0;
        rb.velocity = transform.TransformDirection(localvelocity);

        rb.AddTorque((Vector3.up) * turnSpeed * turnInput);


        cameraPivot.transform.Rotate(0, 0, 240 * Time.deltaTime * turnInput);
        wheel.Rotate(0, 0, -240 * Time.deltaTime * turnInput);
        
    }

   



    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.collider.CompareTag("Enemy"))
        {
            int magnitude = 800;
            Vector3 force = transform.position - collision.transform.position;
            force.Normalize();
            gameObject.GetComponent<Rigidbody>().AddForce(force * magnitude);
        }
       

    }
}
