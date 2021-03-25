using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal_GameManager : MonoBehaviour
{

    public static Portal_GameManager instance;
    [SerializeField] int currentLevel = 0;
    [SerializeField] GameObject[] levels;

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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextLevel()
    {
        levels[currentLevel].SetActive(false);
        currentLevel++;
        if (currentLevel < levels.Length)
        {
            levels[currentLevel].SetActive(true);
        }
        else
        {
            Debug.Log("End");
        }

    }
}
