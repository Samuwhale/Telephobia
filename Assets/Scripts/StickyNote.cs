using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StickyNote : MonoBehaviour, IInteractable
{
    [SerializeField] private TextMeshPro _textMesh;
    [SerializeField] private StickyNoteUI _stickyNoteUI;
    [SerializeField] private GameObject _stickyNoteVisual;

    public void SetText(string text)
    {
        _textMesh.text = text;
    }


    public string GetTextFromMesh()
    {
        return _textMesh.text;
    }

    public void Interact()
    {
        EnterEditMode();
    }

    public void EnterEditMode()
    {
        _stickyNoteUI.Show();
        _stickyNoteUI.SetFieldActive();
        Hide();
    }

    public void PlaceNoteWhereLooking()
    {
        Show();
        Ray playerAim = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;


        if (Physics.Raycast(playerAim, out hit, Mathf.Infinity))
        {
            Vector3 targetPos = hit.point;

            Quaternion targetRot = Quaternion.LookRotation(hit.normal, Camera.main.transform.up);
            targetRot = targetRot * Quaternion.Euler(0, 180, 0);

            transform.SetPositionAndRotation(targetPos, targetRot);
        }
        
    }

    public void Show()
    {
        _stickyNoteVisual.SetActive(true);
    }

    public void Hide()
    {
        _stickyNoteVisual.SetActive(false);
    }

    public void AltInteract()
    {
        // Implement alternative interaction behavior if needed
    }
}