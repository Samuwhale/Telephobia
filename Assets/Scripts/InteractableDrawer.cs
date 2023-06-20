using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableDrawer : MonoBehaviour, IInteractable
{
    private Vector3 _defaultPosition;
    [SerializeField] private float _openSpeed = 1f;
    [SerializeField] private float _openOffset = 1f;
    private bool _isOpen = false;
    
    
    private void Start()
    {
        _defaultPosition = transform.position;
    }

    // // Debug method to open/close drawers using space
    // private void Update()
    // {
    //     if (Input.GetKeyDown(KeyCode.Space))
    //     {
    //         Interact();
    //     }
    // }

    public void Interact()
    {
        ToggleDrawer(!_isOpen);
    }

    public void AltInteract()
    {
        Debug.LogError("Drawer has no AltInteract method implemented");
    }

    void ToggleDrawer(bool open)
    {
        Vector3 targetPosition = open ? _defaultPosition + Vector3.forward * _openOffset : _defaultPosition;
        _isOpen = open;

        StopAllCoroutines();
        StartCoroutine(ToggleDrawerRoutine(targetPosition));
        
    }

    IEnumerator ToggleDrawerRoutine(Vector3 targetPosition)
    {
        while (transform.position != targetPosition)
        {
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * _openSpeed);
            yield return new WaitForEndOfFrame();
        }
    }
    
    
}
