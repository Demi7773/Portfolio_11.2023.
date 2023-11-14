using UnityEngine;

[CreateAssetMenu(fileName = "Helm", menuName = "Items/Helms")]
public class ItemHelm : ItemBase
{
    [SerializeField] private float itemSpeedMod;
    [SerializeField] private float itemTurnRateMod;
    [SerializeField] private float itemStoppingMod;

    public float ItemSpeedMod => itemSpeedMod;
    public float ItemTurnRateMod => itemTurnRateMod;
    public float ItemStoppingMod => itemStoppingMod;
}
