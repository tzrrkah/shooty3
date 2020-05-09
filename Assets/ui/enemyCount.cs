using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class enemyCount : MonoBehaviour
{
    public Slider enemyCountObj;
    public void onChng()
    {
        gameManager.manager.maxEnemies = (int)enemyCountObj.value;
    }
    // Start is called before the first frame update
    void Start()
    {
        enemyCountObj.value = gameManager.manager.maxEnemies;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
