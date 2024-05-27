using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    public Text txtName;
    public Text txtSentence;

    Queue<string> sentences = new Queue<string>();
    public void Begin(Dialogue info) {
        sentences.Clear();
        txtName.text = info.name;
        foreach(var sentence in info.sentences)
        {
            sentences.Enqueue(sentence);
        }
        Next();
    }
    
    private void Next()
    {
        if (sentences.Count == 0) {
            End();
        }

        txtSentence.text=sentences.Dequeue(); //끝나지 않았을 때
    }

    private void End() {
        Debug.Log("End");
    }


}
