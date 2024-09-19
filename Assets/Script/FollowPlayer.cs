using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;

    //For switching camera 
    private Vector3 offset1 = new Vector3(0, 7, -8.85f);
    private Vector3 offset2 = new Vector3(0, 2.28f, 1);
    private Vector3 currentOffset;

// Start is called before the first frame update
    void Start()
    {
        currentOffset = offset1;
    }

    void CameraSwitcher()
    {
        if(currentOffset == offset1)
        {
            currentOffset = offset2;
        }
        else if(currentOffset == offset2)
        {
            currentOffset = offset1;
        }

    }


    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            CameraSwitcher();
        }

        transform.position = player.transform.position + currentOffset;

    }
}
