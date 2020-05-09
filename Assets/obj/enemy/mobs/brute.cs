using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brute : enemy
{
    public eLaser eLaserObj;
    // Start is called before the first frame update
    void Start()
    {
        health = 50;
        value = 10;
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
        eLaser newEl = Instantiate(eLaserObj, enemyObj.transform);
        newEl.transform.Rotate(90, 0, 0);
        newEl.transform.localScale = new Vector3(.2f, 25, .2f);
        newEl.transform.localPosition = new Vector3(0, 0, 26);
        newEl.name = "enemyLaser";
        yield return new WaitForSeconds(1);
    }
}
