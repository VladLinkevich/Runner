using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player player = null;

    [SerializeField] private float jumpForce = 500f;

    private Rigidbody2D body;

    private bool isGround = true;

    public bool IsGround => isGround;

    #region MonoBehaviour Callbacks

    private void Awake()
    {
        if (player == null)
        {
            player = this;
        }

        Messenger.AddListener(GameEvent.JUMP, Jump);

        body = GetComponent<Rigidbody2D>();
    }

    private void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.JUMP, Jump);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Wall") { isGround = true; }
    }

    #endregion


    private void Jump()
    {
        if (isGround)
        {
            if (Physics2D.gravity.x > 0) { body.AddForce(Vector2.left * jumpForce); }
            else { body.AddForce(Vector2.right * jumpForce); }

            isGround = false;
        }
    }

}
