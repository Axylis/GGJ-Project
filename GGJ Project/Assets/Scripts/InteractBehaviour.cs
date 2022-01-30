using System.Collections.Generic;
using UnityEngine;

public class InteractBehaviour : MonoBehaviour
{
    [System.Serializable] public struct item{
        [SerializeField] string name;
        [SerializeField] Sprite inventoryImage;
        public bool hidden;

        public void setName(string _name){
            name = _name;
        }
        public string getName(){
            return name;
        }
        public void setImage(Sprite _inventoryImage){
            inventoryImage = _inventoryImage;
        }
        public Sprite getImage(){
            return inventoryImage;
        }
    };

    public List<item> allItems;
    public List<bool> hidden;
}
