using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveState : MonoBehaviour
{
    public void RemoveTinnitus()
    {
        StartCoroutine("Wait");
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(5f);
        AkSoundEngine.SetRTPCValue("Tinnitus", 0f);
    }
}
