using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using UnityEngine;

public class PlayerManagement : MonoBehaviour
{
    //Based on "How to make an object follow the mouse in Unity" by Karolio: https://www.youtube.com/watch?v=mF_BB_YsyDk
    Camera cam;

    int score = 1;  //This variable keeps track of the score
    public float sizeIncrement; //Determins amount of size increase (Lower number = Bigger increase)
    float playerSize; //Used to Determine the size of the player object.
    int points;

    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
    }

    //This function deals with everything happening when colliding with an object
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Object") //If collided object have the tag "Object"
        {
            points = 1;

            score = ComputeScore(score, points);

            SizeController();
            Destroy(other.gameObject); //Destroy the collided object
        }

        if (other.gameObject.tag == "Object2") //If collided object have the tag "Object"
        {
            points = 10;

            score = ComputeScore(score, points);

            SizeController();
            Destroy(other.gameObject); //Destroy the collided object
        }

    }

    int ComputeScore(int a, int b) //Adds the points variable to the score
    {
        int computedScore = a + b;

        return computedScore;
    }

    void SizeController()
    {
        playerSize = 1 + (score / sizeIncrement); // Determines the size of the player object. Devides score by sizeUp to control growth of the player object
        Vector3 sizeVector = new Vector3(playerSize, playerSize, 0); //Creates a new vecter called "sizeVector" which is based on the size variable.
        transform.localScale = sizeVector; //Uses the sizeVector to grow the player object. (Sets scale of object to sizeVector's values)
        Debug.Log("Score = " + score); //Prints score to console
        Debug.Log("Player Size = " + playerSize); //Prints playerSize to console
    }

}
