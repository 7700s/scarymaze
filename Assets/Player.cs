using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    Transform cursor;
    public bool shouldWait = false;
    public float time = 0;
    // Start is called before the first frame update
    void Start()
    {
        cursor = GetComponent<Transform>();
        print(SceneManager.GetActiveScene().name);
        string name = SceneManager.GetActiveScene().name;
        if(name == "Jumpscare")
        {
            shouldWait = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0f;
        cursor.position = pos;
        
        if (shouldWait)
        {
            time += Time.deltaTime;
            print(time);
        }
        if (time > 4f)
        {
            shouldWait = false;
            time = 0;
            SceneManager.LoadScene("StartScene", LoadSceneMode.Single);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("Change"))
        {
            switch (SceneManager.GetActiveScene().name)
            {
                case "Level1":
                    SceneManager.LoadScene("Level2",LoadSceneMode.Single);
                    break;
                case "Level2":
                    SceneManager.LoadScene("Level3", LoadSceneMode.Single);
                    break;
                case "Level3":
                    SceneManager.LoadScene("Jumpscare", LoadSceneMode.Single);
                    break;
            }
        }
        if (collision.gameObject.name.Contains("Bad"))
        {
            SceneManager.LoadScene("StartScene", LoadSceneMode.Single);
        }
    }
    
    
}
