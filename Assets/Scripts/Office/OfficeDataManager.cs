using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Networking;

public class OfficeDataManager : MonoBehaviour, ICellDelegate
{
    [SerializeField] private string serviceKey;
    [SerializeField] private OfficeCellController officeCellPrefab;
    [SerializeField] private MoreButtonCellController moreButtonPrefab;
    [SerializeField] private DetailPanelController detailPanelPrefab;
    [SerializeField] private CreatePanelController createPanelPrefab;
    [SerializeField] private Transform content;
    [SerializeField] private Transform canvas;

    // �ҷ��� ��� Office ����Ʈ
    private List<Office> officeList = new List<Office>();

    private void Start()
    {
        StartCoroutine(LoadData(0));
    }

    IEnumerator LoadData(int page, GameObject previousMoreButton = null)
    {
        // ���� URL ����
        string url = string.Format("{0}?page={1}&perPage={2}&serviceKey={3}",
            Constants.url, page, Constants.perPage, serviceKey);

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

                    OfficeCellController officeCellController = Instantiate(officeCellPrefab, content);
                    officeCellController.SetData(officeArray[i].�繫�Ҹ�,
                        officeArray[i].��������, officeArray[i].��ȭ��ȣ,
                        officeList.Count - 1);

                    officeCellController.cellDelegate = this;
                }

                // More Button ����
                if (previousMoreButton != null) Destroy(previousMoreButton);

                // More Button �߰�
                int currentTotalCount = officeData.perPage * (officeData.page - 1) + officeData.currentCount;

                if (currentTotalCount < officeData.totalCount)
                {
                    MoreButtonCellController moreButtonCellController = Instantiate(moreButtonPrefab, content);
                    moreButtonCellController.loadMoreData = () =>
                    {
                        StartCoroutine(LoadData(officeData.page + 1, moreButtonCellController.gameObject));
                    };
                }
            }
        }
    }

    public void OnClickCell(int index)
    {
        DetailPanelController detailPanelController = Instantiate(detailPanelPrefab, canvas);
        detailPanelController.SetData(officeList[index]);
    }

    /// <summary>
    /// + ��ư ������ �� ȣ��Ǵ� �޼���
    /// </summary>
    public void OnClickAddButton()
    {
        CreatePanelController createPanelController = Instantiate(createPanelPrefab, canvas);
    }
}
