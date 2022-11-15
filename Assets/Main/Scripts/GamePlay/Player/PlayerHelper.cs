using UnityEngine;
using System;
using System.Collections.Generic;

public static class PlayerHelper
{ 
    const int playerStackItemCapacity = 100;
    static int MoneyAmount = 3 + DataHandler.UILevel * 2;
    static int stackItemAmount; 

 

    public static void UpdateStackItemAmount(int amount)
    {
        stackItemAmount += amount;
      
    }
    public static void UpdateMoneyAmount(int amount)
    {
        
        DataHandler.Money += amount * MoneyAmount;
        
    }

    public static int GetStackItemAmount()
    {
        return stackItemAmount;
    }
    public static int GetPlayerStackItemCapacity()
    {
        return playerStackItemCapacity;
    }

    public static bool CanPickStackItem()
    {
        if (stackItemAmount >= playerStackItemCapacity) return false;
        else return true;
    }
    public static void ResetStackItemAmount()
    {
        stackItemAmount = 0;
    }
}
   

