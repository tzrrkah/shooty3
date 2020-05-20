using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class btnMissile : MonoBehaviour
{
    public Button btnMissileObj;
    public void onClk()
    {

        if (gameManager.manager.score >= gameManager.manager.missilePrice)
        {
            gameManager.manager.score -= gameManager.manager.missilePrice;
            gameManager.manager.missileLevel++;
            gameManager.manager.missileActive = true;
            gameManager.manager.basicActive = false;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        btnMissileObj.GetComponentInChildren<Text>().text = "missile " + gameManager.manager.missilePrice;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
