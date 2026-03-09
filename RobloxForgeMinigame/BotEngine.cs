using System.Diagnostics;
using System.Drawing;
using System;

namespace RobloxForgeMinigame;

public enum GamePhase
{
    Stage1_WaitColor,
    Stage2_Slider,
    Stage3_WaitClick,
    Stage4_Icons,
    Idle
}

public class BotEngine
{
    private CancellationTokenSource? _cancellation;
    private Task? _botTask;
    private GamePhase _currentPhase = GamePhase.Stage1_WaitColor;
    private int _stage2LogTimer = 0;
    
    public event Action<GamePhase>? OnPhaseChanged;
    public event Action<int>? OnColorDiffChanged;
    public event Action<Color, Color>? OnColorsUpdated;

    // Настройки включения этапов
    public bool EnableStage1 { get; set; } = true;
    public bool EnableStage2 { get; set; } = true;
    public bool EnableStage3 { get; set; } = true;
    public bool EnableStage4 { get; set; } = true;

    // Настройки из UI (Этап 1)
    public Point PixelPhase1 { get; set; } = new Point(800, 450); 
    public Color TargetColorPhase1 { get; set; } = Color.White;
    // Координаты начала свайпа
    public Point DragStartPhase1 { get; set; } = new Point(900, 500);
    // Размах свайпа вверх-вниз в пикселях
    public int DragDistancePhase1 { get; set; } = 200; 
    // Скорость свайпа
    public int DragSpeedPhase1 { get; set; } = 25;
    // Смещение точки зажатия от центра зоны свайпа (по Y)
    public int DragOffsetPhase1 { get; set; } = 0;
    // Чувствительность к изменению цвета (сумма разниц RGB, от 0 до 765)
    public int ColorTolerancePhase1 { get; set; } = 30;

    // Настройки из UI (Этап 2)
    public Point PixelPhase2 { get; set; } = new Point(800, 450);
    public int ColorTolerancePhase2 { get; set; } = 30;
    public Rectangle SearchRectPhase2 { get; set; } = new Rectangle(700, 300, 150, 400); // Зона слайдера
    public Color SliderColorPhase2 { get; set; } = Color.Yellow;
    public Color ZoneColorPhase2 { get; set; } = Color.LimeGreen;
    public int MatchTolerancePhase2 { get; set; } = 30;

    // Настройки из UI (Этап 3)
    public Point PixelPhase3 { get; set; } = new Point(800, 450);
    public int ClickCountPhase3 { get; set; } = 5;
    public int ClickIntervalPhase3 { get; set; } = 100; // мс

    // Настройки из UI (Этап 4)
    public Rectangle SearchRectPhase4 { get; set; } = new Rectangle(500, 300, 800, 600); // Зона поиска пикселя
    public Color TargetColorPhase4 { get; set; } = Color.FromArgb(0, 255, 0); // Зеленый (цель)
    public Color PreTargetColorPhase4 { get; set; } = Color.White; // Белый (подготовка/предикт)
    public int MatchTolerancePhase4 { get; set; } = 30;
    public int ScanIntervalPhase4 { get; set; } = 50; // Интервал сканирования Этапа 4
    public Point ClickOffsetPhase4 { get; set; } = new Point(0, 0); 
    public Point ExitPixelPhase4 { get; set; } = new Point(800, 450);
    public int ColorTolerancePhase4 { get; set; } = 30;

    // Задержки между этапами (мс)
    public int DelayAfterS1 { get; set; } = 500;
    public int DelayAfterS2 { get; set; } = 500;
    public int DelayAfterS3 { get; set; } = 500;

    public void Start()
    {
        _currentPhase = GetNextPhase(GamePhase.Idle);
        
        if (_currentPhase == GamePhase.Idle)
        {
            Console.WriteLine("Все этапы отключены!");
            return;
        }

        if (_currentPhase == GamePhase.Stage2_Slider)
        {
            CenteringMouseForS2();
        }

        _cancellation = new CancellationTokenSource();
        _botTask = Task.Run(() => RunBotLoop(_cancellation.Token));
    }

