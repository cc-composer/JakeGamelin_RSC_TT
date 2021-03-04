using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody rbody;
    [SerializeField] int gunSwitch;
    GunType gunType;
    string switchName;
    Camera cam => Camera.main;

    private void Start()
    {
        gunType = GetComponent<GunType>();
        rbody = GetComponent<Rigidbody>();

        switchName = gunType.gun[gunSwitch];
        AkSoundEngine.SetSwitch("GunType", switchName, gameObject);
    }

    private void Update()
    {
        rbody.velocity = transform.forward * 10f;
    }

    private void OnCollisionEnter(Collision other)
    {
        ImpactType impact = other.gameObject.GetComponent<ImpactType>();

        if (impact == null)
        {
            AkSoundEngine.SetSwitch("ImpactType", "Wood", gameObject); //change if needed
        }
        else
        {
            AkSoundEngine.SetSwitch("ImpactType", impact.material, gameObject);
            print(impact.material);
        }

        AkSoundEngine.PostEvent("Play_Impact", gameObject);
        CheckForRocketLauncherBlast(other.gameObject);
        Destroy(gameObject);
    }

    private void CheckForRocketLauncherBlast(GameObject other)
    {
        if(switchName == "RocketLauncher")
        {
            float dist = Vector3.Distance(cam.transform.position, other.transform.position);
            if(dist <= 10f)
            {
                RemoveState rs = cam.GetComponent<RemoveState>();
                
                AkSoundEngine.SetRTPCValue("Tinnitus", 100f);
                rs.RemoveTinnitus();
            }
        }
    }
}
