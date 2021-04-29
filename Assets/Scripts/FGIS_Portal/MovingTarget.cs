using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTarget : MonoBehaviour
{
    private int nextPointId;
    private Transform[] points;
    [SerializeField] int moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        points = Portal_GameManager.instance.portalPoints;
        //Get random position inside the portal
        nextPointId = Random.Range(0,points.Length);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveToNextPoint();
    }

    public void MoveToNextPoint()
    {
        transform.position = Vector3.MoveTowards(transform.position, points[nextPointId].position, moveSpeed * Time.fixedDeltaTime);

        if (Vector2.Distance(transform.position, points[nextPointId].position) < .2f)
        {
            nextPointId = Random.Range(0, points.Length);
        }
    }

}
