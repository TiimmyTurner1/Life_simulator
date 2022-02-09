using UnityEngine;
using DG.Tweening;
using TMPro;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject _bars;
    [SerializeField] private TMP_Text _buttonText;
    [SerializeField] private PlayerMover _playerMover;
    [SerializeField] private Player _player;

    private CanvasGroup _barsCanvasGroup;
    private void Start()
    {
        _barsCanvasGroup = _bars.GetComponent<CanvasGroup>();
        _barsCanvasGroup.alpha = 0;
        
        _buttonText.DOFade(0, 2).SetLoops(-1, LoopType.Yoyo);
        
        _playerMover.MakeAgentFixed();
        _player.IsLifeValuesEnabled = false;
    }

    public void OnPlayButtonClick()
    {
        _barsCanvasGroup.alpha = 1;
        _playerMover.MakeAgentMovable();
        _player.IsLifeValuesEnabled = true;
        gameObject.SetActive(false);
    }
}
