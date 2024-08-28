using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMouseLook : MonoBehaviour
{
    public Transform playerBody;
    public float mouseSensitivity = 100f;
    float xRotation = 0f;

    [Header("Interacting with objects")]
    public LayerMask whatIsCraftable;

	private GameObject previousHitObject = null;

	public AudioSource interactAduio;

	// Start is called before the first frame update
	void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //Mouse look logic
		float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
		float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

		xRotation -= mouseY;
		xRotation = Mathf.Clamp(xRotation, -90f, 90f);

		transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
		playerBody.Rotate(Vector3.up * mouseX);


		//Player interaction with craftable objects

		if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out RaycastHit hitInfo, 5, whatIsCraftable))
		{
			if (Input.GetKeyDown(KeyCode.E))
			{
				if(hitInfo.transform.TryGetComponent<ItemObject>(out ItemObject item)) 
				{

					interactAduio.Play();
					item.PickupItem();
				}
			}

			//Add outline to looked at object
			if (!hitInfo.transform.gameObject.TryGetComponent<Outline>(out var outline))
			{
				outline = hitInfo.transform.gameObject.AddComponent<Outline>();
			}
			outline.enabled = true;


			if (previousHitObject != null && previousHitObject != hitInfo.transform.gameObject)
			{
				var previousOutline = previousHitObject.GetComponent<Outline>();
				if (previousOutline != null)
				{
					previousOutline.enabled = false;
				}
			}

			previousHitObject = hitInfo.transform.gameObject;
		}
		else
		{
			if (previousHitObject != null)
			{
				var previousOutline = previousHitObject.GetComponent<Outline>();
				if (previousOutline != null)
				{
					previousOutline.enabled = false;
				}
				previousHitObject = null;
			}
		}



	}
}
