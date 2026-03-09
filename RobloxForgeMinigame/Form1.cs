namespace RobloxForgeMinigame;

public partial class Form1 : Form
{
    private bool _isRunning = false;
    private OverlayForm? _overlay;
    private BotEngine _bot;
    private System.Windows.Forms.Timer _hotkeyTimer;

    public Form1()
    {
        InitializeComponent();
        this.TopMost = true; // Закрепляем окно поверх других

        // Программно адаптируем UI под новые реалии 1 Этапа
        // (UI теперь визуально настроен в Form1.Designer.cs для совместимости с Rider)

        // Stage 1 Drag Events
        AttachDragToChange(txtRectX);
        AttachDragToChange(txtRectY);
        AttachDragToChange(txtRectW);
        AttachDragToChange(txtRectH);
        AttachDragToChange(_txtDragDist);
        AttachDragToChange(_txtDragSpeed);
        AttachDragToChange(_txtDragOffset);
        AttachDragToChange(_txtColorTolerance);
        AttachDragToChange(txtDelayS1);

        // Stage 2 Drag Events
        AttachDragToChange(txtRectX2);
        AttachDragToChange(txtRectY2);
        AttachDragToChange(txtRectW2);
        AttachDragToChange(txtRectH2);
        AttachDragToChange(txtCheckX2);
        AttachDragToChange(txtCheckY2);
        AttachDragToChange(txtTolerance2);
        AttachDragToChange(txtDelayS2);

        // Stage 3 Drag Events
        AttachDragToChange(txtCheckX3);
        AttachDragToChange(txtCheckY3);
        AttachDragToChange(txtClickCount3);
        AttachDragToChange(txtClickInterval3);
        AttachDragToChange(txtDelayS3);

        // Stage 4 Drag Events
        AttachDragToChange(txtRectX4);
        AttachDragToChange(txtRectY4);
        AttachDragToChange(txtRectW4);
        AttachDragToChange(txtRectH4);
        AttachDragToChange(txtExitX4);
        AttachDragToChange(txtExitY4);
        AttachDragToChange(txtExitTolerance4);
        AttachDragToChange(txtOffsetX4);
        AttachDragToChange(txtOffsetY4);
        AttachDragToChange(txtScanInterval4);
        AttachDragToChange(txtPredictPaddingS4);
        
        // Stage 2 Color Pickers (теперь обрабатываются через ColorPickerOverlay, см. ниже)

        // Отключение оверлея при переключении между этапами
        tabControlSettings.SelectedIndexChanged += (s, e) => {
            if (_overlay != null && !_overlay.IsDisposed)
            {
                _overlay.Close();
                _overlay = null;
            }
        };

        // Гарантируем TopMost
        this.TopMost = true;

        _bot = new BotEngine();
        
        // Передаем начальные состояния включенных/отключенных этапов
        _bot.EnableStage1 = chkStage1.Checked;
        _bot.EnableStage2 = chkStage2.Checked;
        _bot.EnableStage3 = chkStage3.Checked;
        _bot.EnableStage4 = chkStage4.Checked;
        
        // Подписываемся на события движка
        _bot.OnPhaseChanged += HandlePhaseChanged;
        _bot.OnColorDiffChanged += HandleColorDiffChanged;
        _bot.OnColorsUpdated += HandleColorsUpdated;
        
        // Подключаем пипетку к кнопкам и превью цветов 1 этапа
        btnChooseColor.Click += (s, e) => PickStage1Color();
        lblColorPreview.Click += (s, e) => PickStage1Color();

        // Подключаем пипетку к кнопкам и превью цветов 2 этапа
        btnSliderColor.Click += (s, e) => PickSliderColor();
        lblSliderPreview.Click += (s, e) => PickSliderColor();
        btnZoneColor.Click += (s, e) => PickZoneColor();
        lblZonePreview.Click += (s, e) => PickZoneColor();

        // Stage 4 Handlers
        btnTargetColorS4.Click += (s, e) => PickStage4TargetColor();
        lblTargetPreviewS4.Click += (s, e) => PickStage4TargetColor();
        btnExitColorS4.Click += (s, e) => PickStage4ExitColor();
        lblExitPixelS4.Click += (s, e) => PickStage4ExitColor();

        // Таймер для проверки горячих клавиш
        _hotkeyTimer = new System.Windows.Forms.Timer();
        _hotkeyTimer.Interval = 50; // Проверяем 20 раз в секунду
        _hotkeyTimer.Tick += CheckHotkeys;
        _hotkeyTimer.Start();
        
        // Загружаем сохраненные настройки
        LoadSettings();

        // Подписываемся на закрытие формы для сохранения положения
        this.FormClosing += (s, e) => SaveSettings();
    }

