using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapnScript : MonoBehaviour
{
    public GameObject[] obstacles;

    public GameObject final_obstacle;

    GameObject temp_obs;

    float temp_pos = 1.4f;
    float temp_rot1 = 48.5f;
    readonly float temp_rot2 = 90;
    float temp_rot3;

    public float minus_Pos = .5f;
    public float minus_Rot = 3.5f;

    // Start is called before the first frame update
    void Awake()
    {
        for (int i = 0; i < 200; i++)
        {
            if (i < 2)
                temp_obs = Instantiate(obstacles[0]);
            else
                temp_obs = Instantiate(obstacles[Random.Range(0, 4)]);

            temp_pos -= .5f;
            temp_rot1 -= 3.5f;
            temp_rot3 = temp_rot1;

            if (Random.value < .1f)
            {
                temp_rot1 = temp_rot3 - temp_rot2;
            }//+90 derece

            temp_obs.transform.position = new Vector3(0, temp_pos, 0);
            temp_obs.transform.eulerAngles = new Vector3(0, temp_rot1, 0);
            temp_rot1 = temp_rot3;
        }

        Instantiate(final_obstacle, new Vector3(0, temp_pos - 5f, 0), Quaternion.identity);
    }
}
