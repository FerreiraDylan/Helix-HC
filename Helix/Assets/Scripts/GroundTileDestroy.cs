using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTileDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerExit(Collider other)
    {
        GameManager.instance.progress += 1;
        Destroy(transform.parent.gameObject, 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
