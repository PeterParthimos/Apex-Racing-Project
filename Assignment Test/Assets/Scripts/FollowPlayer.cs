using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float newX = (player.transform.position.x + 20);
        float newY = (player.transform.position.y + 30);
        float newZ = (player.transform.position.z);

        transform.position = new Vector3(newX, newY, newZ);
    }
}
