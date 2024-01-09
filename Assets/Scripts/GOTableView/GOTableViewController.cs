using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GOTableViewController : MonoBehaviour
{
    // Cell�� �����ϱ� ���� Cell Prefab
    [SerializeField] protected GOTableViewCell cellPrefab;
    // Cell�� �����ϰ� �� Content ��ü
    [SerializeField] protected Transform content;

    protected Queue<GOTableViewCell> reuseQueue = new Queue<GOTableViewCell>();

    // Cell�� ����
    private float cellHeight;

    // ��ü Cell�� ����
    private int totalRows;

    // �ڽ� Ŭ�������� GOTableViewController�� ǥ���ؾ� �� ��ü Data�� ���� ��ȯ�ϴ� �޼���
    protected abstract int numberOfRows();

    // �� index�� Cell�� ��ȯ�ϴ� �޼���
    protected abstract GOTableViewCell cellForRowAtIndex(int index);

    private void Start()
    {
        totalRows = this.numberOfRows();
        float screenHeight = Screen.height;
        cellHeight = cellPrefab.GetComponent<RectTransform>().sizeDelta.y;

        // ǥ���ؾ� �� Cell�� �� ���
        int maxRows = (int)(screenHeight / cellHeight) + 2;
        maxRows = (maxRows > totalRows) ? totalRows : maxRows;

        // Content ũ�� ����
        RectTransform contentTransform = content.GetComponent<RectTransform>();
        contentTransform.sizeDelta = new Vector2(contentTransform.sizeDelta.x, totalRows * cellHeight);


    }
}