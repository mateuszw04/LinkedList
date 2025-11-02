namespace LinkedList
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
            btnPrzed = new Button();
            UpDownValue = new NumericUpDown();
            btnPo = new Button();
            label1 = new Label();
            label2 = new Label();
            UpDownIndex = new NumericUpDown();
            label3 = new Label();
            listBox1 = new ListBox();
            listBox2 = new ListBox();
            ((System.ComponentModel.ISupportInitialize)UpDownValue).BeginInit();
            ((System.ComponentModel.ISupportInitialize)UpDownIndex).BeginInit();
            SuspendLayout();
            // 
            // btnPrzed
            // 
            btnPrzed.Location = new Point(418, 12);
            btnPrzed.Name = "btnPrzed";
            btnPrzed.Size = new Size(170, 23);
            btnPrzed.TabIndex = 1;
            btnPrzed.Text = "Dodaj Przed";
            btnPrzed.UseVisualStyleBackColor = true;
            btnPrzed.Click += btnPrzed_Click_1;
            // 
            // UpDownValue
            // 
            UpDownValue.Location = new Point(274, 12);
            UpDownValue.Name = "UpDownValue";
            UpDownValue.Size = new Size(120, 23);
            UpDownValue.TabIndex = 2;
            // 
            // btnPo
            // 
            btnPo.Location = new Point(418, 43);
            btnPo.Name = "btnPo";
            btnPo.Size = new Size(170, 23);
            btnPo.TabIndex = 3;
            btnPo.Text = "Dodaj Po";
            btnPo.UseVisualStyleBackColor = true;
            btnPo.Click += btnPo_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(274, 93);
            label1.Name = "label1";
            label1.Size = new Size(0, 15);
            label1.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(208, 16);
            label2.Name = "label2";
            label2.Size = new Size(50, 15);
            label2.TabIndex = 5;
            label2.Text = "Wartosc";
            // 
            // UpDownIndex
            // 
            UpDownIndex.Location = new Point(274, 43);
            UpDownIndex.Name = "UpDownIndex";
            UpDownIndex.Size = new Size(120, 23);
            UpDownIndex.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(217, 45);
            label3.Name = "label3";
            label3.Size = new Size(41, 15);
            label3.TabIndex = 7;
            label3.Text = "Indeks";
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(418, 93);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(120, 109);
            listBox1.TabIndex = 8;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // listBox2
            // 
            listBox2.FormattingEnabled = true;
            listBox2.ItemHeight = 15;
            listBox2.Location = new Point(274, 93);
            listBox2.Name = "listBox2";
            listBox2.Size = new Size(120, 109);
            listBox2.TabIndex = 8;
            listBox2.SelectedIndexChanged += listBox2_SelectedIndexChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(listBox2);
            Controls.Add(listBox1);
            Controls.Add(label3);
            Controls.Add(UpDownIndex);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnPo);
            Controls.Add(UpDownValue);
            Controls.Add(btnPrzed);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)UpDownValue).EndInit();
            ((System.ComponentModel.ISupportInitialize)UpDownIndex).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnPrzed;
        private NumericUpDown UpDownValue;
        private Button btnPo;
        private Label label1;
        private Label label2;
        private NumericUpDown UpDownIndex;
        private Label label3;
        private ListBox listBox1;
        private ListBox listBox2;
    }
}
