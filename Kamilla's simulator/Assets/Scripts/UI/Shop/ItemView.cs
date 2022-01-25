using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ItemView : MonoBehaviour
{
    [SerializeField] private TMP_Text _label;
    [SerializeField] private TMP_Text _price;
    [SerializeField] private Image _icon;
    [SerializeField] private Button _buyButton;

    private FoodItem _items;

    public event UnityAction<FoodItem, ItemView> BuyButtonClick;

    private void OnEnable()
    {
        _buyButton.onClick.AddListener(OnBuyButtonClick);
    }

    private void OnDisable()
    {
        _buyButton.onClick.RemoveListener(OnBuyButtonClick);
    }

    public void Render(FoodItem item)
    {
        _items = item;

        _label.text = item.Label;
        _price.text = item.Price.ToString();
        _icon.sprite = item.Icon;
    }

    private void OnBuyButtonClick()
    {
        BuyButtonClick?.Invoke(_items, this);
    }
}
