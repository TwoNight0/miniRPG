using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootHolds : MonoBehaviour
{
    /// <summary>
    /// ���� x : 4.15 / z : 2.5
    /// ���� ���� : 0.75 / ���� : 0.7
    /// �Ѱ��� : 12 x 8 = 96���� ����
    /// </summary>

    [SerializeField] private GameObject foothold;
    private GameObject foothold_parent;
    private List<GameObject> list_foothold;

    [Header("Max")]
    public int row = 12;
    public int col = 8;

    //����
    [Header("Gap")]
    public float rowGap = 0.75f;
    public float colGap = 0.72f;

    private Vector3 firstFootholdpos;

    //����� ����Ʈ�� �־ ���� �ϰ� �ʿ�� ���׸��� �����ؼ� ���

    // Start is called before the first frame update
    void Start()
    {
        // �ػ󵵸� �ȼ��� ������Ű��
        Screen.SetResolution(1920, 1080, true);

        // �ػ󵵸� ������ ������Ű��
        


        footholdInit();
    }

    public void footholdInit()
    {
        list_foothold = new List<GameObject>();

        foothold_parent = GameObject.Find("FootHolds");

        firstFootholdpos = new Vector3(-4.15f, 0, 2.5f);

        int totalFoothold = row * col;
        for (int i = 0; i < totalFoothold; i++)
        {
            GameObject tile = Instantiate(foothold, foothold_parent.transform);
            tile.transform.position = new Vector3(firstFootholdpos.x + ((i % row) * rowGap), 0, firstFootholdpos.z - ((i / row) * colGap));
            list_foothold.Add(tile);
        }
    }

    private void printList(int _total, List<GameObject> _list)
    {
        for(int i = 0; i < _total; i++)
        {
            Debug.Log( i + " : " +_list[i].transform.position);
        }
    }

}
