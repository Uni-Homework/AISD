namespace lab_12_forms;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        txtInput = new TextBox();
        listBoxResults = new ListBox();
        btnLoadDictionary = new Button();
        btnFindClosest = new Button();
        SuspendLayout();
        // 
        // txtInput
        // 
        txtInput.Location = new Point(12, 13);
        txtInput.Name = "txtInput";
        txtInput.Size = new Size(187, 23);
        txtInput.TabIndex = 0;
        // 
        // listBoxResults
        // 
        listBoxResults.FormattingEnabled = true;
        listBoxResults.ItemHeight = 15;
        listBoxResults.Location = new Point(12, 41);
        listBoxResults.Name = "listBoxResults";
        listBoxResults.Size = new Size(616, 394);
        listBoxResults.TabIndex = 1;
        // 
        // btnLoadDictionary
        // 
        btnLoadDictionary.Location = new Point(482, 12);
        btnLoadDictionary.Name = "btnLoadDictionary";
        btnLoadDictionary.Size = new Size(146, 23);
        btnLoadDictionary.TabIndex = 2;
        btnLoadDictionary.Text = "Подгрузить словарь";
        btnLoadDictionary.UseVisualStyleBackColor = true;
        btnLoadDictionary.Click += btnLoadDictionary_Click;
        // 
        // btnFindClosest
        // 
        btnFindClosest.Location = new Point(205, 13);
        btnFindClosest.Name = "btnFindClosest";
        btnFindClosest.Size = new Size(61, 23);
        btnFindClosest.TabIndex = 3;
        btnFindClosest.Text = "Найти";
        btnFindClosest.UseVisualStyleBackColor = true;
        btnFindClosest.Click += btnFindClosest_Click;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(640, 450);
        Controls.Add(btnFindClosest);
        Controls.Add(btnLoadDictionary);
        Controls.Add(listBoxResults);
        Controls.Add(txtInput);
        Name = "Form1";
        Text = "Form1";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private TextBox txtInput;
    private ListBox listBoxResults;
    private Button btnLoadDictionary;
    private Button btnFindClosest;
}