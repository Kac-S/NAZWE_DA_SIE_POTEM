using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foodScript : MonoBehaviour
{
    [SerializeField]
    float growTime = 5f;

    float time = 0f;

    [SerializeField]
    float initScale = 10f;
    [SerializeField]
    float scaleMultiplier = 1f;
    void Start()
    {
        
    }

    void Update()
    {
        if (time < growTime)
        {
            time += Time.deltaTime;
            Vector3 scaleV = new Vector3(initScale+time, initScale + time, 1);
            transform.localScale = scaleV;
        }
    }
}
