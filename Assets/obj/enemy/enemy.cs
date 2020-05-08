using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public enemy enemyObj;
    public bullet bulletObj;
    public player playerObj;
    public int health,value;
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
        if (Time.time > lastDamage + damageCd)        {
            
            if (c.name == "playerLaser")
            {
                StartCoroutine(damageColor(e));
//                Debug.Log(e.name);
                e.health -= c.GetComponent<bullet>().damage;
                chkDeath(e);
                lastDamage = Time.time;
                //damageCd = .1f;
            }            
        }
    }
    IEnumerator damageColor(enemy e)
    {
        e.GetComponent<Renderer>().material = dmgMat;
        yield return new WaitForSeconds(damageCd);
        e.GetComponent<Renderer>().material = eMat;
    }
    public void chkDeath(enemy e)
    {
        if(e.health <= 0)
        {
            gameManager.manager.score += e.value;
            Destroy(e.gameObject);
            gameManager.manager.enemyCount--;
        }
    }
    public void chkPos(enemy e)
    {
        if (e.transform.position.x < -51)
        {
            Destroy(e.gameObject);
            gameManager.manager.enemyCount--;
        }
    }
}
