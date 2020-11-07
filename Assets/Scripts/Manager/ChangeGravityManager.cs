using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeGravityManager: MonoBehaviour
{
    public static ChangeGravityManager instance = null;

    [SerializeField] private float gravity = 50f;

    private bool isRight = false;
    public bool IsRight => isRight;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        Messenger.AddListener(GameEvent.CHANGEGRAVITY, ChangeGravityOrientation);
    }
    private void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.CHANGEGRAVITY, ChangeGravityOrientation);
    }

    private void ChangeGravityOrientation()
    {
        if (Player.player.IsGround)
        {
            if (isRight)
            {
                Physics2D.gravity = new Vector2(gravity, 0f);
            } else
            {
                Physics2D.gravity = new Vector2(-gravity, 0f);
            }
            isRight = !isRight;
        }
    }
}
