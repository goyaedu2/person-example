using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using TMPro;

public class CreatePanelController : MonoBehaviour
{
    [SerializeField] TMP_InputField addressInputField;
    [SerializeField] TMP_InputField nameInputField;
    [SerializeField] TMP_InputField registInputField;
    [SerializeField] TMP_InputField numberInputField;
    [SerializeField] TMP_InputField businessInputField;
    [SerializeField] TMP_InputField phoneInputField;

    void Awake()
    {
        addressInputField.text = "";
        nameInputField.text = "";
        registInputField.text = "";
        numberInputField.text = "";
        businessInputField.text = "";
        phoneInputField.text = "";
    }

    /// <summary>
    /// 저장 버튼 클릭시 실행할 메서드
    /// </summary>
    public void OnClickSaveButton()
    {

    }

    /// <summary>
    /// 닫기 버튼 클릭시 실행할 메서드
    /// </summary>
    public void OnClickCloseButton()
    {
        Destroy(gameObject);
    }
}
