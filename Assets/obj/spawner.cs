using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class spawner : MonoBehaviour
{
    public spawner spawnerObj;
    public grunt gruntObj;
    public brute bruteObj;
    public spinner spinnerObj;
    public Text txtToPlayer,txtECount;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(gameManager.manager.level);
        switch (gameManager.manager.level)
        {
            case 1:
                txtToPlayer.text = "level 1 grunts";
                StartCoroutine(spawnGrunt(100, .2f));
                gameManager.manager.enemyCount = 100;
                break;
            case 2:
                txtToPlayer.text = "level 2 brutes";
                StartCoroutine(spawnBrute(20, 1f));
                gameManager.manager.enemyCount = 20;
                break;
            case 3:
                txtToPlayer.text = "level 3 spinners";
                StartCoroutine(spawnSpinner(30, 1));
                gameManager.manager.enemyCount = 30;
                break;
        }
                
    }

    // Update is called once per frame
    void Update()
    {
        txtECount.text = gameManager.manager.enemyCount.ToString();
        if (gameManager.manager.enemyCount < 1)
        {
            SceneManager.LoadScene("shop");
            gameManager.manager.level++;
        }
    }
    IEnumerator spawnSpinner(int spawnNum, float spawnCd)
    {
        yield return new WaitForSeconds(2);
        for (int i = 0; i < spawnNum; i++)
        {
            float zVal = Random.Range(-25f, 25f);
            spinner newS=Instantiate(spinnerObj, new Vector3(45, 1.5f, zVal), Quaternion.Euler(0, -90, 0));
            newS.name = "spinner";
            yield return new WaitForSeconds(spawnCd);
        }
    }
    IEnumerator spawnBrute(int spawnNum, float spawnCd)
    {
        yield return new WaitForSeconds(2);
        for (int i = 0; i < spawnNum; i++)
        {
            float zVal = Random.Range(-25f, 25f);
            brute newB = Instantiate(bruteObj, new Vector3(45, 1.5f, zVal), Quaternion.Euler(0,-90,0));
            newB.name = "brute";
            yield return new WaitForSeconds(spawnCd);
        }
    }
    IEnumerator spawnGrunt(int spawnNum, float spawnCd)
    {
        yield return new WaitForSeconds(2);
        for(int i = 0; i < spawnNum; i++)
        {
            float zVal = Random.Range(-25f, 25f);
            grunt newG = Instantiate(gruntObj, new Vector3(45, 1.5f, zVal), Quaternion.identity);
            newG.name = "grunt";
            yield return new WaitForSeconds(spawnCd);
        }
        
    }
}
