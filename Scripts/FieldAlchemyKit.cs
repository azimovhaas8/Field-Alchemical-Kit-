using UnityEngine;
using DaggerfallWorkshop.Game.Items;
using DaggerfallWorkshop.Game.Serialization;
using DaggerfallConnect;

namespace FieldAlchemicalLab
{
    //Portbale alchemy kit
    public class FieldAlchemyKit : LabItemLogic
    {

        public const int templateIndex = 901;

        public FieldAlchemyKit() : base(ItemGroups.MetalIngredients, templateIndex)
        {
        }

        public override uint GetItemID()
        {
            return templateIndex;
        }

        public bool IsStackable()
        {
            return false;
        }

        public override int DurabilityLoss => 10;

        public override ItemData_v1 GetSaveData()
        {
            ItemData_v1 data = base.GetSaveData();
            data.className = typeof(FieldAlchemyKit).ToString();
            return data;
        }
    }
}