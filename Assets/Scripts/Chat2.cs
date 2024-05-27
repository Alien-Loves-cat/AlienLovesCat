using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chat2 : MonoBehaviour
{
    public Text ChatText; // ���� ä���� ������ �ؽ�Ʈ
    public Text CharacterName; // ĳ���� �̸��� ������ �ؽ�Ʈ


    public List<KeyCode> skipButton; // ��ȭ�� ������ �ѱ� �� �ִ� Ű

    public string writerText = "";

    bool isButtonClicked = false;

    void Start()
    {
        StartCoroutine(TextPractice());
    }

    void Update()
    {
        foreach (var element in skipButton) // ��ư �˻�
        {
            if (Input.GetKeyDown(element))
            {
                isButtonClicked = true;
            }
        }
    }


    IEnumerator NormalChat(string narrator, string narration)
    {
        int a = 0;
        CharacterName.text = narrator;
        writerText = "";

        for (a = 0; a < narration.Length; a++) //�ؽ�Ʈ Ÿ���� ȿ��
        {
            writerText += narration[a]; //�� ������ ����
            ChatText.text = writerText;
            yield return null;
        }

        
        while (true) //Ű�� �ٽ� ���� ������ ������ ���
        {
            if (isButtonClicked)
            {
                isButtonClicked = false;
                break;
            }
            yield return null;
        }
    }

    IEnumerator TextPractice()
    {
        yield return StartCoroutine(NormalChat("???", "����� ������ ��򰡸� ������ �ִ�."));
        yield return StartCoroutine(NormalChat("???", "���� ����� �༺�� �� �������ʴ´�. �� �� Ȯ���ұ�?"));
    }
}
