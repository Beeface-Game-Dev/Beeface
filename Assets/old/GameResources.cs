using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class GameResources
{
    public static event EventHandler OnfoodAmountChanged;

    private static int foodAmuont;

    public static void AddfoodAmount(int amount)
    {
        foodAmuont += amount;
        if (OnfoodAmountChanged != null) OnfoodAmountChanged(null, EventArgs.Empty);
    }

    public static int GetfoodAmount()
    {
        return foodAmuont;
    }
}
