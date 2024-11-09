using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSpawnScript : MonoBehaviour
{

    public GameObject Arrow;
    public float SpawnRate;
    public float timer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < SpawnRate)
        {
            timer = timer + Time.deltaTime;
        }
        else
        {
            SpawnArrow();
            timer = 0;
        }
    }

    void SpawnArrow()
    {
        SpawnRate = Random.Range(3.0f, 5.0f);

        Instantiate(Arrow, new Vector3(transform.position.x, transform.position.y, 0), transform.rotation);
    }
}
