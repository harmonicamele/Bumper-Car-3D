using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pcinput : IPlayerInput
{
    
    public float Horizontal => Input.GetAxis("Horizontal");
    
}
