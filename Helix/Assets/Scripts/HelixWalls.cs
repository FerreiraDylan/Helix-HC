using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelixWalls : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var tmp = Random.Range(1, transform.childCount - 1);
        Debug.Log(tmp);

        for (int i = 0; i != tmp; i++)
        {
            Destroy(transform.GetChild(transform.childCount - 1).gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
 