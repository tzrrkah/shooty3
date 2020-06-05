using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spinner : enemy
{
    public eLaserSml eLaserSmlObj;
    // Start is called before the first frame update
    void Start()
    {
        health = 300;
        value = 1;
        moveSpd = .3f;        
        StartCoroutine(moveSpinner());
    }

    // Update is called once per frame
    void Update()
    {
        chkPos(enemyObj);
    }
    IEnumerator moveSpinner()
    {
        float xPos = Random.Range(-10f, 40f);
        float zPos = Random.Range(-25f, 25f);
        Vector3 tPos =new Vector3(xPos, 1.5f, zPos);
        while(Vector3.Distance(enemyObj.transform.position, tPos) > 1)
        {
            enemyObj.transform.position = Vector3.MoveTowards(enemyObj.transform.position, tPos, moveSpd);
            yield return new WaitForFixedUpdate();
        }
        StartCoroutine(shoot());
        yield return new WaitForSeconds(2f);
        //move left again

        while (enemyObj.transform.position.x > -51)
        {
            enemyObj.transform.position = Vector3.MoveTowards(enemyObj.transform.position, enemyObj.transform.position+new Vector3(-10,0,0), moveSpd);
            yield return new WaitForFixedUpdate();
        }
    }
    IEnumerator shoot()
    {
        while (true)
        {
            enemyObj.transform.Rotate(0, 20, 0);
            eLaserSml newELS = Instantiate(eLaserSmlObj, enemyObj.transform.position, enemyObj.transform.rotation);
            newELS.bulletSpd = 1000;
            newELS.name = "enemyLaserSmall";
            newELS.GetComponent<Rigidbody>().AddForce(newELS.transform.TransformDirection(newELS.transform.forward*newELS.bulletSpd));
            yield return new WaitForSeconds(.1f);
        }        
    }
    public void OnTriggerStay(Collider c)
    {
        triggerProc(enemyObj, c);
    }
    public void OnTriggerEnter(Collider c)
    {
        triggerProc(enemyObj, c);
    }
}
