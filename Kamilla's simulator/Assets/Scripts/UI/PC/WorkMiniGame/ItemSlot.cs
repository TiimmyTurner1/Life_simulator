using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    [SerializeField] private WorkMiniGame _workMiniGame;
    [SerializeField] private WorkMiniGame.ItemsColor _color;

    public void OnDrop(PointerEventData eventData)
    {
        WorkMiniGame.ItemsColor currentColor = eventData.pointerDrag.GetComponent<DragDrop>().Color;
        
        if (eventData.pointerDrag != null && currentColor == _color)
        {
            _workMiniGame.PayMoney();
            Destroy(eventData.pointerDrag);
        }
        else if (eventData.pointerDrag != null && currentColor != _color)
        {
            _workMiniGame.TakeMoney();
            Destroy(eventData.pointerDrag);
        }
    }
}
