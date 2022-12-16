using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseScreen : MonoBehaviour
{

    public void ShowPauseScreen() {
        gameObject.SetActive(true);
    }

    public void HidePauseScreen() {
        gameObject.SetActive(false);
    }
}
