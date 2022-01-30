using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class InteractableItem : MonoBehaviour
{
    [SerializeField] int itemID;
    [SerializeField] int speechGroupNum = -1;
    [SerializeField] bool takeAfterInteract;
    [SerializeField] bool autoMove = true;
    [SerializeField] float interactRange = 0.2f;
    [SerializeField] Transform interactLocation;
    InventoryManager inventoryScript;
    MainCharacterMovement movementScript;
    bool interacting = false;

    void Awake(){
        inventoryScript = GameObject.Find("Inventory").GetComponent<InventoryManager>();
        if(inventoryScript.itemList.hidden[itemID]){
            Destroy(this.gameObject);
        }
        movementScript = GameObject.Find("Player").GetComponent<MainCharacterMovement>();
    }

    void OnMouseDown(){
        if(!movementScript.autoMove){
            interacting = true;
            movementScript.autoMove = autoMove;
            movementScript.targetLocation = interactLocation;
        }
    }

    void Update(){
        if(interacting){
            if(!autoMove || Mathf.Abs(movementScript.transform.position.x - interactLocation.position.x) < interactRange){
                movementScript.autoMove = false;
                interacting = false;
                inventoryScript.updateScriptInstance();
                if(!inventoryScript.speechScript.isSpeaking){
                    if(inventoryScript.addItem(itemID, speechGroupNum, takeAfterInteract) && takeAfterInteract){
                        Destroy(this.gameObject);
                    }
                }
            }
        }
    }
}
