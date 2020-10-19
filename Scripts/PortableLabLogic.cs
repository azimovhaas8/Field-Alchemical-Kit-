using DaggerfallConnect.Arena2;
using DaggerfallWorkshop.Game.Items;
using DaggerfallWorkshop.Game.UserInterface;
using DaggerfallWorkshop.Game.UserInterfaceWindows;

namespace FieldAlchemicalLab
{
    public class FieldPotionMixing : DaggerfallPotionMakerWindow
    {
        const int itemBrokenTextId = 29;

        DaggerfallUnityItem item;

        public FieldPotionMixing(IUserInterfaceManager uiManager, DaggerfallUnityItem item)
            : base(uiManager)
        {
            this.item = item;
        }

        protected override void MixCauldron()
        {
            base.MixCauldron();

            item.currentCondition -= 10;

            if (item.currentCondition < 1)
            {
                TextFile.Token[] tokens = DaggerfallUnity.TextProvider.GetRSCTokens(itemBrokenTextId);
                if (tokens != null && tokens.Length > 0)
                {
                    DaggerfallMessageBox messageBox = new DaggerfallMessageBox(uiManager, this);
                    messageBox.SetTextTokens(tokens, item);
                    messageBox.ClickAnywhereToClose = true;
                    messageBox.Show();
                }
                parentPanel.OnMouseMove += ParentPanel_OnMouseMove;
            }
        }

        private void ParentPanel_OnMouseMove(int x, int y)
        {
            parentPanel.OnMouseMove -= ParentPanel_OnMouseMove;
            CloseWindow();
        }
    }
}