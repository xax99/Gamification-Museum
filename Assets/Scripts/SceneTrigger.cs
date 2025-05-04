using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine;
using TMPro;
using System.Collections;

public class SceneTrigger : MonoBehaviour
{
    public string sceneName;
    public float displayTime = 3f;

    private bool isShowing = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (HudManager.Instance.currentSceneName != sceneName)
            {
                HudManager.Instance.currentSceneName = sceneName;
                if (!isShowing)
                    StartCoroutine(ShowSceneName());
            }
        }
    }

    private IEnumerator ShowSceneName()
    {
        isShowing = true;
        var text = HudManager.Instance.sceneNameLabel;
        if (text != null)
        {
            text.text = sceneName;
            text.enabled = true;
            yield return new WaitForSeconds(displayTime);
            text.enabled = false;
        }
        isShowing = false;
    }
}
