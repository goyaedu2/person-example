using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public delegate void LoadMoreData();

public class MoreButtonCellController : MonoBehaviour
{
    public Button button;
    public LoadMoreData loadMoreData;

    private void Start()
    {
        button = GetComponentInChildren<Button>();
    }

    public void OnClickMoreButton()
    {
        button.interactable = false;
        if (loadMoreData != null) loadMoreData.Invoke();
    }
}
