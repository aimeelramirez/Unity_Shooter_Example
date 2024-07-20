using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutMap : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 RespawnPos;
    Vector3 line;
    void Start()
    {
        RespawnPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) {
            this.transform.position = Vector3.zero;
        Debug.Log("Click");
    }
      
    }
}
