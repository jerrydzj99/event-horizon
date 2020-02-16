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
    }


}
