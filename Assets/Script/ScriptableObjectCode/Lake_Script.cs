using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lake_Script : MonoBehaviour
{
    public GameObject player;
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            /*���ε� �� */
            player.GetComponent<Player_Script>().Damage(1);

        }
    }
}
