using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorManager : MonoBehaviour
{
    public int destinationID;
    private void OnMouseDown()
    {
        SceneManager.LoadScene(destinationID);
    }
    
}
