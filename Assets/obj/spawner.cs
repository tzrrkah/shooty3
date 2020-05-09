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
    public gunner gunnerObj;
    public spreader spreaderObj;
    public Text txtToPlayer,txtECount;
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(gameManager.manager.level);
        switch (gameManager.manager.level)
        {
            case 1:
                txtToPlayer.text = "level 1 grunts";
                StartCoroutine(spawnGrunt(gameManager.manager.maxEnemies, .2f));
                //gameManager.manager.enemyCount = 50;
                break;
            case 2:
                txtToPlayer.text = "level 2 brutes";
                StartCoroutine(spawnBrute(gameManager.manager.maxEnemies, 1f));
                //gameManager.manager.enemyCount = 50;
                break;
            case 3:
                txtToPlayer.text = "level 3 spinners";
                StartCoroutine(spawnSpinner(gameManager.manager.maxEnemies, 1));
                //gameManager.manager.enemyCount = 50;
                break;
            case 4:
                txtToPlayer.text = "level 4 gunner";
                StartCoroutine(spawnGunner(gameManager.manager.maxEnemies, .5f));
                //gameManager.manager.enemyCount = 50;
                break;
            case 5:
                txtToPlayer.text = "level 5 spreader";
                StartCoroutine(spawnSpreader(gameManager.manager.maxEnemies, .5f));
                //gameManager.manager.enemyCount = 50;
                break;            
            case 6:
                txtToPlayer.text = "level 6 everything";
                StartCoroutine(spawnEverything(gameManager.manager.maxEnemies, .2f));
                //gameManager.manager.enemyCount = 50;
                break;
        }
        gameManager.manager.enemyCount = gameManager.manager.maxEnemies;
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
    IEnumerator spawnEverything(int spawnNum, float spawnCd)
    {
        yield return new WaitForSeconds(2);
        for (int i = 0; i < spawnNum; i++)
        {
            int spawnType = Random.Range(1, 6);
            switch (spawnType)
            {
                case 1:
                    StartCoroutine(spawnGrunt(1, .1f));
                    break;
                case 2:
                    StartCoroutine(spawnBrute(1, .1f));
                    break;
                case 3:
                    StartCoroutine(spawnSpinner(1, .1f));
                    break;
                case 4:
                    StartCoroutine(spawnGunner(1, .1f));
                    break;                
                case 5:
                    StartCoroutine(spawnSpreader(1, .1f));
                    break;
            }
            yield return new WaitForSeconds(spawnCd);
        }
    }
    IEnumerator spawnSpreader(int spawnNum, float spawnCd)
    {
        yield return new WaitForSeconds(2);
        for (int i = 0; i < spawnNum; i++)
        {
            float zVal = Random.Range(-10f, -25f);
            spreader newS = Instantiate(spreaderObj, new Vector3(45, 1.5f, zVal), Quaternion.Euler(0, -90, 0));
            newS.name = "spreader";
            yield return new WaitForSeconds(spawnCd);
        }
    }
    IEnumerator spawnGunner(int spawnNum, float spawnCd)
    {
        yield return new WaitForSeconds(2);
        for (int i = 0; i < spawnNum; i++)
        {
            float zVal = Random.Range(10f, 25f);
            gunner newG = Instantiate(gunnerObj, new Vector3(45, 1.5f, zVal), Quaternion.Euler(0, -90, 0));
            newG.name = "gunner";
            yield return new WaitForSeconds(spawnCd);
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
