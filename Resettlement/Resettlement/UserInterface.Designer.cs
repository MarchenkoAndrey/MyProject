namespace Resettlement
{
    partial class UserInterface
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
            this.greedy_btn = new System.Windows.Forms.Button();
            this.fullSearch_btn = new System.Windows.Forms.Button();
            this.labelOne = new System.Windows.Forms.Label();
            this.squareOne_input = new System.Windows.Forms.TextBox();
            this.labelTwo = new System.Windows.Forms.Label();
            this.squareTwo_input = new System.Windows.Forms.TextBox();
            this.labelCountFloor = new System.Windows.Forms.Label();
            this.lossesTwo_label = new System.Windows.Forms.Label();
            this.lossesOne_label = new System.Windows.Forms.Label();
            this.realizat_label = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            UserInterface.resultFullSearch_label = new System.Windows.Forms.Label();
            UserInterface.resultGreedy_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // greedy_btn
            // 
            this.greedy_btn.Location = new System.Drawing.Point(289, 134);
            this.greedy_btn.Name = "greedy_btn";
            this.greedy_btn.Size = new System.Drawing.Size(119, 23);
            this.greedy_btn.TabIndex = 0;
            this.greedy_btn.Text = "Жадный алгоритм";
            this.greedy_btn.UseVisualStyleBackColor = true;
            this.greedy_btn.Click += new System.EventHandler(this.greedy_btn_Click);
            // 
            // fullSearch_btn
            // 
            this.fullSearch_btn.Location = new System.Drawing.Point(425, 134);
            this.fullSearch_btn.Name = "fullSearch_btn";
            this.fullSearch_btn.Size = new System.Drawing.Size(117, 23);
            this.fullSearch_btn.TabIndex = 1;
            this.fullSearch_btn.Text = "Полный перебор";
            this.fullSearch_btn.UseVisualStyleBackColor = true;
            this.fullSearch_btn.Click += new System.EventHandler(this.fullSearch_btn_Click);
            // 
            // labelOne
            // 
            this.labelOne.AutoSize = true;
            this.labelOne.Location = new System.Drawing.Point(26, 45);
            this.labelOne.Name = "labelOne";
            this.labelOne.Size = new System.Drawing.Size(251, 13);
            this.labelOne.TabIndex = 2;
            this.labelOne.Text = "Введите площади однокомнатных через пробел";
            this.labelOne.Click += new System.EventHandler(this.labelOne_Click);
            // 
            // squareOne_input
            // 
            this.squareOne_input.Location = new System.Drawing.Point(289, 42);
            this.squareOne_input.Name = "squareOne_input";
            this.squareOne_input.Size = new System.Drawing.Size(253, 20);
            this.squareOne_input.TabIndex = 3;
            this.squareOne_input.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // labelTwo
            // 
            this.labelTwo.AutoSize = true;
            this.labelTwo.Location = new System.Drawing.Point(26, 83);
            this.labelTwo.Name = "labelTwo";
            this.labelTwo.Size = new System.Drawing.Size(249, 13);
            this.labelTwo.TabIndex = 4;
            this.labelTwo.Text = "Введите площади двухкомнатных через пробел";
            // 
            // squareTwo_input
            // 
            this.squareTwo_input.Location = new System.Drawing.Point(289, 80);
            this.squareTwo_input.Name = "squareTwo_input";
            this.squareTwo_input.Size = new System.Drawing.Size(253, 20);
            this.squareTwo_input.TabIndex = 5;
            this.squareTwo_input.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // labelCountFloor
            // 
            this.labelCountFloor.AutoSize = true;
            this.labelCountFloor.Location = new System.Drawing.Point(26, 112);
            this.labelCountFloor.Name = "labelCountFloor";
            this.labelCountFloor.Size = new System.Drawing.Size(158, 13);
            this.labelCountFloor.TabIndex = 6;
            this.labelCountFloor.Text = "Выберите количество этажей";
            this.labelCountFloor.Click += new System.EventHandler(this.label1_Click);
            // 
            // lossesTwo_label
            // 
            this.lossesTwo_label.AutoSize = true;
            this.lossesTwo_label.Location = new System.Drawing.Point(23, 229);
            this.lossesTwo_label.Name = "lossesTwo_label";
            this.lossesTwo_label.Size = new System.Drawing.Size(0, 13);
            this.lossesTwo_label.TabIndex = 9;
            // 
            // lossesOne_label
            // 
            this.lossesOne_label.AutoSize = true;
            this.lossesOne_label.Location = new System.Drawing.Point(23, 207);
            this.lossesOne_label.Name = "lossesOne_label";
            this.lossesOne_label.Size = new System.Drawing.Size(0, 13);
            this.lossesOne_label.TabIndex = 8;
            // 
            // realizat_label
            // 
            this.realizat_label.AutoSize = true;
            this.realizat_label.Location = new System.Drawing.Point(23, 180);
            this.realizat_label.Name = "realizat_label";
            this.realizat_label.Size = new System.Drawing.Size(0, 13);
            this.realizat_label.TabIndex = 10;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(190, 112);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(60, 17);
            this.radioButton1.TabIndex = 17;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "1 Этаж";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(190, 134);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(66, 17);
            this.radioButton2.TabIndex = 18;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "2 Этажа";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(190, 158);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(66, 17);
            this.radioButton3.TabIndex = 19;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "3 Этажа";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // resultFullSearch_label2
            // 
            UserInterface.resultFullSearch_label.AutoSize = true;
            UserInterface.resultFullSearch_label.Location = new System.Drawing.Point(23, 261);
            UserInterface.resultFullSearch_label.Name = "resultFullSearch_label";
            UserInterface.resultFullSearch_label.Size = new System.Drawing.Size(35, 13);
            UserInterface.resultFullSearch_label.TabIndex = 20;
            UserInterface.resultFullSearch_label.Text = "";
            // 
            // resultGreedy_label2
            // 
            UserInterface.resultGreedy_label.AutoSize = true;
            UserInterface.resultGreedy_label.Location = new System.Drawing.Point(604, 261);
            UserInterface.resultGreedy_label.Name = "resultGreedy_label";
            UserInterface.resultGreedy_label.Size = new System.Drawing.Size(35, 13);
            UserInterface.resultGreedy_label.TabIndex = 21;
            UserInterface.resultGreedy_label.Text = "";
            // 
            // UserInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1086, 556);
            this.Controls.Add(UserInterface.resultGreedy_label);
            this.Controls.Add(UserInterface.resultFullSearch_label);
            this.Controls.Add(this.radioButton3);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.realizat_label);
            this.Controls.Add(this.lossesTwo_label);
            this.Controls.Add(this.lossesOne_label);
            this.Controls.Add(this.labelCountFloor);
            this.Controls.Add(this.squareTwo_input);
            this.Controls.Add(this.labelTwo);
            this.Controls.Add(this.squareOne_input);
            this.Controls.Add(this.labelOne);
            this.Controls.Add(this.fullSearch_btn);
            this.Controls.Add(this.greedy_btn);
            this.Name = "UserInterface";
            this.Text = "UserInterface";
            this.Load += new System.EventHandler(this.UserInterface_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button greedy_btn;
        private System.Windows.Forms.Button fullSearch_btn;
        private System.Windows.Forms.Label labelOne;
        private System.Windows.Forms.TextBox squareOne_input;
        private System.Windows.Forms.Label labelTwo;
        private System.Windows.Forms.TextBox squareTwo_input;
        private System.Windows.Forms.Label labelCountFloor;
        private System.Windows.Forms.Label lossesTwo_label;
        private System.Windows.Forms.Label lossesOne_label;
        private System.Windows.Forms.Label realizat_label;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        protected static System.Windows.Forms.Label resultFullSearch_label;
        protected static System.Windows.Forms.Label resultGreedy_label;
    }
}