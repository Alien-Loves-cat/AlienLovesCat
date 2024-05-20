using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject hpImage; //HP 수 표시하는 이미지
    public Sprite life1Image; //hp1
    public Sprite life2Image; //hp2
    public Sprite life3Image; //hp3
    public Sprite life4Image; //hp4
    public Sprite life5Image; //hp5
    public GameObject planetImage;
    public GameObject planetText;
    public GameObject questButton;
    public GameObject questPanel;
    
    public bool questFlag=false; //퀘스트 띄움 여부
    public bool inventoryFlag=false; //인벤토리 띄움 여부
     
    void Start()
    {
        questPanel.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void QuestOpen()
    {
        if (questFlag == false)
        {
            questPanel.SetActive(true);
            questFlag = true;
        }
        else {
            questPanel.SetActive(false);
            questFlag = false;
        }

    }

}
