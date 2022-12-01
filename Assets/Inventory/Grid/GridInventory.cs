using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//����ഢ�����������ͼ������ص��ز���sprite����ϵͳԤ������Ч��
[CreateAssetMenu(fileName = "Inventory/Grid", menuName = "GridInventory")]//���½������ѡ�������unity�Ҽ��˵�
public class GridInventory : ScriptableObject
{
    [System.Serializable]
    public struct Cell
    {
        public Mesh mesh;
        public Material material;
    };
    [Tooltip("�����ǲ�ͬ���ε�mesh�ļ���ǰ�������ֺ����Ǹ߶Ⱦ���ֵ,���С�_���ı�ʾ�߶��Ǹ���")]
    public Cell mountain3, hill2, hill1, ground0, pit_1, basin_2, valley_3, hole;
}