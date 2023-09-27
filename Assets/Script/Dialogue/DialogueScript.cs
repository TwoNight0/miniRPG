using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

public abstract class DialogueScript
{
    //ū Ʋ
    protected List<string> ListDialogue = new List<string>();

    int page;

    /// <summary>
    /// �������� ���������� �־�� index => ������
    /// ��縦 ������ stringbuilder�� ��Ʈ���� �����ϰ� �ϼ��� ��Ʈ���� ����Ʈ�� ���� ��
    /// </summary>
    public abstract void printDialogue();

    /// <summary>
    /// �������� �ڵ����� �Ѱ��ִ� �Լ�
    /// </summary>
    /// <param name="_second">�ѱ�� �� �ɸ��� �ð�</param>
    /// <param name="_Text">��縦 ������ �ؽ�Ʈ</param>
    /// <returns></returns>
    public IEnumerator turnOverPage(float _second, TextMeshProUGUI _Text)
    {
        //_Text.text = this.ListDialogue[page];
        //yield return new WaitForSeconds(0.1f);
        ////Debug.Log("DD");
        //yield return new WaitForSeconds(_second);
        //page++;
        while (page < this.ListDialogue.Count)
        {
            _Text.text = this.ListDialogue[page];
            yield return new WaitForSeconds(_second);
            page++;
        }
        ////�ִ� �ε������� ������쿡�� �Ѱ�
        //if(page < this.ListDialogue.Count)
        //{
        //    page++;
        //    _Text.text = this.ListDialogue[page];
        //}
       
        //Debug.Log("DD2");
    }

}
