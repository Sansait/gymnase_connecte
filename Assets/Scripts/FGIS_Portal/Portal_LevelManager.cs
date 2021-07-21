using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal_LevelManager : MonoBehaviour
{
    [SerializeField] int nbStepsStart;
    int nbStepsCurrent;
    void Start()
    {
        nbStepsCurrent = nbStepsStart;
    }
    public void NextStep()
    {
        nbStepsCurrent--;
        if (nbStepsCurrent <= 0)
        {
            Portal_GameManager.instance.NextLevel();
        }
    }

    public void Restart()
    {
        nbStepsCurrent = nbStepsStart;
    }
}
