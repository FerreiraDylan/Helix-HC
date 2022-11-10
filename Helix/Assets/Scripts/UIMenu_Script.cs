using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMenu_Script : MonoBehaviour
{
    public Text txt_level;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        txt_level.text = "NIVEAU " + GameManager.instance.level.ToString();
    }
}
