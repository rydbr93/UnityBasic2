using UnityEngine;

public class SData : SingletonBehabiour<SData>
{
    [SerializeField] Test testDatas; // DataTableÀÇ µ¥ÀÌÅÍ ÅÇ Name
    public static TestData[] TestData { get { return Instance.testDatas.dataArray; } } // µ¥ÀÌÅÍ ÅÇ Name + Data
    public static TestData GetTestData(int _id)
    {
        for (int i = 0; i < TestData.Length; i++)
            if (TestData[i].ID_I == _id)
                return TestData[i];
        return null;
    }

    [SerializeField] Dialogue dialogueDatas; // DataTableÀÇ µ¥ÀÌÅÍ ÅÇ Name
    public static DialogueData[] DialogueData { get { return Instance.dialogueDatas.dataArray; } } // µ¥ÀÌÅÍ ÅÇ Name + Data
    public static DialogueData GetDialogueData(int _id)
    {
        for (int i = 0; i < DialogueData.Length; i++)
        {
            if (DialogueData[i].ID == _id)
            {
                return DialogueData[i];
            }
        }
        return null;
    }

    [SerializeField] Character characterDatas; // DataTableÀÇ µ¥ÀÌÅÍ ÅÇ Name
    public static CharacterData[] CharacterData { get { return Instance.characterDatas.dataArray; } } // µ¥ÀÌÅÍ ÅÇ Name + Data
    public static CharacterData GetCharacterData(int _id)
    {
        for (int i = 0; i < CharacterData.Length; i++) //¹Ýº¹¹®À¸·Î ¿¢¼¿ ½ÃÆ®¸¦ È®ÀÎÇÏ¸é¼­ Æ¯Á¤ Á¶°ÇÀÇ _id¸¦ Ã£À¸¸é °ª ¹ÝÈ¯
        {
            if (CharacterData[i].ID == _id)
            {
                return CharacterData[i];
            }
        }
        return null;
    }

}
