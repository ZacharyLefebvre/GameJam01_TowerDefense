using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridTiling : MonoBehaviour
{
    public Transform hexPrefab;

    public int gridWidth = 30;
    public int gridHeight = 30;

    float hexWidth = 1.732f;
    float hexHeight = 2f;

    public float gap = 0.0f;

    Vector3 startPos;

    private void Awake()
    {
        AddGap();
        CalculateStartPos();
        CreateGrid();
        transform.position = new Vector3(0, -20, 0);
    }

    void AddGap()
    {
        hexWidth += hexWidth * gap;
        hexHeight += hexHeight * gap;
    }

    void CalculateStartPos()
    {
        float offset = 0;

        if (gridHeight / 2 % 2 != 0)
            offset = hexWidth / 2;

        float x = - hexWidth * (gridWidth / 2) - offset;
        float z = hexHeight * 0.75f * (gridHeight / 2);

        startPos = new Vector3(x + 0.34f, -.01f, -6.69f);
    }

    Vector3 CalculateWorldPos(Vector3 gridPos)
    {
        float offset = 0;
        if (gridPos.y % 2 != 0)
            offset = hexWidth / 2;

        float x = startPos.x + gridPos.x * hexWidth + offset;
        float y = startPos.z + gridPos.y * hexHeight * .75f;

        return new Vector3(x, y, 0);
    }

    void CreateGrid()
    {
        int hexagonNumber = 0;
        for (int y = 0; y < gridHeight; y++)
        {
            for (int x = 0; x < gridWidth; x++)
            {
                hexagonNumber++;
                Transform hex = Instantiate(hexPrefab) as Transform;
                Vector2 gridPos = new Vector2(x, y);
                hex.position = CalculateWorldPos(gridPos);
                hex.parent = this.transform;
                hex.name = "Hexagon" + hexagonNumber;
            }
        }
    }
}
