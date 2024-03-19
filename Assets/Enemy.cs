using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemy : MonoBehaviour
{
    public float speed = 50f;

    private Transform target;
    private int wavePointIndex = 0;

    private void Start()
    {
        target = Waypoints.wpoints[0];
    }

    private void Update()
    {
        Vector3 direction = target.position - transform.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWayPoint();
        }

    }

    void GetNextWayPoint()
    {
        if (wavePointIndex >= Waypoints.wpoints.Length - 1)
        {
            Destroy(gameObject);
            return;
        }
        wavePointIndex++;
        target = Waypoints.wpoints[wavePointIndex];
    }
}