    private void btnReset_Click(object? sender, EventArgs e)
    {
        ResetSettings();
    }

    private void BtnToggleOverlay_Click(object? sender, EventArgs e)
    {
        if (_overlay == null || _overlay.IsDisposed)
        {
            _overlay = new OverlayForm(_bot, tabControlSettings.SelectedIndex);
            _overlay.Show();
        }
        else
        {
            _overlay.Close();
            _overlay = null;
        }
    }

    private void CheckHotkeys(object? sender, EventArgs e)
    {
        // Проверяем нажат ли Right Control
        // GetAsyncKeyState возвращает short, где старший бит равен 1, если кнопка нажата
        if (_isRunning && (Win32.GetAsyncKeyState(Win32.VK_RCONTROL) & 0x8000) != 0)
        {
            // Эмулируем нажатие кнопки СТОП
            btnStartStop.PerformClick();
        }
    }

    private void ChkStage_CheckedChanged(object? sender, EventArgs e)
    {
        if (_bot != null)
        {
            _bot.EnableStage1 = chkStage1.Checked;
            _bot.EnableStage2 = chkStage2.Checked;
            _bot.EnableStage3 = chkStage3.Checked;
            _bot.EnableStage4 = chkStage4.Checked;
            SaveSettings(); // Сохраняем состояние при изменении
        }
    }

    private void btnTargetColorS4_Click(object sender, EventArgs e)
    {
        PickStage4TargetColor();
    }

    private void btnPreTargetColorS4_Click(object sender, EventArgs e)
    {
        using (var picker = new ColorPickerOverlay())
        {
            if (picker.ShowDialog() == DialogResult.OK)
            {
                lblPreTargetPreviewS4.BackColor = picker.SelectedColor;
                _bot.PreTargetColorPhase4 = picker.SelectedColor;
                SaveSettings();
            }
        }
    }

    private void btnExitColorS4_Click(object sender, EventArgs e)
    {
        PickStage4ExitColor();
    }

    private void btnStartStop_Click(object sender, EventArgs e)
    {
        _isRunning = !_isRunning;

        if (_isRunning)
        {
            btnStartStop.Text = "STOP";
            lblGlobalStatus.BackColor = Color.Green;
            
            // Запускаем бота
            _bot.Start();
        }
        else
        {
            btnStartStop.Text = "START";
            lblGlobalStatus.BackColor = Color.Red;
            ResetLamps();
            
            // Останавливаем бота
            _bot.Stop();
        }
    }

    private void PickStage1Color()
    {
        using var picker = new ColorPickerOverlay();
        if (picker.ShowDialog() == DialogResult.OK)
        {
            _bot.TargetColorPhase1 = picker.SelectedColor;
            lblColorPreview.BackColor = _bot.TargetColorPhase1;
        }
    }

    private void PickSliderColor()
    {
        using var picker = new ColorPickerOverlay();
        if (picker.ShowDialog() == DialogResult.OK)
        {
            _bot.SliderColorPhase2 = picker.SelectedColor;
            lblSliderPreview.BackColor = _bot.SliderColorPhase2;
        }
    }

    private void PickZoneColor()
    {
        using var picker = new ColorPickerOverlay();
        if (picker.ShowDialog() == DialogResult.OK)
        {
            _bot.ZoneColorPhase2 = picker.SelectedColor;
            lblZonePreview.BackColor = _bot.ZoneColorPhase2;
        }
    }

