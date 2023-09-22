using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
    [SerializeField] private GameObject Subtitles;

    private List<int> Dialogues_list;
    private List<int> Journey_list;
    private List<Button> selections;

    //���� ��� �������
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

        for(int i = 0; i < Journey_list.Count; i++)
        {
            Debug.Log(i + 1 + "��° : " + Journey_list[i]);
        }

    }


}
