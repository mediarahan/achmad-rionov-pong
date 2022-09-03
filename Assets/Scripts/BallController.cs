using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public Vector2 speed;
    public Vector2 resetPosition;

    [SerializeField]
    private Rigidbody2D rig;

    private void Start()
    {
        rig.velocity = speed;
        rig = GetComponent<Rigidbody2D>();
    }

    public void ResetBall()
    {
        transform.position = new Vector3 (resetPosition.x,resetPosition.y, 2);
    }

    public void ActivatePowerupSpeedup(float magnitude)
    {
        rig.velocity *= magnitude;
    }
}
