using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//����ഢ�����������ͼ������ص��ز���sprite����ϵͳԤ������Ч��
[CreateAssetMenu(fileName = "Inventory/Element", menuName = "ElementInventory")]//���½������ѡ�������unity�Ҽ��˵�
public class ElementInventory : ScriptableObject
{
    [Tooltip("")]
    public Material red, green,blue, yellow;
}