using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MngUI : MonoBehaviour
{

    #region Script


    #endregion

    //test
    public GameObject inventory;
    public GameObject stat;


    #region Button
    private Button BtnSetting;
    private Button BtnInventory;
    //����
    private Button BtnStat;



    //����
    private Button BtnCrew_0;
    private Button BtnCrew_1;
    private Button BtnCrew_2;
    private Button BtnCrew_3;
    #endregion




    // Start is called before the first frame update
    void Start()
    {
        initUI();

    }

    /// <summary>
    /// initialize
    /// </summary>
    private void initUI()
    {
        //�ػ� ����
        float targetRatio = 16.0f / 9.0f;
        float ratio = (float)Screen.width / (float)Screen.height;
        float scaleHeight = ratio / targetRatio;
        float fixedWidth = (float)Screen.width / scaleHeight;
        Screen.SetResolution((int)fixedWidth, Screen.height, true);


        #region ��ư �Ҵ�

        BtnSetting = GameObject.Find("BtnSetting").GetComponent<Button>();
        BtnSetting.onClick.AddListener(() => {
            //����â
        });

        BtnInventory = GameObject.Find("BtnInventroy").GetComponent<Button>();
        BtnInventory.onClick.AddListener(() => {
            //�κ��丮

        });

        BtnStat = GameObject.Find("BtnStat").GetComponent<Button>();
        BtnStat.onClick.AddListener(() => {
            //ĳ����â ����


            //����â �Ѱ�
            stat.SetActive(!stat.activeSelf);

            //��ũ��Ʈ���� �Լ��� �����ͼ� �ؽ�Ʈ �Ҵ����ְ�

        });
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
