using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class btnGo : MonoBehaviour
{
    public Button btnGoObj;
    public void onClk()
    {
        SceneManager.LoadScene("main");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
