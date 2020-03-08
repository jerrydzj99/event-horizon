using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour
{
    public DataController dataController;
    public Player player;
    public GameObject deadend;
    public GameObject hallway;
    public GameObject corner;
    public GameObject tshaped;
    public GameObject intersection;

    // ***** TODO: PRIVATE VARIABLES *****
    private int[,] mapArray;
    private int playerX;
    private int playerY;

    // Start is called before the first frame update
    void Start()
    {
        // ***** TODO: PROCEDUALLY GENERATE THE MAP *****

        // For testing only!
        mapArray = new int[4, 3] {{0, 0, 0}, {1, 1, 1}, {0, 0, 0}, {0, 0, 0}};
        playerX = 1;
        playerY = 0;

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
            case DataController.Direction.Up:
                newX = playerX - 1;
                break;
            case DataController.Direction.Down:
                newX = playerX + 1;
                break;
            case DataController.Direction.Left:
                newY = playerY - 1;
                break;
            case DataController.Direction.Right:
                newY = playerY + 1;
                break;
        }

        Debug.Log(newX);
        Debug.Log(newY);

        int numDoors = 0;
        bool up = false;
        bool down = false;
        bool left = false;
        bool right = false;

        if (newY + 1 < mapArray.GetLength(1) && mapArray[newX, newY + 1] == 1)
        {
            Debug.Log("right door available");
            numDoors += 1;
            right = true;
        }
        if (newY - 1 >= 0 && mapArray[newX, newY - 1] == 1)
        {
            Debug.Log("left door available");
            numDoors += 1;
            left = true;
        }
        if (newX + 1 < mapArray.GetLength(0) && mapArray[newX + 1, newY] == 1)
        {
            Debug.Log("down door available");
            numDoors += 1;
            down = true;
        }
        if (newX - 1 >= 0 && mapArray[newX - 1, newY] == 1)
        {
            Debug.Log("up door available");
            numDoors += 1;
            up = true;
        }

        Debug.Log(numDoors);

        GameObject room = corner;
        switch(numDoors)
        {
            case 1:
                room = deadend;
                break;
            case 2:
                if ((left && right) || (up && down)) {
                    room = hallway;
                }
                break;
            case 3:
                room = tshaped;
                break;
            case 4:
                room = intersection;
                break;
        }

        //TODO calculate local transform, and pass it into update player position

        player.UpdatePlayerPosition(room);

    }


}
