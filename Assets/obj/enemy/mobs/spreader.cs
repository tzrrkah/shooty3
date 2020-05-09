using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spreader : enemy
{
    bool hasShot;
    public ebullet ebulletObj;
    // Start is called before the first frame update
    void Start()
    {
        health = 10;
        value = 10;
        moveSpd = .07f;
        lastShoot = Time.time;
        shootCd = Random.Range(0f, 2f);
        hasShot = false;
        playerObj = GameObject.FindGameObjectWithTag("Player").GetComponent<player>();
    }

    // Update is called once per frame
    void Update()
    {
        moveLeft(enemyObj);
        shoot();
        chkPos(enemyObj);
    }
    void shoot()
    {
        enemyObj.transform.LookAt(playerObj.transform);
        if (hasShot == false)
        {
            StartCoroutine(shootSpread());
        }
    }
    IEnumerator shootSpread()
    {
        hasShot = true;
        float waitTime = Random.Range(0f, 3f);
        yield return new WaitForSeconds(waitTime);
        for (int i = -2; i <= 2; i++)
        {
            ebullet newEB = Instantiate(ebulletObj, enemyObj.transform.position, enemyObj.transform.rotation);
            newEB.transform.Rotate(0, i * 15, 0);
            newEB.bulletSpd = 1000;
            newEB.name = "enemyBullet";
            newEB.GetComponent<Rigidbody>().AddForce(newEB.transform.TransformDirection( Vector3.forward * newEB.bulletSpd));
        }
    }
    public void OnTriggerStay(Collider c)
    {
        triggerProc(enemyObj, c);
    }
}
