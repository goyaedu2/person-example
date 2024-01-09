using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class OfficeTableViewController : GOTableViewController
{
    [SerializeField] private string serviceKey;

    private List<Office> officeList = new List<Office>();

    protected void Start()
    {
        StartCoroutine(LoadData());
    }

    protected override int numberOfRows()
    {
        return officeList.Count;
    }

    protected override GOTableViewCell cellForRowAtIndex(int index)
    {
        // Cell 객체 만들고 반환
        OfficeTableViewCell cell = dequeueReuseableCell() as OfficeTableViewCell;

        if (cell == null) 
        {
            cell = Instantiate(cellPrefab, content) as OfficeTableViewCell;
        }

        cell.Index = index;
        cell.officeName.text = officeList[index].사무소명;
        cell.businessType.text = officeList[index].영업구분;
        cell.phoneNumber.text = officeList[index].전화번호;
            
        return cell;
    }

    IEnumerator LoadData()
    {
        string url = string.Format("{0}?page={1}&perPage={2}&serviceKey={3}",
            Constants.url, 0, 100, serviceKey);

        UnityWebRequest request = new UnityWebRequest();
        using (request = UnityWebRequest.Get(url))
        {
            yield return request.SendWebRequest();

            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(request.error);
            }
            else
            {
                string result = request.downloadHandler.text;

                OfficeData officeData = JsonUtility.FromJson<OfficeData>(result);
                Office[] officeArray = officeData.data;

                for (int i = 0; i < officeArray.Length; i++)
                {
                    officeList.Add(officeArray[i]);
                }
            }

            base.Start();
        }
    }
}
