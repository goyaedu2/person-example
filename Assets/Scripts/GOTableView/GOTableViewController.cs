using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GOTableViewController : MonoBehaviour
{
    // Cell을 생성하기 위한 Cell Prefab
    [SerializeField] protected GOTableViewCell cellPrefab;
    // Cell을 생성하게 될 Content 객체
    [SerializeField] protected Transform content;

    // Cell 재사용을 위한 Queue
    protected Queue<GOTableViewCell> reuseQueue = new Queue<GOTableViewCell>();

    // Cell간의 연결 고리를 관리하기 위한 List
    protected LinkedList<GOTableViewCell> cellLinkedList = new LinkedList<GOTableViewCell>();

    // Cell의 높이
    private float cellHeight;

    // 전체 Cell의 개수
    private int totalRows;

    // 자식 클래스에서 GOTableViewController가 표시해야 할 전체 Data의 수를 반환하는 메서드
    protected abstract int numberOfRows();

    // 각 index의 Cell을 반환하는 메서드
    protected abstract GOTableViewCell cellForRowAtIndex(int index);

    protected virtual void Start()
    {
        totalRows = this.numberOfRows();
        float screenHeight = Screen.height;
        cellHeight = cellPrefab.GetComponent<RectTransform>().sizeDelta.y;

        // 표시해야 할 Cell의 수 계산
        int maxRows = (int)(screenHeight / cellHeight) + 2;
        maxRows = (maxRows > totalRows) ? totalRows : maxRows;

        // Content 크기 조정
        RectTransform contentTransform = content.GetComponent<RectTransform>();
        contentTransform.sizeDelta = new Vector2(0, totalRows * cellHeight);

        // 초기 Cell을 생성
        for (int i=0; i<maxRows; i++)
        {
            GOTableViewCell cell = cellForRowAtIndex(i);
            cell.gameObject.transform.localPosition = new Vector3(0, -i * cellHeight, 0);
            cellLinkedList.AddLast(cell);
        }
    }

    /// <summary>
    /// 재사용이 가능한 Cell을 반환해주는 메서드
    /// </summary>
    /// <returns>재사용 Cell 혹은 null</returns>
    protected GOTableViewCell dequeueReuseableCell()
    {
        if (reuseQueue.Count > 0)
        {
            GOTableViewCell cell = reuseQueue.Dequeue();
            cell.gameObject.SetActive(true);
            return cell;
        }
        else
        {
            return null;
        }
    }

    public void OnValueChanged(Vector2 vector)
    {
        Debug.Log($"Screen.height: {Screen.height}, content.localPosition.y: {content.localPosition.y}");

        if ((cellLinkedList.Last.Value.Index < totalRows - 1) &&
            (content.localPosition.y + Screen.height > cellLinkedList.Last.Value.Index * cellHeight + cellHeight))
        {
            // 하단에 새로운 Cell이 만들어지는 상황

            // 처음에 있던 Cell은 Reuse Queue 저장
            LinkedListNode<GOTableViewCell> firstCellNode = cellLinkedList.First;
            cellLinkedList.RemoveFirst();
            firstCellNode.Value.gameObject.SetActive(false);
            reuseQueue.Enqueue(firstCellNode.Value);

            // 하단에 새로운 Cell 생성
            LinkedListNode<GOTableViewCell> lastCellNode = cellLinkedList.Last;
            int currentIndex = lastCellNode.Value.Index;
            GOTableViewCell cell = cellForRowAtIndex(currentIndex + 1);
            cell.gameObject.transform.localPosition = new Vector3(0, -(currentIndex + 1) * cellHeight, 0);
            cellLinkedList.AddAfter(lastCellNode, cell);
            cell.gameObject.transform.SetAsLastSibling();

        }
        else if ((cellLinkedList.First.Value.Index > 0) &&
            (content.localPosition.y < cellLinkedList.First.Value.Index * cellHeight))
        {
            // 상단에 새로운 Cell이 만들어지는 상황

            // 마지막에 있던 Cell은 Reuse Queue 저장
            LinkedListNode<GOTableViewCell> lastCellNode = cellLinkedList.Last;
            cellLinkedList.RemoveLast();
            lastCellNode.Value.gameObject.SetActive(false);
            reuseQueue.Enqueue(lastCellNode.Value);

            // 상단에 새로운 Cell 생성
            LinkedListNode<GOTableViewCell> firstCellNode = cellLinkedList.First;
            int currentIndex = firstCellNode.Value.Index;
            GOTableViewCell cell = cellForRowAtIndex(currentIndex - 1);
            cell.gameObject.transform.localPosition = new Vector3(0, -(currentIndex - 1) * cellHeight, 0);
            cellLinkedList.AddBefore(firstCellNode, cell);
            cell.gameObject.transform.SetAsFirstSibling();
        }
    }
}