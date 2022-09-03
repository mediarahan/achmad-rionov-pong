using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSpeedupController : MonoBehaviour
{
    public PowerupManager manager;
    public Collider2D ball;
    public float magnitude;
    
    private void Update()
    {
        manager.powerUpList.Remove(gameObject);
        Object.Destroy(gameObject, 7.5f);
    }
  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == ball)
        {
            ball.GetComponent<BallController>().ActivatePowerupSpeedup(magnitude);
            manager.RemovePowerUp(gameObject);
        }
    }
}
