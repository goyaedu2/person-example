using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DetailPanelController : MonoBehaviour
{
    [SerializeField] TMP_Text addressText;
    [SerializeField] TMP_Text nameText;
    [SerializeField] TMP_Text registText;
    [SerializeField] TMP_Text numberText;
    [SerializeField] TMP_Text businessText;
    [SerializeField] TMP_Text phoneText;

    private void Awake()
    {
        addressText.text = "";
        nameText.text = "";
        registText.text = "";
        numberText.text = "";
        businessText.text = "";
        phoneText.text = "";
    }

    public void SetData(Office office)
    {
        addressText.text = office.도로명주소;
        nameText.text = office.사무소명;
        registText.text = office.신고구분;
        numberText.text = office.연번.ToString();
        businessText.text = office.영업구분;
        phoneText.text = office.전화번호;
    }

    public void OnClickCloseButton()
    {
        Destroy(gameObject);
    }
}
