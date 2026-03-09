namespace RobloxForgeMinigame;

partial class Form1
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        btnStartStop = new System.Windows.Forms.Button();
        lblGlobalStatus = new System.Windows.Forms.Label();
        chkStage1 = new System.Windows.Forms.CheckBox();
        lblLamp1 = new System.Windows.Forms.Label();
        chkStage2 = new System.Windows.Forms.CheckBox();
        lblLamp2 = new System.Windows.Forms.Label();
        chkStage3 = new System.Windows.Forms.CheckBox();
        lblLamp3 = new System.Windows.Forms.Label();
        chkStage4 = new System.Windows.Forms.CheckBox();
        lblLamp4 = new System.Windows.Forms.Label();
        groupBoxSettings = new System.Windows.Forms.GroupBox();
        tabControlSettings = new System.Windows.Forms.TabControl();
        tabPageStage1 = new System.Windows.Forms.TabPage();
        btnChooseColor = new System.Windows.Forms.Button();
        lblColorPreview = new System.Windows.Forms.Label();
        lblTargetColor = new System.Windows.Forms.Label();
        lblSearchRect = new System.Windows.Forms.Label();
        lblX = new System.Windows.Forms.Label();
        txtRectX = new System.Windows.Forms.TextBox();
        lblY = new System.Windows.Forms.Label();
        txtRectY = new System.Windows.Forms.TextBox();
        lblW = new System.Windows.Forms.Label();
        txtRectW = new System.Windows.Forms.TextBox();
        lblH = new System.Windows.Forms.Label();
        txtRectH = new System.Windows.Forms.TextBox();
        lblDist = new System.Windows.Forms.Label();
        _txtDragDist = new System.Windows.Forms.TextBox();
        lblSpeed = new System.Windows.Forms.Label();
        _txtDragSpeed = new System.Windows.Forms.TextBox();
        lblOffset = new System.Windows.Forms.Label();
        _txtDragOffset = new System.Windows.Forms.TextBox();
        lblTolerance = new System.Windows.Forms.Label();
        _txtColorTolerance = new System.Windows.Forms.TextBox();
        lblDelayS1 = new System.Windows.Forms.Label();
        txtDelayS1 = new System.Windows.Forms.TextBox();
        btnToggleOverlay = new System.Windows.Forms.Button();
        tabPageStage2 = new System.Windows.Forms.TabPage();
        lblSearchRectS2 = new System.Windows.Forms.Label();
        txtRectX2 = new System.Windows.Forms.TextBox();
        txtRectY2 = new System.Windows.Forms.TextBox();
        txtRectW2 = new System.Windows.Forms.TextBox();
        txtRectH2 = new System.Windows.Forms.TextBox();
        lblCheckPixelS2 = new System.Windows.Forms.Label();
        txtCheckX2 = new System.Windows.Forms.TextBox();
        txtCheckY2 = new System.Windows.Forms.TextBox();
        lblTolS2 = new System.Windows.Forms.Label();
        txtTolerance2 = new System.Windows.Forms.TextBox();
        lblSliderColor = new System.Windows.Forms.Label();
        lblSliderPreview = new System.Windows.Forms.Label();
        btnSliderColor = new System.Windows.Forms.Button();
        lblZoneColor = new System.Windows.Forms.Label();
        lblZonePreview = new System.Windows.Forms.Label();
        btnZoneColor = new System.Windows.Forms.Button();
        lblDelayS2 = new System.Windows.Forms.Label();
        txtDelayS2 = new System.Windows.Forms.TextBox();
        btnToggleOverlayS2 = new System.Windows.Forms.Button();
        tabPageStage3 = new System.Windows.Forms.TabPage();
        lblCheckPixelS3 = new System.Windows.Forms.Label();
        txtCheckX3 = new System.Windows.Forms.TextBox();
        txtCheckY3 = new System.Windows.Forms.TextBox();
        lblClickCountS3 = new System.Windows.Forms.Label();
        txtClickCount3 = new System.Windows.Forms.TextBox();
        lblClickIntervalS3 = new System.Windows.Forms.Label();
        txtClickInterval3 = new System.Windows.Forms.TextBox();
        lblDelayS3 = new System.Windows.Forms.Label();
        txtDelayS3 = new System.Windows.Forms.TextBox();
        btnToggleOverlayS3 = new System.Windows.Forms.Button();
        tabPageStage4 = new System.Windows.Forms.TabPage();
        lblSearchRectS4 = new System.Windows.Forms.Label();
        txtRectX4 = new System.Windows.Forms.TextBox();
        txtRectY4 = new System.Windows.Forms.TextBox();
        txtRectW4 = new System.Windows.Forms.TextBox();
        txtRectH4 = new System.Windows.Forms.TextBox();
        lblTargetColorS4 = new System.Windows.Forms.Label();
        lblTargetPreviewS4 = new System.Windows.Forms.Label();
        btnTargetColorS4 = new Button();
        lblExitColorS4 = new Label();
        lblExitPixelS4 = new System.Windows.Forms.Label();
        btnExitColorS4 = new System.Windows.Forms.Button();
        txtExitX4 = new System.Windows.Forms.TextBox();
        txtExitY4 = new System.Windows.Forms.TextBox();
        lblExitTolS4 = new System.Windows.Forms.Label();
        txtExitTolerance4 = new System.Windows.Forms.TextBox();
        lblOffsetS4 = new System.Windows.Forms.Label();
        txtOffsetX4 = new System.Windows.Forms.TextBox();
        txtOffsetY4 = new System.Windows.Forms.TextBox();
        lblScanIntervalS4 = new System.Windows.Forms.Label();
        txtScanInterval4 = new System.Windows.Forms.TextBox();
        btnToggleOverlayS4 = new System.Windows.Forms.Button();
        lblStartColor = new System.Windows.Forms.Label();
        lblCurrentColor = new System.Windows.Forms.Label();
        lblStartColorTitle = new System.Windows.Forms.Label();
        lblCurrentColorTitle = new System.Windows.Forms.Label();
        btnReset = new System.Windows.Forms.Button();
        btnApplyRect = new System.Windows.Forms.Button();
        groupBoxSettings.SuspendLayout();
        tabControlSettings.SuspendLayout();
        tabPageStage1.SuspendLayout();
        tabPageStage2.SuspendLayout();
        tabPageStage3.SuspendLayout();
        tabPageStage4.SuspendLayout();
        SuspendLayout();
        //
        // btnStartStop
        //
        btnStartStop.Font = new System.Drawing.Font("Segoe UI", 7.6800003F, System.Drawing.FontStyle.Bold);
        btnStartStop.Location = new System.Drawing.Point(14, 16);
        btnStartStop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
        btnStartStop.Name = "btnStartStop";
        btnStartStop.Size = new System.Drawing.Size(137, 53);
        btnStartStop.TabIndex = 0;
        btnStartStop.Text = "START";
        btnStartStop.UseVisualStyleBackColor = true;
        btnStartStop.Click += btnStartStop_Click;
        //
        // lblGlobalStatus
        //
        lblGlobalStatus.BackColor = System.Drawing.Color.Red;
        lblGlobalStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        lblGlobalStatus.Location = new System.Drawing.Point(158, 16);
        lblGlobalStatus.Name = "lblGlobalStatus";
        lblGlobalStatus.Size = new System.Drawing.Size(45, 53);
        lblGlobalStatus.TabIndex = 1;
        //
        // chkStage1
        //
        chkStage1.AutoSize = true;
        chkStage1.Checked = true;
        chkStage1.CheckState = System.Windows.Forms.CheckState.Checked;
        chkStage1.Location = new System.Drawing.Point(14, 105);
        chkStage1.Name = "chkStage1";
        chkStage1.Size = new System.Drawing.Size(198, 24);
        chkStage1.TabIndex = 2;
        chkStage1.Text = "Этап 1: Ожидание цвета";
        chkStage1.UseVisualStyleBackColor = true;
        chkStage1.CheckedChanged += ChkStage_CheckedChanged;
        //
        // lblLamp1
        //
        lblLamp1.BackColor = System.Drawing.Color.Gray;
        lblLamp1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        lblLamp1.Location = new System.Drawing.Point(210, 103);
        lblLamp1.Name = "lblLamp1";
        lblLamp1.Size = new System.Drawing.Size(23, 26);
        lblLamp1.TabIndex = 3;
        //
        // chkStage2
        //
        chkStage2.AutoSize = true;
        chkStage2.Checked = true;
        chkStage2.CheckState = System.Windows.Forms.CheckState.Checked;
        chkStage2.Location = new System.Drawing.Point(14, 145);
        chkStage2.Name = "chkStage2";
        chkStage2.Size = new System.Drawing.Size(149, 24);
        chkStage2.TabIndex = 4;
        chkStage2.Text = "Этап 2: Ползунок";
        chkStage2.UseVisualStyleBackColor = true;
        chkStage2.CheckedChanged += ChkStage_CheckedChanged;
        //
        // lblLamp2
        //
        lblLamp2.BackColor = System.Drawing.Color.Gray;
        lblLamp2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        lblLamp2.Location = new System.Drawing.Point(210, 143);
        lblLamp2.Name = "lblLamp2";
        lblLamp2.Size = new System.Drawing.Size(23, 26);
        lblLamp2.TabIndex = 5;
        //
        // chkStage3
        //
        chkStage3.AutoSize = true;
        chkStage3.Checked = true;
        chkStage3.CheckState = System.Windows.Forms.CheckState.Checked;
        chkStage3.Location = new System.Drawing.Point(14, 185);
        chkStage3.Name = "chkStage3";
        chkStage3.Size = new System.Drawing.Size(124, 24);
        chkStage3.TabIndex = 6;
        chkStage3.Text = "Этап 3: Клики";
        chkStage3.UseVisualStyleBackColor = true;
        chkStage3.CheckedChanged += ChkStage_CheckedChanged;
        //
        // lblLamp3
        //
        lblLamp3.BackColor = System.Drawing.Color.Gray;
        lblLamp3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        lblLamp3.Location = new System.Drawing.Point(210, 183);
        lblLamp3.Name = "lblLamp3";
        lblLamp3.Size = new System.Drawing.Size(23, 26);
        lblLamp3.TabIndex = 7;
        //
        // chkStage4
        //
        chkStage4.AutoSize = true;
        chkStage4.Checked = true;
        chkStage4.CheckState = System.Windows.Forms.CheckState.Checked;
        chkStage4.Location = new System.Drawing.Point(14, 225);
        chkStage4.Name = "chkStage4";
        chkStage4.Size = new System.Drawing.Size(134, 24);
        chkStage4.TabIndex = 8;
        chkStage4.Text = "Этап 4: Иконки";
        chkStage4.UseVisualStyleBackColor = true;
        chkStage4.CheckedChanged += ChkStage_CheckedChanged;
        //
        // lblLamp4
        //
        lblLamp4.BackColor = System.Drawing.Color.Gray;
        lblLamp4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        lblLamp4.Location = new System.Drawing.Point(210, 223);
        lblLamp4.Name = "lblLamp4";
        lblLamp4.Size = new System.Drawing.Size(23, 26);
        lblLamp4.TabIndex = 9;
        //
        // groupBoxSettings
        //
        groupBoxSettings.Controls.Add(tabControlSettings);
        groupBoxSettings.Controls.Add(lblStartColor);
        groupBoxSettings.Controls.Add(lblCurrentColor);
        groupBoxSettings.Controls.Add(lblStartColorTitle);
        groupBoxSettings.Controls.Add(lblCurrentColorTitle);
        groupBoxSettings.Controls.Add(btnReset);
        groupBoxSettings.Controls.Add(btnApplyRect);
        groupBoxSettings.Location = new System.Drawing.Point(14, 260);
        groupBoxSettings.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
        groupBoxSettings.Name = "groupBoxSettings";
        groupBoxSettings.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
        groupBoxSettings.Size = new System.Drawing.Size(425, 480);
        groupBoxSettings.TabIndex = 10;
        groupBoxSettings.TabStop = false;
        groupBoxSettings.Text = "Настройки Бот-движка";
        //
        // tabControlSettings
        //
        tabControlSettings.Controls.Add(tabPageStage1);
        tabControlSettings.Controls.Add(tabPageStage2);
        tabControlSettings.Controls.Add(tabPageStage3);
        tabControlSettings.Controls.Add(tabPageStage4);
        tabControlSettings.Location = new System.Drawing.Point(6, 95);
        tabControlSettings.Name = "tabControlSettings";
        tabControlSettings.SelectedIndex = 0;
        tabControlSettings.Size = new System.Drawing.Size(410, 343);
        tabControlSettings.TabIndex = 20;
        //
        // tabPageStage1
        //
        tabPageStage1.Controls.Add(btnChooseColor);
        tabPageStage1.Controls.Add(lblColorPreview);
        tabPageStage1.Controls.Add(lblTargetColor);
        tabPageStage1.Controls.Add(lblSearchRect);
        tabPageStage1.Controls.Add(lblX);
        tabPageStage1.Controls.Add(txtRectX);
        tabPageStage1.Controls.Add(lblY);
        tabPageStage1.Controls.Add(txtRectY);
        tabPageStage1.Controls.Add(lblW);
        tabPageStage1.Controls.Add(txtRectW);
        tabPageStage1.Controls.Add(lblH);
        tabPageStage1.Controls.Add(txtRectH);
        tabPageStage1.Controls.Add(lblDist);
        tabPageStage1.Controls.Add(_txtDragDist);
        tabPageStage1.Controls.Add(lblSpeed);
        tabPageStage1.Controls.Add(_txtDragSpeed);
        tabPageStage1.Controls.Add(lblOffset);
        tabPageStage1.Controls.Add(_txtDragOffset);
        tabPageStage1.Controls.Add(lblTolerance);
        tabPageStage1.Controls.Add(_txtColorTolerance);
        tabPageStage1.Controls.Add(lblDelayS1);
        tabPageStage1.Controls.Add(txtDelayS1);
        tabPageStage1.Controls.Add(btnToggleOverlay);
        tabPageStage1.Location = new System.Drawing.Point(4, 29);
        tabPageStage1.Name = "tabPageStage1";
        tabPageStage1.Padding = new System.Windows.Forms.Padding(3);
        tabPageStage1.Size = new System.Drawing.Size(402, 310);
        tabPageStage1.TabIndex = 0;
        tabPageStage1.Text = "Этап 1 (Свайп)";
        tabPageStage1.UseVisualStyleBackColor = true;
        //
        // btnChooseColor
        //
        btnChooseColor.Location = new System.Drawing.Point(152, 92);
        btnChooseColor.Name = "btnChooseColor";
        btnChooseColor.Size = new System.Drawing.Size(65, 30);
        btnChooseColor.TabIndex = 2;
        btnChooseColor.Text = "Выбрать";
        btnChooseColor.UseVisualStyleBackColor = true;
        //
        // lblColorPreview
        //
        lblColorPreview.BackColor = System.Drawing.Color.White;
        lblColorPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        lblColorPreview.Location = new System.Drawing.Point(121, 96);
        lblColorPreview.Name = "lblColorPreview";
        lblColorPreview.Size = new System.Drawing.Size(25, 25);
        lblColorPreview.TabIndex = 1;
        //
        // lblTargetColor
        //
        lblTargetColor.AutoSize = true;
        lblTargetColor.Location = new System.Drawing.Point(7, 97);
        lblTargetColor.Name = "lblTargetColor";
        lblTargetColor.Size = new System.Drawing.Size(108, 20);
        lblTargetColor.TabIndex = 0;
        lblTargetColor.Text = "Целевой цвет:";
        //
        // lblSearchRect
        //
        lblSearchRect.AutoSize = true;
        lblSearchRect.Location = new System.Drawing.Point(7, 129);
        lblSearchRect.Name = "lblSearchRect";
        lblSearchRect.Size = new System.Drawing.Size(191, 20);
        lblSearchRect.TabIndex = 3;
        lblSearchRect.Text = "Настройки (Цвет / Свайп):";
        //
        // lblX
        //
        lblX.AutoSize = true;
        lblX.Location = new System.Drawing.Point(10, 155);
        lblX.Name = "lblX";
        lblX.Size = new System.Drawing.Size(58, 20);
        lblX.TabIndex = 4;
        lblX.Text = "Цвет X:";
        //
        // txtRectX
        //
        txtRectX.Location = new System.Drawing.Point(70, 152);
        txtRectX.Name = "txtRectX";
        txtRectX.Size = new System.Drawing.Size(50, 27);
        txtRectX.TabIndex = 5;
        txtRectX.Text = "800";
        //
        // lblY
        //
        lblY.AutoSize = true;
        lblY.Location = new System.Drawing.Point(130, 155);
        lblY.Name = "lblY";
        lblY.Size = new System.Drawing.Size(57, 20);
        lblY.TabIndex = 6;
        lblY.Text = "Цвет Y:";
        //
        // txtRectY
        //
        txtRectY.Location = new System.Drawing.Point(193, 152);
        txtRectY.Name = "txtRectY";
        txtRectY.Size = new System.Drawing.Size(50, 27);
        txtRectY.TabIndex = 7;
        txtRectY.Text = "450";
        //
        // lblW
        //
        lblW.AutoSize = true;
        lblW.Location = new System.Drawing.Point(10, 190);
        lblW.Name = "lblW";
        lblW.Size = new System.Drawing.Size(72, 20);
        lblW.TabIndex = 8;
        lblW.Text = "Зажим X:";
        //
        // txtRectW
        //
        txtRectW.Location = new System.Drawing.Point(85, 187);
        txtRectW.Name = "txtRectW";
        txtRectW.Size = new System.Drawing.Size(50, 27);
        txtRectW.TabIndex = 9;
        txtRectW.Text = "100";
        //
        // lblH
        //
        lblH.AutoSize = true;
        lblH.Location = new System.Drawing.Point(145, 190);
        lblH.Name = "lblH";
        lblH.Size = new System.Drawing.Size(71, 20);
        lblH.TabIndex = 10;
        lblH.Text = "Зажим Y:";
        //
        // txtRectH
        //
        txtRectH.Location = new System.Drawing.Point(215, 187);
        txtRectH.Name = "txtRectH";
        txtRectH.Size = new System.Drawing.Size(50, 27);
        txtRectH.TabIndex = 11;
        txtRectH.Text = "100";
        //
        // lblDist
        //
        lblDist.AutoSize = true;
        lblDist.Location = new System.Drawing.Point(10, 25);
        lblDist.Name = "lblDist";
        lblDist.Size = new System.Drawing.Size(61, 20);
        lblDist.TabIndex = 13;
        lblDist.Text = "Размах:";
        //
        // _txtDragDist
        //
        _txtDragDist.Location = new System.Drawing.Point(77, 22);
        _txtDragDist.Name = "_txtDragDist";
        _txtDragDist.Size = new System.Drawing.Size(40, 27);
        _txtDragDist.TabIndex = 14;
        _txtDragDist.Text = "200";
        //
        // lblSpeed
        //
        lblSpeed.AutoSize = true;
        lblSpeed.Location = new System.Drawing.Point(124, 25);
        lblSpeed.Name = "lblSpeed";
        lblSpeed.Size = new System.Drawing.Size(46, 20);
        lblSpeed.TabIndex = 15;
        lblSpeed.Text = "Скор:";
        //
        // _txtDragSpeed
        //
        _txtDragSpeed.Location = new System.Drawing.Point(176, 22);
        _txtDragSpeed.Name = "_txtDragSpeed";
        _txtDragSpeed.Size = new System.Drawing.Size(40, 27);
        _txtDragSpeed.TabIndex = 16;
        _txtDragSpeed.Text = "25";
        //
        // lblOffset
        //
        lblOffset.AutoSize = true;
        lblOffset.Location = new System.Drawing.Point(222, 25);
        lblOffset.Name = "lblOffset";
        lblOffset.Size = new System.Drawing.Size(52, 20);
        lblOffset.TabIndex = 17;
        lblOffset.Text = "Смещ:";
        //
        // _txtDragOffset
        //
        _txtDragOffset.Location = new System.Drawing.Point(280, 22);
        _txtDragOffset.Name = "_txtDragOffset";
        _txtDragOffset.Size = new System.Drawing.Size(40, 27);
        _txtDragOffset.TabIndex = 18;
        _txtDragOffset.Text = "0";
        //
        // lblTolerance
        //
        lblTolerance.AutoSize = true;
        lblTolerance.Location = new System.Drawing.Point(10, 225);
        lblTolerance.Name = "lblTolerance";
        lblTolerance.Size = new System.Drawing.Size(112, 20);
        lblTolerance.TabIndex = 19;
        lblTolerance.Text = "Дельта (0-765):";
        //
        // _txtColorTolerance
        //
        _txtColorTolerance.Location = new System.Drawing.Point(135, 222);
        _txtColorTolerance.Name = "_txtColorTolerance";
        _txtColorTolerance.Size = new System.Drawing.Size(50, 27);
        _txtColorTolerance.TabIndex = 20;
        _txtColorTolerance.Text = "30";
        //
        // lblDelayS1
        //
        lblDelayS1.AutoSize = true;
        lblDelayS1.Location = new System.Drawing.Point(220, 225);
        lblDelayS1.Name = "lblDelayS1";
        lblDelayS1.Size = new System.Drawing.Size(111, 20);
        lblDelayS1.TabIndex = 21;
        lblDelayS1.Text = "Задержка (мс):";
        //
        // txtDelayS1
        //
        txtDelayS1.Location = new System.Drawing.Point(365, 222);
        txtDelayS1.Name = "txtDelayS1";
        txtDelayS1.Size = new System.Drawing.Size(40, 27);
        txtDelayS1.TabIndex = 22;
        txtDelayS1.Text = "500";
        //
        // btnToggleOverlay
        //
        btnToggleOverlay.Location = new System.Drawing.Point(10, 265);
        btnToggleOverlay.Name = "btnToggleOverlay";
        btnToggleOverlay.Size = new System.Drawing.Size(310, 35);
        btnToggleOverlay.TabIndex = 22;
        btnToggleOverlay.Text = "Отрисовка зон (Вкл/Выкл)";
        btnToggleOverlay.UseVisualStyleBackColor = true;
        btnToggleOverlay.Click += BtnToggleOverlay_Click;
        //
        // tabPageStage2
        //
        tabPageStage2.Controls.Add(lblSearchRectS2);
        tabPageStage2.Controls.Add(txtRectX2);
        tabPageStage2.Controls.Add(txtRectY2);
        tabPageStage2.Controls.Add(txtRectW2);
        tabPageStage2.Controls.Add(txtRectH2);
        tabPageStage2.Controls.Add(lblCheckPixelS2);
        tabPageStage2.Controls.Add(txtCheckX2);
        tabPageStage2.Controls.Add(txtCheckY2);
        tabPageStage2.Controls.Add(lblTolS2);
        tabPageStage2.Controls.Add(txtTolerance2);
        tabPageStage2.Controls.Add(lblSliderColor);
        tabPageStage2.Controls.Add(lblSliderPreview);
        tabPageStage2.Controls.Add(btnSliderColor);
        tabPageStage2.Controls.Add(lblZoneColor);
        tabPageStage2.Controls.Add(lblZonePreview);
        tabPageStage2.Controls.Add(btnZoneColor);
        tabPageStage2.Controls.Add(lblDelayS2);
        tabPageStage2.Controls.Add(txtDelayS2);
        tabPageStage2.Controls.Add(btnToggleOverlayS2);
        tabPageStage2.Location = new System.Drawing.Point(4, 29);
        tabPageStage2.Name = "tabPageStage2";
        tabPageStage2.Padding = new System.Windows.Forms.Padding(3);
        tabPageStage2.Size = new System.Drawing.Size(402, 310);
        tabPageStage2.TabIndex = 1;
        tabPageStage2.Text = "Этап 2 (Слайдер)";
        tabPageStage2.UseVisualStyleBackColor = true;
        //
        // lblSearchRectS2
        //
        lblSearchRectS2.AutoSize = true;
        lblSearchRectS2.Location = new System.Drawing.Point(10, 10);
        lblSearchRectS2.Name = "lblSearchRectS2";
        lblSearchRectS2.Size = new System.Drawing.Size(164, 20);
        lblSearchRectS2.TabIndex = 0;
        lblSearchRectS2.Text = "Зона поиска (X,Y,W,H):";
        //
        // txtRectX2
        //
        txtRectX2.Location = new System.Drawing.Point(10, 35);
        txtRectX2.Name = "txtRectX2";
        txtRectX2.Size = new System.Drawing.Size(45, 27);
        txtRectX2.TabIndex = 1;
        txtRectX2.Text = "700";
        //
        // txtRectY2
        //
        txtRectY2.Location = new System.Drawing.Point(60, 35);
        txtRectY2.Name = "txtRectY2";
        txtRectY2.Size = new System.Drawing.Size(45, 27);
        txtRectY2.TabIndex = 2;
        txtRectY2.Text = "300";
        //
        // txtRectW2
        //
        txtRectW2.Location = new System.Drawing.Point(110, 35);
        txtRectW2.Name = "txtRectW2";
        txtRectW2.Size = new System.Drawing.Size(45, 27);
        txtRectW2.TabIndex = 3;
        txtRectW2.Text = "150";
        //
        // txtRectH2
        //
        txtRectH2.Location = new System.Drawing.Point(160, 35);
        txtRectH2.Name = "txtRectH2";
        txtRectH2.Size = new System.Drawing.Size(45, 27);
        txtRectH2.TabIndex = 4;
        txtRectH2.Text = "400";
        //
        // lblCheckPixelS2
        //
        lblCheckPixelS2.AutoSize = true;
        lblCheckPixelS2.Location = new System.Drawing.Point(10, 145);
        lblCheckPixelS2.Name = "lblCheckPixelS2";
        lblCheckPixelS2.Size = new System.Drawing.Size(168, 20);
        lblCheckPixelS2.TabIndex = 5;
        lblCheckPixelS2.Text = "Контроль выхода (X,Y):";
        //
        // txtCheckX2
        //
        txtCheckX2.Location = new System.Drawing.Point(10, 170);
        txtCheckX2.Name = "txtCheckX2";
        txtCheckX2.Size = new System.Drawing.Size(50, 27);
        txtCheckX2.TabIndex = 6;
        txtCheckX2.Text = "800";
        //
        // txtCheckY2
        //
        txtCheckY2.Location = new System.Drawing.Point(65, 170);
        txtCheckY2.Name = "txtCheckY2";
        txtCheckY2.Size = new System.Drawing.Size(50, 27);
        txtCheckY2.TabIndex = 7;
        txtCheckY2.Text = "450";
        //
        // lblTolS2
        //
        lblTolS2.AutoSize = true;
        lblTolS2.Location = new System.Drawing.Point(125, 173);
        lblTolS2.Name = "lblTolS2";
        lblTolS2.Size = new System.Drawing.Size(60, 20);
        lblTolS2.TabIndex = 8;
        lblTolS2.Text = "Дельта:";
        //
        // txtTolerance2
        //
        txtTolerance2.Location = new System.Drawing.Point(185, 170);
        txtTolerance2.Name = "txtTolerance2";
        txtTolerance2.Size = new System.Drawing.Size(40, 27);
        txtTolerance2.TabIndex = 9;
        txtTolerance2.Text = "30";
        //
        // lblSliderColor
        //
        lblSliderColor.AutoSize = true;
        lblSliderColor.Location = new System.Drawing.Point(10, 70);
        lblSliderColor.Name = "lblSliderColor";
        lblSliderColor.Size = new System.Drawing.Size(113, 20);
        lblSliderColor.TabIndex = 10;
        lblSliderColor.Text = "Цвет ползунка:";
        //
        // lblSliderPreview
        //
        lblSliderPreview.BackColor = System.Drawing.Color.Yellow;
        lblSliderPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        lblSliderPreview.Location = new System.Drawing.Point(130, 68);
        lblSliderPreview.Name = "lblSliderPreview";
        lblSliderPreview.Size = new System.Drawing.Size(25, 25);
        lblSliderPreview.TabIndex = 11;
        //
        // btnSliderColor
        //
        btnSliderColor.Location = new System.Drawing.Point(160, 65);
        btnSliderColor.Name = "btnSliderColor";
        btnSliderColor.Size = new System.Drawing.Size(40, 30);
        btnSliderColor.TabIndex = 12;
        btnSliderColor.Text = "...";
        //
        // lblZoneColor
        //
        lblZoneColor.AutoSize = true;
        lblZoneColor.Location = new System.Drawing.Point(10, 105);
        lblZoneColor.Name = "lblZoneColor";
        lblZoneColor.Size = new System.Drawing.Size(85, 20);
        lblZoneColor.TabIndex = 13;
        lblZoneColor.Text = "Цвет зоны:";
        //
        // lblZonePreview
        //
        lblZonePreview.BackColor = System.Drawing.Color.LimeGreen;
        lblZonePreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        lblZonePreview.Location = new System.Drawing.Point(130, 103);
        lblZonePreview.Name = "lblZonePreview";
        lblZonePreview.Size = new System.Drawing.Size(25, 25);
        lblZonePreview.TabIndex = 14;
        //
        // btnZoneColor
        //
        btnZoneColor.Location = new System.Drawing.Point(160, 100);
        btnZoneColor.Name = "btnZoneColor";
        btnZoneColor.Size = new System.Drawing.Size(40, 30);
        btnZoneColor.TabIndex = 15;
        btnZoneColor.Text = "...";
        //
        // lblDelayS2
        //
        lblDelayS2.AutoSize = true;
        lblDelayS2.Location = new System.Drawing.Point(232, 173);
        lblDelayS2.Name = "lblDelayS2";
        lblDelayS2.Size = new System.Drawing.Size(85, 20);
        lblDelayS2.TabIndex = 16;
        lblDelayS2.Text = "Пауза (мс):";
        //
        // txtDelayS2
        //
        txtDelayS2.Location = new System.Drawing.Point(345, 170);
        txtDelayS2.Name = "txtDelayS2";
        txtDelayS2.Size = new System.Drawing.Size(45, 27);
        txtDelayS2.TabIndex = 17;
        txtDelayS2.Text = "500";
        //
        // btnToggleOverlayS2
        //
        btnToggleOverlayS2.Location = new System.Drawing.Point(10, 210);
        btnToggleOverlayS2.Name = "btnToggleOverlayS2";
        btnToggleOverlayS2.Size = new System.Drawing.Size(310, 35);
        btnToggleOverlayS2.TabIndex = 22;
        btnToggleOverlayS2.Text = "Отрисовка зон (Вкл/Выкл)";
        btnToggleOverlayS2.UseVisualStyleBackColor = true;
        btnToggleOverlayS2.Click += BtnToggleOverlay_Click;
        //
        // tabPageStage3
        //
        tabPageStage3.Controls.Add(lblCheckPixelS3);
        tabPageStage3.Controls.Add(txtCheckX3);
        tabPageStage3.Controls.Add(txtCheckY3);
        tabPageStage3.Controls.Add(lblClickCountS3);
        tabPageStage3.Controls.Add(txtClickCount3);
        tabPageStage3.Controls.Add(lblClickIntervalS3);
        tabPageStage3.Controls.Add(txtClickInterval3);
        tabPageStage3.Controls.Add(lblDelayS3);
        tabPageStage3.Controls.Add(txtDelayS3);
        tabPageStage3.Controls.Add(btnToggleOverlayS3);
        tabPageStage3.Location = new System.Drawing.Point(4, 29);
        tabPageStage3.Name = "tabPageStage3";
        tabPageStage3.Padding = new System.Windows.Forms.Padding(3);
        tabPageStage3.Size = new System.Drawing.Size(402, 310);
        tabPageStage3.TabIndex = 2;
        tabPageStage3.Text = "Этап 3 (Клики)";
        tabPageStage3.UseVisualStyleBackColor = true;
        //
        // lblCheckPixelS3
        //
        lblCheckPixelS3.AutoSize = true;
        lblCheckPixelS3.Location = new System.Drawing.Point(10, 10);
        lblCheckPixelS3.Name = "lblCheckPixelS3";
        lblCheckPixelS3.Size = new System.Drawing.Size(129, 20);
        lblCheckPixelS3.TabIndex = 0;
        lblCheckPixelS3.Text = "Точка клика (X,Y):";
        //
        // txtCheckX3
        //
        txtCheckX3.Location = new System.Drawing.Point(10, 35);
        txtCheckX3.Name = "txtCheckX3";
        txtCheckX3.Size = new System.Drawing.Size(50, 27);
        txtCheckX3.TabIndex = 1;
        txtCheckX3.Text = "800";
        //
        // txtCheckY3
        //
        txtCheckY3.Location = new System.Drawing.Point(65, 35);
        txtCheckY3.Name = "txtCheckY3";
        txtCheckY3.Size = new System.Drawing.Size(50, 27);
        txtCheckY3.TabIndex = 2;
        txtCheckY3.Text = "450";
        //
        // lblClickCountS3
        //
        lblClickCountS3.AutoSize = true;
        lblClickCountS3.Location = new System.Drawing.Point(10, 75);
        lblClickCountS3.Name = "lblClickCountS3";
        lblClickCountS3.Size = new System.Drawing.Size(113, 20);
        lblClickCountS3.TabIndex = 3;
        lblClickCountS3.Text = "Кол-во кликов:";
        //
        // txtClickCount3
        //
        txtClickCount3.Location = new System.Drawing.Point(145, 72);
        txtClickCount3.Name = "txtClickCount3";
        txtClickCount3.Size = new System.Drawing.Size(45, 27);
        txtClickCount3.TabIndex = 4;
        txtClickCount3.Text = "5";
        //
        // lblClickIntervalS3
        //
        lblClickIntervalS3.AutoSize = true;
        lblClickIntervalS3.Location = new System.Drawing.Point(10, 110);
        lblClickIntervalS3.Name = "lblClickIntervalS3";
        lblClickIntervalS3.Size = new System.Drawing.Size(111, 20);
        lblClickIntervalS3.TabIndex = 5;
        lblClickIntervalS3.Text = "Интервал (мс):";
        //
        // txtClickInterval3
        //
        txtClickInterval3.Location = new System.Drawing.Point(125, 107);
        txtClickInterval3.Name = "txtClickInterval3";
        txtClickInterval3.Size = new System.Drawing.Size(45, 27);
        txtClickInterval3.TabIndex = 6;
        txtClickInterval3.Text = "100";
        //
        // lblDelayS3
        //
        lblDelayS3.AutoSize = true;
        lblDelayS3.Location = new System.Drawing.Point(10, 145);
        lblDelayS3.Name = "lblDelayS3";
        lblDelayS3.Size = new System.Drawing.Size(150, 20);
        lblDelayS3.TabIndex = 7;
        lblDelayS3.Text = "Пауза после S3 (мс):";
        //
        // txtDelayS3
        //
        txtDelayS3.Location = new System.Drawing.Point(155, 142);
        txtDelayS3.Name = "txtDelayS3";
        txtDelayS3.Size = new System.Drawing.Size(50, 27);
        txtDelayS3.TabIndex = 8;
        txtDelayS3.Text = "500";
        //
        // btnToggleOverlayS3
        //
        btnToggleOverlayS3.Location = new System.Drawing.Point(10, 265);
        btnToggleOverlayS3.Name = "btnToggleOverlayS3";
        btnToggleOverlayS3.Size = new System.Drawing.Size(310, 35);
        btnToggleOverlayS3.TabIndex = 22;
        btnToggleOverlayS3.Text = "Отрисовка зон (Вкл/Выкл)";
        btnToggleOverlayS3.UseVisualStyleBackColor = true;
        btnToggleOverlayS3.Click += BtnToggleOverlay_Click;
        //
        // tabPageStage4
        //
        tabPageStage4.Controls.Add(lblSearchRectS4);
        tabPageStage4.Controls.Add(txtRectX4);
        tabPageStage4.Controls.Add(txtRectY4);
        tabPageStage4.Controls.Add(txtRectW4);
        tabPageStage4.Controls.Add(txtRectH4);
        tabPageStage4.Controls.Add(lblTargetColorS4);
        tabPageStage4.Controls.Add(lblTargetPreviewS4);
        tabPageStage4.Controls.Add(btnTargetColorS4);
        tabPageStage4.Controls.Add(lblExitColorS4);
        tabPageStage4.Controls.Add(lblExitPixelS4);
        tabPageStage4.Controls.Add(btnExitColorS4);
        tabPageStage4.Controls.Add(txtExitX4);
        tabPageStage4.Controls.Add(txtExitY4);
        tabPageStage4.Controls.Add(lblExitTolS4);
        tabPageStage4.Controls.Add(txtExitTolerance4);
        tabPageStage4.Controls.Add(lblOffsetS4);
        tabPageStage4.Controls.Add(txtOffsetX4);
        tabPageStage4.Controls.Add(txtOffsetY4);
        tabPageStage4.Controls.Add(lblScanIntervalS4);
        tabPageStage4.Controls.Add(txtScanInterval4);
        tabPageStage4.Controls.Add(btnToggleOverlayS4);
        tabPageStage4.Location = new System.Drawing.Point(4, 29);
        tabPageStage4.Name = "tabPageStage4";
        tabPageStage4.Padding = new System.Windows.Forms.Padding(3);
        tabPageStage4.Size = new System.Drawing.Size(402, 310);
        tabPageStage4.TabIndex = 3;
        tabPageStage4.Text = "Этап 4 (Иконки)";
        tabPageStage4.UseVisualStyleBackColor = true;
        //
        // lblSearchRectS4
        //
        lblSearchRectS4.AutoSize = true;
        lblSearchRectS4.Location = new System.Drawing.Point(10, 10);
        lblSearchRectS4.Name = "lblSearchRectS4";
        lblSearchRectS4.Size = new System.Drawing.Size(164, 20);
        lblSearchRectS4.TabIndex = 0;
        lblSearchRectS4.Text = "Зона поиска (X,Y,W,H):";
        //
        // txtRectX4
        //
        txtRectX4.Location = new System.Drawing.Point(10, 35);
        txtRectX4.Name = "txtRectX4";
        txtRectX4.Size = new System.Drawing.Size(45, 27);
        txtRectX4.TabIndex = 1;
        txtRectX4.Text = "500";
        //
        // txtRectY4
        //
        txtRectY4.Location = new System.Drawing.Point(60, 35);
        txtRectY4.Name = "txtRectY4";
        txtRectY4.Size = new System.Drawing.Size(45, 27);
        txtRectY4.TabIndex = 2;
        txtRectY4.Text = "300";
        //
        // txtRectW4
        //
        txtRectW4.Location = new System.Drawing.Point(110, 35);
        txtRectW4.Name = "txtRectW4";
        txtRectW4.Size = new System.Drawing.Size(45, 27);
        txtRectW4.TabIndex = 3;
        txtRectW4.Text = "800";
        //
        // txtRectH4
        //
        txtRectH4.Location = new System.Drawing.Point(160, 35);
        txtRectH4.Name = "txtRectH4";
        txtRectH4.Size = new System.Drawing.Size(45, 27);
        txtRectH4.TabIndex = 4;
        txtRectH4.Text = "600";
        //
        // lblTargetColorS4
        //
        lblTargetColorS4.AutoSize = true;
        lblTargetColorS4.Location = new System.Drawing.Point(10, 75);
        lblTargetColorS4.Name = "lblTargetColorS4";
        lblTargetColorS4.Size = new System.Drawing.Size(108, 20);
        lblTargetColorS4.TabIndex = 5;
        lblTargetColorS4.Text = "Целевой цвет:";
        //
        // lblTargetPreviewS4
        //
        lblTargetPreviewS4.BackColor = System.Drawing.Color.Red;
        lblTargetPreviewS4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        lblTargetPreviewS4.Location = new System.Drawing.Point(125, 75);
        lblTargetPreviewS4.Name = "lblTargetPreviewS4";
        lblTargetPreviewS4.Size = new System.Drawing.Size(30, 20);
        lblTargetPreviewS4.TabIndex = 6;
        //
        // btnTargetColorS4
        //
        btnTargetColorS4.Location = new Point(165, 70);
        btnTargetColorS4.Name = "btnTargetColorS4";
        btnTargetColorS4.Size = new Size(80, 30);
        btnTargetColorS4.TabIndex = 7;
        btnTargetColorS4.Text = "Пипетка";
        btnTargetColorS4.UseVisualStyleBackColor = true;
        btnTargetColorS4.Click += new EventHandler(btnTargetColorS4_Click);
        //
        // lblExitPixelS4
        //
        lblExitPixelS4.Location = new System.Drawing.Point(6, 110);
        lblExitPixelS4.Name = "lblExitPixelS4";
        lblExitPixelS4.Size = new System.Drawing.Size(108, 23);
        lblExitPixelS4.TabIndex = 8;
        lblExitPixelS4.Text = "Точка выхода (X,Y):";
        //
        // btnExitColorS4
        //
        btnExitColorS4.Location = new System.Drawing.Point(210, 105);
        btnExitColorS4.Name = "btnExitColorS4";
        btnExitColorS4.Size = new System.Drawing.Size(80, 30);
        btnExitColorS4.TabIndex = 9;
        btnExitColorS4.Text = "Пипетка";
        //
        // txtExitX4
        //
        txtExitX4.Location = new System.Drawing.Point(110, 107);
        txtExitX4.Name = "txtExitX4";
        txtExitX4.Size = new System.Drawing.Size(45, 27);
        txtExitX4.TabIndex = 10;
        txtExitX4.Text = "800";
        //
        // txtExitY4
        //
        txtExitY4.Location = new System.Drawing.Point(160, 107);
        txtExitY4.Name = "txtExitY4";
        txtExitY4.Size = new System.Drawing.Size(45, 27);
        txtExitY4.TabIndex = 11;
        txtExitY4.Text = "450";
        //
        // lblExitTolS4
        //
        lblExitTolS4.AutoSize = true;
        lblExitTolS4.Location = new System.Drawing.Point(10, 145);
        lblExitTolS4.Name = "lblExitTolS4";
        lblExitTolS4.Size = new System.Drawing.Size(91, 20);
        lblExitTolS4.TabIndex = 12;
        lblExitTolS4.Text = "Допуск (30):";
        //
        // txtExitTolerance4
        //
        txtExitTolerance4.Location = new System.Drawing.Point(110, 142);
        txtExitTolerance4.Name = "txtExitTolerance4";
        txtExitTolerance4.Size = new System.Drawing.Size(45, 27);
        txtExitTolerance4.TabIndex = 13;
        txtExitTolerance4.Text = "30";
        //
        // lblOffsetS4
        //
        lblOffsetS4.AutoSize = true;
        lblOffsetS4.Location = new System.Drawing.Point(10, 180);
        lblOffsetS4.Name = "lblOffsetS4";
        lblOffsetS4.Size = new System.Drawing.Size(163, 20);
        lblOffsetS4.TabIndex = 14;
        lblOffsetS4.Text = "Смещение клика (X,Y):";
        //
        // txtOffsetX4
        //
        txtOffsetX4.Location = new System.Drawing.Point(179, 177);
        txtOffsetX4.Name = "txtOffsetX4";
        txtOffsetX4.Size = new System.Drawing.Size(45, 27);
        txtOffsetX4.TabIndex = 15;
        txtOffsetX4.Text = "0";
        //
        // txtOffsetY4
        //
        txtOffsetY4.Location = new System.Drawing.Point(229, 177);
        txtOffsetY4.Name = "txtOffsetY4";
        txtOffsetY4.Size = new System.Drawing.Size(45, 27);
        txtOffsetY4.TabIndex = 16;
        txtOffsetY4.Text = "0";
        //
        // lblScanIntervalS4
        //
        lblScanIntervalS4.AutoSize = true;
        lblScanIntervalS4.Location = new System.Drawing.Point(10, 215);
        lblScanIntervalS4.Name = "lblScanIntervalS4";
        lblScanIntervalS4.Size = new System.Drawing.Size(130, 20);
        lblScanIntervalS4.TabIndex = 17;
        lblScanIntervalS4.Text = "Интервал (мс):";
        //
        // txtScanInterval4
        //
        txtScanInterval4.Location = new System.Drawing.Point(145, 212);
        txtScanInterval4.Name = "txtScanInterval4";
        txtScanInterval4.Size = new System.Drawing.Size(45, 27);
        txtScanInterval4.TabIndex = 18;
        txtScanInterval4.Text = "50";
        //
        // btnToggleOverlayS4
        //
        btnToggleOverlayS4.Location = new System.Drawing.Point(10, 265);
        btnToggleOverlayS4.Name = "btnToggleOverlayS4";
        btnToggleOverlayS4.Size = new System.Drawing.Size(310, 35);
        btnToggleOverlayS4.TabIndex = 19;
        btnToggleOverlayS4.Text = "Отрисовка зон (Вкл/Выкл)";
        btnToggleOverlayS4.UseVisualStyleBackColor = true;
        btnToggleOverlayS4.Click += BtnToggleOverlay_Click;
        //
        // lblStartColor
        //
        lblStartColor.BackColor = System.Drawing.Color.Black;
        lblStartColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        lblStartColor.Location = new System.Drawing.Point(65, 62);
        lblStartColor.Name = "lblStartColor";
        lblStartColor.Size = new System.Drawing.Size(30, 25);
        lblStartColor.TabIndex = 24;
        //
        // lblCurrentColor
        //
        lblCurrentColor.BackColor = System.Drawing.Color.Black;
        lblCurrentColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        lblCurrentColor.Location = new System.Drawing.Point(165, 62);
        lblCurrentColor.Name = "lblCurrentColor";
        lblCurrentColor.Size = new System.Drawing.Size(30, 25);
        lblCurrentColor.TabIndex = 26;
        //
        // lblStartColorTitle
        //
        lblStartColorTitle.AutoSize = true;
        lblStartColorTitle.Location = new System.Drawing.Point(10, 65);
        lblStartColorTitle.Name = "lblStartColorTitle";
        lblStartColorTitle.Size = new System.Drawing.Size(50, 20);
        lblStartColorTitle.TabIndex = 23;
        lblStartColorTitle.Text = "Старт:";
        //
        // lblCurrentColorTitle
        //
        lblCurrentColorTitle.AutoSize = true;
        lblCurrentColorTitle.Location = new System.Drawing.Point(110, 65);
        lblCurrentColorTitle.Name = "lblCurrentColorTitle";
        lblCurrentColorTitle.Size = new System.Drawing.Size(35, 20);
        lblCurrentColorTitle.TabIndex = 25;
        lblCurrentColorTitle.Text = "Тек:";
        //
        // btnReset
        //
        btnReset.Location = new System.Drawing.Point(180, 445);
        btnReset.Name = "btnReset";
        btnReset.Size = new System.Drawing.Size(140, 35);
        btnReset.TabIndex = 21;
        btnReset.Text = "Сброс (Дефолт)";
        btnReset.UseVisualStyleBackColor = true;
        btnReset.Click += btnReset_Click;
        //
        // btnApplyRect
        //
        btnApplyRect.Location = new System.Drawing.Point(10, 445);
        btnApplyRect.Name = "btnApplyRect";
        btnApplyRect.Size = new System.Drawing.Size(160, 35);
        btnApplyRect.TabIndex = 12;
        btnApplyRect.Text = "Применить координаты";
        btnApplyRect.UseVisualStyleBackColor = true;
        btnApplyRect.Click += btnApplyRect_Click;
        //
        // Form1
        //
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackColor = System.Drawing.SystemColors.Control;
        ClientSize = new System.Drawing.Size(464, 771);
        Controls.Add(groupBoxSettings);
        Controls.Add(lblLamp4);
        Controls.Add(chkStage4);
        Controls.Add(lblLamp3);
        Controls.Add(chkStage3);
        Controls.Add(lblLamp2);
        Controls.Add(chkStage2);
        Controls.Add(lblLamp1);
        Controls.Add(chkStage1);
        Controls.Add(lblGlobalStatus);
        Controls.Add(btnStartStop);
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
        MaximizeBox = false;
        Text = "Forge Bot";
        TopMost = true;
        groupBoxSettings.ResumeLayout(false);
        groupBoxSettings.PerformLayout();
        tabControlSettings.ResumeLayout(false);
        tabPageStage1.ResumeLayout(false);
        tabPageStage1.PerformLayout();
        tabPageStage2.ResumeLayout(false);
        tabPageStage2.PerformLayout();
        tabPageStage3.ResumeLayout(false);
        tabPageStage3.PerformLayout();
        tabPageStage4.ResumeLayout(false);
        tabPageStage4.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private System.Windows.Forms.Button btnStartStop;
    private System.Windows.Forms.Label lblGlobalStatus;
    private System.Windows.Forms.CheckBox chkStage1;
    private System.Windows.Forms.Label lblLamp1;
    private System.Windows.Forms.CheckBox chkStage2;
    private System.Windows.Forms.Label lblLamp2;
    private System.Windows.Forms.CheckBox chkStage3;
    private System.Windows.Forms.Label lblLamp3;
    private System.Windows.Forms.CheckBox chkStage4;
    private System.Windows.Forms.Label lblLamp4;
    private System.Windows.Forms.GroupBox groupBoxSettings;
    private System.Windows.Forms.Label lblTargetColor;
    private System.Windows.Forms.Label lblColorPreview;
    private System.Windows.Forms.Button btnChooseColor;
    private System.Windows.Forms.Label lblSearchRect;
    private System.Windows.Forms.TextBox txtRectX;
    private System.Windows.Forms.TextBox txtRectY;
    private System.Windows.Forms.TextBox txtRectW;
    private System.Windows.Forms.TextBox txtRectH;
    private System.Windows.Forms.Label lblX;
    private System.Windows.Forms.Label lblY;
    private System.Windows.Forms.Label lblW;
    private System.Windows.Forms.Label lblH;
    private System.Windows.Forms.Button btnApplyRect;
    private System.Windows.Forms.Label lblDist;
    private System.Windows.Forms.TextBox _txtDragDist;
    private System.Windows.Forms.Label lblSpeed;
    private System.Windows.Forms.TextBox _txtDragSpeed;
    private System.Windows.Forms.Label lblOffset;
    private System.Windows.Forms.TextBox _txtDragOffset;
    private System.Windows.Forms.Label lblTolerance;
    private System.Windows.Forms.TextBox _txtColorTolerance;
    private System.Windows.Forms.Button btnReset;
    private System.Windows.Forms.Button btnToggleOverlay;
    private System.Windows.Forms.Label lblStartColor;
    private System.Windows.Forms.Label lblCurrentColor;
    private System.Windows.Forms.Label lblStartColorTitle;
    private System.Windows.Forms.Label lblCurrentColorTitle;
    private System.Windows.Forms.TabControl tabControlSettings;
    private System.Windows.Forms.TabPage tabPageStage1;
    private System.Windows.Forms.TabPage tabPageStage2;
    private System.Windows.Forms.TabPage tabPageStage3;
    private System.Windows.Forms.TabPage tabPageStage4;
    // Stage 2 Controls
    private System.Windows.Forms.Label lblSearchRectS2;
    private System.Windows.Forms.TextBox txtRectX2;
    private System.Windows.Forms.TextBox txtRectY2;
    private System.Windows.Forms.TextBox txtRectW2;
    private System.Windows.Forms.TextBox txtRectH2;
    private System.Windows.Forms.Label lblCheckPixelS2;
    private System.Windows.Forms.TextBox txtCheckX2;
    private System.Windows.Forms.TextBox txtCheckY2;
    private System.Windows.Forms.Label lblTolS2;
    private System.Windows.Forms.TextBox txtTolerance2;
    private System.Windows.Forms.Label lblSliderColor;
    private System.Windows.Forms.Label lblSliderPreview;
    private System.Windows.Forms.Button btnSliderColor;
    private System.Windows.Forms.Label lblZoneColor;
    private System.Windows.Forms.Label lblZonePreview;
    private System.Windows.Forms.Button btnZoneColor;
    private System.Windows.Forms.Button btnToggleOverlayS2;
    // Stage 3 Controls
    private System.Windows.Forms.Label lblCheckPixelS3;
    private System.Windows.Forms.TextBox txtCheckX3;
    private System.Windows.Forms.TextBox txtCheckY3;
    private System.Windows.Forms.Label lblClickCountS3;
    private System.Windows.Forms.TextBox txtClickCount3;
    private System.Windows.Forms.Label lblClickIntervalS3;
    private System.Windows.Forms.TextBox txtClickInterval3;
    private System.Windows.Forms.Button btnToggleOverlayS3;
    // Stage 4 Controls
    private System.Windows.Forms.Label lblSearchRectS4;
    private System.Windows.Forms.TextBox txtRectX4;
    private System.Windows.Forms.TextBox txtRectY4;
    private System.Windows.Forms.TextBox txtRectW4;
    private System.Windows.Forms.TextBox txtRectH4;
    private System.Windows.Forms.Label lblTargetColorS4;
    private System.Windows.Forms.Label lblTargetPreviewS4;
    private System.Windows.Forms.Button btnTargetColorS4;
    private System.Windows.Forms.Label lblExitColorS4;
    private System.Windows.Forms.Label lblExitPixelS4;
    private System.Windows.Forms.Button btnExitColorS4;
    private System.Windows.Forms.TextBox txtExitX4;
    private System.Windows.Forms.TextBox txtExitY4;
    private System.Windows.Forms.Label lblExitTolS4;
    private System.Windows.Forms.TextBox txtExitTolerance4;
    private System.Windows.Forms.Label lblOffsetS4;
    private System.Windows.Forms.TextBox txtOffsetX4;
    private System.Windows.Forms.TextBox txtOffsetY4;
    private System.Windows.Forms.Button btnToggleOverlayS4;
    private System.Windows.Forms.Label lblDelayS1;
    private System.Windows.Forms.TextBox txtDelayS1;
    private System.Windows.Forms.Label lblDelayS2;
    private System.Windows.Forms.TextBox txtDelayS2;
    private System.Windows.Forms.Label lblDelayS3;
    private System.Windows.Forms.TextBox txtDelayS3;
    private System.Windows.Forms.Label lblScanIntervalS4;
    private System.Windows.Forms.TextBox txtScanInterval4;
}