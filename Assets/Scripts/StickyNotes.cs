using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyNotes : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject _stickyNotePrefab;
    public void Interact()
    {
        var stickyNoteObject = Instantiate(_stickyNotePrefab, transform.position, Quaternion.identity);
        StickyNote stickyNote = stickyNoteObject.GetComponent<StickyNote>(); 
        stickyNote.EnterEditMode();
    }

    public void AltInteract()
    {
     
    }
}