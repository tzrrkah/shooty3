using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wpnMissile : weapon
{
    public missile missileObj;
    // Start is called before the first frame update
    void Start()
    {
        lastFire = 0;
        fireCd = 0;
        if (gameManager.manager.missileActive == false)
        {
            this.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update() //todo enemy mvment
    {
        if (gameManager.manager.missileActive == true)
        {
            if (Time.time > lastFire + fireCd)
            {
                //StartCoroutine(wpnFire());
                wpnFire();
                lastFire = Time.time;
                fireCd = 1f / ((float)gameManager.manager.missileLevel); // +2);
            }
        }
    }
    void wpnFire()
    {
        missile newM = Instantiate(missileObj, this.transform.position, this.transform.rotation);
    }
}
