using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicZone : MonoBehaviour
{
    public bool playSpecialMusic = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Asegúrate de que tu jugador tenga el tag "Player"
        {
            MusicManager music = FindObjectOfType<MusicManager>();
            if (music != null)
            {
                if (playSpecialMusic)
                    music.PlaySpecial();
                else
                    music.PlayAmbient(); // Si sales de la zona, vuelve a la música original
            }
        }
    }
}

