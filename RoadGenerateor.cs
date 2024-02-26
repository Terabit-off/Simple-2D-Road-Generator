using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadGenerateor : MonoBehaviour
{
    #region public variables
    public GameObject road, turnLeftRoad, turnRightRoad;
    public int roadLength = 10;
    #endregion

    #region privat variables
    private Vector3 currentPosition;
    private Quaternion currentRotation;
    public bool previousTurnLeft;
    #endregion

    public void StartGame()
    {
        previousTurnLeft = false;
        currentPosition = transform.position;
        currentRotation = transform.rotation;
        RoadGenerateStart();
    }
    public void RoadGenerateStart()
    {
        for (int i = 0; i < roadLength; i++)
        {
            Generate();
        }
    }
    void Generate()
    {
        currentPosition += currentRotation * Vector3.up;    //move up position for spawn road

        bool turnLeft = Random.value < 0.5f;    //Random. straight or turn road

        if (previousTurnLeft)   //Spawn turn left road
        {
            if(turnLeft) // Random. Spawn turn road
            { 
                currentRotation *= Quaternion.Euler(0, 0, 90); // left
                Instantiate(turnLeftRoad, currentPosition, currentRotation, transform);
                previousTurnLeft = !previousTurnLeft;
            }
            else Instantiate(road, currentPosition, currentRotation, transform);    //Random. Spawn straight road
        }
        else    //Spawm turn Right road
        {
            if(!turnLeft)  // It`s can be "turnLeft", but it`s  "!turnLeft" for more random :)
            {
                currentRotation *= Quaternion.Euler(0, 0, -90); // right
                Instantiate(turnRightRoad, currentPosition, currentRotation, transform);
                previousTurnLeft = !previousTurnLeft;
            }
            else Instantiate(road, currentPosition, currentRotation, transform); //Random. Spawn straight road
        }
    }
    public void RoadClear()
    {
        // If write "for(int i = 0; i < road count; i++)", it`s doesn't work correctly
        for (int i = transform.childCount - 1; i >= 0; i--)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
    }
}
