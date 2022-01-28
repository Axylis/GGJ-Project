using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class InteractableItem : MonoBehaviour
{
    
    void OnMouseDown(){
        Debug.Log(gameObject.name + " Clicked!");
        Destroy(this.gameObject);
    }
}
