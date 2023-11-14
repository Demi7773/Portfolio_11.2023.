using UnityEngine;

[CreateAssetMenu(fileName = "Armor", menuName = "Items/Armors")]
public class ItemArmor : ItemBase
{
    [SerializeField] private float itemHPMod;
    [SerializeField] private float itemDmgReducMod;
    [SerializeField] private float itemSpeedMod;

    public float ItemHPMod => itemHPMod;
    public float ItemDmgReducMod => itemDmgReducMod;
    public float ItemSpeedMod => itemSpeedMod;
}
