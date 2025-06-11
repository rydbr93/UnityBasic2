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


    int id = 1;

    // Start is called before the first frame update
    void Start()
    {
        RefreshUI();
    }

    public void OnClickButton()
    {
        id++; //버튼이 눌리면 아이디가 눌리고 다음 아디이로 넘어가서 출력됨.
        RefreshUI();
    }


    void RefreshUI()
    {
        int CharacterID = SData.GetDialogueData(id).Character[0]; //대사 테이블의 1번 ID의 캐릭터 컬럼을 가지고 온다.

        Txt_Name.text = SData.GetCharacterData(CharacterID).Name; //캐릭터 테이블에서  캐릭터 ID에 해당하는 이름을 가지고 온다.
        Txt_NameTitle.text = SData.GetCharacterData(CharacterID).Title; //캐릭터 테이블에서 캐릭터 ID에 해당하는 타이틀을 가지고 온다.

        Txt_Dialogue.text = SData.GetDialogueData(id).Dialogue; //ID값에 해당하는 칼럼 데이터값을 가져옴

        img_BG.sprite = Resources.Load<Sprite>("Img/Renpy/" + SData.GetDialogueData(id).Bgimage);

        for (int i = 0; i < img_Character.Length; i++)
        {
            img_Character[i].gameObject.SetActive(false);
        }


        for (int i = 1; i <= img_Character.Length; i++)
        {
            for (int j = 0; j < SData.GetDialogueData(id).Character.Length; j++)
            {
                if(j == SData.GetDialogueData(id).Position[i]) //0
                {
                    img_Character[j].sprite = Resources.Load<Sprite>("Img/Renpy/" + SData.GetCharacterData(SData.GetDialogueData(id).Character[i]).Image);
                    img_Character[j].gameObject.SetActive(true);
                }
            }

        }
    }
}
