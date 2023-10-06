using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Text;
using UnityEditor.SceneManagement;
using DG.Tweening;


public enum Condition
{
    //전투중
    Battle,
    //대화중
    Conversation
}


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
    //자막
    [SerializeField] private GameObject objSubtitles;
    //설명
    [SerializeField] private GameObject objDialogue;
    //일차
    [SerializeField] private GameObject objDate;
    //선택창
    [SerializeField] private GameObject objSelections;


    //여행가능한 총 이벤트 
    private List<int> Dialogues_list;
    //실질적인 여행리스트
    private List<int> Journey_list;

    //버튼 선택지(content에 추가예정)
    private List<Button> selections;

    private bool stopPage = false;

    [Tooltip("넘기는 시간")] public float TimeTurn = 2.0f;

    #region TextMeshPro
    //자막바꾸기용
    TextMeshProUGUI textSub;
    //대사바꾸기용
    TextMeshProUGUI textDial;
    //일차 바꾸기용
    TextMeshProUGUI textDate;
    #endregion

    private int nowDate = 0;

    //현재 어떠한 장면인지
    private Dialogues nowDialogue;

    // Start is called before the first frame update
    void Start()
    {
        Dialogues_list = new List<int>();
        Journey_list = new List<int>();


        textSub = objSubtitles.GetComponent<TextMeshProUGUI>();
        textDial = objDialogue.GetComponent<TextMeshProUGUI>();
        textDate = objDate.GetComponent<TextMeshProUGUI>();
        
        //dialText.text = "너 태어남";

        initDialogueList();

        //여행일정을 짜기
        makeJourney();

        //현재 모험상태 설정
        nowDialogue = Dialogues.Start_Dialogue;

        PrintJourney();

        StartCoroutine(printDate());


    }

    private void Update()
    {
        dialogueChange(nowDialogue);
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
    /// 조건에 맞게 대화를 버튼을 추가하거나 수정 , 매개변수에 nowDialogue를 넣어 사용
    /// </summary>
    public void dialogueChange(Dialogues _Dialogue)
    {
        if (!stopPage)
        {
            switch (_Dialogue)
            {
                case Dialogues.Start_Dialogue:
                    //일단 페이지 멈춰
                    stopPage = true;

                    //이미지
                    MainImage.sprite = Resources.Load<Sprite>("DialogueImg/Start_Dialogue");

                    //자막
                    objSubtitles.SetActive(false);

                    //선택지
                    objSelections.SetActive(false);

                    //설명
                    DialogueScript_Start dial_start = new DialogueScript_Start();

                    dial_start.printDialogue();

                    StartCoroutine(dial_start.turnOverPage(TimeTurn, textDial));
                    StopCoroutine(dial_start.turnOverPage(TimeTurn, textDial));

                    break;
                case Dialogues.Slave_dealer:

                    break;
                case Dialogues.Excalibur:

                    break;
                case Dialogues.Boss:

                    break;
                case Dialogues.Encounter_wizard:

                    break;
                case Dialogues.Encounter_pirate:

                    break;
                case Dialogues.Deal_with_Devil:

                    break;
                case Dialogues.Village:

                    break;
                case Dialogues.Temple_antique:

                    break;
                case Dialogues.Robber:

                    break;
                case Dialogues.Vampire_curse:

                    break;
            }           
        }
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

        //Start
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

        //Boss
        Journey_list.Add(1);
    }

    public void PrintJourney()
    {
        for (int i = 0; i < Journey_list.Count; i++)
        {
            Debug.Log(i + 1 + "번째 : " + Journey_list[i]);
        }
    }

    /// <summary>
    /// 몇 초 후에 문장을 넘기는 함수
    /// </summary>
    /// <returns></returns>
    IEnumerator turnOverPage(float _second, StringBuilder _stringBuilder)
    {
        textDial.text = _stringBuilder.ToString();
        yield return new WaitForSeconds(_second);
        _stringBuilder.Clear();

    }

    /// <summary>
    /// 날짜를 표기하는 함수
    /// </summary>
    IEnumerator printDate()
    {
        //왼쪽오른쪽 끄기
        MngUI.instance.PanelLeft.SetActive(false);
        MngUI.instance.PanelRight.SetActive(false);

        //메인이미지 off
        MainImage.gameObject.SetActive(false);

        //대사 off
        objDialogue.gameObject.SetActive(false);

        //선택지 off
        objSelections.gameObject.SetActive(false);

        //위치 기억 및 위치변경
        Vector3 tmpPos = objDate.transform.position;
        objDate.transform.DOMove(new Vector3(Screen.width / 2, Screen.height / 2), 0.8f, false);

        //크기 키우고
        objDate.transform.DOScale(3.0f, 1f);

        yield return null;

        //날짜변경해주고
        nowDate++;
        textDate.text = nowDate.ToString() + "DAY";

        //져니에서 이름가져와 보여주기
        nowDialogue = (Dialogues)Journey_list[nowDate-1];

        yield return new WaitForSeconds(0.8f);
        objDate.transform.DOShakePosition(1.0f, 14.0f, 10);


        textDate.text = nowDialogue.ToString();

        yield return new WaitForSeconds(2.0f);

        //다시 날짜로바꾸고 빠르게 제자리고
        textDate.text = nowDate.ToString() + "DAY";
        yield return null;
        objDate.transform.DOScale(1.0f, 1f);
        objDate.transform.DOMove(tmpPos, 0.3f, false);

        yield return new WaitForSeconds(0.5f);

        //메인이미지 off
        MainImage.gameObject.SetActive(true);

        //대사 off
        objDialogue.gameObject.SetActive(true);

        //선택지 off
        objSelections.gameObject.SetActive(true);

        //왼쪽오른쪽 켜주기
        MngUI.instance.PanelLeft.SetActive(true);
        MngUI.instance.PanelRight.SetActive(true);


        yield return null;

    }


}
