using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class DialogueScript_Start : DialogueScript
{
    public override void printDialogue()
    {

        StringBuilder sb = new StringBuilder();
        sb.Append("����� ���� ��ҿ��� ���� ��ϴ�, ����� ������ [");
        sb.Append(UnitStat.instance.racial);
        sb.Append("] �̸� ���� ���� ������ [");
        sb.Append(UnitStat.instance.racial);
        sb.Append("] �Դϴ�");
        this.ListDialogue.Add(sb.ToString());

        StringBuilder sb2 = new StringBuilder();
        sb2.Append("��ſ� ����Ǽ���");
        this.ListDialogue.Add(sb2.ToString());

        StringBuilder sb3 = new StringBuilder();
        sb3.Append("bye bye");
        this.ListDialogue.Add(sb3.ToString());

    }

   
}
