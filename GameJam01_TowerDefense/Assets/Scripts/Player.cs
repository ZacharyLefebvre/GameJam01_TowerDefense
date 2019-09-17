using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int playerHealth = 100;

	void Awake ()
    {

	}

    public void DamagePlayer(int damageTaken)
    {
        playerHealth -= damageTaken;

        if (playerHealth <= 0)
        {
            // créer un event?
        }
    }
}
