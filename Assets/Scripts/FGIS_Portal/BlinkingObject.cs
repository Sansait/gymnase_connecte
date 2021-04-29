using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkingObject : MonoBehaviour
{
    [SerializeField] float activeTime;
    private float inactiveTime;
    private float timer;

    private bool isActive;

    private MeshRenderer myMesh;
    private Collider myCollider;

    // Start is called before the first frame update
    void Start()
    {
        myMesh = GetComponent<MeshRenderer>();
        myCollider = GetComponent<Collider>();

        isActive = true;
        inactiveTime = Random.Range(2,6);
        timer = activeTime;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.deltaTime;
        if(!isActive && timer >= inactiveTime)
        {
            myMesh.enabled = true ;
            myCollider.enabled = true;

            isActive = true;
            timer = 0;
        }
        else if(isActive && timer >= activeTime)
        {
            myMesh.enabled = false;
            myCollider.enabled = false;
            isActive = false;
            timer = 0;
        }
    }
}
