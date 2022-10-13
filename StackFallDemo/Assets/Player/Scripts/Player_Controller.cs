using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    Rigidbody rb;

    [SerializeField] private float manuel_jumpSpeed;
    [SerializeField] private float default_jumpSpeed;

    bool isMoving;
    bool isTouch;
    bool justOnce = true;

    public GameObject gameOver_Panel;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            isMoving = true;
            isTouch = true;
        }
        else
            isTouch = false;
    }

    private void FixedUpdate()
    {
        if (isMoving)
        {
            rb.velocity = new Vector3(0, -manuel_jumpSpeed, 0);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        AreaCheckAndJump(collision);

        if (collision.gameObject.CompareTag("SafeArea") && isMoving)
        {
            collision.transform.parent.gameObject.GetComponent<Explode_Controller>().CallExplode();
        }
        isMoving = false;
    }

    private void OnCollisionStay(Collision collision)
    {
        isMoving = false;
        if (!isMoving)
            AreaCheckAndJump(collision);

        if (collision.gameObject.CompareTag("DangerArea") && isTouch&&justOnce)
        {
            StartCoroutine(StayDetection(collision));
            justOnce = false;
        }
    }
    void AreaCheckAndJump(Collision collision)
    {
        if (collision.gameObject.CompareTag("SafeArea") || collision.gameObject.CompareTag("DangerArea") || collision.gameObject.CompareTag("FinalPoint"))
            rb.velocity = new Vector3(0, default_jumpSpeed * Time.deltaTime, 0);
    }

    IEnumerator StayDetection(Collision collision)
    {
        yield return new WaitForSeconds(.05f);
        if (isTouch)
        {
            gameOver_Panel.SetActive(true);
            Time.timeScale = 0;
        }
        justOnce = true;
    }
}
