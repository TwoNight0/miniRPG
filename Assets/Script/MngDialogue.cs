using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Text;

public enum Dialogues {

    //[����]
    //����ȭ�� 1���� ����, ����, �������� �˷���
    Start_Dialogue,
    //���� ��â�� �ݰ� ������ ��ȯ
    Boss,


    //[���� �̺�Ʈ]
    //������� ���� ��ȭ or ����
    Encounter_wizard,
    //������ ���� ��ȭ or ����
    Encounter_pirate,
    //���� �϶� �� ��ȭâ�� ���� ���� â�� ����
    Village,
    //��� ���
    Temple_antique,
    //����
    Robber,
    //�����ǰ�
    Excalibur,
    //�Ǹ����� �ŷ�
    Deal_with_Devil,
    //�뿹���� �뿹 ���� �ְ� ���Ḧ �������
    Slave_dealer,
    //�������� ����
    Vampire_curse,

}



public class MngDialogue : MonoBehaviour
{
    [SerializeField] private Image MainImage;
    //�ڸ�
    [SerializeField] private GameObject objSubtitles;
    //����
    [SerializeField] private GameObject objDialogue;
    //����
    [SerializeField] private GameObject objDate;
    //����â
    [SerializeField] private GameObject objSelections;


    //���డ���� �� �̺�Ʈ 
    private List<int> Dialogues_list;
    //�������� ���ฮ��Ʈ
    private List<int> Journey_list;

    //��ư ������(content�� �߰�����)
    private List<Button> selections;


    #region TextMeshPro
    //�ڸ��ٲٱ��
    TextMeshProUGUI textSub;
    //���ٲٱ��
    TextMeshProUGUI textDial;
    //���� �ٲٱ��
    TextMeshProUGUI textDate;
    #endregion


    //���� ��� �������
    private Dialogues nowDialogue;

    // Start is called before the first frame update
    void Start()
    {
        Dialogues_list = new List<int>();
        Journey_list = new List<int>();


        textSub = objSubtitles.GetComponent<TextMeshProUGUI>();
        textDial = objDialogue.GetComponent<TextMeshProUGUI>();
        textDate = objDialogue.GetComponent<TextMeshProUGUI>();
        
        //dialText.text = "�� �¾";

        initDialogueList();
        makeJourney();

        nowDialogue = Dialogues.Start_Dialogue;

    }

    private void Update()
    {
        dialogueChange(nowDialogue);
    }

    /// <summary>
    /// ���ǿ� ���� ������ ��ư�� ����� �������� �߰��ϴ� �Լ�
    /// </summary>
    public void createBtnbycondition()
    {
        //��ư ����


        //����Ʈ�� �߰�
    }

    /// <summary>
    /// ������ �˻��ϴ� �Լ�
    /// </summary>
    public void checkCondition()
    {

    }


    /// <summary>
    /// ���ǿ� �°� ��ȭ�� ��ư�� �߰��ϰų� ���� , �Ű������� nowDialogue�� �־� ���
    /// </summary>
    public void dialogueChange(Dialogues _Dialogue)
    {
        switch (_Dialogue)
        {
            case Dialogues.Start_Dialogue:
                //�̹���
                MainImage.sprite = Resources.Load<Sprite>("DialogueImg/Start_Dialogue");

                //�ڸ�
                objSubtitles.SetActive(false);

                //������
                objSelections.SetActive(false);

                string temp = textDial.text;

                //����
                StringBuilder sb = new StringBuilder();
                sb.Append("����� ���� ��ҿ��� ���� ��ϴ�, ����� ������");
                sb.Append(UnitStat.instance.racial);
           
                StartCoroutine(turnOverPage(3.0f, sb));


                sb.Append("���� ���� �ɷ�ġ��, ");
                StartCoroutine(turnOverPage(3.0f, sb));
                


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


    /// <summary>
    /// ��� �̺�Ʈ ���� ��� ū ����Ʈ ���⼭ ��������Ʈ�� ���߸��� journey�� ����� ������
    /// </summary>
    private void initDialogueList() {

        int Length = System.Enum.GetValues(typeof(Dialogues)).Length;
        for (int i = 0; i< Length; i++)
        {
            Dialogues_list.Add(i);
        }
    
    }

    /// <summary>
    /// �������� ���̾�α׸� ����
    /// </summary>
    public void RandomDialogue()
    {
        int Length = System.Enum.GetValues(typeof(Dialogues)).Length;
        int RandomDial = Random.Range(0, Length);
        
        nowDialogue = (Dialogues)RandomDial;
        Debug.Log(nowDialogue.ToString());
    }

    /// <summary>
    /// ����Ʈ�� ������ ������� ����
    /// </summary>
    public void makeJourney()
    {
        /*
         1���� : ������ ���� �˸���
        ~ ����
         10���� : ��������
         */

        //�����˸���
        Journey_list.Add(0);

        //ū����Ʈ�� ������ �� ���⼭ �����ϴ� ���� ������
        List<int> copylist = new List<int>(Dialogues_list);

        int RandomNum;


        //9�� ����
        for(int i = 0; i< 8; i++)
        {
            //���� �� ����(0,1�� ���� �������� �̺�Ʈ��)
            RandomNum = Random.Range(2, copylist.Count-1);

            //���� index�� ������
            Journey_list.Add(copylist[RandomNum]);

            //������ �ε����� ����(�ߺ�����)
            copylist.RemoveAt(RandomNum);
        }

        //for(int i = 0; i < Journey_list.Count; i++)
        //{
        //    Debug.Log(i + 1 + "��° : " + Journey_list[i]);
        //}

    }

    /// <summary>
    /// �� �� �Ŀ� ������ �ѱ�� �Լ�
    /// </summary>
    /// <returns></returns>
    IEnumerator turnOverPage(float _second, StringBuilder _stringBuilder)
    {
        textDial.text = _stringBuilder.ToString();
        yield return new WaitForSeconds(_second);
        _stringBuilder.Clear();

    }
}
