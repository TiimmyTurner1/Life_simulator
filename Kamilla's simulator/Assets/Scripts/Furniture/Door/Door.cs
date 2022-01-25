using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Door : MonoBehaviour
{
    [SerializeField] private DoorOpener _doorOpener;
    
    private Animator _animator;    
    private bool _rightDoorOpened;
    private bool _leftDoorOpened;
    
    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rightDoorOpened = false;
        _leftDoorOpened = false;
    }

    public void OpenRight()
    {
        if(_leftDoorOpened == false)
        {
            _animator.Play("OpenRight");
            _rightDoorOpened = true;
        }        
    }   

    public void OpenLeft()
    {
        if(_rightDoorOpened == false)
        {
            _animator.Play("OpenLeft");
            _leftDoorOpened = true;
        }        
    }

    public void Close()
    {
        if (_rightDoorOpened == true)
        {
            _animator.Play("CloseRight");
            _rightDoorOpened = false;
        }            
        else if (_leftDoorOpened == true)
        {
            _animator.Play("CloseLeft");
            _leftDoorOpened = false;
        }            
        else
            return;
    }
}
