using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    void PlayFootstepSound()
    {
        RaycastHit hit;

        if(Physics.Raycast(transform.position, Vector3.down, out hit))
        {
            SoundMaterial sm = hit.collider.gameObject.GetComponent<SoundMaterial>();
            if (sm != null)
            {
                sm.material.SetValue();
            }
        }
        
        AkSoundEngine.PostEvent("Play_Footstep", gameObject);
    }
}
