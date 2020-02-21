using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // ***** TODO: GLOBAL VARIABLES *****
    public MainController control;
    public GameObject currentRoom;
    public GameObject player;
    // ***** TODO: PRIVATE VARIABLES *****

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // ***** TODO: TRIGGER MOVEMENT *****

    void OnTriggerStay(Collider other) {
        // The Direction and UP, DOWN, LEFT and RIGHT are enums declared in DataController
        if (other.GetComponent<DataController.Direction>() == DataController.Direction.Up) {
            control.PlayerMoveUp();
        }
        if (other.GetComponent<DataController.Direction>() == DataController.Direction.Down)
        {
            control.PlayerMoveDown();
        }
        if (other.GetComponent<DataController.Direction>() == DataController.Direction.Left)
        {
            control.PlayerMoveLeft();
        }
        if (other.GetComponent<DataController.Direction>() == DataController.Direction.Right)
        {
            control.PlayerMoveRight();
        }
    }

    // ***** TODO: UPDATE PLAYER POSITION *****

    // Move the player to the room passed in as an argument and set the localTransform
    public void UpdatePlayerPosition(GameObject room, Transform localTransform)
    {
        currentRoom = room;
        player.transform.position = localTransform.position;
    }
}
