using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class HoverRaycast : MonoBehaviour
{

    private float raycastRange = 3f;

    private string jewelTag = "JewelTag";
    private string torchTag = "TorchTag";
    private string torchStickTag = "TorchStickTag";
    private string swordTag = "SwordTag";

    private TextMeshProUGUI hoverText;
    private GameObject hoverTextObject;

    [SerializeField] private TextMeshProUGUI hideObjectiveText;

    void Start()
    {
        hoverTextObject = GameObject.Find("OnHoverText");
        hoverText = hoverTextObject.GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        string interactButton = GetInteractButton();
        string objectiveButton = GetObjectiveButton();

        string GetInteractButton()
        {
            if (Gamepad.current != null)
            {
                return "LT";
            }
            else
            {
                return "E";
            }
        }

        string GetObjectiveButton()
        {
            if (Gamepad.current != null)
            {
                return "LB";
            }
            else
            {
                return "TAB";
            }
        }

        // This is in update, because if the player disconnects or reconnects a controller in the middle of the game, it will update the displayed text
        hideObjectiveText.text = "Press \"" + objectiveButton + "\" to hide objectives";

        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, raycastRange))
        {
            if (hit.collider.CompareTag(jewelTag))
            {
                hoverTextObject.gameObject.SetActive(true);
                hoverText.text = "Press \"" + interactButton + "\" to awaken";
            }
            else if (hit.collider.CompareTag(torchTag) && (GameObject.FindGameObjectsWithTag("TorchStickTag").Length == 0))  
            {
                hoverTextObject.gameObject.SetActive(true);
                hoverText.text = "Press \"" + interactButton + "\" to light torch";
            }
            else if (hit.collider.CompareTag(torchStickTag))
            {
                hoverTextObject.gameObject.SetActive(true);
                hoverText.text = "Press \"" + interactButton + "\" to pick up torch";
            }
            else if (hit.collider.CompareTag(swordTag))
            {
                hoverTextObject.gameObject.SetActive(true);
                hoverText.text = "Press \"" + interactButton + "\" to pick up sword";
            }
            else
            {
                hoverTextObject.gameObject.SetActive(false);
            }
        }
        else
        {
            hoverTextObject.gameObject.SetActive(false);
        }
    }
}
