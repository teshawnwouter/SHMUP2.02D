using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public PowerUps upgrade;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player.FindObjectOfType<Player>().powerUp.Add(upgrade);
        upgrade.Aply(collision.gameObject);
        Destroy(this.gameObject);
    }

}
