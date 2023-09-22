using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum Dialogues {

    //[고정]
    //시작화면 1일차 종족, 성별, 강점등을 알려줌
    Start_Dialogue,
    //보스 이창을 닫고 보스를 소환
    Boss,


    //[가변 이벤트]
    //마법사와 조우 대화 or 전투
    Encounter_wizard,
    //해적과 조우 대화 or 전투
    Encounter_pirate,
    //마을 일때 이 대화창을 끄고 마을 창을 열것
    Village,
    //고대 사원
    Temple_antique,
    //강도
    Robber,
    //전설의검
    Excalibur,
    //악마와의 거래
    Deal_with_Devil,
    //노예상인 노예 돈을 주고 동료를 살수있음
    Slave_dealer,
    //흡혈귀의 저주
    Vampire_curse,
}



public class MngDialogue : MonoBehaviour
{
    [SerializeField] private Image MainImage;
    [SerializeField] private GameObject Subtitles;

    private List<int> Dialogues_list;
    private List<int> Journey_list;
    private List<Button> selections;

    //현재 어떠한 장면인지
    private Dialogues nowDialogue;

    // Start is called before the first frame update
    void Start()
    {
        Dialogues_list = new List<int>();
        Journey_list = new List<int>();
        initDialogueList();
        makeJourney();
    }

    /// <summary>
    /// 조건에 따라 선택지 버튼을 만들고 선택지에 추가하는 함수
    /// </summary>
    public void createBtnbycondition()
    {
        //버튼 생성


        //리스트에 추가
    }

    /// <summary>
    /// 조건을 검사하는 함수
    /// </summary>
    public void checkCondition()
    {

    }

    /// <summary>
    /// 모든 이벤트 들이 담긴 큰 리스트 여기서 작은리스트로 간추린걸 journey로 만들어 쓸예정
    /// </summary>
    private void initDialogueList() {

        int Length = System.Enum.GetValues(typeof(Dialogues)).Length;
        for (int i = 0; i< Length; i++)
        {
            Dialogues_list.Add(i);
        }
    
    }

    /// <summary>
    /// 랜덤으로 다이얼로그를 정함
    /// </summary>
    public void RandomDialogue()
    {
        int Length = System.Enum.GetValues(typeof(Dialogues)).Length;
        int RandomDial = Random.Range(0, Length);
        
        nowDialogue = (Dialogues)RandomDial;
        Debug.Log(nowDialogue.ToString());
    }

    /// <summary>
    /// 리스트에 여행을 어떤순으로 될지
    /// </summary>
    public void makeJourney()
    {
        /*
         1일차 : 무조건 생성 알리미
        ~ 랜덤
         10일차 : 보스전투
         */

        //생성알리미
        Journey_list.Add(0);

        //큰리스트를 복사한 후 여기서 실행하는 동안 뺄거임
        List<int> copylist = new List<int>(Dialogues_list);

        int RandomNum;


        //9번 실행
        for(int i = 0; i< 8; i++)
        {
            //랜덤 수 생성(0,1은 제외 고정적인 이벤트임)
            RandomNum = Random.Range(2, copylist.Count-1);

            //랜덤 index를 가져옴
            Journey_list.Add(copylist[RandomNum]);

            //가져온 인덱스를 삭제(중복방지)
            copylist.RemoveAt(RandomNum);
        }

        for(int i = 0; i < Journey_list.Count; i++)
        {
            Debug.Log(i + 1 + "번째 : " + Journey_list[i]);
        }

    }


}
