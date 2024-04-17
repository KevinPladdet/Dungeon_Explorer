using UnityEngine;
using UnityEngine.InputSystem;

public class RaycastShoot : MonoBehaviour
{

    [SerializeField] private Camera playerCamera;
    private float range = 3.5f;

    private void Update()
    {
        Vector3 start = playerCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
    }

    public void OnShoot(InputAction.CallbackContext context)
    {
        Ray ray = new Ray
        {
            origin = playerCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0)),
            direction = playerCamera.transform.forward
        };

        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, range))
        {
            //IInteractable interactable = hitInfo.collider.GetComponent<IInteractable>();
            //if(interactable != null)
            //{
            //    interactable.Interact();
            //}

            if (hitInfo.collider.CompareTag("TorchTag"))
            {
                ILightable lightable = hitInfo.collider.GetComponent<ILightable>();
                if (lightable != null)
                {
                    lightable.LightTorch();
                }
            }
            else if (hitInfo.collider.CompareTag("JewelTag"))
            {
                IOpenable openable = hitInfo.collider.GetComponent<IOpenable>();
                if (openable != null)
                {
                    openable.OpenDoor();
                }
            }
            else if (hitInfo.collider.CompareTag("TorchStickTag"))
            {
                IPickupable pickupable = hitInfo.collider.GetComponent<IPickupable>();
                if (pickupable != null) 
                {
                    pickupable.PickUpTorchStick();
                }
            }
            else if (hitInfo.collider.CompareTag("SwordTag"))
            {
                IPickupSword pickupsword = hitInfo.collider.GetComponent<IPickupSword>();
                if (pickupsword != null)
                {
                    pickupsword.PickUpSwordObject();
                }
            }
        }
    }
}
