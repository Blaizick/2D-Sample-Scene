using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private GameObject player;
    public float cameraspeed;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        transform.position = Vector2.Lerp(transform.position, player.transform.position, cameraspeed);
        transform.position = new Vector3(transform.position.x, 0, -10);
    }
}
