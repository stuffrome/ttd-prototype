using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class FinishLine : MonoBehaviour
{
    public int player;
    public GameObject endMenu;
    private const string TEXT_TAG = "EndText";

    private void OnTriggerEnter(Collider other)
    {
        TextMeshProUGUI textComponent = GetText();
        if (textComponent != null)
        {
            textComponent.text = "Player " + player + " wins!";
        }

        Time.timeScale = 0f;
        endMenu.SetActive(true);
    }

    private TextMeshProUGUI GetText()
    {
        GameObject textGO = null;
        for (int i = 0; i < endMenu.transform.childCount; i++)
        {
            Transform child = endMenu.transform.GetChild(i);
            if (child.tag == TEXT_TAG)
            {
                textGO = child.gameObject;
            }
        }
        return textGO.GetComponent<TextMeshProUGUI>();
    }
}
