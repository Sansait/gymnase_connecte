using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal_LevelManager : MonoBehaviour
{
    [SerializeField] int nbSteps;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextStep()
    {
        nbSteps--;
        if(nbSteps <= 0)
        {
            Portal_GameManager.instance.NextLevel();
        }
    }
}
