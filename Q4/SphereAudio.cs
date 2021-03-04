using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereAudio : MonoBehaviour
{
    void PlayAudio()
    {
        AkSoundEngine.PostEvent("Play_RandomBass", gameObject);
    }
}
