using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    public static gameManager manager;
    public int level,enemyCount,maxEnemies,laserPrice,laserLevel,spreadPrice,spreadLevel,missilePrice,missileLevel;
    public float score;
    public bool basicActive, laserActive, spreadActive, missileActive;
    public AudioSource sndSrc;
    public float soundVol;
    public AudioClip explode;
    public List<enemy> enemyList;
    void Awake()
    {
        if (manager == null)
        {
            DontDestroyOnLoad(gameObject);
            manager = this;

        }
        else if (manager != this)
        {
            Destroy(gameObject);
        }
        laserPrice = 100;
        spreadPrice = 100;
        missilePrice = 100;
    }
    // Start is called before the first frame update
    void Start()
    {
        maxEnemies = 10;
        level = 1;
        basicActive = true;
        laserActive = false;
        spreadActive = false;
        missileActive = false;
        soundVol = .5f;
        score = 300;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