    private GamePhase GetNextPhase(GamePhase current)
    {
        GamePhase next = current;
        while (true)
        {
            // Определяем следующий этап по порядку
            switch (next)
            {
                case GamePhase.Stage1_WaitColor: next = GamePhase.Stage2_Slider; break;
                case GamePhase.Stage2_Slider:    next = GamePhase.Stage3_WaitClick; break;
                case GamePhase.Stage3_WaitClick: next = GamePhase.Stage4_Icons; break;
                case GamePhase.Stage4_Icons:     next = GamePhase.Idle; break;
                case GamePhase.Idle:             next = GamePhase.Stage1_WaitColor; break;
            }

            // Если прошли полный круг и вернулись в Idle (или дошли до конца)
            if (next == GamePhase.Idle) return GamePhase.Idle;

            // Проверяем, включен ли этап
            if (next == GamePhase.Stage1_WaitColor && EnableStage1) return next;
            if (next == GamePhase.Stage2_Slider && EnableStage2) return next;
            if (next == GamePhase.Stage3_WaitClick && EnableStage3) return next;
            if (next == GamePhase.Stage4_Icons && EnableStage4) return next;
        }
    }

    public void Stop()
    {
        _cancellation?.Cancel();
    }

    private void RunBotLoop(CancellationToken token)
    {
        GamePhase lastPhase = GamePhase.Idle;
        Color? initialColorPhase1 = null;
        Color? initialColorPhase2 = null;
        Color? initialColorPhase4 = null;
        int dragDir = 1; // 1 - вниз, -1 - вверх
        int currentDragY = 0;
        bool isDragging = false;

        while (!token.IsCancellationRequested)
        {
            if (_currentPhase != lastPhase)
            {
                // Если это не самый первый запуск (когда lastPhase == Idle), делаем задержку
                if (lastPhase != GamePhase.Idle)
                {
                    int delay = 0;
                    switch (lastPhase)
                    {
                        case GamePhase.Stage1_WaitColor: delay = DelayAfterS1; break;
                        case GamePhase.Stage2_Slider:    delay = DelayAfterS2; break;
                        case GamePhase.Stage3_WaitClick: delay = DelayAfterS3; break;
                    }

                    if (delay > 0)
                    {
                        Console.WriteLine($"[Движок] Задержка после {lastPhase}: {delay} мс...");
                        Thread.Sleep(delay);
                    }
                }

                OnPhaseChanged?.Invoke(_currentPhase);
                lastPhase = _currentPhase;

                // Сброс контекста при смене фазы
                if (_currentPhase == GamePhase.Stage1_WaitColor)
                {
                    initialColorPhase1 = null;
                }
                else if (_currentPhase == GamePhase.Stage2_Slider)
                {
                    initialColorPhase2 = null;
                    CenteringMouseForS2();
                }
                else if (_currentPhase == GamePhase.Stage4_Icons)
                {
                    initialColorPhase4 = null;
                }
            }

            try
            {
                switch (_currentPhase)
                {
                    case GamePhase.Stage1_WaitColor:
                        using (var bmp = ImageProcessor.CaptureScreen(PixelPhase1.X, PixelPhase1.Y, 1, 1))
                        {
                            Color currentColor = bmp.GetPixel(0, 0);

                            if (initialColorPhase1 == null)
                            {
                                // Запоминаем исходный цвет при старте этапа
                                initialColorPhase1 = currentColor;
                                Console.WriteLine($"[Этап 1] Исходный цвет сохранен: {initialColorPhase1}");
                                OnColorsUpdated?.Invoke(initialColorPhase1.Value, currentColor);

                                // Делаем стартовый клик, чтобы поймать фокус окна на целевом пикселе
                                Win32.ClickAt(PixelPhase1.X, PixelPhase1.Y);
                                Thread.Sleep(100); // Даем игре время на реакцию
                            }
                            else
                            {
                                // Считаем дельту изменения цвета
                                int colorDiff =
                                    ImageProcessor.GetColorDifference(initialColorPhase1.Value, currentColor);
                                Console.WriteLine(
                                    $"[Этап 1] Дельта цвета: {colorDiff} (Порог: {ColorTolerancePhase1})");
                                OnColorDiffChanged?.Invoke(colorDiff);
                                OnColorsUpdated?.Invoke(initialColorPhase1.Value, currentColor);

                                if (colorDiff > ColorTolerancePhase1)
                                {
                                    // Условие выполнено (цвет достаточно сильно изменился)
                                    if (isDragging)
                                    {
                                        Win32.mouse_event(0x0004 /*MOUSEEVENTF_LEFTUP*/, 0, 0, 0, 0);
                                        isDragging = false;
                                    }

                                    Console.WriteLine("[Этап 1] Успех! Переход к следующему этапу.");

                                    // Переходим к следующему включенному этапу
                                    _currentPhase = GetNextPhase(_currentPhase);
                                }
                                else
                                {
                                    // Иначе зажимаем ЛКМ и тянем вверх-вниз
                                    if (!isDragging)
                                    {
                                        // Точка зажатия с учетом смещения
                                        int startY = DragStartPhase1.Y + DragOffsetPhase1;

                                        // Перемещаемся к точке зажатия (Точка 1 + Offset)
                                        Win32.DragCursorTo(DragStartPhase1.X, startY);
                                        Thread.Sleep(100);

                                        // Зажимаем кнопку
                                        Win32.mouse_event(0x0002 /*MOUSEEVENTF_LEFTDOWN*/, 0, 0, 0, 0);
                                        Thread.Sleep(200); // Увеличенная задержка для надежного захвата

                                        // Делаем микро-сдвиг, чтобы игра поняла, что начался драг
                                        Win32.DragCursorTo(DragStartPhase1.X, startY + 2);
                                        Thread.Sleep(100); // Даем игре осознать начало перемещения

                                        isDragging = true;
                                        // Начинаем движение от точки фактического зажатия
                                        currentDragY = startY;
                                        
                                        // Дополнительная небольшая задержка перед началом осцилляции, как просил пользователь
                                        Thread.Sleep(50);
                                    }

                                    currentDragY += dragDir * DragSpeedPhase1;

                                    // Соблюдаем границы зоны свайпа (вокруг DragStartPhase1)
                                    int minY = DragStartPhase1.Y - DragDistancePhase1;
                                    int maxY = DragStartPhase1.Y + DragDistancePhase1;

                                    if (currentDragY >= maxY)
                                    {
                                        currentDragY = maxY;
                                        dragDir = -1;
                                    }
                                    else if (currentDragY <= minY)
                                    {
                                        currentDragY = minY;
                                        dragDir = 1;
                                    }

                                    // Двигаем мышь строго по оси X точки зажатия
                                    Win32.DragCursorTo(DragStartPhase1.X, currentDragY);
                                }
                            }
                        }

                        break;

                    case GamePhase.Stage2_Slider:
                        using (var fullBmp = ImageProcessor.CaptureScreen(SearchRectPhase2.X, SearchRectPhase2.Y,
                                   SearchRectPhase2.Width, SearchRectPhase2.Height))
                        {
                            // 1. Проверяем условие завершения этапа (пиксель в другом месте)
                            // Захватываем точку контроля (относительно всего экрана)
                            using (var checkBmp = ImageProcessor.CaptureScreen(PixelPhase2.X, PixelPhase2.Y, 1, 1))
                            {
                                Color currentColor = checkBmp.GetPixel(0, 0);
                                if (initialColorPhase2 == null)
                                {
                                    initialColorPhase2 = currentColor;
                                    OnColorsUpdated?.Invoke(initialColorPhase2.Value, currentColor);
                                }
                                else
                                {
                                    int colorDiff =
                                        ImageProcessor.GetColorDifference(initialColorPhase2.Value, currentColor);
                                    OnColorDiffChanged?.Invoke(colorDiff);
                                    OnColorsUpdated?.Invoke(initialColorPhase2.Value, currentColor);

                                    if (colorDiff > ColorTolerancePhase2)
                                    {
                                        Console.WriteLine("[Этап 2] Успех! Переход к следующему этапу.");
                                        _currentPhase = GetNextPhase(_currentPhase);
                                    }
                                }
                            }

                            // 2. Логика удержания ползунка
                            // Сканируем всю ширину зоны поиска (не только центр) для надежности
                            int minSliderY = int.MaxValue, maxSliderY = int.MinValue;
                            int minZoneY = int.MaxValue, maxZoneY = int.MinValue;
                            int countSlider = 0, countZone = 0;

                            for (int x = 0; x < SearchRectPhase2.Width; x += 5) // Шаг 5 для скорости
                            {
                                for (int y = 0; y < SearchRectPhase2.Height; y += 2)
                                {
                                    Color p = fullBmp.GetPixel(x, y);

                                    // Ищем ползунок
                                    if (ImageProcessor.GetColorDifference(p, SliderColorPhase2) < MatchTolerancePhase2)
                                    {
                                        if (y < minSliderY) minSliderY = y;
                                        if (y > maxSliderY) maxSliderY = y;
                                        countSlider++;
                                    }

                                    // Ищем зону
                                    if (ImageProcessor.GetColorDifference(p, ZoneColorPhase2) < MatchTolerancePhase2)
                                    {
                                        if (y < minZoneY) minZoneY = y;
                                        if (y > maxZoneY) maxZoneY = y;
                                        countZone++;
                                    }
                                }
                            }

                            if (countSlider > 0 && countZone > 0)
                            {
                                // Используем математический центр для исключения искажений, если ползунок срезан краем зоны поиска
                                int avgSliderY = minSliderY + (maxSliderY - minSliderY) / 2;
                                int avgZoneY = minZoneY + (maxZoneY - minZoneY) / 2;

                                _stage2LogTimer++;
                                if (_stage2LogTimer % 20 == 0)
                                {
                                    Console.WriteLine($"[Этап 2] Вижу! Плз:{avgSliderY} (нашел {countSlider} пкс), Зона:{avgZoneY} (нашел {countZone} пкс)");
                                }

                                // Проверяем, не упал ли ползунок в самый низ
                                bool isAtBottom = (maxSliderY >= SearchRectPhase2.Height - 15);

                                // Если ползунок ниже зоны (Y больше) или он лежит на дне
                                if (avgSliderY > avgZoneY + 3 || isAtBottom)
                                {
                                    if (!isDragging)
                                    {
                                        Console.WriteLine($"[Этап 2] ЗАЖАТЬ (P:{avgSliderY} > Z:{avgZoneY}{(isAtBottom ? " [ДНО]" : "")})");
                                        Win32.mouse_event(0x0002 /*MOUSEEVENTF_LEFTDOWN*/, 0, 0, 0, 0);
                                        isDragging = true;
                                    }
                                    else if (isAtBottom && _stage2LogTimer % 2 == 0)
                                    {
                                        // "Отлепляем" ползунок от дна быстрым повторным кликом, если долгое зажатие не помогает
                                        Win32.mouse_event(0x0004 /*MOUSEEVENTF_LEFTUP*/, 0, 0, 0, 0);
                                        Thread.Sleep(20);
                                        Win32.mouse_event(0x0002 /*MOUSEEVENTF_LEFTDOWN*/, 0, 0, 0, 0);
                                    }
                                }
                                else if (avgSliderY <= avgZoneY && !isAtBottom)
                                {
                                    if (isDragging)
                                    {
                                        Console.WriteLine($"[Этап 2] ОТПУСТИТЬ (P:{avgSliderY} <= Z:{avgZoneY})");
                                        Win32.mouse_event(0x0004 /*MOUSEEVENTF_LEFTUP*/, 0, 0, 0, 0);
                                        isDragging = false;
                                    }
                                }
                            }
                            else
                            {
                                _stage2LogTimer++;
                                if (_stage2LogTimer % 20 == 0)
                                {
                                    Console.WriteLine($"[Этап 2] НЕ ВИЖУ! Слайдер пкс: {countSlider}, Зона пкс: {countZone}. Цвета: Плз={SliderColorPhase2}, Зн={ZoneColorPhase2}");
                                }

                                if (isDragging)
                                {
                                    Console.WriteLine(
                                        $"[Этап 2] ПОТЕРЯ (Слайдер:{countSlider}, Зона:{countZone}). ОТПУСКАЕМ.");
                                    Win32.mouse_event(0x0004 /*MOUSEEVENTF_LEFTUP*/, 0, 0, 0, 0);
                                    isDragging = false;
                                }
                            }
                        }

                        break;

                    case GamePhase.Stage3_WaitClick:
                        Console.WriteLine($"[Этап 3] Начало серии из {ClickCountPhase3} кликов в ({PixelPhase3.X}, {PixelPhase3.Y}) с интервалом {ClickIntervalPhase3} мс.");
                        
                        for (int i = 0; i < ClickCountPhase3; i++)
                        {
                            Win32.ClickAt(PixelPhase3.X, PixelPhase3.Y);
                            if (ClickIntervalPhase3 > 0) Thread.Sleep(ClickIntervalPhase3);
                        }

                        Console.WriteLine("[Этап 3] Серия кликов завершена. Переход к следующему этапу.");
                        _currentPhase = GetNextPhase(_currentPhase);
                        break;

                    case GamePhase.Stage4_Icons:
                        using (var screenBmp = ImageProcessor.CaptureScreen(SearchRectPhase4.X, SearchRectPhase4.Y, SearchRectPhase4.Width, SearchRectPhase4.Height))
                        {
                            // 1. Проверяем условие завершения (Exit Pixel)
                            using (var checkBmp = ImageProcessor.CaptureScreen(ExitPixelPhase4.X, ExitPixelPhase4.Y, 1, 1))
                            {
                                Color currentColor = checkBmp.GetPixel(0, 0);
                                if (initialColorPhase4 == null)
                                {
                                    initialColorPhase4 = currentColor;
                                    OnColorsUpdated?.Invoke(initialColorPhase4.Value, currentColor);
                                }
                                else
                                {
                                    int colorDiff = ImageProcessor.GetColorDifference(initialColorPhase4.Value, currentColor);
                                    OnColorDiffChanged?.Invoke(colorDiff);
                                    OnColorsUpdated?.Invoke(initialColorPhase4.Value, currentColor);

                                    if (colorDiff > ColorTolerancePhase4)
                                    {
                                        Console.WriteLine($"[Этап 4] Успех! Цвет в точке выхода изменился (Дельта: {colorDiff}). Завершение.");
                                        _currentPhase = GetNextPhase(_currentPhase);
                                        break;
                                    }
                                }
                            }

                            // 2. Ищем пиксели в области для определения границ фигуры (круга)
                            int minX = int.MaxValue, minY = int.MaxValue;
                            int maxX = int.MinValue, maxY = int.MinValue;
                            int foundCount = 0;

                            for (int y = 0; y < SearchRectPhase4.Height; y += 3)
                            {
                                for (int x = 0; x < SearchRectPhase4.Width; x += 3)
                                {
                                    Color p = screenBmp.GetPixel(x, y);
                                    if (ImageProcessor.GetColorDifference(p, TargetColorPhase4) < MatchTolerancePhase4)
                                    {
                                        if (x < minX) minX = x;
                                        if (y < minY) minY = y;
                                        if (x > maxX) maxX = x;
                                        if (y > maxY) maxY = y;
                                        foundCount++;
                                    }
                                }
                            }

                            if (foundCount > 0)
                            {
                                // Вычисляем геометрический центр найденной фигуры
                                int centerX = minX + (maxX - minX) / 2;
                                int centerY = minY + (maxY - minY) / 2;

                                int targetX = SearchRectPhase4.X + centerX + ClickOffsetPhase4.X;
                                int targetY = SearchRectPhase4.Y + centerY + ClickOffsetPhase4.Y;

                                Console.WriteLine($"[Этап 4] Найдено {foundCount} пикселей. Центр фигуры: ({centerX},{centerY}). Кликаю в ({targetX}, {targetY}).");
                                Win32.ClickAt(targetX, targetY);
                            }
                            else
                            {
                                _stage2LogTimer++;
                                if (_stage2LogTimer % 20 == 0)
                                {
                                    Console.WriteLine($"[Этап 4] Ищу пиксель цвета {TargetColorPhase4} в области {SearchRectPhase4}...");
                                }
                                
                                // Используем настраиваемый интервал опроса
                                if (ScanIntervalPhase4 > 0) Thread.Sleep(ScanIntervalPhase4);
                            }
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error in bot loop: {ex.Message}");
            }

            // Небольшая задержка, чтобы не грузить CPU (в 4 этапе используем свой интервал)
            if (_currentPhase != GamePhase.Stage4_Icons)
            {
                Thread.Sleep(50);
            }
            else
            {
                // В 4 этапе спим самый минимум, так как там есть ScanIntervalPhase4
                Thread.Sleep(10);
            }
        }
    }

    private void CenteringMouseForS2()
    {
        if (Screen.PrimaryScreen != null)
        {
            int centerX = Screen.PrimaryScreen.Bounds.Width / 2;
            int centerY = Screen.PrimaryScreen.Bounds.Height / 2;
            Win32.DragCursorTo(centerX, centerY);
            Console.WriteLine("[Движок] Мышь центрирована для Этапа 2.");
        }
    }
}
