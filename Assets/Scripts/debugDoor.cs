using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateOnZ : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            gameObject.SetActive(false);
        }
    }
}
