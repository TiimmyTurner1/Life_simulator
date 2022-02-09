using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PcPanel : MonoBehaviour
{
    [SerializeField] private WorkMiniGame _workMiniGame;
    [SerializeField] private Image _buttonBackground;
    
    public void OnOffButtonClick()
    {
        GameObject workMiniGamePanel = _workMiniGame.gameObject;
        
        if (workMiniGamePanel.activeSelf == false)
        {
            workMiniGamePanel.SetActive(true);
            _buttonBackground.color = Color.green;
        }
        else
        {
            _buttonBackground.color = Color.red;
            workMiniGamePanel.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
