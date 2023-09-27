using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class DialogueScript_Start : DialogueScript
{
    public override void printDialogue()
    {

        StringBuilder sb = new StringBuilder();
        sb.Append("당신은 낯선 장소에서 눈을 뜹니다, 당신의 종족은 [");
        sb.Append(UnitStat.instance.racial);
        sb.Append("] 이며 가장 강한 스탯은 [");
        sb.Append(UnitStat.instance.racial);
        sb.Append("] 입니다");
        this.ListDialogue.Add(sb.ToString());

        StringBuilder sb2 = new StringBuilder();
        sb2.Append("즐거운 여행되세요");
        this.ListDialogue.Add(sb2.ToString());

        StringBuilder sb3 = new StringBuilder();
        sb3.Append("bye bye");
        this.ListDialogue.Add(sb3.ToString());

    }

   
}
