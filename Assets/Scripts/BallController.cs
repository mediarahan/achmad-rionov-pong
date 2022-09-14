using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public Vector2 speed;
    public Vector2 resetPosition;

    [SerializeField]
    private Rigidbody2D rig;

    [HideInInspector]
    public PaddleController lastPaddle;

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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Paddle"))
        {
            lastPaddle = collision.collider.GetComponent<PaddleController>();
            Debug.Log("Last Paddle: " + lastPaddle.gameObject.name);
        }
    }

    public void ActivatePUPaddleSize(float scale)
    {
        lastPaddle.ActivatePowerupPaddleSize(scale);
    }

    public void ActivatePUPaddleSpeed(int multiplier)
    {
        lastPaddle.ActivatePowerupPaddleSpeed(multiplier);
    }
}
