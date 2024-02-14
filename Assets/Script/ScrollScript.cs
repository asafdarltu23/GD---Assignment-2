using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollScript : MonoBehaviour
{
    //The three game objects with asteroids that we will be moving
    public Transform firstPiece;
    public Transform secondPiece;
    public Transform thirdPiece;
    public Transform fourthPiece;
    //The piece that's currently infront
    public Transform currentFrontPiece;

    //The time between each piece movement
    private float timePassed = 0;
    //A timer to keep track of the time between switches
    public float switchTime = 0;
    //The resulting Y-axis distance between a new front piece and the old front piece
    public float switchDistance = 0;

    // Update is called once per frame
    void Update()
    {
        /*The delta time is added to the timePassed variable to keep track of
time passed since a switch*/
        timePassed += Time.deltaTime;

        //If the amount of time required for a switch has passed...
        if (timePassed > switchTime)
        {
            if (firstPiece.position.y < secondPiece.position.y)
            {
                if (firstPiece.position.y < thirdPiece.position.y)
                {
                    if (firstPiece.position.y < fourthPiece.position.y)
                    {
                        //The first piece is the one at the back
                        firstPiece.transform.position =
                            currentFrontPiece.position + Vector3.up * switchDistance;
                        //Is the same as saying
                        //firstPiece.transform.position =
                        //    currentFrontPiece.position + new Vector(0,0,1) * switchDistance

                        currentFrontPiece = firstPiece;
                    }
                }
                else
                {
                    //The third piece is the one at the front
                    thirdPiece.transform.position =
                        currentFrontPiece.position + Vector3.up * switchDistance;

                    currentFrontPiece = thirdPiece;
                }
            }
            else
            {
                if (secondPiece.position.y < thirdPiece.position.y)
                {
                    if (secondPiece.position.y < fourthPiece.position.y)
                    {
                        //The second piece is the one at the middle
                        secondPiece.transform.position =
                            currentFrontPiece.position + Vector3.up * switchDistance;

                        currentFrontPiece = secondPiece;
                    }
                }
                else
                {
                    if (thirdPiece.position.y < fourthPiece.position.y)
                    {
                        //The third piece is the one at the back
                        thirdPiece.transform.position =
                            currentFrontPiece.position + Vector3.up * switchDistance;

                        currentFrontPiece = thirdPiece;
                    }
                    else
                    {
                        fourthPiece.transform.position =
                            currentFrontPiece.position + Vector3.up * switchDistance;

                        currentFrontPiece = fourthPiece;
                    }
                }
            }

            timePassed = 0;
        }
    }
}

