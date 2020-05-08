using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wpnLaser : weapon
{
    public bltLaser bltLaserObj;
    // Start is called before the first frame update
    void Start()
    {
        lastFire = 0;
        fireCd = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > lastFire + fireCd)
        {
            //StartCoroutine(wpnFire());
            wpnFire();
            lastFire = Time.time;
            fireCd = 3;
        }
    }
    void wpnFire()
    {
        bltLaser newBl = Instantiate(bltLaserObj, weaponObj.transform);
        newBl.transform.localPosition = new Vector3(0, 0, 101);
        Destroy(newBl.gameObject, 2.8f);
        //yield return new WaitForSeconds(1);
    }
}
