using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Victory : MonoBehaviour
{
    [SerializeField] private GameObject _victoryWindow;
    [SerializeField] private GameObject _characterObject;
    private IVictory _IVictory;

    private void Start()
    {
        _IVictory = _characterObject.GetComponent<IVictory>();
    }

    public void Update()
    {
        if(_IVictory.IsDestinatedToFinalMovePoint())
        {
            ShowVictory();
        }
    }

    public void ShowVictory()
    {
        Time.timeScale = 0;
        _victoryWindow.SetActive(true);
    }
}
