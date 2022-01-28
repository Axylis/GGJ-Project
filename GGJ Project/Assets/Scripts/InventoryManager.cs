using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager inventoryInstance;
    [SerializeField] List<Image> inventoryUI;
    public InteractBehaviour itemList;
    public List<InteractBehaviour.item> inventorySlot;

    void Start(){
        DontDestroyOnLoad(this);

        if(inventoryInstance == null){
            inventoryInstance = this;
        }else{
            Destroy(this.gameObject);
        }
    }

    public bool addItem(int id){
        if(inventorySlot.Count < inventoryUI.Count){
            inventorySlot.Add(itemList.allItems[id]);
            itemList.obtained[id] = true;
            Debug.Log("Added " + itemList.allItems[id].getName() + " to inventory slot " + (inventorySlot.Count - 1).ToString());
            inventoryUI[inventorySlot.Count - 1].sprite = itemList.allItems[id].getImage();
            return true;
        }else{
            return false;
        }
    }
}