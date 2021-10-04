using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plantManagerScr : MonoBehaviour
{
    [SerializeField]
    float plantTime = 5f;
    [SerializeField]
    GameObject foodObj;

    float time = 0f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (time > plantTime)
        {
            time = 0;
            Vector3 position = new Vector3(Random.Range(-50, 50), 2, Random.Range(-50, 50));
            Instantiate(foodObj, position, transform.rotation);
        }
        time += Time.deltaTime;
    }
}
