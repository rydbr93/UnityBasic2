using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Renpy : MonoBehaviour
{
    [SerializeField] Image img_BG;
    [SerializeField] Image[] img_Character;

    [SerializeField] TextMeshProUGUI Txt_Name; //캐릭터 이름 : 
    [SerializeField] TextMeshProUGUI Txt_NameTitle; //캐릭터 타이틀 : 
    [SerializeField] TextMeshProUGUI Txt_Dialogue; //대사 : 


    // Start is called before the first frame update
    void Start()
    {
        Txt_Name.text = "이름 테스트";
        Txt_NameTitle = "타이틀 테스트";
        Txt_Dialogue = "대사 테스트 입니다.";
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
