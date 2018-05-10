using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

public class FlattenCombo : ComboBox
{
    private Brush BorderBrush = new SolidBrush(Color.Black);
    private Brush ArrowBrush = new SolidBrush(Color.Black);
    private Brush DropButtonBrush = new SolidBrush(Color.Black);

    private Color _borderColor = Color.Black;
    private ButtonBorderStyle _borderStyle = ButtonBorderStyle.Solid;
    private static int WM_PAINT = 0x000F;

    private Color _ButtonColor = SystemColors.Control;

    public Color ButtonColor
    {
        get { return _ButtonColor; }
        set
        {
            _ButtonColor = value;
            DropButtonBrush = new SolidBrush(this.ButtonColor);
            this.Invalidate();
        }
    }

    protected override void WndProc(ref Message m)
    {
        base.WndProc(ref m);

        switch (m.Msg)
        {
            case 0xf:
                BackColor = Color.Black;
                Graphics g = this.CreateGraphics();
                Pen p = new Pen(Color.Black);
                g.FillRectangle(BorderBrush, this.ClientRectangle);

                //Draw the background of the dropdown button
                //Rectangle rect = new Rectangle(this.Width - 17, 0, 17, this.Height);
                //g.FillRectangle(DropButtonBrush, rect);

                //Create the path for the arrow
                System.Drawing.Drawing2D.GraphicsPath pth = new System.Drawing.Drawing2D.GraphicsPath();
                PointF TopLeft = new PointF(this.Width - 13, (this.Height - 5) / 2);
                PointF TopRight = new PointF(this.Width - 6, (this.Height - 5) / 2);
                PointF Bottom = new PointF(this.Width - 9, (this.Height + 2) / 2);
                pth.AddLine(TopLeft, TopRight);
                pth.AddLine(TopRight, Bottom);

                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

                //Determine the arrow's color.
                if (this.DroppedDown)
                {
                    ArrowBrush = new SolidBrush(Color.Black);

                    //Rectangle dropDownBounds = new Rectangle(0, 0, Width, Height + DropDownHeight);
                    //ControlPaint.DrawBorder(g, dropDownBounds, _borderColor, _borderStyle);
                    //ControlPaint.DrawBorder(g, dropDownBounds, _borderColor, 1, ButtonBorderStyle.Dotted, Color.GreenYellow, 1, ButtonBorderStyle.Solid, Color.Gold, 1, ButtonBorderStyle.Dashed, Color.HotPink, 1, ButtonBorderStyle.Solid);

                }
                else
                {
                    ArrowBrush = new SolidBrush(Color.Black);

                    Rectangle dropDownBounds = new Rectangle(0, 0, Width, Height);
                    g.FillRectangle(new SolidBrush(Color.Black), dropDownBounds);
                    //ControlPaint.DrawBorder(g, dropDownBounds, _borderColor, _borderStyle);
                    //ControlPaint.DrawBorder(g, dropDownBounds, _borderColor, 1, ButtonBorderStyle.Dotted, Color.GreenYellow, 1, ButtonBorderStyle.Solid, Color.Gold, 1, ButtonBorderStyle.Dashed, Color.HotPink, 1, ButtonBorderStyle.Solid);

                }

                //Draw the arrow
                g.FillPath(ArrowBrush, pth);

                break;
            default:
                break;
        }
    }



    [Category("Appearance")]
    public Color BorderColor
    {
        get { return _borderColor; }
        set
        {
            _borderColor = value;
            Invalidate(); // causes control to be redrawn
        }
    }

    [Category("Appearance")]
    public ButtonBorderStyle BorderStyle
    {
        get { return _borderStyle; }
        set
        {
            _borderStyle = value;
            Invalidate();
        }
    }

    protected override void OnLostFocus(System.EventArgs e)
    {
        base.OnLostFocus(e);
        this.Invalidate();
    }

    protected override void OnGotFocus(System.EventArgs e)
    {
        base.OnGotFocus(e);
        this.Invalidate();
    }
    protected override void OnResize(EventArgs e)
    {
        base.OnResize(e);
        this.Invalidate();
    }

    private void InitializeComponent()
    {
            this.SuspendLayout();
            // 
            // FlattenCombo
            // 
            this.DropDownClosed += new System.EventHandler(this.FlattenCombo_DropDownClosed);
            this.ResumeLayout(false);

    }

    private void FlattenCombo_DropDownClosed(object sender, EventArgs e)
    {
        var x = SelectedText;
    }
}