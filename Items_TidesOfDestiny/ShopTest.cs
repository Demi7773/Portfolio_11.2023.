using System.Collections.Generic;
using UnityEngine;

public class ShopTest : MonoBehaviour
{
    [SerializeField] private List<ItemBase> potentialItems = new();
    [SerializeField] private List<ItemBase> itemListCopy = new();
    [SerializeField] private List<ItemBase> shopContents = new();
    [SerializeField] private int numberOfItemsInShop;

    [SerializeField] private List<ItemBase> playerInventoryTemp = new();
    [SerializeField] private int playerMoneyTemp;


    private void Start()
    {
        RollItemPool(numberOfItemsInShop);
    }

    private void RollItemPool(int numberOfItems)
    {
        // Temp
        itemListCopy = potentialItems;

        for (int i = 0; i < numberOfItems; i++)
        {
            shopContents.Add(itemListCopy.GetRandomItemAndRemove());
        }
    }

    // Temp buy method, figure out inventory, money system and UI first
    public void BuyItem(int itemIndex/*, int currentMoney*/)
    {
        var itemToBuy = shopContents[itemIndex];

        if (/*currentMoney*/ playerMoneyTemp >= itemToBuy.ItemPrice)
        {
            /*currentMoney*/ playerMoneyTemp -= itemToBuy.ItemPrice;


            playerInventoryTemp.Add(itemToBuy);
        }
        else
        {
            Debug.Log("No enough moneyz...");
        }
    }

    // needs testing, sends copy/reference? of item in (index) slot of shop for getting shop data for UI
    public ItemBase ShopItemInfoByIndex(int index)
    {
        return shopContents[index];
    }
}
