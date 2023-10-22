using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    Transform cursor;
    int scene = 1;
    // Start is called before the first frame update
    void Start()
    {
        cursor = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0f;
        cursor.position = pos;
        
    }
    
}
