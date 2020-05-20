using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missile : bullet
{
    // Start is called before the first frame update
    void Start()
    {
        damage = 100;
        bulletSpd = .4f;
        name = "playerMissile";
    }

    // Update is called once per frame
    void Update()
    {
        //find closest enemy 

        //move to enemy
        enemy tempE = getClosest();
        //Debug.Log(tempE);
        moveTo(tempE);

    }
    enemy getClosest()
    {
        enemy closestE = null;
        float closestDist = Mathf.Infinity;
        foreach(enemy e in gameManager.manager.enemyList)
        {
            if (Vector3.Distance(bulletObj.transform.position, e.transform.position) < closestDist)
            {
                closestE = e;
                closestDist = Vector3.Distance(bulletObj.transform.position, e.transform.position);
            }
        }
        return closestE;
    }
    void moveTo(enemy e)
    {
        Vector3 tPos;
        if (e == null)
        {
            //bulletObj.transform.position = Vector3.MoveTowards(bulletObj.transform.position, e.transform.position, bulletSpd);
            tPos = bulletObj.transform.position + new Vector3(bulletObj.transform.position.x+10, 0, 0);
        }
        else
        {
            bulletObj.transform.LookAt(e.transform);
            tPos = e.transform.position;
            //bulletObj.transform.position = Vector3.MoveTowards(bulletObj.transform.position, e.transform.position, bulletSpd);
        }
        bulletObj.transform.position = Vector3.MoveTowards(bulletObj.transform.position,tPos,bulletSpd);
    }
}
