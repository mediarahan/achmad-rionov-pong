using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupPaddleSizeController : MonoBehaviour
{
    public PowerupManager manager;
    public Collider2D ball;
    public float scale;
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
            ball.GetComponent<BallController>().ActivatePUPaddleSize(scale);
            manager.RemovePowerUp(gameObject);
        }
    }

}
