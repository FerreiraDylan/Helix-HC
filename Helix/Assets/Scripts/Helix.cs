using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helix : MonoBehaviour
{
    [SerializeField] float speedRotation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerMovement.instance.isAlive) 
            if (Input.GetMouseButton(0))
            {
                float rotation = Input.GetAxisRaw("Mouse X");

                transform.Rotate(0f, 0f, rotation * speedRotation * Time.deltaTime);
            }
    }
}
