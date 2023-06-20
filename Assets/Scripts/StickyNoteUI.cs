using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class StickyNoteUI : MonoBehaviour
{
    [SerializeField] private StickyNote _stickyNote;
    [SerializeField] private TMP_InputField _inputField;
    
    
    
    public void Hide()
    {
        _stickyNote.SetText(_inputField.text);
        _inputField.gameObject.SetActive(false);
        _stickyNote.PlaceNoteWhereLooking();
    }

    public void Show()
    {
        _inputField.gameObject.SetActive(true);
        _inputField.text = _stickyNote.GetTextFromMesh();
    }

    public void SetFieldActive()
    {
        _inputField.ActivateInputField();
    }
}
