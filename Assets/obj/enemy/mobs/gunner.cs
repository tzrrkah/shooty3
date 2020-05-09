using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunner : enemy
{
    bool isShooting;
    public eLaserSml eLaserSmlObj;
    // Start is called before the first frame update
    void Start()
    {
        health = 10;
        value = 10;
        moveSpd = .07f;
        lastShoot = Time.time;
        shootCd = Random.Range(0f, 2f);
        isShooting = false;
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
        if(isShooting==false)
        {
            //startcoroutine + fire
            StartCoroutine(shootVolley());
        }
    }
    IEnumerator shootVolley()
    {
        isShooting = true;
        float waitTime = Random.Range(0f, 3f);
        yield return new WaitForSeconds(waitTime);
        for (int i = 0; i < 5; i++)
        {
            eLaserSml newELS = Instantiate(eLaserSmlObj, enemyObj.transform.position, enemyObj.transform.rotation);
            newELS.bulletSpd=30;
            newELS.name = "enemyLaserSmall";
            newELS.GetComponent<Rigidbody>().AddForce((playerObj.transform.position - newELS.transform.position) * newELS.bulletSpd); 
            yield return new WaitForSeconds(.1f);
        }      
    }
    public void OnTriggerStay(Collider c)
    {
        triggerProc(enemyObj, c);
    }
}
