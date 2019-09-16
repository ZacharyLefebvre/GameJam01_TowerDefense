using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    public int playerHealth = 100;

	void Awake ()
    {
        Instance = this;
	}

    public void DamagePlayer()
    {

    }
}
