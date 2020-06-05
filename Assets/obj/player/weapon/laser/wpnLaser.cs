using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wpnLaser : weapon
{
    public bltLaser bltLaserObj;
    public AudioClip lsrSnd;
    public AudioSource lclAudioSrc;
    // Start is called before the first frame update
    void Start()
    {
        lastFire = 0;
        fireCd = 0;
        if (gameManager.manager.laserActive== false)
        {
            this.gameObject.SetActive(false);
        }
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
        bltLaser newBl = Instantiate(bltLaserObj, weaponObj.transform.position,Quaternion.identity);

        Vector3 lsrScale = new Vector3(1, 100, 1 + gameManager.manager.laserLevel / 2);

        newBl.transform.localScale = lsrScale;
        newBl.transform.rotation = Quaternion.Euler(0, 0, 90);
        Destroy(newBl.gameObject, 2.7f);
        StartCoroutine(moveLaser(newBl));
        //gameManager.manager.sndSrc.PlayOneShot(lsrSnd, gameManager.manager.soundVol/6);
        lclAudioSrc.PlayOneShot(lsrSnd, gameManager.manager.soundVol / 6);
    }
    IEnumerator moveLaser(bullet b)
    {
        while (b != null)
        {
            b.transform.position = weaponObj.transform.position + new Vector3(101, 0, 0);
            yield return new WaitForFixedUpdate();
        }
        
    }
}
