using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class InteractableItem : MonoBehaviour
{
    [SerializeField] int itemID;
    InventoryManager inventoryScript;

    void Awake(){
        inventoryScript = GameObject.Find("Inventory").GetComponent<InventoryManager>();
        if(inventoryScript.itemList.obtained[itemID]){
            Destroy(this.gameObject);
        }
    }

    void OnMouseDown(){
        if(inventoryScript.addItem(itemID)){
            Destroy(this.gameObject);
        }
    }
}
