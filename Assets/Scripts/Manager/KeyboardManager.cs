using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardManager : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) { Messenger.Broadcast(GameEvent.CHANGEGRAVITY); }
        if (Input.GetKeyDown(KeyCode.LeftShift)) { Messenger.Broadcast(GameEvent.JUMP); }
    }
}
