using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System;
using UnityEngine;
using Unity.VisualScripting;
using UnityEngine.EventSystems;

public class Hexoutline : MonoBehaviour
{
    private static float Sqrt3 = Mathf.Sqrt(3);
    public Tuple<bool, int> ExitShow = new Tuple<bool, int>(false, 0);
    // Start is called before the first frame update
    private static int[,] PlayerAction =
    {
        {1,1 },
        {0,-1 },
        {1,0 },
        {-1,0 },
        {0,1 },
        {-1,-1 }
    };
    void Start()
    {
        Outline outline = GetComponent<Outline>();
        outline.enabled = ExitShow.Item1;
        outline.color = ExitShow.Item2;
    }

    // Update is called once per frame
    void Update()
    {
        int X = GetComponent<Position>().X;
        int Y = GetComponent<Position>().Y;
        //���ʷ����ı�
        if (Global.CellIfSelected(X, Y) && !ExitShow.Item1)
        {
            ExitShow = new Tuple<bool, int>(true, 1);
            Outline outline = GetComponent<Outline>();
            outline.enabled = ExitShow.Item1;
            outline.color = ExitShow.Item2;
        }

        if (!Global.CellIfSelected(X, Y) && ExitShow.Item1)
        {
            ExitShow = new Tuple<bool, int>(false, 0);
            Outline outline = GetComponent<Outline>();
            outline.enabled = ExitShow.Item1;
            outline.color = ExitShow.Item2;
        }
    }
    //����ƶ�����ͼ���Ϸ����ʸı�
    void OnMouseOver()
    {
        Outline outline = GetComponent<Outline>();
        outline.enabled = true;
        outline.color = 0;
        if (Global.IfCellSelected == 4 && 
            Global.CellIfSelected(GetComponent<Position>().X, GetComponent<Position>().Y))
        {
            int X = GetComponent<Position>().X;
            int Y = GetComponent<Position>().Y;
            for (int i = 0; i < 6; i++)
            {
                int dX = X + PlayerAction[i, 0];
                int dY = Y + PlayerAction[i, 1];
                if (dX < 0) continue;
                if (dY < 0) continue;
                if (dX >= Global.size_x) continue;
                if (dY >= Global.size_y) continue;
                if (Global.GetMapLandform(dX, dY) == 4) continue;
                Show(dX, dY);
            }
        }
    }
    //����뿪��ͼ���Ϸ����ʸı�
    void OnMouseExit()
    {
        Outline outline = GetComponent<Outline>();
        outline.enabled = ExitShow.Item1;
        outline.color = ExitShow.Item2;
        if (Global.IfCellSelected == 4)
        {
            int X = GetComponent<Position>().X;
            int Y = GetComponent<Position>().Y;
            for (int i = 0; i < 6; i++)
            {
                int dX = X + PlayerAction[i, 0];
                int dY = Y + PlayerAction[i, 1];
                if (dX < 0) continue;
                if (dY < 0) continue;
                if (dX >= Global.size_x) continue;
                if (dY >= Global.size_y) continue;
                Hide(dX, dY);
            }
        }
    }
    //AOEר������뿪��ͼ���Ϸ����ʸı����β
    public void Hide6()
    {
        int X = GetComponent<Position>().X;
        int Y = GetComponent<Position>().Y;
        for (int i = 0; i < 6; i++)
        {
            int dX = X + PlayerAction[i, 0];
            int dY = Y + PlayerAction[i, 1];
            if (dX < 0) continue;
            if (dY < 0) continue;
            if (dX >= Global.size_x) continue;
            if (dY >= Global.size_y) continue;
            Hide(dX, dY);
        }
    }
    //AOEר������ƶ�����ͼ���Ϸ����ʸı�
    void Show(int X, int Y)
    {
        Vector3 position = new Vector3(X * Sqrt3 * 10f - Y * 5f * Sqrt3, 501f, Y * 15f);
        Ray ray = new Ray(position, -Vector3.up);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo))
        {
            Debug.Log(hitInfo.collider.gameObject);
            Outline outline = hitInfo.collider.gameObject.GetComponent<Outline>();
            outline.enabled = true;
            outline.color = 0;
        }
    }
    //AOEר������뿪��ͼ���Ϸ����ʸı�
    void Hide(int X, int Y)
    {
        Vector3 position = new Vector3(X * Sqrt3 * 10f - Y * 5f * Sqrt3, 501f, Y * 15f);
        Ray ray = new Ray(position, -Vector3.up);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo))
        {
            Tuple<bool, int>  Show = hitInfo.collider.gameObject.GetComponent<Hexoutline>().ExitShow;
            Outline outline = hitInfo.collider.gameObject.GetComponent<Outline>();
            outline.enabled = Show.Item1;
            outline.color = Show.Item2;
        }
    }
}
