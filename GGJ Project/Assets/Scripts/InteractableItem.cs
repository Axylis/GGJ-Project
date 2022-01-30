using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class InteractableItem : MonoBehaviour
{
    [SerializeField] int itemID;
    [SerializeField] int speechGroupNum = -1;
    [SerializeField] bool hideAfterInteract;
    InventoryManager inventoryScript;

    void Awake(){
        inventoryScript = GameObject.Find("Inventory").GetComponent<InventoryManager>();
        if(inventoryScript.itemList.hidden[itemID]){
            Destroy(this.gameObject);
        }
    }

    void OnMouseDown(){
        inventoryScript.updateScriptInstance();
        if(!inventoryScript.speechScript.isSpeaking){
            if(inventoryScript.addItem(itemID, speechGroupNum, hideAfterInteract) && hideAfterInteract){
                Destroy(this.gameObject);
            }
        }
    }
}
