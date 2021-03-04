using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGun : MonoBehaviour
{
    private int selector = 0;
    private GunType gunType = new GunType();
    
    public GameObject[] bullet;
    [SerializeField] GameObject player;
    
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            GunSwitcher();
        }

        if(Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }

    void GunSwitcher()
    {
        AkSoundEngine.PostEvent("Play_GunSwitch", gameObject);

        int gunsInInventory = gunType.gun.Length - 1;
        
        if(selector == gunsInInventory) { selector = 0; }
        else { selector++; }

        string switchName = gunType.gun[selector];
        AkSoundEngine.SetSwitch("GunType", switchName, gameObject);
    }

    void Fire()
    {
        AkSoundEngine.PostEvent("Play_Gunshot2", gameObject);
        Vector3 bulletPos = player.transform.position+(transform.forward*2);
        Instantiate(bullet[selector], bulletPos, player.transform.rotation);
    }
}
