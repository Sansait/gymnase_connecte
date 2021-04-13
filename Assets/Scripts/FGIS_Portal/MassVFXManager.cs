using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MassVFXManager : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem idleVFX;
    [SerializeField]
    private ParticleSystem chargingVFX;
    [SerializeField]
    private ParticleSystem successVFX;
    // Start is called before the first frame update
    void Start()
    {
        IdleState();
        chargingVFX.Stop();
        successVFX.Stop();
    }

    public void IdleState()
    {
        if (idleVFX.isStopped)
        {
            idleVFX.Play();

        }
 
    }

    public void ChargingState()
    {
        if(chargingVFX.isStopped)
        {
            idleVFX.Stop();
            chargingVFX.Play();
        }
    }
    public void SuccessState()
    {
            successVFX.Play();
    }
}
