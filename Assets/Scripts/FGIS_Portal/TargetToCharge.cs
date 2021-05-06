using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetToCharge : MonoBehaviour
{
    Vector3 targetStartScale;
    bool isCharging;
    float chargingProgress = 0;

    [SerializeField] float chargingDuration = 5;
    [SerializeField] float targetFinalSize;
    [SerializeField] Transform targetTransform;

    [SerializeField]
    private Portal_LevelManager myLevelManager;
    [SerializeField]
    private DeathParticles deathParticles;

    private void Start()
    {
        targetStartScale = targetTransform.localScale;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Mass"))
        {
            //Reset
            chargingProgress = 0;
            targetTransform.localScale = targetStartScale;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Mass"))
        {

            if (chargingProgress >= chargingDuration)
            {
                AudioManager.instance.Play("energy_void");
                deathParticles.PlayDeathParticles(this.transform.position);
                Destroy(gameObject);

                if (myLevelManager != null)
                {
                    myLevelManager.NextStep();
                }
            }
            //Upsizing the scale of the target to "targetFinalSize" in "chargingDuraction" seconds
            else
            {
                chargingProgress += Time.deltaTime;
                // Upsizing effect only on x and z axis
                targetTransform.localScale = new Vector3(targetStartScale.x + ((chargingProgress / chargingDuration) * (targetFinalSize - targetStartScale.x)),
                    targetStartScale.y, targetStartScale.z + ((chargingProgress / chargingDuration) * (targetFinalSize - targetStartScale.z)));
            }
        }
    }
}
