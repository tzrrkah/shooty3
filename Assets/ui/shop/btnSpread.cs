using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class btnSpread : MonoBehaviour
{
    public Button btnObj;
    public wpnSpreader wpnSpreaderObj;

    public void onClk()
    {
        
        if (gameManager.manager.score >= gameManager.manager.spreadPrice)
        {
            gameManager.manager.score -= gameManager.manager.spreadPrice;
            gameManager.manager.spreadLevel++;
            gameManager.manager.spreadActive = true;
            gameManager.manager.basicActive = false;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        btnObj.GetComponentInChildren<Text>().text = "spread " + gameManager.manager.spreadPrice;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
