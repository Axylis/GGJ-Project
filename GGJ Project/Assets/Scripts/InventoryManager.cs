using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager inventoryInstance;
    [SerializeField] List<Image> inventoryUI;
    public InteractBehaviour itemList;
    public List<InteractBehaviour.item> inventorySlot;

    [HideInInspector] public CharacterSpeech speechScript;

    void Start(){
        DontDestroyOnLoad(this);

        if(inventoryInstance == null){
            inventoryInstance = this;
        }else{
            Destroy(this.gameObject);
        }
    }

    public void updateScriptInstance(){
        if(!speechScript){
            speechScript = GameObject.FindWithTag("Player").GetComponent<CharacterSpeech>();
        }
    }

    public bool addItem(int id, int groupNum, bool hide){
        if(inventorySlot.Count < inventoryUI.Count){
            inventorySlot.Add(itemList.allItems[id]);
            itemList.hidden[id] = hide;
            // Debug.Log("Added " + itemList.allItems[id].getName() + " to inventory slot " + (inventorySlot.Count - 1).ToString());
            inventoryUI[inventorySlot.Count - 1].sprite = itemList.allItems[id].getImage();

            if(groupNum >= 0){
                updateScriptInstance();
                
                speechScript.startSpeech(groupNum);
            }
            return true;
        }else{
            return false;
        }
    }
}