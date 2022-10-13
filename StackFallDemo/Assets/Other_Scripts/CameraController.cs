using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public SwapnScript swapnScript;

    public Transform player;

    Vector3 offset;

    [SerializeField] GameObject finalPoint;

    private void Start()
    {
        offset = transform.position;
        finalPoint = GameObject.FindGameObjectWithTag("FinalPoint");
    }

    private void LateUpdate()
    {
        if (transform.position.y - player.position.y > 3f && transform.position.y - finalPoint.transform.position.y >= 4f)
            transform.position = new Vector3(transform.position.x, player.position.y + 3f, transform.position.z);
    }

    public void Set_CameraPosition(GameObject ball)
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, ball.transform.position.y + offset.y, transform.position.z), 10f);
    }
}
