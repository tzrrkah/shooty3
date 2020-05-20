using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicGun : weapon
{
    public basicBullet basicBulletObj;
    public AudioClip smlLaserSnd;

    // Start is called before the first frame update
    void Start()
    {
        lastFire = 0;
        fireCd = .1f;
        if (gameManager.manager.basicActive == false)
        {
            this.gameObject.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        shoot();

    }
    void shoot()
    {
        if (Time.time > lastFire + fireCd)
        {
            basicBullet newB = Instantiate(basicBulletObj, weaponObj.transform.position, weaponObj.transform.rotation);
            //newB.name = "basicBullet";
            newB.bulletSpd=5000;
            newB.GetComponent<Rigidbody>().AddForce(Vector3.right * newB.bulletSpd);
            lastFire = Time.time;
            gameManager.manager.sndSrc.PlayOneShot(smlLaserSnd,gameManager.manager.soundVol);
        }
    }
}
