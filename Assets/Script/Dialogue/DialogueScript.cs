using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

public abstract class DialogueScript
{
    //큰 틀
    protected List<string> ListDialogue = new List<string>();

    int page;

    /// <summary>
    /// 쓸대사들을 페이지별로 넣어둠 index => 페이지
    /// 대사를 넣을때 stringbuilder로 스트링을 조합하고 완성된 스트링을 리스트에 넣을 것
    /// </summary>
    public abstract void printDialogue();

    /// <summary>
    /// 페이지를 자동으로 넘겨주는 함수
    /// </summary>
    /// <param name="_second">넘기는 데 걸리는 시간</param>
    /// <param name="_Text">대사를 보여줄 텍스트</param>
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
        ////최대 인덱스보다 작을경우에만 넘겨
        //if(page < this.ListDialogue.Count)
        //{
        //    page++;
        //    _Text.text = this.ListDialogue[page];
        //}
       
        //Debug.Log("DD2");
    }

}