    private void PickStage4TargetColor()
    {
        using (var picker = new ColorPickerOverlay())
        {
            if (picker.ShowDialog() == DialogResult.OK)
            {
                lblTargetPreviewS4.BackColor = picker.SelectedColor;
                SaveSettings();
            }
        }
    }

    private void PickStage4ExitColor()
    {
        using (var picker = new ColorPickerOverlay())
        {
            if (picker.ShowDialog() == DialogResult.OK)
            {
                txtExitX4.Text = picker.SelectedPoint.X.ToString();
                txtExitY4.Text = picker.SelectedPoint.Y.ToString();
                SaveSettings();
            }
        }
    }

    private void HandlePhaseChanged(GamePhase phase)
    {
        if (this.InvokeRequired)
        {
            this.Invoke(() => HandlePhaseChanged(phase));
            return;
        }

        bool wasOverlayOpen = (_overlay != null && !_overlay.IsDisposed);

        ResetLamps();

        int newTabIndex = -1;
        switch (phase)
        {
            case GamePhase.Stage1_WaitColor: lblLamp1.BackColor = Color.Green; newTabIndex = 0; break;
            case GamePhase.Stage2_Slider:    lblLamp2.BackColor = Color.Green; newTabIndex = 1; break;
            case GamePhase.Stage3_WaitClick: lblLamp3.BackColor = Color.Green; newTabIndex = 2; break;
            case GamePhase.Stage4_Icons:     lblLamp4.BackColor = Color.Green; newTabIndex = 3; break;
        }
        
        // Автоматически переключаем активную вкладку, если бот перешел на новый этап
        if (newTabIndex != -1 && tabControlSettings.SelectedIndex != newTabIndex)
        {
            tabControlSettings.SelectedIndex = newTabIndex; // Это закроет текущий оверлей из-за события SelectedIndexChanged
        }

        // Восстанавливаем оверлей для новой вкладки, если он был включен ранее
        if (wasOverlayOpen && phase != GamePhase.Idle && newTabIndex != -1)
        {
            if (_overlay == null || _overlay.IsDisposed)
            {
                _overlay = new OverlayForm(_bot, newTabIndex);
                _overlay.Show();
            }
            else
            {
                _overlay.Close();
                _overlay = new OverlayForm(_bot, newTabIndex);
                _overlay.Show();
            }
        }
        
        if (phase == GamePhase.Idle)
        {
            groupBoxSettings.Text = "Настройки (Этап 1)";
            if (_isRunning)
            {
                btnStartStop.PerformClick();
            }
            
            // Если бот полностью остановился, отключаем оверлей
            if (_overlay != null && !_overlay.IsDisposed)
            {
                _overlay.Close();
                _overlay = null;
            }
        }
    }

    private void HandleColorDiffChanged(int diff)
    {
        if (this.InvokeRequired)
        {
            this.Invoke(() => HandleColorDiffChanged(diff));
            return;
        }
        groupBoxSettings.Text = $"Настройки (Этап 1) - ДЕЛЬТА: {diff}";
    }

    private void HandleColorsUpdated(Color start, Color current)
    {
        if (this.InvokeRequired)
        {
            this.Invoke(() => HandleColorsUpdated(start, current));
            return;
        }
        lblStartColor.BackColor = start;
        lblCurrentColor.BackColor = current;
    }

    private void btnApplyRect_Click(object sender, EventArgs e)
    {
        ApplyRectSettings(false);
    }

