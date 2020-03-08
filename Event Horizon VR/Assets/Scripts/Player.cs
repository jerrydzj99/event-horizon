using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
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

    void OnTriggerEnter(Collider other)
    {
        // The Direction and UP, DOWN, LEFT and RIGHT are enums declared in DataController
        if (other.CompareTag("UpPortal"))
        {
            control.MovePlayer(DataController.Direction.Up);
        } else if (other.CompareTag("DownPortal"))
        {
            control.MovePlayer(DataController.Direction.Down);
        } else if (other.CompareTag("LeftPortal"))
        {
            control.MovePlayer(DataController.Direction.Left);
        } else if (other.CompareTag("RightPortal"))
        {
            control.MovePlayer(DataController.Direction.Right);
        }
    }

    // ***** TODO: UPDATE PLAYER POSITION *****

    // Move the player to the room passed in as an argument and set the localTransform
    public void UpdatePlayerPosition(GameObject room)
    {
        currentRoom = room;
        player.transform.parent = room.transform;
        player.transform.localPosition = new Vector3(0f, 0f, 0f);
    }
}
