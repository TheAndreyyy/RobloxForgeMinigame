import re

path = 'Form1.Designer.cs'
with open(path, 'r', encoding='utf-8') as f:
    text = f.read()

# Fields to add
fields = '''
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
'''

if 'btnReset;' not in text:
    text = text.replace('private System.Windows.Forms.Button btnApplyRect;', 'private System.Windows.Forms.Button btnApplyRect;' + fields)

init_block = '''
        lblDist = new System.Windows.Forms.Label();
        _txtDragDist = new System.Windows.Forms.TextBox();
        lblSpeed = new System.Windows.Forms.Label();
        _txtDragSpeed = new System.Windows.Forms.TextBox();
        lblOffset = new System.Windows.Forms.Label();
        _txtDragOffset = new System.Windows.Forms.TextBox();
        lblTolerance = new System.Windows.Forms.Label();
        _txtColorTolerance = new System.Windows.Forms.TextBox();
        btnReset = new System.Windows.Forms.Button();
        btnToggleOverlay = new System.Windows.Forms.Button();
'''
if 'btnReset = new System.Windows.Forms.Button();' not in text:
    text = text.replace('btnApplyRect = new System.Windows.Forms.Button();', 'btnApplyRect = new System.Windows.Forms.Button();' + init_block)

controls_block = '''
        groupBoxSettings.Controls.Add(lblDist);
        groupBoxSettings.Controls.Add(_txtDragDist);
        groupBoxSettings.Controls.Add(lblSpeed);
        groupBoxSettings.Controls.Add(_txtDragSpeed);
        groupBoxSettings.Controls.Add(lblOffset);
        groupBoxSettings.Controls.Add(_txtDragOffset);
        groupBoxSettings.Controls.Add(lblTolerance);
        groupBoxSettings.Controls.Add(_txtColorTolerance);
        groupBoxSettings.Controls.Add(btnReset);
        groupBoxSettings.Controls.Add(btnToggleOverlay);
'''

if 'groupBoxSettings.Controls.Add(lblDist);' not in text:
    text = text.replace('groupBoxSettings.Controls.Add(btnApplyRect);', controls_block + '\n        groupBoxSettings.Controls.Add(btnApplyRect);')

props_block = '''
        // 
        // lblDist
        // 
        lblDist.AutoSize = true;
        lblDist.Location = new System.Drawing.Point(10, 25);
        lblDist.Name = "lblDist";
        lblDist.Size = new System.Drawing.Size(59, 20);
        lblDist.TabIndex = 13;
        lblDist.Text = "Размах:";
        // 
        // _txtDragDist
        // 
        _txtDragDist.Location = new System.Drawing.Point(65, 22);
        _txtDragDist.Name = "_txtDragDist";
        _txtDragDist.Size = new System.Drawing.Size(40, 27);
        _txtDragDist.TabIndex = 14;
        _txtDragDist.Text = "200";
        // 
        // lblSpeed
        // 
        lblSpeed.AutoSize = true;
        lblSpeed.Location = new System.Drawing.Point(115, 25);
        lblSpeed.Name = "lblSpeed";
        lblSpeed.Size = new System.Drawing.Size(46, 20);
        lblSpeed.TabIndex = 15;
        lblSpeed.Text = "Скор:";
        // 
        // _txtDragSpeed
        // 
        _txtDragSpeed.Location = new System.Drawing.Point(160, 22);
        _txtDragSpeed.Name = "_txtDragSpeed";
        _txtDragSpeed.Size = new System.Drawing.Size(40, 27);
        _txtDragSpeed.TabIndex = 16;
        _txtDragSpeed.Text = "25";
        // 
        // lblOffset
        // 
        lblOffset.AutoSize = true;
        lblOffset.Location = new System.Drawing.Point(210, 25);
        lblOffset.Name = "lblOffset";
        lblOffset.Size = new System.Drawing.Size(51, 20);
        lblOffset.TabIndex = 17;
        lblOffset.Text = "Смещ:";
        // 
        // _txtDragOffset
        // 
        _txtDragOffset.Location = new System.Drawing.Point(260, 22);
        _txtDragOffset.Name = "_txtDragOffset";
        _txtDragOffset.Size = new System.Drawing.Size(40, 27);
        _txtDragOffset.TabIndex = 18;
        _txtDragOffset.Text = "0";
        // 
        // lblTolerance
        // 
        lblTolerance.AutoSize = true;
        lblTolerance.Location = new System.Drawing.Point(10, 165);
        lblTolerance.Name = "lblTolerance";
        lblTolerance.Size = new System.Drawing.Size(117, 20);
        lblTolerance.TabIndex = 19;
        lblTolerance.Text = "Дельта (0-765):";
        // 
        // _txtColorTolerance
        // 
        _txtColorTolerance.Location = new System.Drawing.Point(135, 162);
        _txtColorTolerance.Name = "_txtColorTolerance";
        _txtColorTolerance.Size = new System.Drawing.Size(50, 27);
        _txtColorTolerance.TabIndex = 20;
        _txtColorTolerance.Text = "30";
        // 
        // btnReset
        // 
        btnReset.Location = new System.Drawing.Point(180, 200);
        btnReset.Name = "btnReset";
        btnReset.Size = new System.Drawing.Size(140, 35);
        btnReset.TabIndex = 21;
        btnReset.Text = "Сброс (Дефолт)";
        btnReset.UseVisualStyleBackColor = true;
        btnReset.Click += new System.EventHandler(this.btnReset_Click);
        // 
        // btnToggleOverlay
        // 
        btnToggleOverlay.Location = new System.Drawing.Point(10, 240);
        btnToggleOverlay.Name = "btnToggleOverlay";
        btnToggleOverlay.Size = new System.Drawing.Size(310, 35);
        btnToggleOverlay.TabIndex = 22;
        btnToggleOverlay.Text = "Отрисовка зон (Вкл/Выкл)";
        btnToggleOverlay.UseVisualStyleBackColor = true;
        btnToggleOverlay.Click += new System.EventHandler(this.BtnToggleOverlay_Click);
'''

