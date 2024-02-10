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

        // 绑定下拉菜单的值改变事件到处理函数
        characterDropdown.onValueChanged.AddListener(OnCharacterDropdownValueChanged);
        characterAge.onValueChanged.AddListener(OnCharacterDropdownValueChanged);
    }

    public void OnCharacterDropdownValueChanged(int selectedIndex)
    {
        if (selectedIndex >= 0 && selectedIndex < characterPortraitTextures.Length&&characterAge.value==0)
        {
            // 将选中的角色立绘 Texture2D 转换为 Sprite，然后应用到 Image 组件的 Source Image
            
            Sprite portraitSprite = SpriteFromTexture(characterPortraitTextures[selectedIndex]);
            characterPortraitImage.sprite = portraitSprite;
        }
         if (selectedIndex >= 0 && selectedIndex < characterPortraitTextures.Length&&characterAge.value==1)
        {
            // 将选中的角色立绘 Texture2D 转换为 Sprite，然后应用到 Image 组件的 Source Image
            
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
        // 创建一个新的 Sprite，使用传入的 Texture2D
        return Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
    }
}
