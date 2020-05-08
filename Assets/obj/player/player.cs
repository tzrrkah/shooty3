using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class player : MonoBehaviour
{
    public player p;
    public int health;
    // Start is called before the first frame update
    void Start()
    {
        health = 100;
    }

    // Update is called once per frame
    void Update()
    {
        cursorMv();
    }
    void cursorMv()
    {
        Vector3 offset = new Vector3(0, 1, 0);
        float speed = .1f;
        RaycastHit h;
        Ray r = Camera.main.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
        if(Physics.Raycast(r,out h))
        {
            RaycastHit[] ha = Physics.RaycastAll(Camera.main.transform.position, r.direction);
            foreach(RaycastHit r2 in ha)
            {
                if (r2.collider.name == "floor")
                {
                    Vector3 tPos = r.origin + (r.direction * r2.distance);
                    p.transform.position = Vector3.Lerp(p.transform.position, tPos + offset, speed);
                }
            }
        }
    }
    void applyDmg(int dmg)
    {
        health -= dmg;
    }
    void OnTriggerEnter(Collider c)
    {
        //Debug.Log("t-" + c.name);
        switch (c.name)
        {
            case "enemyBullet":
                applyDmg(15);
                break;
            case "enemyLaser":
                applyDmg(30);
                break;
            case "enemyLaserSmall":
                applyDmg(5);
                break;
        }
    }
    void OnCollisionEnter(Collision c)
    {
        //Debug.Log("c-" + c.collider.name);
        //take dmg
    }
}
