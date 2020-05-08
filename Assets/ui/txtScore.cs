using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class txtScore : MonoBehaviour
{
    public txtScore txtScoreObj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        txtScoreObj.GetComponent<Text>().text = gameManager.manager.score.ToString();
    }
}
