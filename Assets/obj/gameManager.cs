﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    public static gameManager manager;
    public int score,level,enemyCount,maxEnemies;
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
    }
    // Start is called before the first frame update
    void Start()
    {
        maxEnemies = 50;
        level = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