    private void ApplyRectSettings(bool silent)
    {
        // Phase 1
        if (!int.TryParse(txtRectX.Text, out int px) ||
            !int.TryParse(txtRectY.Text, out int py) ||
            !int.TryParse(txtRectW.Text, out int sx) ||
            !int.TryParse(txtRectH.Text, out int sy) ||
            !int.TryParse(_txtDragDist.Text, out int dist) ||
            !int.TryParse(_txtDragSpeed.Text, out int speed) ||
            !int.TryParse(_txtDragOffset.Text, out int offset) ||
            !int.TryParse(_txtColorTolerance.Text, out int tol))
        {
            if (!silent) MessageBox.Show("Ошибка в параметрах Этапа 1", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        // Phase 2
        if (!int.TryParse(txtRectX2.Text, out int x2) ||
            !int.TryParse(txtRectY2.Text, out int y2) ||
            !int.TryParse(txtRectW2.Text, out int w2) ||
            !int.TryParse(txtRectH2.Text, out int h2) ||
            !int.TryParse(txtCheckX2.Text, out int cx2) ||
            !int.TryParse(txtCheckY2.Text, out int cy2) ||
            !int.TryParse(txtTolerance2.Text, out int tol2))
        {
            if (!silent) MessageBox.Show("Ошибка в параметрах Этапа 2", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        // Phase 3
        if (!int.TryParse(txtCheckX3.Text, out int cx3) ||
            !int.TryParse(txtCheckY3.Text, out int cy3) ||
            !int.TryParse(txtClickCount3.Text, out int clicks3) ||
            !int.TryParse(txtClickInterval3.Text, out int interval3))
        {
            if (!silent) MessageBox.Show("Ошибка в параметрах Этапа 3", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        // Phase 4
        if (!int.TryParse(txtRectX4.Text, out int rx4) ||
            !int.TryParse(txtRectY4.Text, out int ry4) ||
            !int.TryParse(txtRectW4.Text, out int rw4) ||
            !int.TryParse(txtRectH4.Text, out int rh4) ||
            !int.TryParse(txtExitX4.Text, out int ex4) ||
            !int.TryParse(txtExitY4.Text, out int ey4) ||
            !int.TryParse(txtExitTolerance4.Text, out int etol4) ||
            !int.TryParse(txtOffsetX4.Text, out int ox4) ||
            !int.TryParse(txtOffsetY4.Text, out int oy4) ||
            !int.TryParse(txtPredictPaddingS4.Text, out int pad4))
        {
            if (!silent) MessageBox.Show("Ошибка в параметрах Этапа 4", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        // Apply Phase 1
        _bot.PixelPhase1 = new Point(px, py);
        _bot.TargetColorPhase1 = lblColorPreview.BackColor;
        _bot.DragStartPhase1 = new Point(sx, sy);
        _bot.DragDistancePhase1 = dist;
        _bot.DragSpeedPhase1 = speed;
        _bot.DragOffsetPhase1 = offset;
        _bot.ColorTolerancePhase1 = tol;

        // Apply Phase 2
        _bot.SearchRectPhase2 = new Rectangle(x2, y2, w2, h2);
        _bot.PixelPhase2 = new Point(cx2, cy2);
        _bot.ColorTolerancePhase2 = tol2;
        _bot.SliderColorPhase2 = lblSliderPreview.BackColor;
        _bot.ZoneColorPhase2 = lblZonePreview.BackColor;

        // Apply Phase 3
        _bot.PixelPhase3 = new Point(cx3, cy3);
        _bot.ClickCountPhase3 = clicks3;
        _bot.ClickIntervalPhase3 = interval3;

        // Apply Phase 4
        _bot.SearchRectPhase4 = new Rectangle(rx4, ry4, rw4, rh4);
        _bot.TargetColorPhase4 = lblTargetPreviewS4.BackColor;
        _bot.PreTargetColorPhase4 = lblPreTargetPreviewS4.BackColor;
        _bot.ExitPixelPhase4 = new Point(ex4, ey4);
        _bot.ColorTolerancePhase4 = etol4;
        _bot.ClickOffsetPhase4 = new Point(ox4, oy4);
        _bot.ScanIntervalPhase4 = int.TryParse(txtScanInterval4.Text, out var si4) ? si4 : 50;
        _bot.PredictSearchPaddingPhase4 = pad4;

        // Delays
        if (int.TryParse(txtDelayS1.Text, out int d1)) _bot.DelayAfterS1 = d1;
        if (int.TryParse(txtDelayS2.Text, out int d2)) _bot.DelayAfterS2 = d2;
        if (int.TryParse(txtDelayS3.Text, out int d3)) _bot.DelayAfterS3 = d3;

        if (!silent)
            MessageBox.Show("Все настройки применены и сохранены!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
        
        SaveSettings();
        _overlay?.Invalidate();
    }

    private void ResetLamps()
    {
        lblLamp1.BackColor = Color.Gray;
        lblLamp2.BackColor = Color.Gray;
        lblLamp3.BackColor = Color.Gray;
        lblLamp4.BackColor = Color.Gray;
        groupBoxSettings.Text = "Настройки (Этап 1)";
        lblStartColor.BackColor = Color.Black;
        lblCurrentColor.BackColor = Color.Black;
    }

    private Point _dragStartPos;
    private int _dragStartValue;
    private int _dragStartValue2;
    private bool _isDraggingValue;

    private void AttachDragToChange(TextBox tb, TextBox? linkedTb = null)
    {
        tb.MouseDown += (s, e) =>
        {
            if (e.Button == MouseButtons.Left && int.TryParse(tb.Text, out int val))
            {
                _dragStartValue = val;
                if (linkedTb != null && int.TryParse(linkedTb.Text, out int val2))
                {
                    _dragStartValue2 = val2;
                }

                _dragStartPos = Cursor.Position;
                _isDraggingValue = true;
                tb.Capture = true;
                Cursor.Current = Cursors.SizeWE;
            }
        };

        tb.MouseMove += (s, e) =>
        {
            if (_isDraggingValue && tb.Capture)
            {
                Cursor.Current = Cursors.SizeWE;
                int deltaX = Cursor.Position.X - _dragStartPos.X;
                tb.Text = (_dragStartValue + deltaX).ToString();
                
                if (linkedTb != null)
                {
                    linkedTb.Text = (_dragStartValue2 + deltaX).ToString();
                }

                ApplyRectSettings(true); // Применяем тихо для обновления оверлея в реальном времени
            }
        };

        tb.MouseUp += (s, e) =>
        {
            if (_isDraggingValue && e.Button == MouseButtons.Left)
            {
                _isDraggingValue = false;
                tb.Capture = false;
                Cursor.Current = Cursors.Default;
            }
        };
    }

    private string _settingsFile = "settings.json";

    private void SaveSettings()
    {
        var settings = new System.Collections.Generic.Dictionary<string, string>
        {
            { "Px", txtRectX.Text }, { "Py", txtRectY.Text },
            { "Col1", lblColorPreview.BackColor.ToArgb().ToString() },
            { "Sx", txtRectW.Text }, { "Sy", txtRectH.Text },
            { "Dist", _txtDragDist.Text }, { "Speed", _txtDragSpeed.Text },
            { "Offset", _txtDragOffset.Text }, { "Tol", _txtColorTolerance.Text },
            { "DelayS1", txtDelayS1.Text },
            
            { "X2", txtRectX2.Text }, { "Y2", txtRectY2.Text },
            { "W2", txtRectW2.Text }, { "H2", txtRectH2.Text },
            { "Cx2", txtCheckX2.Text }, { "Cy2", txtCheckY2.Text },
            { "Tol2", txtTolerance2.Text },
            { "SCol2", lblSliderPreview.BackColor.ToArgb().ToString() },
            { "ZCol2", lblZonePreview.BackColor.ToArgb().ToString() },
            { "DelayS2", txtDelayS2.Text },

            { "Cx3", txtCheckX3.Text }, { "Cy3", txtCheckY3.Text },
            { "Count3", txtClickCount3.Text }, { "Int3", txtClickInterval3.Text },
            { "DelayS3", txtDelayS3.Text },

            { "X4", txtRectX4.Text }, { "Y4", txtRectY4.Text },
            { "W4", txtRectW4.Text }, { "H4", txtRectH4.Text },
            { "TCol4", lblTargetPreviewS4.BackColor.ToArgb().ToString() },
            { "PCol4", lblPreTargetPreviewS4.BackColor.ToArgb().ToString() },
            { "Ex4", txtExitX4.Text }, { "Ey4", txtExitY4.Text },
            { "ETol4", txtExitTolerance4.Text },
            { "Ox4", txtOffsetX4.Text }, { "Oy4", txtOffsetY4.Text },
            { "ScanInterval4", txtScanInterval4.Text },
            { "Pad4", txtPredictPaddingS4.Text },
            
            { "E1", chkStage1.Checked.ToString() },
            { "E2", chkStage2.Checked.ToString() },
            { "E3", chkStage3.Checked.ToString() },
            { "E4", chkStage4.Checked.ToString() },

            { "WinX", this.Location.X.ToString() },
            { "WinY", this.Location.Y.ToString() },
            { "WinW", this.Size.Width.ToString() },
            { "WinH", this.Size.Height.ToString() }
        };
        
        try 
        {
            System.IO.File.WriteAllText(_settingsFile, System.Text.Json.JsonSerializer.Serialize(settings));
        } 
        catch { }
    }

    private void LoadSettings()
    {
        if (System.IO.File.Exists(_settingsFile))
        {
            try 
            {
                var json = System.IO.File.ReadAllText(_settingsFile);
                var settings = System.Text.Json.JsonSerializer.Deserialize<System.Collections.Generic.Dictionary<string, string>>(json);
                if (settings != null)
                {
                    if (settings.ContainsKey("Px")) txtRectX.Text = settings["Px"];
                    if (settings.ContainsKey("Py")) txtRectY.Text = settings["Py"];
                    if (settings.ContainsKey("Col1") && int.TryParse(settings["Col1"], out int c1)) lblColorPreview.BackColor = Color.FromArgb(c1);
                    if (settings.ContainsKey("Sx")) txtRectW.Text = settings["Sx"];
                    if (settings.ContainsKey("Sy")) txtRectH.Text = settings["Sy"];
                    if (settings.ContainsKey("Dist")) _txtDragDist.Text = settings["Dist"];
                    if (settings.ContainsKey("Speed")) _txtDragSpeed.Text = settings["Speed"];
                    if (settings.ContainsKey("Offset")) _txtDragOffset.Text = settings["Offset"];
                    if (settings.ContainsKey("Tol")) _txtColorTolerance.Text = settings["Tol"];
                    if (settings.ContainsKey("DelayS1")) txtDelayS1.Text = settings["DelayS1"];

                    if (settings.ContainsKey("X2")) txtRectX2.Text = settings["X2"];
                    if (settings.ContainsKey("Y2")) txtRectY2.Text = settings["Y2"];
                    if (settings.ContainsKey("W2")) txtRectW2.Text = settings["W2"];
                    if (settings.ContainsKey("H2")) txtRectH2.Text = settings["H2"];
                    if (settings.ContainsKey("Cx2")) txtCheckX2.Text = settings["Cx2"];
                    if (settings.ContainsKey("Cy2")) txtCheckY2.Text = settings["Cy2"];
                    if (settings.ContainsKey("Tol2")) txtTolerance2.Text = settings["Tol2"];
                    if (settings.ContainsKey("SCol2") && int.TryParse(settings["SCol2"], out int sc)) lblSliderPreview.BackColor = Color.FromArgb(sc);
                    if (settings.ContainsKey("ZCol2") && int.TryParse(settings["ZCol2"], out int zc)) lblZonePreview.BackColor = Color.FromArgb(zc);
                    if (settings.ContainsKey("DelayS2")) txtDelayS2.Text = settings["DelayS2"];

                    if (settings.ContainsKey("Cx3")) txtCheckX3.Text = settings["Cx3"];
                    if (settings.ContainsKey("Cy3")) txtCheckY3.Text = settings["Cy3"];
                    if (settings.ContainsKey("Count3")) txtClickCount3.Text = settings["Count3"];
                    if (settings.ContainsKey("Int3")) txtClickInterval3.Text = settings["Int3"];
                    if (settings.ContainsKey("DelayS3")) txtDelayS3.Text = settings["DelayS3"];

                    if (settings.ContainsKey("X4")) txtRectX4.Text = settings["X4"];
                    if (settings.ContainsKey("Y4")) txtRectY4.Text = settings["Y4"];
                    if (settings.ContainsKey("W4")) txtRectW4.Text = settings["W4"];
                    if (settings.ContainsKey("H4")) txtRectH4.Text = settings["H4"];
                    if (settings.ContainsKey("TCol4") && int.TryParse(settings["TCol4"], out int tc4)) lblTargetPreviewS4.BackColor = Color.FromArgb(tc4);
                    if (settings.ContainsKey("PCol4") && int.TryParse(settings["PCol4"], out int pc4)) lblPreTargetPreviewS4.BackColor = Color.FromArgb(pc4);
                    if (settings.ContainsKey("Ex4")) txtExitX4.Text = settings["Ex4"];
                    if (settings.ContainsKey("Ey4")) txtExitY4.Text = settings["Ey4"];
                    if (settings.ContainsKey("ETol4")) txtExitTolerance4.Text = settings["ETol4"];
                    if (settings.ContainsKey("Ox4")) txtOffsetX4.Text = settings["Ox4"];
                    if (settings.ContainsKey("Oy4")) txtOffsetY4.Text = settings["Oy4"];
                    if (settings.ContainsKey("ScanInterval4")) txtScanInterval4.Text = settings["ScanInterval4"];
                    if (settings.ContainsKey("Pad4")) txtPredictPaddingS4.Text = settings["Pad4"];

                    if (settings.ContainsKey("E1")) chkStage1.Checked = settings["E1"] == "True";
                    if (settings.ContainsKey("E2")) chkStage2.Checked = settings["E2"] == "True";
                    if (settings.ContainsKey("E3")) chkStage3.Checked = settings["E3"] == "True";
                    if (settings.ContainsKey("E4")) chkStage4.Checked = settings["E4"] == "True";

                    if (settings.ContainsKey("WinX") && settings.ContainsKey("WinY") &&
                        int.TryParse(settings["WinX"], out int wx) && int.TryParse(settings["WinY"], out int wy))
                    {
                        this.StartPosition = FormStartPosition.Manual;
                        this.Location = new Point(wx, wy);
                    }
                    if (settings.ContainsKey("WinW") && settings.ContainsKey("WinH") &&
                        int.TryParse(settings["WinW"], out int ww) && int.TryParse(settings["WinH"], out int wh))
                    {
                        this.Size = new Size(ww, wh);
                    }
                }
                ApplyRectSettings(true);
            } 
            catch { }
        }
    }

    private void ResetSettings()
    {
        txtRectX.Text = "800";
        txtRectY.Text = "450";
        lblColorPreview.BackColor = Color.White;
        txtRectW.Text = "900";
        txtRectH.Text = "500";
        _txtDragDist.Text = "200";
        _txtDragSpeed.Text = "25";
        _txtDragOffset.Text = "0";
        _txtColorTolerance.Text = "30";
        txtScanInterval4.Text = "50";
        txtDelayS1.Text = "500";

        txtRectX2.Text = "700";
        txtRectY2.Text = "300";
        txtRectW2.Text = "150";
        txtRectH2.Text = "400";
        txtCheckX2.Text = "800";
        txtCheckY2.Text = "450";
        txtTolerance2.Text = "30";
        lblSliderPreview.BackColor = Color.Yellow;
        lblZonePreview.BackColor = Color.LimeGreen;
        txtDelayS2.Text = "500";

        txtCheckX3.Text = "800";
        txtCheckY3.Text = "450";
        txtClickCount3.Text = "5";
        txtClickInterval3.Text = "100";
        txtDelayS3.Text = "500";

        txtRectX4.Text = "500";
        txtRectY4.Text = "300";
        txtRectW4.Text = "800";
        txtRectH4.Text = "600";
        lblTargetPreviewS4.BackColor = Color.Red;
        txtExitX4.Text = "800";
        txtExitY4.Text = "450";
        txtExitTolerance4.Text = "30";
        txtOffsetX4.Text = "0";
        txtOffsetY4.Text = "0";
        ApplyRectSettings(true);
        SaveSettings();
    }
}