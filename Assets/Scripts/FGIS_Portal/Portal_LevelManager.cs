using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal_LevelManager : MonoBehaviour
{
    [SerializeField] int nbSteps;

    public void NextStep()
    {
        nbSteps--;
        if(nbSteps <= 0)
        {
            Portal_GameManager.instance.NextLevel();
        }
    }
}
