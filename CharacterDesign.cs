using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 [System.Serializable]   
public class CharacterDesign 
{
    public enum Job{Wizard, Samurai}
    public enum Kosei{optimistic,quiet,depressed}
    public enum Toshi{loli,young}
    public string Name;
    public string Description;
    public Job job;
    public Toshi toshi;
    public Kosei kosei;
    public GameObject CharacterImage;
}
