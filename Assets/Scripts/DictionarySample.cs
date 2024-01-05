using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DictionarySample : MonoBehaviour
{
    [SerializeField] Transform content;
    [SerializeField] GameObject cellPrefab;

    // Start is called before the first frame update
    void Start()
    {
        Dictionary<string, string> person1 = new Dictionary<string, string>();
        person1["Name"] = "ȫ�浿";
        person1["Phone"] = "010-1234-5678";
        person1["Address"] = "��⵵ �Ⱦ�� ���ȱ�";

        Dictionary<string, string> person2 = new Dictionary<string, string>();
        person2["Name"] = "��浿";
        person2["Phone"] = "010-1234-0001";
        person2["Address"] = "��⵵ ��õ�� ��õ��";

        Dictionary<string, string> person3 = new Dictionary<string, string>();
        person3["Name"] = "�ֱ浿";
        person3["Phone"] = "010-1234-0002";
        person3["Address"] = "��⵵ ������ �д籸";

        Dictionary<string, string> person4 = new Dictionary<string, string>();
        person4["Name"] = "ȫ�浿";
        person4["Phone"] = "010-1234-5678";
        person4["Address"] = "��⵵ �Ⱦ�� ���ȱ�";

        Dictionary<string, string> person5 = new Dictionary<string, string>();
        person5["Name"] = "��浿";
        person5["Phone"] = "010-1234-0001";
        person5["Address"] = "��⵵ ��õ�� ��õ��";

        Dictionary<string, string> person6 = new Dictionary<string, string>();
        person6["Name"] = "�ֱ浿";
        person6["Phone"] = "010-1234-0002";
        person6["Address"] = "��⵵ ������ �д籸";

        List<Dictionary<string, string>> addressBook = new List<Dictionary<string, string>>();
        addressBook.Add(person1);
        addressBook.Add(person2);
        addressBook.Add(person3);
        addressBook.Add(person4);
        addressBook.Add(person5);
        addressBook.Add(person6);

        // Cell �����
        GameObject cellObject1 = Instantiate(cellPrefab, content);
        CellController cellController1 = cellObject1.GetComponent<CellController>();
        cellController1.SetData(person1);

        GameObject cellObject2 = Instantiate(cellPrefab, content);
        CellController cellController2 = cellObject2.GetComponent<CellController>();
        cellController2.SetData(person2);

        GameObject cellObject3 = Instantiate(cellPrefab, content);
        CellController cellController3 = cellObject3.GetComponent<CellController>();
        cellController3.SetData(person3);

        GameObject cellObject4 = Instantiate(cellPrefab, content);
        CellController cellController4 = cellObject4.GetComponent<CellController>();
        cellController4.SetData(person4);

        GameObject cellObject5 = Instantiate(cellPrefab, content);
        CellController cellController5 = cellObject5.GetComponent<CellController>();
        cellController5.SetData(person5);

        GameObject cellObject6 = Instantiate(cellPrefab, content);
        CellController cellController6 = cellObject6.GetComponent<CellController>();
        cellController6.SetData(person6);
    }
}
