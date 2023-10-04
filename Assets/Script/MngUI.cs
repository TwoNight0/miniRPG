using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class MngUI : MonoBehaviour
{

    #region Script


    #endregion

    //test
    [SerializeField] private GameObject Panel_Inventory;
    [SerializeField] private GameObject PanelStat;
    [SerializeField] private GameObject PanelChactor;

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

    #region Text
    private TextMeshProUGUI UnitData_Racial;
    private TextMeshProUGUI UnitData_Strength;
    private TextMeshProUGUI UnitData_Fitness;
    private TextMeshProUGUI UnitData_Nimble;
    private TextMeshProUGUI UnitData_Intelligence;
    private TextMeshProUGUI UnitData_Accuracy;

    #endregion


   

    private void Awake()
    {
        initUI();
    }

    // Start is called before the first frame update
    void Start()
    {
        PanelStat.SetActive(false);

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
            PanelChactor.SetActive(!PanelChactor.activeSelf);

            //����â �Ѱ�
            PanelStat.SetActive(!PanelStat.activeSelf);

            //��ũ��Ʈ���� �Լ��� �����ͼ� �ؽ�Ʈ �Ҵ����ְ�


        });
        #endregion

        //�����־ ��ã��..?
        #region Text �Ҵ�
        UnitData_Racial = GameObject.Find("UnitData_Racial").GetComponent<TextMeshProUGUI>();
        UnitData_Strength = GameObject.Find("UnitData_Strength").GetComponent<TextMeshProUGUI>();
        UnitData_Fitness = GameObject.Find("UnitData_Fitness").GetComponent<TextMeshProUGUI>();
        UnitData_Nimble = GameObject.Find("UnitData_Nimble").GetComponent<TextMeshProUGUI>();
        UnitData_Intelligence = GameObject.Find("UnitData_Intelligence").GetComponent<TextMeshProUGUI>();
        UnitData_Accuracy = GameObject.Find("UnitData_Accuracy").GetComponent<TextMeshProUGUI>();

        Debug.Log(UnitData_Racial);
        #endregion

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //stat indicate
    public void StatIndicate()
    {
        UnitData_Racial.text = UnitStat.instance.m_racial.ToString();


    }

}
