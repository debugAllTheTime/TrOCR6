﻿using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using static TrOCR.External.NativeMethods;

namespace TrOCR;

public class FloatLayerBase : Form
{
    [DefaultValue(BorderStyle.Fixed3D)]
    [Description("获取或设置边框类型。")]
    public BorderStyle BorderType
    {
        get => _borderType;
        set
        {
            if (_borderType != value)
            {
                _borderType = value;
                Invalidate( );
            }
        }
    }

    [DefaultValue(Border3DStyle.RaisedInner)]
    [Description("获取或设置三维边框样式。")]
    public Border3DStyle Border3DStyle
    {
        get => _border3DStyle;
        set
        {
            if (_border3DStyle != value)
            {
                _border3DStyle = value;
                Invalidate( );
            }
        }
    }

    [DefaultValue(ButtonBorderStyle.Solid)]
    [Description("获取或设置线型边框样式。")]
    public ButtonBorderStyle BorderSingleStyle
    {
        get => _borderSingleStyle;
        set
        {
            if (_borderSingleStyle != value)
            {
                _borderSingleStyle = value;
                Invalidate( );
            }
        }
    }

    [DefaultValue(typeof(Color), "DarkGray")]
    [Description("获取或设置边框颜色（仅当边框类型为线型时有效）。")]
    public Color BorderColor
    {
        get => _borderColor;
        set
        {
            if (!(_borderColor == value))
            {
                _borderColor = value;
                Invalidate( );
            }
        }
    }

    protected sealed override CreateParams CreateParams
    {
        get
        {
            CreateParams createParams = base.CreateParams;
            createParams.Style |= 1073741824;
            createParams.Style |= 67108864;
            createParams.Style |= 65536;
            createParams.Style &= -262145;
            createParams.Style &= -8388609;
            createParams.Style &= -4194305;
            createParams.ExStyle = 0;
            createParams.ExStyle |= 65536;
            return createParams;
        }
    }

    public FloatLayerBase( )
    {
        _mouseMsgFilter = new AppMouseMessageHandler(this);
        InitBaseProperties( );
        _borderType = BorderStyle.Fixed3D;
        _border3DStyle = Border3DStyle.RaisedInner;
        _borderSingleStyle = ButtonBorderStyle.Solid;
        _borderColor = Color.DarkGray;
    }

    protected override void OnLoad(EventArgs e)
    {
        if (!_isShowDialogAgain)
        {
            if (!DesignMode)
            {
                Size frameBorderSize = SystemInformation.FrameBorderSize;
                Size -= frameBorderSize + frameBorderSize;
            }
            base.OnLoad(e);
        }
    }

    protected override void OnShown(EventArgs e)
    {
        if (!_isShowDialogAgain)
        {
            if (Modal)
            {
                _isShowDialogAgain = true;
            }
            Control control;
            if (!DesignMode && (control = GetNextControl(this, true)) != null)
            {
                control.Focus( );
            }
            base.OnShown(e);
        }
    }

    protected override void WndProc(ref Message m)
    {
        if (m.Msg == 24 && m.WParam != IntPtr.Zero && m.LParam == IntPtr.Zero && Modal && Owner != null && !Owner.IsDisposed)
        {
            if (Owner.IsMdiChild)
            {
                EnableWindow(Owner.MdiParent.Handle, true);
                SetParent(Handle, Owner.Handle);
            }
            else
            {
                EnableWindow(Owner.Handle, true);
            }
        }
        base.WndProc(ref m);
    }

