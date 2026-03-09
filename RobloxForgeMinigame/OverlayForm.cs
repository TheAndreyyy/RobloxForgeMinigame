using System;
using System.Drawing;
using System.Windows.Forms;

namespace RobloxForgeMinigame;

public class OverlayForm : Form
{
    private BotEngine _bot;
    private int _activeTab;

    public OverlayForm(BotEngine bot, int activeTab)
    {
        _bot = bot;
        _activeTab = activeTab;
        
        // Настройки для прозрачного оверлея
        this.FormBorderStyle = FormBorderStyle.None;
        this.TopMost = true;
        this.StartPosition = FormStartPosition.Manual;
        
        // Охватываем все экраны
        this.Bounds = SystemInformation.VirtualScreen;
        
        // Делаем форму невидимой (полностью прозрачной), но на ней можно рисовать
        this.BackColor = Color.Magenta;
        this.TransparencyKey = Color.Magenta;
        this.ShowInTaskbar = false;
        
        // Включаем двойную буферизацию для устранения мерцания
        this.DoubleBuffered = true;
        this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
        
        // Таймер для перерисовки (30 FPS для экономии ЦП)
        var timer = new System.Windows.Forms.Timer { Interval = 66 };
        timer.Tick += (s, e) => this.Invalidate();
        timer.Start();
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        Graphics g = e.Graphics;

        if (_activeTab == 0) // Этап 1
        {
            // Рисуем точку проверки цвета (так, чтобы центр оставался свободным)
            using (Pen pen = new Pen(Color.Red, 2))
        {
            int px = _bot.PixelPhase1.X;
            int py = _bot.PixelPhase1.Y;
            g.DrawRectangle(pen, px - 6, py - 6, 12, 12);
            // Линии с отступом от центра, чтобы не закрывать пиксель
            g.DrawLine(pen, px - 12, py, px - 4, py);
            g.DrawLine(pen, px + 4, py, px + 12, py);
            g.DrawLine(pen, px, py - 12, px, py - 4);
            g.DrawLine(pen, px, py + 4, px, py + 12);
            
            g.DrawString("Контроль цвета (Точка 2)", new Font("Arial", 11, FontStyle.Bold), Brushes.Red, px + 10, py - 20);
        }

        // Рисуем линию свайпа
        using (Pen pen = new Pen(Color.LimeGreen, 3))
        {
            int startX = _bot.DragStartPhase1.X;
            int startY = _bot.DragStartPhase1.Y;
            int dist = _bot.DragDistancePhase1;
            
            // Вертикальная линия свайпа
            g.DrawLine(pen, startX, startY - dist, startX, startY + dist);
            
            // Центр зоны свайпа (Точка 1)
            g.FillEllipse(Brushes.White, startX - 3, startY - 3, 6, 6);
            
            // Фактическая точка зажатия с учетом смещения
            int actualClickY = startY + _bot.DragOffsetPhase1;
            using (Pen clickPen = new Pen(Color.Yellow, 2))
            {
                g.DrawLine(clickPen, startX - 8, actualClickY, startX + 8, actualClickY);
                g.DrawLine(clickPen, startX, actualClickY - 8, startX, actualClickY + 8);
            }
            
            // Верхняя и нижняя границы
            g.DrawLine(pen, startX - 15, startY - dist, startX + 15, startY - dist);
            g.DrawLine(pen, startX - 15, startY + dist, startX + 15, startY + dist);

                g.DrawString("Точка зажатия (Точка 1 + Смещение)", new Font("Arial", 11, FontStyle.Bold), Brushes.Yellow, startX + 15, actualClickY - 10);
            }
        }
        else if (_activeTab == 1) // Этап 2
        {
            // --- ЭТАП 2: СЛАЙДЕР ---
            using (Pen pen = new Pen(Color.Cyan, 2))
            {
                pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                g.DrawRectangle(pen, _bot.SearchRectPhase2);
                g.DrawString("Зона поиска слайдера (Этап 2)", new Font("Arial", 10, FontStyle.Italic), Brushes.Cyan, _bot.SearchRectPhase2.X, _bot.SearchRectPhase2.Y - 20);
            }

            using (Pen pen = new Pen(Color.HotPink, 2))
            {
                int px = _bot.PixelPhase2.X;
                int py = _bot.PixelPhase2.Y;
                g.DrawRectangle(pen, px - 6, py - 6, 12, 12);
                g.DrawLine(pen, px - 12, py, px - 4, py);
                g.DrawLine(pen, px + 4, py, px + 12, py);
                g.DrawLine(pen, px, py - 12, px, py - 4);
                g.DrawLine(pen, px, py + 4, px, py + 12);
                g.DrawString("Выход (Этап 2)", new Font("Arial", 11, FontStyle.Bold), Brushes.HotPink, px + 10, py - 20);
            }
        }
        else if (_activeTab == 2) // Этап 3
        {
            // --- ЭТАП 3: КЛИКИ ---
            using (Pen pen = new Pen(Color.White, 2))
            {
                int px = _bot.PixelPhase3.X;
                int py = _bot.PixelPhase3.Y;
                g.DrawRectangle(pen, px - 6, py - 6, 12, 12);
                g.DrawLine(pen, px - 12, py, px - 4, py);
                g.DrawLine(pen, px + 4, py, px + 12, py);
                g.DrawLine(pen, px, py - 12, px, py - 4);
                g.DrawLine(pen, px, py + 4, px, py + 12);
                g.DrawString("Точка клика (Этап 3)", new Font("Arial", 11, FontStyle.Bold), Brushes.White, px + 10, py - 20);
            }
        }
        else if (_activeTab == 3) // Этап 4
        {
            // --- ЭТАП 4: ПОИСК ПИКСЕЛЯ ---
            using (Pen pen = new Pen(Color.Orange, 2))
            {
                pen.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
                g.DrawRectangle(pen, _bot.SearchRectPhase4);
                g.DrawString("Зона поиска пикселя (Этап 4)", new Font("Arial", 10, FontStyle.Italic), Brushes.Orange, _bot.SearchRectPhase4.X, _bot.SearchRectPhase4.Y - 20);
            }

            using (Pen pen = new Pen(Color.Gold, 2))
            {
                int px = _bot.ExitPixelPhase4.X;
                int py = _bot.ExitPixelPhase4.Y;
                g.DrawRectangle(pen, px - 6, py - 6, 12, 12);
                g.DrawLine(pen, px - 12, py, px - 4, py);
                g.DrawLine(pen, px + 4, py, px + 12, py);
                g.DrawLine(pen, px, py - 12, px, py - 4);
                g.DrawLine(pen, px, py + 4, px, py + 12);
                g.DrawString("Точка выхода (Этап 4)", new Font("Arial", 11, FontStyle.Bold), Brushes.Gold, px + 10, py - 20);
            }
        }
    }
    
    // Делаем форму кликабельной насквозь (Click-through), чтобы она не мешала
    protected override CreateParams CreateParams
    {
        get
        {
            CreateParams cp = base.CreateParams;
            cp.ExStyle |= 0x80000 /* WS_EX_LAYERED */ | 0x20 /* WS_EX_TRANSPARENT */;
            return cp;
        }
    }
}
