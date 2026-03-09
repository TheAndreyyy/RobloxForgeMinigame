using System.Runtime.InteropServices;

namespace RobloxForgeMinigame;

public static class Win32
{
    [DllImport("user32.dll")]
    public static extern void mouse_event(uint dwFlags, int dx, int dy, uint dwData, int dwExtraInfo);

    [DllImport("user32.dll")]
    public static extern bool SetCursorPos(int X, int Y);
    
    [DllImport("user32.dll")]
    public static extern bool GetCursorPos(out System.Drawing.Point lpPoint);

    [DllImport("user32.dll")]
    public static extern short GetAsyncKeyState(int vKey);

    public const int VK_RCONTROL = 0xA3;

    // Флаги для mouse_event
    private const uint MOUSEEVENTF_MOVE = 0x0001;
    private const uint MOUSEEVENTF_LEFTDOWN = 0x0002;
    private const uint MOUSEEVENTF_LEFTUP = 0x0004;
    private const uint MOUSEEVENTF_RIGHTDOWN = 0x0008;
    private const uint MOUSEEVENTF_RIGHTUP = 0x0010;
    private const uint MOUSEEVENTF_ABSOLUTE = 0x8000;

    /// <summary>
    /// Эмулирует левый клик мыши в текущей позиции курсора
    /// </summary>
    public static void LeftClick(int delayMs = 20)
    {
        mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
        Thread.Sleep(delayMs); // Пауза между нажатием и отпусканием, чтобы игра успела зарегистрировать
        mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
    }
    
    /// <summary>
    /// Перемещает мышь в координаты экрана и кликает
    /// </summary>
    public static void ClickAt(int x, int y, int delayMs = 20)
    {
        DragCursorTo(x, y);
        Thread.Sleep(50); // Увеличенная пауза после перемещения
        LeftClick(delayMs);
    }

    /// <summary>
    /// Эмулирует реальное перемещение мыши через абсолютные координаты.
    /// Это гораздо лучше понимается игровыми движками как "движение мыши".
    /// </summary>
    public static void DragCursorTo(int x, int y)
    {
        var screen = System.Windows.Forms.Screen.PrimaryScreen;
        if (screen == null) return;

        // Принудительно ставим системный курсор
        SetCursorPos(x, y);

        // Координаты для MOUSEEVENTF_ABSOLUTE идут от 0 до 65535
        int nx = (x * 65536) / screen.Bounds.Width;
        int ny = (y * 65536) / screen.Bounds.Height;
        
        mouse_event(MOUSEEVENTF_MOVE | MOUSEEVENTF_ABSOLUTE, nx, ny, 0, 0);
    }
}
