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
        addressText.text = office.���θ��ּ�;
        nameText.text = office.�繫�Ҹ�;
        registText.text = office.�Ű���;
        numberText.text = office.����.ToString();
        businessText.text = office.��������;
        phoneText.text = office.��ȭ��ȣ;
    }

    public void OnClickCloseButton()
    {
        Destroy(gameObject);
    }
}
