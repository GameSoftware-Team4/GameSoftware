using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Define
{
    public enum WorldObject //������Ʈ���� �Ӽ��� �����ϱ� ���� ������ ����
    { 
        Unknown,
        Player,
        Monster
    }

    public Define.WorldObject returnType(WorldObject type)
    {
        return type;
    }

}
