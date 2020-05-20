using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class brute : enemy
{
    public eLaser eLaserObj;
    // Start is called before the first frame update
    void Start()
    {
        health = 1000;
        value = 1;
        StartCoroutine(moveBrute());
    }

    // Update is called once per frame
    void Update()
    {
        chkPos(enemyObj);
    }
    public void OnTriggerStay(Collider c)
    {
        triggerProc(enemyObj, c);
    }
    public void OnTriggerEnter(Collider c)
    {
        triggerProc(enemyObj, c);
    }
    IEnumerator moveBrute()
    {
        moveSpd = .2f;
        Vector3 tPos = new Vector3(-125, 1.5f, enemyObj.transform.position.z);
        //goto 1/4 pt
        while (enemyObj.transform.position.x > 25)
        {
            enemyObj.transform.position = Vector3.MoveTowards(enemyObj.transform.position, tPos, moveSpd);
            yield return new WaitForFixedUpdate();
        }//fire
        yield return new WaitForSeconds(1);
        StartCoroutine(shoot());
        yield return new WaitForSeconds(3);
        //goto end
        while (enemyObj.transform.position.x > -51)
        {
            enemyObj.transform.position = Vector3.MoveTowards(enemyObj.transform.position, tPos, moveSpd);
            yield return new WaitForFixedUpdate();
        }
    }
    IEnumerator shoot()
    {
        while (enemyObj != null)
        {
            eLaser newEl = Instantiate(eLaserObj, enemyObj.transform.position, Quaternion.identity);
            newEl.transform.Rotate(0, 0, 90);
            newEl.transform.localScale = new Vector3(1, 3, 1);
            newEl.name = "enemyLaser";
            Destroy(newEl.gameObject, 3);
            yield return new WaitForSeconds(2);
        }
    }
}
