using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Mover 
{
    private void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal") * 1.5f;
        float y = Input.GetAxis("Vertical") * 1.5f;

        UpdateMotor(new Vector3(x, y, 0));
    }

}
