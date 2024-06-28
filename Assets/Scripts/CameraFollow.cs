using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform player;
    private Vector3 pos;

    // Min and max limits for the camera's x and y positions
    private float minXLimit = -126f;
    private float maxXLimit = 126f;
    private float minYLimit = -0.5f;  // Adjust these values as needed
    private float maxYLimit = 50f;   // Adjust these values as needed

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
        pos.y = player.position.y;

        // Clamp the camera position within the specified limits
        pos.x = Mathf.Clamp(pos.x, minXLimit, maxXLimit);
        pos.y = Mathf.Clamp(pos.y, minYLimit, maxYLimit);

        transform.position = pos;
    }
}
