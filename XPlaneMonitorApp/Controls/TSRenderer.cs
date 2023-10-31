namespace XPlaneMonitorApp.Controls
{
    public class TSRenderer : ToolStripSystemRenderer
    {

        private static readonly Color BACK_COLOR = Color.FromArgb(64, 64, 64);
        private static readonly Color FORE_COLOR = Color.White;

        public TSRenderer() : base() { }

        public static void SetToolStrip(ToolStrip c)
        {
            c.BackColor = BACK_COLOR;
            c.GripStyle = ToolStripGripStyle.Hidden;
            c.RenderMode = ToolStripRenderMode.Professional;

            c.Renderer = new TSRenderer();

            foreach (ToolStripItem item in c.Items)
            {
                item.ForeColor = FORE_COLOR;
            }
        }

        public static void SetStatusStrip(StatusStrip c)
        {
            c.BackColor = BACK_COLOR;

            c.Renderer = new TSRenderer();

            foreach (ToolStripItem item in c.Items)
            {
                if (item.ForeColor == SystemColors.ControlText)
                {
                    item.ForeColor = FORE_COLOR;
                }
            }
        }

        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
        {
            if (e.ToolStrip.GetType() == typeof(ToolStrip))
            {
                // skip render border
            }
            else
            {
                // do render border
                base.OnRenderToolStripBorder(e);
            }
        }

        protected override void OnRenderButtonBackground(ToolStripItemRenderEventArgs e)
        {
            bool itemChecked = e.Item is ToolStripButton button && button.Checked;
            bool itemSelected = e.Item.Selected || e.Item.Pressed;

            if (itemSelected || itemChecked)
            {
                Rectangle rectangle = new(0, 0, e.Item.Size.Width - 1, e.Item.Size.Height - 1);
                e.Graphics.FillRectangle(new SolidBrush(itemChecked ? Color.IndianRed : Color.FromArgb(22, 65, 124)), rectangle);
                if (itemSelected) e.Graphics.DrawRectangle(new Pen(Color.FromArgb(100, 100, 100)), rectangle);
                return;
            }

            base.OnRenderButtonBackground(e);
        }

        protected override void OnRenderDropDownButtonBackground(ToolStripItemRenderEventArgs e)
        {
            OnRenderButtonBackground(e);
        }

    }
}
