using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wall : MonoBehaviour
{

    public Transform right;
    public Transform left;

    private float screenLeftBound;
    private float screenRightBound;

    private float characterWidth = 1.33f;


    void Start()
    {
        // Get the screen bounds in world coordinates
        screenLeftBound = Camera.main.ScreenToWorldPoint(Vector3.zero).x;
        screenRightBound = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x;

        // Assuming the character's sprite has a BoxCollider2D attached
        //characterWidth = GetComponent<BoxCollider2D>().bounds.size.x;

        // Calculate the left and right bounds for the character movement
        float leftBound = screenLeftBound + characterWidth / 2f;
        float rightBound = screenRightBound - characterWidth / 2f;



        float finalleft = leftBound + -0.604394f;
        float finalRight = rightBound + 0.604394f;


        // Apply the calculated bounds to the left and right wall positions
        Vector3 leftWallPosition = new Vector3(finalleft, left.position.y, left.position.z);
        Vector3 rightWallPosition = new Vector3(finalRight, right.position.y, right.position.z);

        left.transform.position = leftWallPosition;
        right.transform.position = rightWallPosition;
    }


}
