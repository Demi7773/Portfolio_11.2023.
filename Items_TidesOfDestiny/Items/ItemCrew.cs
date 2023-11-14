using UnityEngine;

[CreateAssetMenu(fileName = "Crew", menuName = "Items/Crews")]
public class ItemCrew : ItemBase
{
    [SerializeField] private float itemReloadSpeedMod;
    [SerializeField] private float itemTurnRateMod;
    [SerializeField] private float itemSpeedMod;
    [SerializeField] private float itemHPMod;

    public float ItemReloadSpeedMod => itemReloadSpeedMod;
    public float ItemTurnRateMod => itemTurnRateMod;
    public float ItemSpeedMod => itemSpeedMod;
    public float ItemHPMod => itemHPMod;
}
