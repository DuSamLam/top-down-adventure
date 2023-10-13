using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //importing SceneManagement library
public class PlayerController : MonoBehaviour
{
    public float speed = .01f;
    public bool hasKey = false;

    public GameObject key;

    public static PlayerController instance;

    // Start is called before the first frame update
    void Start()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        GameObject.DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        //create a variable that holds value of position (position will always be a Vector value!)
        Vector3 newPosition = transform.position;

        //press W key to move up
        if (Input.GetKey("w"))
        {
            newPosition.y += speed; //same as newPosition.y = newPosition.y + speed
        }

        //press S key to move down
        if (Input.GetKey("s"))
        {
            newPosition.y -= speed;
        }

        //press A key to move left
        if (Input.GetKey("a"))
        {
            newPosition.x -= speed;
        }

        //press D key to move right
        if (Input.GetKey("d"))
        {
            newPosition.x += speed;
        }

        //update the current position to the new position
        transform.position = newPosition;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag.Equals("Door"))
        {
            Debug.Log("hit");
            SceneManager.LoadScene(1); //access SceneManager class for LoadScene function
        }

        if(collision.gameObject.tag.Equals("Key"))
        {
            Debug.Log("obtained key");
            key.SetActive(false); //key disapears
            hasKey = true; //player has the key now

        }

        if (collision.gameObject.tag.Equals("exit"))
        {
            Debug.Log("hit");
            SceneManager.LoadScene(0); //access SceneManager class for LoadScene function
        }

        
        
    }
}