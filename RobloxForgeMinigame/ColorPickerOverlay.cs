using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace RobloxForgeMinigame;

public class ColorPickerOverlay : Form
{
    private Bitmap? _screenCapture;
    public Color SelectedColor { get; private set; } = Color.Empty;
    public Point SelectedPoint { get; private set; } = Point.Empty;

    public ColorPickerOverlay()
    {
        this.FormBorderStyle = FormBorderStyle.None;
        this.TopMost = true;
        this.StartPosition = FormStartPosition.Manual;
        this.Bounds = SystemInformation.VirtualScreen;
        this.ShowInTaskbar = false;
        this.Cursor = Cursors.Cross;

        this.MouseClick += OnOverlayClick;
        this.KeyDown += OnOverlayKeyDown;
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        CaptureScreen();
    }

    private void CaptureScreen()
    {
        _screenCapture = new Bitmap(this.Bounds.Width, this.Bounds.Height, PixelFormat.Format32bppArgb);
        using (var g = Graphics.FromImage(_screenCapture))
        {
            g.CopyFromScreen(this.Bounds.X, this.Bounds.Y, 0, 0, this.Bounds.Size, CopyPixelOperation.SourceCopy);
        }
        this.BackgroundImage = _screenCapture;
    }

    public void StartPicking(Action<Color> onColorPicked)
    {
        // Для обратной совместимости, если нужно
        if (this.ShowDialog() == DialogResult.OK)
        {
            onColorPicked?.Invoke(SelectedColor);
        }
    }

    private void OnOverlayKeyDown(object? sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Escape)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }

    private void OnOverlayClick(object? sender, MouseEventArgs e)
    {
        if (_screenCapture != null)
        {
            SelectedColor = _screenCapture.GetPixel(e.X, e.Y);
            SelectedPoint = new Point(e.X, e.Y);
            this.DialogResult = DialogResult.OK;
        }
        this.Close();
    }

    protected override void OnFormClosed(FormClosedEventArgs e)
    {
        _screenCapture?.Dispose();
        base.OnFormClosed(e);
    }
}
