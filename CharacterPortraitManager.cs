using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class CharacterPortraitManager : MonoBehaviour
{
    public Dropdown characterDropdown;
    public Dropdown characterAge;
    public Image characterPortraitImage;

    public Texture2D[] characterPortraitTextures;

    private void Start()
    {
        characterDropdown.ClearOptions();
        characterDropdown.AddOptions(GetCharacterNames());

        // �������˵���ֵ�ı��¼���������
        characterDropdown.onValueChanged.AddListener(OnCharacterDropdownValueChanged);
        characterAge.onValueChanged.AddListener(OnCharacterDropdownValueChanged);
    }

    public void OnCharacterDropdownValueChanged(int selectedIndex)
    {
        if (selectedIndex >= 0 && selectedIndex < characterPortraitTextures.Length&&characterAge.value==0)
        {
            // ��ѡ�еĽ�ɫ���� Texture2D ת��Ϊ Sprite��Ȼ��Ӧ�õ� Image ����� Source Image
            
            Sprite portraitSprite = SpriteFromTexture(characterPortraitTextures[selectedIndex]);
            characterPortraitImage.sprite = portraitSprite;
        }
         if (selectedIndex >= 0 && selectedIndex < characterPortraitTextures.Length&&characterAge.value==1)
        {
            // ��ѡ�еĽ�ɫ���� Texture2D ת��Ϊ Sprite��Ȼ��Ӧ�õ� Image ����� Source Image
            
            Sprite portraitSprite = SpriteFromTexture(characterPortraitTextures[selectedIndex+3]);
            characterPortraitImage.sprite = portraitSprite;
        }
    }

    private List<Dropdown.OptionData> GetCharacterNames()
    {
        List<Dropdown.OptionData> characterNames = new List<Dropdown.OptionData>();
        for (int i = 0; i < characterPortraitTextures.Length; i++)
        { 
            if(i==0){characterNames.Add(new Dropdown.OptionData("quiet"));}
            if(i==1){characterNames.Add(new Dropdown.OptionData("optimistic"));} 
            if(i==2){characterNames.Add(new Dropdown.OptionData("depressed" ));}
            
        }
        return characterNames;
    }

    private Sprite SpriteFromTexture(Texture2D texture)
    {
        // ����һ���µ� Sprite��ʹ�ô���� Texture2D
        return Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
    }
}
