using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wpnSpreader : weapon
{
    public bltSpreader bltSpreaderObj;
    public AudioClip spreadSnd;
    // Start is called before the first frame update
    void Start()
    {
        lastFire = 0;
        fireCd = .5f;
        if (gameManager.manager.spreadActive == false)
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
        //int spreadNum;
        if (Time.time > lastFire + fireCd)
        {
            float angleBetween = 10- gameManager.manager.spreadLevel;
            float startingAngle = 90 - (gameManager.manager.spreadLevel * angleBetween); //todo
            
            for (int i = 0; i < gameManager.manager.spreadLevel*2+1; i++)
            {
                bltSpreader newBs = Instantiate(bltSpreaderObj,this.transform.position,Quaternion.identity);                
                newBs.transform.rotation = Quaternion.Euler (0,startingAngle+ angleBetween*i, 0);
                newBs.bulletSpd = 2000;
                newBs.GetComponent<Rigidbody>().AddForce(newBs.transform.TransformDirection(Vector3.forward * newBs.bulletSpd));                   
            }
            gameManager.manager.sndSrc.PlayOneShot(spreadSnd, gameManager.manager.soundVol/5);
            lastFire = Time.time;
        }
    }
}
