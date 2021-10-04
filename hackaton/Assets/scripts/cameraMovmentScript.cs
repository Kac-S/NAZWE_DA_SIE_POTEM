using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovmentScript : MonoBehaviour
{
    [SerializeField]
    float sensitivity = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Fire1"))
        {
            Vector3 moveV = new Vector3(-Input.GetAxis("Mouse X"), 0, -Input.GetAxis("Mouse Y"));
            transform.position = transform.position + moveV * sensitivity;
        }
    }
}
