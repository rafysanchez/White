using System.Windows.Automation;
using TestStack.White.UIItems.Actions;

namespace TestStack.White.UIItems
{
    public class GroupBox : UIItemContainer
    {
        protected GroupBox() {}
        public GroupBox(AutomationElement automationElement, IActionListener actionListener) : base(automationElement, actionListener) {}
    }
}