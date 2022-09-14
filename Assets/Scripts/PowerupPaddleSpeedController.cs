using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupPaddleSpeedController : MonoBehaviour
{
    public PowerupManager manager;
    public Collider2D ball;
    public int multiplier;
    public int destroy;

    private void Start()
    {
        StartCoroutine(DestroyCountdown());
    }

    private IEnumerator DestroyCountdown()
    {
        while (true)
        {
            yield return new WaitForSeconds(destroy);
            manager.powerUpList.Remove(gameObject);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == ball)
        {
            ball.GetComponent<BallController>().ActivatePUPaddleSpeed(multiplier);
            manager.RemovePowerUp(gameObject);
        }
    }

}
