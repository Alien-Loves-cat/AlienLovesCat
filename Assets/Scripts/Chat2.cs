using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chat2 : MonoBehaviour
{
    public Text ChatText; // 실제 채팅이 나오는 텍스트
    public Text CharacterName; // 캐릭터 이름이 나오는 텍스트


    public List<KeyCode> skipButton; // 대화를 빠르게 넘길 수 있는 키

    public string writerText = "";

    bool isButtonClicked = false;

    void Start()
    {
        StartCoroutine(TextPractice());
    }

    void Update()
    {
        foreach (var element in skipButton) // 버튼 검사
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

        for (a = 0; a < narration.Length; a++) //텍스트 타이핑 효과
        {
            writerText += narration[a]; //더 느리게 수정
            ChatText.text = writerText;
            yield return null;
        }

        
        while (true) //키를 다시 누를 때까지 무한정 대기
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
        yield return StartCoroutine(NormalChat("???", "당신은 우주의 어딘가를 떠돌고 있다."));
        yield return StartCoroutine(NormalChat("???", "아직 당신의 행성이 잘 보이지않는다. 좀 더 확대할까?"));
    }
}
