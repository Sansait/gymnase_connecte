using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal_GameManager : MonoBehaviour
{

    int[] correctSymbolsId;
    int correctKnot;

    public static Portal_GameManager instance;
    [SerializeField] int currentLevel;
    [SerializeField] GameObject[] levels;
    [SerializeField] GameObject[] symbols;
    [SerializeField] GameObject[] knots;
    [SerializeField] GameObject[] targets;

    [SerializeField] GameObject levelsParent;
    [SerializeField] GameObject portalGame;

    public Transform [] portalPoints;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    void Start()
    {
        correctSymbolsId = new int[4];
        levelsParent.SetActive(false);
        portalGame.SetActive(true);
        currentLevel = 0;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            
            ResetGame();
        }
        else if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            correctSymbolsId[0] = 5;
            correctSymbolsId[1] = 1;
            correctSymbolsId[2] = 7;
            correctSymbolsId[3] = 9;
            correctKnot = 0;
            levelsParent.SetActive(true);
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            correctSymbolsId[0] = 6;
            correctSymbolsId[1] = 2;
            correctSymbolsId[2] = 8;
            correctSymbolsId[3] = 10;
            correctKnot = 1;
            levelsParent.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            correctSymbolsId[0] = 7;
            correctSymbolsId[1] = 3;
            correctSymbolsId[2] = 9;
            correctSymbolsId[3] = 11;
            correctKnot = 2;
            levelsParent.SetActive(true);

        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            correctSymbolsId[0] = 8;
            correctSymbolsId[1] = 4;
            correctSymbolsId[2] = 10;
            correctSymbolsId[3] = 0;
            correctKnot = 3;
            levelsParent.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            correctSymbolsId[0] = 9;
            correctSymbolsId[1] = 5;
            correctSymbolsId[2] = 11;
            correctSymbolsId[3] = 1;
            correctKnot = 4;
            levelsParent.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            correctSymbolsId[0] = 10;
            correctSymbolsId[1] = 6;
            correctSymbolsId[2] = 0;
            correctSymbolsId[3] = 2;
            correctKnot = 5;
            levelsParent.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            correctSymbolsId[0] = 11;
            correctSymbolsId[1] = 7;
            correctSymbolsId[2] = 1;
            correctSymbolsId[3] = 3;
            correctKnot = 6;
            levelsParent.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            correctSymbolsId[0] = 0;
            correctSymbolsId[1] = 8;
            correctSymbolsId[2] = 2;
            correctSymbolsId[3] = 4;
            correctKnot = 7;
            levelsParent.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            correctSymbolsId[0] = 1;
            correctSymbolsId[1] = 9;
            correctSymbolsId[2] = 3;
            correctSymbolsId[3] = 5;
            correctKnot = 8;
            levelsParent.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            correctSymbolsId[0] = 2;
            correctSymbolsId[1] = 10;
            correctSymbolsId[2] = 4;
            correctSymbolsId[3] = 6;
            correctKnot = 9;
            levelsParent.SetActive(true);
        }
    }

    public void NextLevel()
    {
        levels[currentLevel].SetActive(false);
        symbols[correctSymbolsId[currentLevel]].SetActive(true);
        currentLevel++;
        if (currentLevel < levels.Length)
        {
            levels[currentLevel].SetActive(true);
        }
        else
        {
            levelsParent.SetActive(false);
            knots[correctKnot].SetActive(true);
            portalGame.SetActive(false);

        }

    }

    public void ResetGame()
    {
        for (int i = 0; i < symbols.Length; i++)
        {
            symbols[i].SetActive(false);

        }

        for (int i = 0; i < knots.Length; i++)
        {
            knots[i].SetActive(false);
        }

        correctSymbolsId = new int[4];
        levelsParent.SetActive(false);
        portalGame.SetActive(true);

        for (int i = 0; i < targets.Length; i++)
        {
            targets[i].SetActive(true);
        }

        for (int i = 0; i < levels.Length; i++)
        {
            levels[i].GetComponent<Portal_LevelManager>().Restart();
            levels[i].SetActive(false);
        }


        currentLevel = 0;
        levels[0].SetActive(true);

    }

}   
