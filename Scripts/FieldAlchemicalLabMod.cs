using DaggerfallWorkshop;
using DaggerfallWorkshop.Game;
using DaggerfallWorkshop.Game.Items;
using DaggerfallWorkshop.Game.Utility.ModSupport;
using UnityEngine;
using System.Collections.Generic;
using DaggerfallWorkshop.Game.Utility.ModSupport.ModSettings;
using DaggerfallWorkshop.Game.Entity;
using DaggerfallWorkshop.Game.Formulas;
using DaggerfallWorkshop.Game.UserInterface;
using DaggerfallWorkshop.Game.UserInterfaceWindows;

namespace FieldAlchemicalLab
{
    public class FieldAlchemicalLabMod : MonoBehaviour
    {
        static Mod mod;

        [Invoke(StateManager.StateTypes.Start, 0)]
        public static void Init(InitParams initParams)
        {
            mod = initParams.Mod;
            var go = new GameObject(mod.Title);
            go.AddComponent<FieldAlchemicalLabMod>();
        }

        void Awake()
        {
            InitMod();
            mod.IsReady = true;
        }

        public static void InitMod()
        {
            Debug.Log("Begin mod init: FieldAlchemicalLabMod");

            ItemHelper itemHelper = DaggerfallUnity.Instance.ItemHelper;

            itemHelper.RegisterCustomItem(FieldAlchemyKit.templateIndex, ItemGroups.MetalIngredients, typeof(FieldAlchemyKit));
        }
    }
}
