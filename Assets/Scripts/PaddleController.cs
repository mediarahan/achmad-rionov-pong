using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public int speed;
    public KeyCode upKey;
    public KeyCode downKey;

    private Rigidbody2D rig;

    //Powerup Stuff
    private Coroutine PowerupTimer;
    private bool isPowerupPaddleSizeActive;
    private bool isPowerupPaddleSpeedActive;
    private Vector3 originalScale;
    private int originalSpeed;
    
    // Start is called before the first frame update
    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        //object gerak pakai input
        MoveObject(GetInput());
    }

    private Vector2 GetInput()
    {
        Vector2 movement = Vector2.zero;

        if (Input.GetKey(upKey))
        {
            return Vector2.up * speed;
        }
        if (Input.GetKey(downKey))
        {
            return Vector2.down * speed;
        }
        return Vector2.zero;
    }

    private void MoveObject(Vector2 movement)
    {
        //Debug.Log("Test: " + movement);
        rig.velocity = movement;
    }

    //Powerup Paddle Size
    public void ActivatePowerupPaddleSize(float scale)
    {
        if (isPowerupPaddleSizeActive == false)
        {
            isPowerupPaddleSizeActive = true;
            originalScale = transform.localScale;
            transform.localScale = new Vector3 (transform.localScale.x , transform.localScale.y * scale, transform.localScale.z);

            PowerupTimer = StartCoroutine(TimerCoroutine(5.0f, DeactivatePowerupPaddleSize));
        }
        else
        {
            StopCoroutine(PowerupTimer);
            PowerupTimer = StartCoroutine(TimerCoroutine(5.0f, DeactivatePowerupPaddleSize));
        }
    }

    public void DeactivatePowerupPaddleSize()
    {
        isPowerupPaddleSizeActive = false;
        transform.localScale = originalScale;
    }

    //timer
    private IEnumerator TimerCoroutine(float time, System.Action onTimerEnd)
    {
        yield return new WaitForSeconds(time);
        onTimerEnd();
    }

    //Powerup Paddle Speed
    public void ActivatePowerupPaddleSpeed(int multiplier)
    {
        if (isPowerupPaddleSpeedActive == false)
        {
            isPowerupPaddleSpeedActive = true;
            originalSpeed = speed;
            speed *= multiplier;

            PowerupTimer = StartCoroutine(TimerCoroutine(5.0f, DeactivatePowerupPaddleSpeed));
        }
        else
        {
            StopCoroutine(PowerupTimer);
            PowerupTimer = StartCoroutine(TimerCoroutine(5.0f, DeactivatePowerupPaddleSpeed));
        }
    }

    public void DeactivatePowerupPaddleSpeed()
    {
        isPowerupPaddleSpeedActive = false;
        speed = originalSpeed;
    }
}
