using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UnitStat : characterData
{
    public static UnitStat instance;

    public UnitStat()
    {
        

    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }

        InitStat();
    }

    [SerializeField] private int InitStatPoint = 5;

    public new Racial racial;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void Attack()
    {
        throw new System.NotImplementedException();
    }

    public override void Move()
    {
        throw new System.NotImplementedException();
    }

    public override void Skill_A()
    {
        throw new System.NotImplementedException();
    }

    public override void Skill_B()
    {
        throw new System.NotImplementedException();
    }

    public override void Skill_C()
    {
        throw new System.NotImplementedException();
    }

    private void InitStat()
    {
        //�ʱ� ���� �߰�
        while (InitStatPoint > 0)
        {
            int r = UnityEngine.Random.Range(0, 5);

            switch (r)
            {
                case 0:
                    Strength++;
                    InitStatPoint--;
                    break;
                case 1:
                    Fitness++;
                    InitStatPoint--;
                    break;
                case 2:
                    Nimble++;
                    InitStatPoint--;
                    break;
                case 3:
                    Intelligence++;
                    InitStatPoint--;
                    break;
                case 4:
                    Accuracy++;
                    InitStatPoint--;
                    break;
            }

        }


        //���� ����
        int len = System.Enum.GetValues(typeof(Racial)).Length;
        int IntRacial = UnityEngine.Random.Range(0, len);
        // �ٰ� �ǰ� ��ø ���� ����

        //��ũ : �ٷ� + 4, �ǰ� + 3, ��ø -1, ���� - 2 -> +4
        //���� : ���� + 4, ��ø + 1, �ǰ� - 1 -> +4
        //�ΰ� : �ǰ� ���� �� ���� +1 -> +4
        //����� : �ٷ� + 2, ���� + 1, �ǰ� + 3, ��ø -2, -> +4 
        //���� : ��ø + 4, ���� +1, ���� -1 -> +4

        //������ �ش�Ǵ� ���� ���� 
        switch (IntRacial)
        {
            case 0:
                //��ũ
                Strength += 4;
                Fitness += 3;
                Intelligence -= 2;
                Nimble -= 1;

                //����
                racial = Racial.Orc;
                break;
            case 1:
                //����
                Intelligence += 4;
                Nimble += 1;
                Fitness -=1;

                racial = Racial.Orc;
                break;
            case 2:
                //�ΰ�
                Strength += 1;
                Nimble += 1;
                Intelligence += 1;
                Accuracy += 1;

                racial = Racial.Human;
                break;
            case 3:
                //�����
                Strength += 2;
                Intelligence += 1;
                Fitness += 3;
                Nimble -= 2;

                racial = Racial.Dwarf;
                break;
            case 4:
                Nimble += 4;
                Intelligence -= 1;
                Accuracy +=1;

                racial = Racial.Mammon;
                break;
        }

        Debug.Log("���� : " + (Racial)IntRacial);

        Debug.Log("�ٷ� : " + Strength);
        Debug.Log("�ǰ� : " + Fitness);
        Debug.Log("��ø : " + Nimble);
        Debug.Log("���� : " + Intelligence);
        Debug.Log("���� : " + Accuracy);

    }
}
