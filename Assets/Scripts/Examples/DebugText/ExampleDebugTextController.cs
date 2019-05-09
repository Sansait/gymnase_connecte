using CRI.HitBoxTemplate.Serial;
using UnityEngine;

namespace CRI.HitBoxTemplate.Example
{
    public class ExampleDebugTextController : MonoBehaviour
    {
        private void OnEnable()
        {
            ImpactPointControl.onImpact += OnImpact;
        }

        private void OnDisable()
        {
            ImpactPointControl.onImpact -= OnImpact;
        }

        private void OnImpact(object sender, ImpactPointControlEventArgs e)
        {
            Debug.Log(string.Format("Impact: Player [{0}], Position [{1}], Accelerometer [{2}]",
                e.playerIndex,
                e.impactPosition,
                e.accelerometer));
        }
    }
}
