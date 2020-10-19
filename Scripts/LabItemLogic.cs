using System.Collections.Generic;
using UnityEngine;
using DaggerfallConnect.Arena2;
using DaggerfallWorkshop;
using DaggerfallWorkshop.Game;
using DaggerfallWorkshop.Game.Entity;
using DaggerfallWorkshop.Game.Items;
using DaggerfallWorkshop.Game.UserInterface;
using DaggerfallWorkshop.Game.UserInterfaceWindows;

namespace FieldAlchemicalLab
{
    /// <summary>
    /// Field Alchemical Lab
    /// </summary>
    public abstract class LabItemLogic : DaggerfallUnityItem
    {
      UserInterfaceManager uiManager = DaggerfallUI.Instance.UserInterfaceManager;

        public LabItemLogic(ItemGroups itemGroup, int templateIndex) : base(itemGroup, templateIndex)
        {
            DaggerfallUnity.Instance.ItemHelper.RegisterItemUseHandler(901, UseFieldAlchemyKit); 
        }

        public abstract uint GetItemID();

        public abstract int DurabilityLoss { get; }

        ItemCollection mixItemCollection;

        public bool UseItem(ItemCollection collection)
        {
            if (GameManager.Instance.AreEnemiesNearby())
            {
                DaggerfallUI.MessageBox("Can't mix potions with enemies around.");
                return true;
            }
            return true;
        }

        public void RepairItem_OnItemPicked(int index, string itemName)
        {
            PlayerEntity playerEntity = GameManager.Instance.PlayerEntity;

            bool toolBroke = currentCondition <= DurabilityLoss;
            LowerCondition(DurabilityLoss, playerEntity, mixItemCollection); 
        }

        private static bool UseFieldAlchemyKit(DaggerfallUnityItem FieldAlchemyKit, ItemCollection collection)
        {
            DaggerfallUnity.Instance.ItemHelper.RegisterItemUseHandler(901, UseFieldAlchemyKit);

            if (FieldAlchemyKit.currentCondition > 0)
               DaggerfallUI.UIManager.PushWindow(new FieldPotionMixing(DaggerfallUI.UIManager, FieldAlchemyKit));
            return true;
        }
    }
}