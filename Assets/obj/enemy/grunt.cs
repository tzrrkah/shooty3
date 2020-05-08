using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grunt : enemy
{
    // Start is called before the first frame update
    void Start()
    {
        health = 1;
        value = 1;
        moveSpd = .1f;
        lastShoot = Time.time;
        shootCd = Random.Range(0f, 2f);

    }

    // Update is called once per frame
    void Update()
    {
        moveLeft(enemyObj);
        shoot();
        chkPos(enemyObj);
        playerObj = GameObject.FindGameObjectWithTag("Player").GetComponent<player>();
    }

    public void OnTriggerStay(Collider c)
    {
        triggerProc(enemyObj, c);
    }
    void shoot()
    {
        enemyObj.transform.LookAt(playerObj.transform);
        if (Time.time>lastShoot+shootCd)
        {
            float moveSpdBlt = 30;
            bullet newB = Instantiate(bulletObj, enemyObj.transform.position,enemyObj.transform.rotation);
            //newEB.transform.LookAt(playerObj.transform);
            newB.GetComponent<Rigidbody>().AddForce((playerObj.transform.position- newB.transform.position) * moveSpdBlt);
            newB.name = "enemyBullet";
            Destroy(newB.gameObject, 5);
            lastShoot = Time.time;
            shootCd = 10;
        }  
    }
}
