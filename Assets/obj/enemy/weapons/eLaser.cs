using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eLaser : bullet
{
    // Start is called before the first frame update
    void Start()
    {
        bulletSpd = .4f;
    }

    // Update is called once per frame
    void Update()
    {
            bulletObj.transform.position = Vector3.MoveTowards(bulletObj.transform.position, bulletObj.transform.position + new Vector3(-10, 0, 0), bulletSpd);

    }
}