# Update button rect and labels
text = re.sub(r'btnApplyRect\.Location = new System\.Drawing\.Point\([^)]+\);', r'btnApplyRect.Location = new System.Drawing.Point(10, 200);', text)
text = re.sub(r'btnApplyRect\.Size = new System\.Drawing\.Size\([^)]+\);', r'btnApplyRect.Size = new System.Drawing.Size(160, 35);', text)

text = re.sub(r'lblSearchRect\.Text = "[^"]+";', r'lblSearchRect.Text = "Настройки (Цвет / Свайп):";', text)

text = re.sub(r'lblX\.Text = "X:";', r'lblX.Text = "Цвет X:";', text)
text = re.sub(r'lblX\.Location = new System\.Drawing\.Point\([^)]+\);', r'lblX.Location = new System.Drawing.Point(10, 95);', text)
text = re.sub(r'txtRectX\.Location = new System\.Drawing\.Point\([^)]+\);', r'txtRectX.Location = new System.Drawing.Point(70, 92);', text)
text = re.sub(r'txtRectX\.Size = new System\.Drawing\.Size\([^)]+\);', r'txtRectX.Size = new System.Drawing.Size(50, 27);', text)

text = re.sub(r'lblY\.Text = "Y:";', r'lblY.Text = "Цвет Y:";', text)
text = re.sub(r'lblY\.Location = new System\.Drawing\.Point\([^)]+\);', r'lblY.Location = new System.Drawing.Point(130, 95);', text)
text = re.sub(r'txtRectY\.Location = new System\.Drawing\.Point\([^)]+\);', r'txtRectY.Location = new System.Drawing.Point(185, 92);', text)
text = re.sub(r'txtRectY\.Size = new System\.Drawing\.Size\([^)]+\);', r'txtRectY.Size = new System.Drawing.Size(50, 27);', text)

text = re.sub(r'lblW\.Text = "W:";', r'lblW.Text = "Зажим X:";', text)
text = re.sub(r'lblW\.Location = new System\.Drawing\.Point\([^)]+\);', r'lblW.Location = new System.Drawing.Point(10, 130);', text)
text = re.sub(r'txtRectW\.Location = new System\.Drawing\.Point\([^)]+\);', r'txtRectW.Location = new System.Drawing.Point(85, 127);', text)
text = re.sub(r'txtRectW\.Size = new System\.Drawing\.Size\([^)]+\);', r'txtRectW.Size = new System.Drawing.Size(50, 27);', text)

text = re.sub(r'lblH\.Text = "H:";', r'lblH.Text = "Зажим Y:";', text)
text = re.sub(r'lblH\.Location = new System\.Drawing\.Point\([^)]+\);', r'lblH.Location = new System.Drawing.Point(145, 130);', text)
text = re.sub(r'txtRectH\.Location = new System\.Drawing\.Point\([^)]+\);', r'txtRectH.Location = new System.Drawing.Point(215, 127);', text)
text = re.sub(r'txtRectH\.Size = new System\.Drawing\.Size\([^)]+\);', r'txtRectH.Size = new System.Drawing.Size(50, 27);', text)

# Insert props block
if 'lblDist.AutoSize' not in text:
    text = text.replace('// \n        // Form1', props_block + '\n        // \n        // Form1')

with open(path, 'w', encoding='utf-8') as f:
    f.write(text)
print("UPDATED")
