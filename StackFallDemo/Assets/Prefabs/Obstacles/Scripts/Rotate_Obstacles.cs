using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate_Obstacles : MonoBehaviour
{
    void FixedUpdate()
    {
        transform.Rotate(0, GameManager.obs_rot_speed * Time.fixedDeltaTime, 0);
    }

}