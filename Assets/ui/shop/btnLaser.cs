using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class btnLaser : MonoBehaviour
{
    public Button btnLaserObj;
    //public wpnLaser wpnLaserObj;
    public void onClk()
    {
        
        if (gameManager.manager.score>= gameManager.manager.laserPrice)
        {
            gameManager.manager.score -= gameManager.manager.laserPrice;            
            gameManager.manager.laserLevel++;
            gameManager.manager.laserActive = true;
            gameManager.manager.basicActive = false;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        btnLaserObj.GetComponentInChildren<Text>().text = "laser " + gameManager.manager.laserPrice;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
