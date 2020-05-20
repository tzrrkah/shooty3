using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public enemy enemyObj;
    public bullet bulletObj;
    public player playerObj;
    public float health,value;
    public float lastDamage, damageCd,moveSpd,lastShoot,shootCd;
    public Material eMat, dmgMat;
    // Start is called before the first frame update
    void Start()
    {
        lastDamage = 0;
        damageCd = .02f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void triggerProc(enemy e,Collider c)
    {
        if (Time.time > lastDamage + damageCd)        
        {
            
            switch (c.name)// == )
            {
                case "playerBasic":
                    Destroy(c.gameObject);
                    StartCoroutine(damageColor(e));
                    e.health -= c.GetComponent<bullet>().damage;
                    break;
                case "playerSpread":
                    Destroy(c.gameObject);
                    StartCoroutine(damageColor(e));
                    e.health -= c.GetComponent<bullet>().damage;
                    break;
                case "playerLaser":
                    StartCoroutine(damageColor(e));
                    e.health -= c.GetComponent<bullet>().damage;
                    break;
                case "playerMissile":
                    Destroy(c.gameObject);
                    StartCoroutine(damageColor(e));
                    e.health -= c.GetComponent<bullet>().damage;
                    break;
            }
            chkDeath(e,false);
            lastDamage = Time.time;
        }
    }
    IEnumerator damageColor(enemy e)
    {
        e.GetComponent<Renderer>().material = dmgMat;
        yield return new WaitForSeconds(damageCd);
        e.GetComponent<Renderer>().material = eMat;
    }
    public void chkDeath(enemy e,bool offScrn)
    {
        if(e.health <= 0)
        {
            if (offScrn == false)
            {
                gameManager.manager.score += e.value;
                gameManager.manager.sndSrc.PlayOneShot(gameManager.manager.explode, gameManager.manager.soundVol);
            }
            gameManager.manager.enemyList.Remove(e);
            Destroy(e.gameObject);
            gameManager.manager.enemyCount--;            
        }
    }
    public void chkPos(enemy e)
    {
        if (e.transform.position.x < -51)
        {
            e.health = 0;
            chkDeath(e,true);
        }
    }
    public void moveLeft(enemy e)
    {
        Vector3 tPos = e.transform.position + new Vector3(-10, 0, 0);
        e.transform.position = Vector3.MoveTowards(e.transform.position, tPos, moveSpd);
    }
}
