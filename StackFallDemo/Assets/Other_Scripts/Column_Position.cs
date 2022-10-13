using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Column_Position : MonoBehaviour
{

    new Camera camera;
    private void Awake()
    {
        camera = Camera.main;
    }

    void Update()
    {
        gameObject.transform.position = new Vector3(transform.position.x,camera.transform.position.y-7f,transform.position.z);
    }
}
