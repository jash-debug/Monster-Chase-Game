using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform player;

    private Vector3 pos;
    private float minLimit = 126f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (!player)
            return;

        pos = transform.position;

        pos.x = player.position.x;

        pos.x = (pos.x > minLimit) ? minLimit : pos.x;
        pos.x = (pos.x < -minLimit) ? -minLimit : pos.x;


        transform.position = pos;




    }
}
