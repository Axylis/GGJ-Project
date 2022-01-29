using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void changeScene(int id){
        SceneManager.LoadScene(id);
    }

    public void changeScene(string name){
        SceneManager.LoadScene(name);
    }

    public void quitGame(){
        Application.Quit();
    }
}
