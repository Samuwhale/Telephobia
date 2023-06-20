

using UnityEngine;
using System.Collections;
using StarterAssets;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;

public class CrosshairGUI : MonoBehaviour
{

	public GameObject firstperson;
	public Texture2D m_crosshairTexture;
	public Texture2D m_useTexture;
	public float RayLength = 3f;

	public bool m_DefaultReticle;
	public bool m_UseReticle;
	public bool m_ShowCursor = false;
	public KeyCode Curserswitch;

	private bool m_bIsCrosshairVisible = true;
	private Rect m_crosshairRect;
	private Ray playerAim;
	private Camera playerCam;

	public Texture2D cursorTexture;
	public bool lockcursor;
	public KeyCode Bugswitch;

	private void Start()
    {
		Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.ForceSoftware);
		//
    }

    private void OnApplicationFocus(bool focus)
    {
		//Cursor.lockState = CursorLockMode.Locked;
	}
    void Update()
	{
        if (Input.GetKeyDown(Bugswitch))
        {
			lockcursor = !lockcursor;

			//
		}
        if (lockcursor)
        {
	        Cursor.lockState = CursorLockMode.Locked; // Locks the cursor
	        Cursor.visible = true; // Hides the cursor
	        Cursor.lockState = CursorLockMode.None;

	        Vector2 warpPosition = Screen.safeArea.center;  // Set the position to the center of the screen
	        Mouse.current.WarpCursorPosition(warpPosition); // Warps the cursor position to the center
	        InputState.Change(Mouse.current.position, warpPosition); // Changes the current mouse position to the center
        }
		
		playerCam = Camera.main;

		Ray playerAim = playerCam.GetComponent<Camera>().ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
		RaycastHit hit;

		if (Physics.Raycast(playerAim, out hit, RayLength))
		{
			if (hit.collider.gameObject.tag == "Interact")
			{
				m_DefaultReticle = false;
				m_UseReticle = true;
			}
			if (hit.collider.gameObject.tag == "InteractItem")
			{
				m_DefaultReticle = false;
				m_UseReticle = true;
			}
			if (hit.collider.gameObject.tag == "Door")
			{
				m_DefaultReticle = false;
				m_UseReticle = true;
			}
			// if interactable object:
			if (hit.collider.GetComponent<IInteractable>() != null || hit.collider.GetComponentInParent<IInteractable>() != null)
			{
				m_DefaultReticle = false;
				m_UseReticle = true;
			} 
		}
		else
		{
			m_DefaultReticle = true;
			m_UseReticle = false;
		}
		/*
	if(!m_ShowCursor){
		Cursor.visible = (false);
		Cursor.lockState = CursorLockMode.Locked;			
	}else{
		Cursor.visible = (true);
		Cursor.lockState = CursorLockMode.None;						
	}
	*/
		if (Input.GetKeyDown(Curserswitch))
		{
			m_ShowCursor = !m_ShowCursor;
		}

		if (m_ShowCursor)
		{
			//firstperson.GetComponent<FirstPersonController>().enabled = false;
			//Cursor.visible = (true);
			//Cursor.lockState = CursorLockMode.None;
			//m_DefaultReticle = false;
			//m_UseReticle = false;
		}
		else
		{
			//firstperson.GetComponent<FirstPersonController>().enabled = true;
			
			
			//Cursor.visible = (false);
			//Cursor.lockState = CursorLockMode.Locked;
		}
		
	}

	void Awake()
	{
		if (m_DefaultReticle)
		{
			m_crosshairRect = new Rect((Screen.width - m_crosshairTexture.width) / 2,
								  (Screen.height - m_crosshairTexture.height) / 2,
								  m_crosshairTexture.width,
								  m_crosshairTexture.height);
		}

		if (m_UseReticle)
		{
			m_crosshairRect = new Rect((Screen.width - m_useTexture.width) / 2,
								  (Screen.height - m_useTexture.height) / 2,
								  m_useTexture.width,
								  m_useTexture.height);
		}
	}

	void OnGUI()
	{
		if (m_bIsCrosshairVisible)
			if (m_DefaultReticle)
			{
				//GUI.DrawTexture(m_crosshairRect, m_crosshairTexture);
			}
		if (m_UseReticle)
		{
			//GUI.DrawTexture(m_crosshairRect, m_useTexture);
		}
	}
}