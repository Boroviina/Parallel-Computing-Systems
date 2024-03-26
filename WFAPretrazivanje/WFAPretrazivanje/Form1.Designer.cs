namespace WFAPretrazivanje
{
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            toolTipClear = new ToolTip(components);
            label3 = new Label();
            btnClear = new Button();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            logoviRtxt = new RichTextBox();
            rbtnSekvencijalno = new RadioButton();
            rbtnParalelno = new RadioButton();
            txtPojamZaPretragu = new TextBox();
            toolStrip1 = new ToolStrip();
            toolStripButton1 = new ToolStripButton();
            toolStripButton2 = new ToolStripButton();
            button1 = new Button();
            tredoviTxt = new Label();
            pronadjeniFajloviTxt = new Label();
            txtUkupanBroj = new TextBox();
            txtVrijeme = new TextBox();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(42, 33);
            label3.Name = "label3";
            label3.Size = new Size(61, 20);
            label3.TabIndex = 5;
            label3.Text = "Tredovi:";
            // 
            // btnClear
            // 
            btnClear.Location = new Point(667, 81);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(94, 29);
            btnClear.TabIndex = 6;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(20, 84);
            label4.Name = "label4";
            label4.Size = new Size(83, 20);
            label4.TabIndex = 7;
            label4.Text = "Ukupan br.:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(295, 84);
            label5.Name = "label5";
            label5.Size = new Size(128, 20);
            label5.TabIndex = 10;
            label5.Text = "Pronadjeni fajlovi:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(24, 119);
            label6.Name = "label6";
            label6.Size = new Size(62, 20);
            label6.TabIndex = 11;
            label6.Text = "Vrijeme:";
            // 
            // logoviRtxt
            // 
            logoviRtxt.Location = new Point(20, 195);
            logoviRtxt.Name = "logoviRtxt";
            logoviRtxt.Size = new Size(768, 226);
            logoviRtxt.TabIndex = 13;
            logoviRtxt.Text = "";
            // 
            // rbtnSekvencijalno
            // 
            rbtnSekvencijalno.AutoSize = true;
            rbtnSekvencijalno.Location = new Point(295, 119);
            rbtnSekvencijalno.Name = "rbtnSekvencijalno";
            rbtnSekvencijalno.Size = new Size(120, 24);
            rbtnSekvencijalno.TabIndex = 14;
            rbtnSekvencijalno.TabStop = true;
            rbtnSekvencijalno.Text = "Sekvencijalno";
            rbtnSekvencijalno.UseVisualStyleBackColor = true;
            // 
            // rbtnParalelno
            // 
            rbtnParalelno.AutoSize = true;
            rbtnParalelno.Location = new Point(447, 117);
            rbtnParalelno.Name = "rbtnParalelno";
            rbtnParalelno.Size = new Size(91, 24);
            rbtnParalelno.TabIndex = 15;
            rbtnParalelno.TabStop = true;
            rbtnParalelno.Text = "Paralelno";
            rbtnParalelno.UseVisualStyleBackColor = true;
            rbtnParalelno.MouseDown += rbtnParalelno_MouseDown;
            // 
            // txtPojamZaPretragu
            // 
            txtPojamZaPretragu.Location = new Point(24, 162);
            txtPojamZaPretragu.Name = "txtPojamZaPretragu";
            txtPojamZaPretragu.Size = new Size(628, 27);
            txtPojamZaPretragu.TabIndex = 16;
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripButton1, toolStripButton2 });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(800, 27);
            toolStrip1.TabIndex = 17;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            toolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripButton1.Image = (Image)resources.GetObject("toolStripButton1.Image");
            toolStripButton1.ImageTransparentColor = Color.Magenta;
            toolStripButton1.Name = "toolStripButton1";
            toolStripButton1.Size = new Size(99, 24);
            toolStripButton1.Text = "Select Folder";
            toolStripButton1.Click += selectFolderToolStripMenuItem_Click;
            // 
            // toolStripButton2
            // 
            toolStripButton2.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripButton2.Image = (Image)resources.GetObject("toolStripButton2.Image");
            toolStripButton2.ImageTransparentColor = Color.Magenta;
            toolStripButton2.Name = "toolStripButton2";
            toolStripButton2.Size = new Size(42, 24);
            toolStripButton2.Text = "EXIT";
            toolStripButton2.Click += exitToolStripMenuItem_Click;
            // 
            // button1
            // 
            button1.Location = new Point(677, 162);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 18;
            button1.Text = "Pretraga";
            button1.UseVisualStyleBackColor = true;
            button1.Click += btnPretraga_Click;
            // 
            // tredoviTxt
            // 
            tredoviTxt.AutoSize = true;
            tredoviTxt.Location = new Point(126, 33);
            tredoviTxt.Name = "tredoviTxt";
            tredoviTxt.Size = new Size(0, 20);
            tredoviTxt.TabIndex = 19;
            // 
            // pronadjeniFajloviTxt
            // 
            pronadjeniFajloviTxt.AutoSize = true;
            pronadjeniFajloviTxt.Location = new Point(447, 84);
            pronadjeniFajloviTxt.Name = "pronadjeniFajloviTxt";
            pronadjeniFajloviTxt.Size = new Size(0, 20);
            pronadjeniFajloviTxt.TabIndex = 20;
            // 
            // txtUkupanBroj
            // 
            txtUkupanBroj.Location = new Point(109, 77);
            txtUkupanBroj.Name = "txtUkupanBroj";
            txtUkupanBroj.Size = new Size(166, 27);
            txtUkupanBroj.TabIndex = 21;
            // 
            // txtVrijeme
            // 
            txtVrijeme.Location = new Point(92, 112);
            txtVrijeme.Name = "txtVrijeme";
            txtVrijeme.Size = new Size(183, 27);
            txtVrijeme.TabIndex = 22;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txtVrijeme);
            Controls.Add(txtUkupanBroj);
            Controls.Add(pronadjeniFajloviTxt);
            Controls.Add(tredoviTxt);
            Controls.Add(button1);
            Controls.Add(toolStrip1);
            Controls.Add(txtPojamZaPretragu);
            Controls.Add(rbtnParalelno);
            Controls.Add(rbtnSekvencijalno);
            Controls.Add(logoviRtxt);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(btnClear);
            Controls.Add(label3);
            Name = "Form1";
            Text = "Form1";
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolTip toolTipClear;
        private Label label3;
        private Button btnClear;
        private Label label4;
        private Label label5;
        private Label label6;
        private RichTextBox logoviRtxt;
        private RadioButton rbtnSekvencijalno;
        private RadioButton rbtnParalelno;
        private TextBox txtPojamZaPretragu;
        private ToolStrip toolStrip1;
        private ToolStripButton toolStripButton1;
        private Button button1;
        private ToolStripButton toolStripButton2;
        private Label tredoviTxt;
        private Label pronadjeniFajloviTxt;
        private TextBox txtUkupanBroj;
        private TextBox txtVrijeme;
    }
}
