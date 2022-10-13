using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode_Controller : MonoBehaviour
{
    public Explode[] explodes;

    public void CallExplode()
    {
        foreach (var item in explodes)
        {
            item.Break();
        }
        StartCoroutine(DestroyAllObjects());
    }

    IEnumerator DestroyAllObjects()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
