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


    int id = 1;

    // Start is called before the first frame update
    void Start()
    {
        RefreshUI();
    }

    public void OnClickButton()
    {
        id++; //��ư�� ������ ���̵� ������ ���� �Ƶ��̷� �Ѿ�� ��µ�.
        RefreshUI();
    }


    void RefreshUI()
    {
        int CharacterID = SData.GetDialogueData(id).Character[0]; //��� ���̺��� 1�� ID�� ĳ���� �÷��� ������ �´�.

        Txt_Name.text = SData.GetCharacterData(CharacterID).Name; //ĳ���� ���̺���  ĳ���� ID�� �ش��ϴ� �̸��� ������ �´�.
        Txt_NameTitle.text = SData.GetCharacterData(CharacterID).Title; //ĳ���� ���̺��� ĳ���� ID�� �ش��ϴ� Ÿ��Ʋ�� ������ �´�.

        Txt_Dialogue.text = SData.GetDialogueData(id).Dialogue; //ID���� �ش��ϴ� Į�� �����Ͱ��� ������

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
