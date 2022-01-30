using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSpeech : MonoBehaviour
{
    [SerializeField] Transform speechBuble;
    [SerializeField] Text speechText;
    [SerializeField] List<StringListWrapper> allDialogue;

    [HideInInspector] public bool isSpeaking;
    int activeGroup, currentLine;

    [System.Serializable]
    public class ListWrapper<T>
    {
        public List<T> InnerList;
        public T this[int key]{
            get{
                return InnerList[key];
            }
            set{
                InnerList[key] = value;
            }
        }

        // Read-only property describing how many elements are in the List.
        public int Count {
            get {
                return InnerList.Count;
            }
        }
    };

    [System.Serializable]
    public class StringListWrapper : ListWrapper<string> { }

    public void startSpeech(int groupNum){
        isSpeaking = true;
        activeGroup = groupNum;
        currentLine = -1;
        nextLine();
    }

    public void nextLine(){
        if(allDialogue[activeGroup].Count > ++currentLine){
            speechText.text = allDialogue[activeGroup][currentLine];
        }else{
            isSpeaking = false;
        }
    }

    void Update(){
        speechBuble.gameObject.SetActive(isSpeaking);
        if(transform.position.x > 0){
            speechText.transform.rotation = Quaternion.Euler(0, 180, 0);
            speechBuble.rotation = Quaternion.Euler(0, 180, 0);
        }else{
            speechText.transform.rotation = Quaternion.Euler(0, 0, 0);
            speechBuble.rotation = Quaternion.Euler(0, 0, 0);
        }

        if(isSpeaking){
            if(Input.GetMouseButtonDown(0)){
                nextLine();
            }
        }
    }
}