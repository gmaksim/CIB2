namespace NlgDBcredProg
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button6 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button13 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.button12 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(256, 540);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(240, 22);
            this.button6.TabIndex = 4;
            this.button6.Text = "Поиск (ФИО, ИНН)";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.searchForm_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(856, 394);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 142);
            this.button3.TabIndex = 6;
            this.button3.Text = "Список доп.сог. и группы объектов З/П";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.spis_dop_sog_and__gr_obj_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(175, 7);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(22, 21);
            this.button4.TabIndex = 7;
            this.button4.Text = "С";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.saveName_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(438, 191);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(25, 21);
            this.button8.TabIndex = 10;
            this.button8.Text = "С";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.saveKredDocum_Click);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(693, 191);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(23, 21);
            this.button10.TabIndex = 15;
            this.button10.Text = "С";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.saveZalogPoruch_Click);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(381, 369);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(25, 21);
            this.button11.TabIndex = 16;
            this.button11.Text = "С";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.saveOsnovnSd_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(10, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 20);
            this.label1.TabIndex = 18;
            this.label1.Text = "НАИМЕНОВАНИЕ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(502, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(357, 15);
            this.label3.TabIndex = 20;
            this.label3.Text = "Список доп.соглашений и основная сделка (выдача)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(253, 193);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(179, 15);
            this.label4.TabIndex = 21;
            this.label4.Text = "Кредитная документация";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(502, 193);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(185, 15);
            this.label5.TabIndex = 22;
            this.label5.Text = "Залогодатели/Поручители";
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(865, 7);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(25, 21);
            this.button13.TabIndex = 25;
            this.button13.Text = "С";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.saveOsnSdelkVdch_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(253, 371);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(122, 15);
            this.label8.TabIndex = 27;
            this.label8.Text = "Основная сделка";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(56, 540);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(110, 20);
            this.textBox1.TabIndex = 29;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(253, 11);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(157, 15);
            this.label7.TabIndex = 30;
            this.label7.Text = "Кредитный договор №";
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(416, 9);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(23, 21);
            this.button12.TabIndex = 31;
            this.button12.Text = "С";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.saveKredDog_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(856, 215);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 150);
            this.button2.TabIndex = 32;
            this.button2.Text = "Документы заемщика и участников сделки";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.DocumentsForm_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.PeachPuff;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(11, 543);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 15);
            this.label2.TabIndex = 33;
            this.label2.Text = "Имя:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.PeachPuff;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(172, 543);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(25, 15);
            this.label6.TabIndex = 34;
            this.label6.Text = "ID:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(203, 539);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(38, 20);
            this.textBox2.TabIndex = 35;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Cornsilk;
            this.ClientSize = new System.Drawing.Size(1068, 741);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.button13);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button6);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "CIB - Основное окно";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected internal System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox2;
    }
}

