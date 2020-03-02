using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour
{
    public DataController dataController;
    public PlayerController playerController;
    public GameObject deadend;
    public GameObject hallway;
    public GameObject corner;
    public GameObject tshaped;
    public GameObject intersection;

    // ***** TODO: PRIVATE VARIABLES *****
    private int[][] mapArray;
    private int playerX;
    private int playerY;

    // Start is called before the first frame update
    void Start()
    {
        // ***** TODO: PROCEDUALLY GENERATE THE MAP *****

        // ***** TODO: INITIALIZE PLAYER POSITION *****

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // ***** TODO: PLAYER MOVEMENT HANDLER *****

    // Move the player up by block in the direction specified if there is a room (called by PlayerController), do nothing if there is no room
    public void MovePlayer(DataController.Direction direction) {
        // Compute the destination room and the localTransform relative to the new room (this depends on the way from which the player enters the room) from direction and mapArray
        // Call playerController.UpdatePlayerPosition(GameObject room, Transform localTransform)
        int newX = playerX;
        int newY = playerY;
        switch (direction)
        {
            case Up:
                newY = playerY + 1;
            case Down:
                newY = playerY - 1;
            case Left:
                newX = playerX - 1;
            case Right:
                newx = playerX + 1;
        }

        int numDoors = 0;
        bool up = false;
        bool down = false;
        bool left = false;
        bool right = false;
        if (newX + 1 < mapArray.Length() && mapArray[newX + 1][newY])
        {
            numDoors += 1;
            up = true;
        }
        if (newX - 1 > 0 && mapArray[newX - 1][newY])
        {
            numDoors += 1;
            down = true;
        }
        if (newY + 1 < mapArray[0].Length() && mapArray[newX][newY + 1])
        {
            numDoors += 1;
            right = true;
        }
        if (newY - 1 > 0 && mapArray[newX][newY - 1])
        {
            numDoors += 1;
            left = true;
        }

        GameObject room = corner;
        switch(numDoors)
        {
            case 1:
                room = deadend;
            case 2:
                if ((left && right) || (up && down) {
                    room = hallway;
                }
            case 3:
                room = tshaped;
            case 4:
                room = intersection;
        }

        //TODO calculate local transform, and pass it into update player position
    }


}
