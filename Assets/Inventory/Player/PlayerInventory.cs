using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//����ഢ�����������ͼ������ص��ز���sprite����ϵͳԤ������Ч��
[CreateAssetMenu(fileName = "Inventory/Player", menuName = "PlayerInventory")]//���½������ѡ�������unity�Ҽ��˵�
public class PlayerInventory : ScriptableObject
{
    [Tooltip("")]
    public GameObject player1, player2, player3;
}