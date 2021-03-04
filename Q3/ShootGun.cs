using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootGun : MonoBehaviour
{
    private float waitTime;

    void Start()
    {
        waitTime = 10f;
        StartCoroutine("Wait");
    }

    IEnumerator Wait()
    { 
        yield return new WaitForSeconds(waitTime);
        waitTime = Random.Range(1f, 1.5f);
        Shoot();
    }

    void Shoot()
    {
        AkSoundEngine.PostEvent("Play_Gunshot", gameObject);
        StartCoroutine("Wait");
    } 
   
}
