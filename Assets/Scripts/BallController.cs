using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public Vector2 speed;

    [SerializeField]
    private Rigidbody2D rig;

    private void Start()
    {
        rig.velocity = speed;
        rig = GetComponent<Rigidbody2D>();
    }
}
