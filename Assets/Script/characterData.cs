using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//CC �� ����
public enum State
{
    Default,
    Stun,
    Immobilized,
    Move,
    Idle
}

public enum Racial
{
    //�� �� �� �� ��

    //��ũ : �ٷ� + 2, �ǰ� + 1, ���� - 2, ���� -1
    Orc,

    //���� : ���� + 2, �ǰ� - 2
    Elf,

    //�ΰ� : �߰� ���� x 
    Human,

    //����� : �ٷ� + 1, �ǰ� + 1, ���� ��ø -2, 
    Dwarf, 

    //���� : �ٷ� +1, ��ø + 2, ���� -2, ���� -1  
    Mammon,
}

public enum AttackType_player
{   
    Melee,//����
    Range//���Ÿ�
}

public abstract class characterData : MonoBehaviour
{
    //ĳ���� �г���
    protected string Name;
    //ĳ���� ID
    protected int characterID;

    //����
    protected int Level = 1;
    //����ġ
    protected float LevelExp = 0.0f;
    //����ġ �ƽ�
    protected float MaxLevelExp;

    //�þ�
    protected float RangeOfView;

    //ü��
    protected float Hp;

    //�ִ�ü��
    protected float MaxHp;
    
    //�⺻ ���ݷ�
    protected float DmgPhysics = 20.0f;
    //�ֹ���
    protected float DmgMagic = 0.0f;
    //����
    protected float DefPhysics = 10.0f;
    //��������
    protected float DefMagic = 0.0f;
    //��Ÿ�� ������
    protected float CoolDownRatio;

    //��Ÿ�
    protected int AttackRange;
    //���ݼӵ�
    protected float AttackSpeed;
    //ġ��Ÿ��
    protected float CriticalRatio = 0.0f;
    //����
    protected float HpAbsorb = 0.0f;
    //�ִ븶��
    protected int MaxMana;

    #region state

    //�ٷ�
    protected int Strength = 2;

    //�ǰ�
    protected int Fitness = 2;

    //��ø
    protected int Nimble = 2;

    //����
    protected int Intelligence = 2;

    //����
    protected int Accuracy = 2;

    #endregion



    //���� Ÿ��
    protected AttackType_player attackType;

    //����
    protected State state;

    protected Racial racial;
    private object cas;

    //�⺻ ����
    public abstract void Attack();

    //Ŭ�� �̵�
    public abstract void Move();

    public virtual void LevelUp(int _level)
    {
        //200 300 400 250 300 ...
        MaxLevelExp = _level * 100.0f + 100.0f;
    }
    public abstract void Skill_A();
    public abstract void Skill_B();
    public abstract void Skill_C();

  

}