    protected override void OnPaintBackground(PaintEventArgs e)
    {
        base.OnPaintBackground(e);
        if (_borderType == BorderStyle.Fixed3D)
        {
            ControlPaint.DrawBorder3D(e.Graphics, ClientRectangle, Border3DStyle);
            return;
        }
        if (_borderType == BorderStyle.FixedSingle)
        {
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle, BorderColor, BorderSingleStyle);
        }
    }

    protected override void OnVisibleChanged(EventArgs e)
    {
        if (!DesignMode)
        {
            if (Visible)
            {
                Application.AddMessageFilter(_mouseMsgFilter);
            }
            else
            {
                Application.RemoveMessageFilter(_mouseMsgFilter);
            }
        }
        base.OnVisibleChanged(e);
    }

    public DialogResult ShowDialog(Control control) => ShowDialog(control, 0, control.Height);

    public DialogResult ShowDialog(Control control, int offsetX, int offsetY) => ShowDialog(control, new Point(offsetX, offsetY));

    public DialogResult ShowDialog(Control control, Point offset) => ShowDialogInternal(control, offset);

    public DialogResult ShowDialog(ToolStripItem item) => ShowDialog(item, 0, item.Height + 4);

    public DialogResult ShowDialog(ToolStripItem item, int offsetX, int offsetY) => ShowDialog(item, new Point(offsetX, offsetY));

    public DialogResult ShowDialog(ToolStripItem item, Point offset) => ShowDialogInternal(item, offset);

    public void Show(Control control) => Show(control, 0, control.Height);

    public void Show(Control control, int offsetX, int offsetY) => Show(control, new Point(offsetX, offsetY));

    public void Show(Control control, Point offset) => ShowInternal(control, offset);

    public void Show(ToolStripItem item) => Show(item, 0, item.Height);

    public void Show(ToolStripItem item, int offsetX, int offsetY) => Show(item, new Point(offsetX, offsetY));

    public void Show(ToolStripItem item, Point offset) => ShowInternal(item, offset);

    public DialogResult ShowDialogInternal(Component controlOrItem, Point offset)
    {
        DialogResult dialogResult;
        if (Visible)
        {
            dialogResult = DialogResult.None;
        }
        else
        {
            SetLocationAndOwner(controlOrItem, offset);
            dialogResult = base.ShowDialog( );
        }
        return dialogResult;
    }

    public void ShowInternal(Component controlOrItem, Point offset)
    {
        if (!Visible)
        {
            SetLocationAndOwner(controlOrItem, offset);
            base.Show( );
        }
    }

    public void SetLocationAndOwner(Component controlOrItem, Point offset)
    {
        Point empty = Point.Empty;
        if (controlOrItem is ToolStripItem toolStripItem)
        {
            empty.Offset(toolStripItem.Bounds.Location);
            controlOrItem = toolStripItem.Owner;
        }
        Control control = (Control) controlOrItem;
        empty.Offset(GetControlLocationInForm(control));
        empty.Offset(offset);
        Location = empty;
        Owner = control.FindForm( );
    }

    public static Point GetControlLocationInForm(Control c)
    {
        Point location = c.Location;
        while ((c = c.Parent) is not Form)
        {
            location.Offset(c.Location);
        }
        return location;
    }

    public void InitBaseProperties( )
    {
        base.ControlBox = false;
        base.FormBorderStyle = FormBorderStyle.SizableToolWindow;
        base.Text = string.Empty;
        base.HelpButton = false;
        base.Icon = null;
        base.IsMdiContainer = false;
        base.MaximizeBox = false;
        base.MinimizeBox = false;
        base.ShowIcon = false;
        base.ShowInTaskbar = false;
        base.StartPosition = FormStartPosition.Manual;
        base.TopMost = false;
        base.WindowState = FormWindowState.Normal;
    }

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("请使用别的重载！", true)]
    public new DialogResult ShowDialog( ) => throw new NotImplementedException( );

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("请使用别的重载！", true)]
    public new DialogResult ShowDialog(IWin32Window owner) => throw new NotImplementedException( );

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("请使用别的重载！", true)]
    public new void Show( ) => throw new NotImplementedException( );

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("请使用别的重载！", true)]
    public new void Show(IWin32Window owner) => throw new NotImplementedException( );

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("禁用该属性！", true)]
    public new bool ControlBox
    {
        get => false;
        set
        {
        }
    }

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("设置边框请使用Border相关属性！", true)]
    public new FormBorderStyle FormBorderStyle
    {
        get => FormBorderStyle.SizableToolWindow;
        set
        {
        }
    }

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("禁用该属性！", true)]
    public sealed override string Text
    {
        get => string.Empty;
        set
        {
        }
    }

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("禁用该属性！", true)]
    public new bool HelpButton
    {
        get => false;
        set
        {
        }
    }

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("禁用该属性！", true)]
    public new Image Icon
    {
        get => null;
        set
        {
        }
    }

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("禁用该属性！", true)]
    public new bool IsMdiContainer
    {
        get => false;
        set
        {
        }
    }

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("禁用该属性！", true)]
    public new bool MaximizeBox
    {
        get => false;
        set
        {
        }
    }

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("禁用该属性！", true)]
    public new bool MinimizeBox
    {
        get => false;
        set
        {
        }
    }

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("禁用该属性！", true)]
    public new bool ShowIcon
    {
        get => false;
        set
        {
        }
    }

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("禁用该属性！", true)]
    public new bool ShowInTaskbar
    {
        get => false;
        set
        {
        }
    }

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("禁用该属性！", true)]
    public new FormStartPosition StartPosition
    {
        get => FormStartPosition.Manual;
        set
        {
        }
    }

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("禁用该属性！", true)]
    public new bool TopMost
    {
        get => false;
        set
        {
        }
    }

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("禁用该属性！", true)]
    public new FormWindowState WindowState
    {
        get => FormWindowState.Normal;
        set
        {
        }
    }

    public readonly AppMouseMessageHandler _mouseMsgFilter;

    public bool _isShowDialogAgain;

    public BorderStyle _borderType;

    public Border3DStyle _border3DStyle;

    public ButtonBorderStyle _borderSingleStyle;

    public Color _borderColor;

    public class AppMouseMessageHandler : IMessageFilter
    {
        public AppMouseMessageHandler(FloatLayerBase layerForm) => _layerForm = layerForm;

        public bool PreFilterMessage(ref Message m)
        {
            if (m.Msg == 513 && _layerForm.Visible && !GetWindowRect(_layerForm.Handle).Contains(MousePosition))
            {
                _layerForm.Hide( );
            }
            return false;
        }

        public readonly FloatLayerBase _layerForm;
    }
}
