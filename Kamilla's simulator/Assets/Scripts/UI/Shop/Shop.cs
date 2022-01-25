using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private List<FoodItem> _items;
    [SerializeField] private Player _player;
    [SerializeField] private ItemView _itemTemplate;
    [SerializeField] private GameObject _itemContainer;

    private void Start()
    {
        for (int i = 0; i < _items.Count; i++)
        {
            AddItem(_items[i]);
        }
    }

    private void AddItem(FoodItem item)
    {
        var view = Instantiate(_itemTemplate, _itemContainer.transform);
        view.BuyButtonClick += OnBuyButtonClick;
        view.Render(item);
    }

    private void OnBuyButtonClick(FoodItem item, ItemView view)
    {

    }
}
