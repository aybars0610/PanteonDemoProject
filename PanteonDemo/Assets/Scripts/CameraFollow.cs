using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    [SerializeField] private Vector3 offset = new Vector3(0, 1.3f, -1.5f);
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 moveVector = player.transform.position + offset;
        transform.position = moveVector;
        Camera.main.transform.rotation = Quaternion.Euler(25, 0, 0);

     

    }
}
