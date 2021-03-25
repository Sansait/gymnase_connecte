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
            //Upsizing the scale of the target to "targetFinalSize" in "chargingDuraction" seconds
            if (chargingProgress < chargingDuration)
            {
                chargingProgress += Time.deltaTime;
                Debug.Log(chargingProgress);
                // Upsizing effect only on x and z axis
                targetTransform.localScale = new Vector3(targetStartScale.x + ((chargingProgress / chargingDuration) * (targetFinalSize-targetStartScale.x)), targetStartScale.y, targetStartScale.z + ((chargingProgress / chargingDuration) * (targetFinalSize - targetStartScale.z)));
            }
            else
            {
                // Call what you want when the target is fully charged
                //Zodiac_GameManager.singleton.
            }
        }
    }
}
