using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Define_jhj
{
    public enum WorldObject_jhj //������Ʈ���� �Ӽ��� �����ϱ� ���� ������ ����
    { 
        Unknown,
        Player,
        Monster
    }

    public Define_jhj.WorldObject_jhj returnType(WorldObject_jhj type)
    {
        return type;
    }

}
