using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowLeftMoveScript : MonoBehaviour
{
    public float MoveSpeed = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.right * MoveSpeed) * Time.deltaTime;

    }
}
