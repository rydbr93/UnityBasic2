using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Renpy : MonoBehaviour
{
    [SerializeField] Image img_BG;
    [SerializeField] Image[] img_Character;

    [SerializeField] TextMeshProUGUI Txt_Name; //ĳ���� �̸� : 
    [SerializeField] TextMeshProUGUI Txt_NameTitle; //ĳ���� Ÿ��Ʋ : 
    [SerializeField] TextMeshProUGUI Txt_Dialogue; //��� : 


    // Start is called before the first frame update
    void Start()
    {
        Txt_Name.text = "�̸� �׽�Ʈ";
        Txt_NameTitle = "Ÿ��Ʋ �׽�Ʈ";
        Txt_Dialogue = "��� �׽�Ʈ �Դϴ�.";
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
