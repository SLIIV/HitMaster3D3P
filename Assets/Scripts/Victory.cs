using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Victory : MonoBehaviour
{
    [SerializeField] private GameObject _victoryWindow;

    public void ShowVictory()
    {
        Time.timeScale = 0;
        _victoryWindow.SetActive(true);
    }
}
