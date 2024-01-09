using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GOTableViewController : MonoBehaviour
{
    // Cell을 생성하기 위한 Cell Prefab
    [SerializeField] protected GOTableViewCell cellPrefab;
    // Cell을 생성하게 될 Content 객체
    [SerializeField] protected Transform content;

    protected Queue<GOTableViewCell> reuseQueue = new Queue<GOTableViewCell>();

    // Cell의 높이
    private float cellHeight;

    // 전체 Cell의 개수
    private int totalRows;

    // 자식 클래스에서 GOTableViewController가 표시해야 할 전체 Data의 수를 반환하는 메서드
    protected abstract int numberOfRows();

    // 각 index의 Cell을 반환하는 메서드
    protected abstract GOTableViewCell cellForRowAtIndex(int index);

    private void Start()
    {
        totalRows = this.numberOfRows();
        float screenHeight = Screen.height;
        cellHeight = cellPrefab.GetComponent<RectTransform>().sizeDelta.y;

        // 표시해야 할 Cell의 수 계산
        int maxRows = (int)(screenHeight / cellHeight) + 2;
        maxRows = (maxRows > totalRows) ? totalRows : maxRows;

        // Content 크기 조정
        RectTransform contentTransform = content.GetComponent<RectTransform>();
        contentTransform.sizeDelta = new Vector2(contentTransform.sizeDelta.x, totalRows * cellHeight);


    }
}