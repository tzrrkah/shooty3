using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class txtLsrLvl : MonoBehaviour
{
    public Text lsrLvlObj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lsrLvlObj.text = gameManager.manager.laserLevel.ToString();
    }
}
